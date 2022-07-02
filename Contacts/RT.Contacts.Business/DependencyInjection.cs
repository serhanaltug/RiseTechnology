using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.Business.Abstract;
using RT.Contacts.Business.Concrete;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.DataAccess.Concrete;

namespace RT.Contacts.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IContactDetailDal, ContactDetailDal>();
            return services;
        }
    }
}
