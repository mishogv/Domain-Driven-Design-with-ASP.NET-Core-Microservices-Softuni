namespace BCSystem.Web.Features
{
    using BCSystem.Application.BusinessCards.BusinessCards.Comands.Create;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BusinessCardController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateBusinessCardOutputModel>> Create(
            CreateBusinessCardCommand command)
            => await this.Send(command);
    }
}
