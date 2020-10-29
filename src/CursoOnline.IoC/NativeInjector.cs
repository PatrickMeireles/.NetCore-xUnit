using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Services;
using CursoOnline.Dominio.Interface;
using CursoOnline.Infrastructure.Context;
using CursoOnline.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CursoOnline.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<ICursoAppServices, CursoAppServices>();


            //Repository
            services.AddScoped<ICursoRepository, CursoRepository>();


            services.AddScoped<BaseContext>();
        }
    }
}
