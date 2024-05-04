
using Microsoft.AspNetCore.Mvc;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class KnowledgeController : ControllerBase
    {
        /*public KnowledgeController() { }

        [HttpPost("")]
        public async Task<IActionResult> AddNewPlayer
            ([FromServices] CreateKnowledgeAction createNewKnowledge,
            [FromBody] KnowledgeDto knowledgDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewKnowledge.CreateNewKnowledge(knowledgDto);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }*/
    }
}
