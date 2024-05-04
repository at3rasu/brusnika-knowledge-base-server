using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace BrusnikaKnowledgeBaseServer.Core.Models.DbModels
{
    public class Knowledge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
    }
}
