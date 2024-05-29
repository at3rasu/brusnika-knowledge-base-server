using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.Dtos
{
    public class FormuleResultDto
    {
        public int? Id { get; set; }
        public List<double>? Values { get; set; }
    }
}
