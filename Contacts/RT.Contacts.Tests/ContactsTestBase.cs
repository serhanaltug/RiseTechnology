using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.Business.Abstract;
using RT.Contacts.CompositionRoot;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.Tests
{
    public abstract class ContactsTestBase : IClassFixture<RepositoryFixture>, IDisposable
    {
        readonly ServiceCollection _services;
        protected IServiceProvider _provider;
        protected IContactService _contacts;
        protected int testDataId;

        public ContactsTestBase(RepositoryFixture fixture)
        {
            _services = fixture.Services;
            _provider = _services.BuildServiceProvider().CreateScope().ServiceProvider;
            _contacts = _provider.GetService<IContactService>();

            TestDataSetup();
        }

        private void TestDataSetup()
        {
            _contacts.Add(new Contact { Ad = "Test Contact Name", Soyad = "Test Contact Surname", Firma = "Test Contact Company" });
            testDataId = _contacts.GetAll().Data.Last().UUID;
            _contacts.AddDetail(new ContactDetail { ContactUUID = testDataId, BilgiTipi = BilgiTipi.TelefonNumarasi, BilgiIcerigi = "+90 224 2222222" });
            _contacts.AddDetail(new ContactDetail { ContactUUID = testDataId, BilgiTipi = BilgiTipi.EmailAdresi, BilgiIcerigi = "test@test.com" });
            _contacts.AddDetail(new ContactDetail { ContactUUID = testDataId, BilgiTipi = BilgiTipi.Konum, BilgiIcerigi = "Bursa" });
        }

        public void Dispose()
        {
            _contacts.GetAll().Data.Where(x => x.Ad.ToLower().Contains("test")).ToList().ForEach(x => _contacts.Delete(x));
            
        }
    }
}