using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace BrusnikaKnowledgeBaseServer.Core.Models.DbModels
{
    public partial class Knowledge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Content { get; set; }
        public string FileName { get; set; }
        public string Src { get; set; }
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
