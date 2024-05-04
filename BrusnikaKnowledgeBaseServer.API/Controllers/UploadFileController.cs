using BrusnikaKnowledgeBaseServer.Application.Actions.UploadFileActions;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BrusnikaKnowledgeBaseServer.API.Controllers
{
    [Route("/api/[controller]")]
    public class UploadFileController : ControllerBase
    {
        public UploadFileController() { }

        [HttpPost("")]
        public async Task<IActionResult> AddNewFile
            ([FromServices] CreateUploadFileAction createNewFile,
            [FromBody] UploadFileDto uploadFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await createNewFile.CreateNewFile(uploadFile);

            Response.StatusCode = result.ResultStatus;
            return new JsonResult(result.ResultContent);
        }
    }
}
