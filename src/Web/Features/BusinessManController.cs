namespace BCSystem.Web.Features
{
    using BCSystem.Application.BusinessCards.BusinessMans.Commands.Edit;
    using BCSystem.Application.BusinessCards.BusinessMans.Queries.Details;
    using BCSystem.Application.Common;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BusinessManController : ApiController
    {
        [HttpGet(Id)]
        public async Task<ActionResult<BusinessManDetailsOutputModel>> Details(
            [FromRoute] DetailsBusinessManQuery query)
            => await this.Send(query);

        [HttpPut(Id)]
        public async Task<ActionResult> Edit(
            int id, EditBusinessManCommand command)
            => await this.Send(command.SetId(id));
    }
}
