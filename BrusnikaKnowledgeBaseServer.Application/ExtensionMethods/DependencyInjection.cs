using BrusnikaKnowledgeBaseServer.Application.Actions.FormuleActions;
using BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions;
using BrusnikaKnowledgeBaseServer.Application.Actions.UploadFileActions;
using Microsoft.Extensions.DependencyInjection;

namespace BrusnikaKnowledgeBaseServer.Application.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases
            (this IServiceCollection services)
        {
            services.AddScoped<CreateKnowledgeAction>();
            services.AddScoped<GetAllKnowledgesAction>();
            services.AddScoped<CreateFormuleAction>();
            services.AddScoped<GetFormuleResultAction>();
            return services;
        }
    }
}
