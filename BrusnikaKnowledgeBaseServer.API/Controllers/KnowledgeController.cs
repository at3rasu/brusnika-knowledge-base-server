
using BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        public KnowledgeController() { }

        [HttpPost("")]
        public async Task<IActionResult> AddNewPlayer
            ([FromServices] CreateKnowledgeAction createNewKnowledge,
            [FromForm] KnowledgeDto knowledgDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewKnowledge.CreateNewKnowledge(knowledgDto);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }
    }
}
