using AutoMapper;
using BrusnikaKnowledgeBaseServer.Application.Actions.FormuleActions;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("/api/[controller]/")]
    [ApiController]
    public class FormuleController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly FormuleContext formuleContext;

        public FormuleController(FormuleContext context, IMapper map)
        {
            formuleContext = context;
            mapper = map;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewPFormule
            ([FromServices] CreateFormuleAction createNewFormule,
            [FromForm] FormuleDto formuleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewFormule.CreateFormule(formuleDto);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }

        [HttpPost("result")]
        public async Task<IActionResult> GetResult
            ([FromServices] GetFormuleResultAction createNewFormule,
            [FromForm] FormuleResultDto formuleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewFormule.CreateFormule(formuleDto);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }

        [HttpGet]
        public async Task<IEnumerable<Formule>> GetAllFormules()
        {
            return await formuleContext.Formules.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Formule>> GetFormule
            (int id)
        {
            var existingEntity = await formuleContext.Formules.FindAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            return existingEntity;
        }
    }
}
