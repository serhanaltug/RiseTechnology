using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.Business;
using RT.Contacts.DataAccess.Concrete;
using System.Globalization;
using System.Reflection;

namespace RT.Contacts.CompositionRoot
{
    public static class MockSetup
    {
        public static void InitializeTestContainer(IServiceCollection services)
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //var assemblies = new List<Assembly> { typeof(PostgreSqlEfDbContext).Assembly };

            services.AddBusinessServices();
        }
    }
}