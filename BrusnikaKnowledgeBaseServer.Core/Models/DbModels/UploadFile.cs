using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace BrusnikaKnowledgeBaseServer.Core.Models.DbModels
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name = "File")]
        [NotMapped] // Используем атрибут NotMapped для игнорирования свойства в EF Core
        public IFormFile Content { get; set; }

        public byte[] FileContent { get; set; } // Массив байтов для хранения содержимого файла

    }
}
