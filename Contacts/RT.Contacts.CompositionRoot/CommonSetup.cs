using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.Business;
using System.Reflection;

namespace RT.Contacts.CompositionRoot
{
    public static class CommonSetup
    {
        public static void InitializeServices(IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            services.AddBusinessServices();
        }
    }
}