using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace BrusnikaKnowledgeBaseServer.Core.Models.DbModels
{
    public partial class Formule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
        public List<string> Variables { get; set; }
        [NotMapped]
        public List<double> Values { get; set; }
    }
}
