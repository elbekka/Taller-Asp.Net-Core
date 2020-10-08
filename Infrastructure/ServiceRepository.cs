using Infrastructure.Programmers;
using Infrastructure.ProgrammerType;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class ServiceRepository
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IProgrammerRespository, ProgramRespository>()
                   .AddTransient<IProgrammerType,ProgrammerType.ProgrammerType>();
        }
    }
}
