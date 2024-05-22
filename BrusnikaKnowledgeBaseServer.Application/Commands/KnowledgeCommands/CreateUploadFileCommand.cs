using AutoMapper;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.UploadFileCommands
{
   /* internal class CreateUploadFileCommand : IRequest<int>
    {
        public UploadFileDto UploadFile { get; set; }
    }
    internal class CreateUploadFileCommandHandler : AbstractHandler, IRequestHandler<CreateUploadFileCommand, int>
    {
        private readonly IMapper mapper;

        public CreateUploadFileCommandHandler(IUploadFileDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateUploadFileCommand request, CancellationToken cancellationToken)
        {
            var toAdd = mapper.Map<UploadFile>(request.UploadFile);
            toAdd = AddFile(toAdd).Result;
            await db.AddAsync(toAdd);
            await db.SaveChangesAsync();
            return toAdd.Id;
        }
        public async Task<UploadFile> AddFile(UploadFile uploadFile)
        {
            if (uploadFile.Content != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadFile.Content.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.Content.CopyToAsync(fileStream);
                }
                uploadFile.Path = path;
                uploadFile.Name = uploadFile.Content.FileName;
                db.UploadFiles.Add(uploadFile);
                await db.SaveChangesAsync();
            }

            return uploadFile;
        }
    }*/
}
