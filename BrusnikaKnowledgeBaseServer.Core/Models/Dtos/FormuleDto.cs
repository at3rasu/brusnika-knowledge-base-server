using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.Dtos
{
    public record class FormuleDto
    {
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
    }
}
