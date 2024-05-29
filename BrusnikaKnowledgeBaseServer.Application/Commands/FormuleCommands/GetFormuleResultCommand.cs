using AutoMapper;
using BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.FormuleCommands
{
    public class GetFormuleResultCommand : IRequest<double>
    {
        public FormuleResultDto Formule { get; set; }
        public JsonPatchDocument<Formule> PatchModel { get; set; }
    }
    internal class GetFormuleResultCommandHandler : AbstractFormuleHandler, IRequestHandler<GetFormuleResultCommand, double>
    {
        private readonly IMapper mapper;

        public GetFormuleResultCommandHandler(IFormuleDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<double> Handle(GetFormuleResultCommand request, CancellationToken cancellationToken)
        {
            double result = default;
            var toAdd =  await db.Formules.FindAsync(request.Formule.Id);

            /*if (toAdd.Content != null)
            {// Формула в виде строки*/
                var formule = await db.Formules.FindAsync(request.Formule.Id);
            var d = new Dictionary<string, double>();
                for (var i = 0; i < toAdd.Variables.Count; i++)
            {
                d.Add(toAdd.Variables[i], request.Formule.Values[i]);
            }
                // Подстановка значений переменных в формулу
                string replacedFormula = ReplaceVariables(formule.Content.Split('=')[1], d);

                // Вычисление результата
                result = EvaluateExpression(replacedFormula);

                // Вывод результата
/*
            }*/
            return result;
        }

        static string ReplaceVariables(string formulaString, Dictionary<string, double> variables)
        {
            // Создаем регулярное выражение для поиска переменных в формуле
            Regex regex = new Regex(@"\b[a-zA-Z]+\b");

            // Заменяем каждую переменную в формуле на её значение
            string replacedFormula = regex.Replace(formulaString, match =>
            {
                string variable = match.Value;
                if (variables.ContainsKey(variable))
                {
                    return variables[variable].ToString();
                }
                return variable; // Если значение переменной не найдено, оставляем переменную без изменений
            });

            return replacedFormula;
        }

        static double EvaluateExpression(string expression)
        {
            // Используем NCalc для вычисления выражения
            Expression exp = new Expression(expression);
            return Convert.ToDouble(exp.Evaluate());
        }
    }
}