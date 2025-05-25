using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstract;
using SchoolProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Dependency_injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSchoolProjectServices(this IServiceCollection Services)
        {
            return Services.AddServices();
        }

        private static IServiceCollection AddServices(this IServiceCollection Services)
        {
            return Services.AddTransient<IStudentService, StudentService>();
        }
    }
}
