namespace BCSystem.Web.Features
{
    using BCSystem.Application.BusinessCards.BusinessCards.Comands.Create;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<CreateBusinessCardOutputModel>> Delete(
             CreateBusinessCardCommand command)
             => await this.Send(command);

        [Authorize]
        [HttpGet(nameof(Details))]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> Details(
             CreateBusinessCardCommand command)
             => await this.Send(command);

        [Authorize]
        [HttpGet(nameof(Edit))]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> Edit(
             CreateBusinessCardCommand command)
             => await this.Send(command);

        [Authorize]
        [HttpPost(nameof(AllByUser))]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> AllByUser(
           CreateBusinessCardCommand command)
           => await this.Send(command);

        [Authorize]
        [HttpPost(nameof(AllByCompany))]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> AllByCompany(
           CreateBusinessCardCommand command)
           => await this.Send(command);
    }
}
