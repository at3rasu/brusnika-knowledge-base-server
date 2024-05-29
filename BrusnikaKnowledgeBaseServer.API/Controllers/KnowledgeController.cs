
using AutoMapper.QueryableExtensions;
using AutoMapper;
using BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using BrusnikaKnowledgeBaseServer.Core.Models.RequestModels;
using BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly KnowledgeContext knowledgeContext;
        public KnowledgeController(KnowledgeContext context, IMapper mapper)
        {
            knowledgeContext = context;
            this.mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewKnowledge
            ([FromServices] CreateKnowledgeAction createNewKnowledge,
            [FromForm] KnowledgeCreateDto knowledge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewKnowledge.CreateNewKnowledge(knowledge);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllKnowledges
            ([FromServices] GetAllKnowledgesAction getAllKnowlledgesAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await getAllKnowlledgesAction.GetAllKnowledges());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeDto>> GetKnowledge
            (int id)
        {
            var existingEntity = await knowledgeContext.Knowledges.FindAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            return mapper.Map<KnowledgeDto>(existingEntity);
        }
    }
}
