
using AutoMapper.QueryableExtensions;
using AutoMapper;
using BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using BrusnikaKnowledgeBaseServer.Core.Models.RequestModels;
using BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [EnableCors("CorsPolicy")]
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
        public async Task<IEnumerable<Knowledge>> GetAllKnowledges()
        {
            return await knowledgeContext.Knowledges.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Knowledge>> GetKnowledge(int id)
        {
            var knowledge = await knowledgeContext.Knowledges.FindAsync(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            return knowledge;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Knowledge>> DeleteKnowledge(int id)
        {
            var knowledge = await knowledgeContext.Knowledges.FindAsync(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            knowledgeContext.Knowledges.Remove(knowledge);
            await knowledgeContext.SaveChangesAsync();

            return knowledge;
        }
    }
}
