namespace BCSystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Models;
    using Domain.Statistics.Models;
    using Events;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using BCSystem.Infrastructure.Statistics;
    using BCSystem.Infrastructure.BusinessCards;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;

    internal class BusinessCardDbContext : IdentityDbContext<User>,
        IBusinessCardDbContext,
        IStatisticsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public BusinessCardDbContext(
            DbContextOptions<BusinessCardDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public virtual DbSet<BusinessCard> BusinessCards { get; set; } = default!;

        public virtual DbSet<BusinessMan> BusinessMens { get; set; } = default!;

        public virtual DbSet<Statistics> Statistics { get; set; } = default!;

        public virtual DbSet<BusinessCardView> BusinessCardViews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
