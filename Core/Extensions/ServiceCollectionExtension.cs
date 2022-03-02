using Autofac.Core;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependecyResolovers(this IServiceCollection service,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(service);
            }
            return ServiceTool.Create(service);
        }
    }
}
