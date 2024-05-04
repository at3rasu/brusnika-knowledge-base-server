using BrusnikaKnowledgeBaseServer.Application.Actions.UploadFileActions;
using Microsoft.Extensions.DependencyInjection;

namespace BrusnikaKnowledgeBaseServer.Application.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases
            (this IServiceCollection services)
        {
            services.AddScoped<CreateUploadFileAction>();

            return services;
        }
    }
}
