using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.Dtos
{
    public class KnowledgeCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Content { get; set; }
    }
}
