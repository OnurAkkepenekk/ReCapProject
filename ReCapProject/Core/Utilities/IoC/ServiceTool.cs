using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    // Injetions'ları kontrol ettiğimiz noktadır.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        // .Net servislerini(IServiceCollection services) al ve onu built et. 
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
