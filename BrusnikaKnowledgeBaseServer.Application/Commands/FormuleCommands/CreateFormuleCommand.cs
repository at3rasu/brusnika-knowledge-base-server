using AutoMapper;
using BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions;
using BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers;
using BrusnikaKnowledgeBaseServer.Application.Commands.KnowledgeCommands;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.FormuleCommands
{
    public class CreateFormuleCommand : IRequest<int>
    {
        public FormuleDto Formule { get; set; }
        public JsonPatchDocument<Formule> PatchModel { get; set; }
    }
    internal class CreateFormuleCommandHandler : AbstractFormuleHandler, IRequestHandler<CreateFormuleCommand, int>
    {
        private readonly IMapper mapper;

        public CreateFormuleCommandHandler(IFormuleDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateFormuleCommand request, CancellationToken cancellationToken)
        {
            var toAdd = mapper.Map<Formule>(request.Formule);
            await db.AddAsync(toAdd);
            await db.SaveChangesAsync();

            if (toAdd.Content != null)
            {
                var formula = toAdd.Content.Split('=')[1];

                toAdd.Variables = GetVariables(formula);

                db.Update(toAdd);
                await db.SaveChangesAsync();
            }
            return toAdd.Id;
        }


        static List<string> GetVariables(string formulaString)
        {
            Regex regex = new Regex(@"\b[a-zA-Z]+\b");

            // Список для хранения переменных
            List<string> variables = new List<string>();

            // Поиск переменных в строке
            MatchCollection matches = regex.Matches(formulaString);
            foreach (Match match in matches)
            {
                string variable = match.Value;
                if (!variables.Contains(variable))
                {
                    variables.Add(variable);
                }
            }
            return variables;
        }
    }
}
