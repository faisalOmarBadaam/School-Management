
using SchoolProject.Core.Dependency_injection;
using SchoolProject.Infrastructure.Dependency_injection;
using SchoolProject.Service.Dependency_injection;
using SchoolProjectApi.GlobalExcepion;

namespace SchoolProjectApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddInfrastructureServices(builder.Configuration)
                            .AddSchoolProjectServices()
                            .AddCoreServices();


            builder.Services.AddExceptionHandler<GlobalException>();
            builder.Services.AddProblemDetails();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger Demo"));
            app.UseAuthorization();
            app.UseExceptionHandler(x => { });
            app.MapControllers();

            app.Run();
        }
    }
}
