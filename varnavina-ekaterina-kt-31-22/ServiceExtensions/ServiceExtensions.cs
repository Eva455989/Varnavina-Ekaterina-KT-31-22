using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces;

namespace varnavina_ekaterina_kt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
