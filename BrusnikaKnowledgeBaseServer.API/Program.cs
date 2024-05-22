using BrusnikaKnowledgeBaseServer.Application;
using BrusnikaKnowledgeBaseServer.Application.ExtensionMethods;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts;
using BrusnikaKnowledgeBaseServer.Core.Models.MappingProfiles;
using Microsoft.Extensions.FileProviders;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AbstractHandler>());
builder.Services.AddAutoMapper(typeof(AutomapperPing));
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new KnowledgeMappingProfile());
}).CreateMapper());

builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddMvcCore();

builder.Services.AddDbContext<IKnowledgeDbContext, KnowledgeContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("KnowledgeBase"));
});
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                }));

builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();

/*builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = "dist";
});*/

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddUseCases();
builder.Services.AddTransient<UploadFileContext>();



var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/api/StaticFiles"
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example v1"));
}
app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

//app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();