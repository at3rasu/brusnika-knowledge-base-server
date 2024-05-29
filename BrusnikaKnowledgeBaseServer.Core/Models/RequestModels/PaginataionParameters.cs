using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.RequestModels
{
    public record PaginationParameters
    {
        [Range(1, 250, ErrorMessage = "Limit must be greater than 0 and less or equal to 250.")]
        public int Limit { get; set; } = 10;

        [Range(0, int.MaxValue, ErrorMessage = "Offset must be greater than or equal to 0.")]
        public int Offset { get; set; } = 0;
    }
}
