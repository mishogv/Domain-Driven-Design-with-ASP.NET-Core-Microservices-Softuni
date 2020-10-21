namespace BCSystem.Web.Features
{
    using BCSystem.Application.BusinessCards.BusinessCards.Comands.Create;
    using BCSystem.Application.BusinessCards.BusinessCards.Comands.Delete;
    using BCSystem.Application.BusinessCards.BusinessCards.Comands.Edit;
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.All;
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Details;
    using BCSystem.Application.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BusinessCardController : ApiController
    {
        [Authorize]
        [HttpPost(nameof(Create))]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> Create(
            CreateBusinessCardCommand command)
            => await this.Send(command);

        [Authorize]
        [HttpPost(nameof(Delete))]
        public async Task<ActionResult<Result>> Delete(
             DeleteBusinessCardCommand command)
             => await this.Send(command);

        [Authorize]
        [HttpGet(nameof(Details))]
        public async Task<ActionResult<BusinessCardOutputModel>> Details(
             DetailsBusinessCardQuery command)
             => await this.Send(command);

        [Authorize]
        [HttpPost(nameof(Edit))]
        public async Task<ActionResult<Result>> Edit(
             EditBusinessCardCommand command)
             => await this.Send(command);

        [Authorize]
        [HttpPost(nameof(All))]
        public async Task<ActionResult<IEnumerable<BusinessCardOutputModel>>> All(
           GetAllBusinessCardQuery command)
           => await this.Send(command);

        [Authorize]
        [HttpGet(nameof(AllByCompanyName))]
        public async Task<ActionResult<IEnumerable<BusinessCardOutputModel>>> AllByCompanyName(
           GetAllByCompanyNameBusinessCardQuery command)
           => await this.Send(command);

        [Authorize]
        [HttpGet(nameof(AllByCompanyName))]
        public async Task<ActionResult<IEnumerable<BusinessCardOutputModel>>> AllByCompanyUserId(
           GetAllByUserBusinessCardQuery command)
           => await this.Send(command);
    }
}
