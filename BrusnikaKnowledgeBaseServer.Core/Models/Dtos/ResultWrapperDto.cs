using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.Dtos
{
    public class ResultWrapperDto
    {
        public int ResultStatus { get; set; }
        public object ResultContent { get; set; }
    }

    public class ErrorResponseDto
    {
        public string ErrorTextForUser { get; set; }
    }
}
