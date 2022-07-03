using RT.Contacts.CompositionRoot;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.Tests
{
    public class ContactTests : ContactsTestBase
    {

        public ContactTests(RepositoryFixture fixture) : base(fixture) { }

        [Fact]
        public void Test_01_Clear_Test_Data_If_Exists() 
        {
            _contacts.GetAll().Data.Where(x => x.Ad.ToLower().Contains("test")).ToList().ForEach(x => _contacts.Delete(x));
            Assert.False(_contacts.GetAll().Data.Where(x => x.Ad.ToLower().Contains("test")).Any());
        }

        [Fact]
        public void Test_02_Should_Add_New_Contact()
        {
            var contact = new Contact { Ad = "Test Name", Soyad = "Test Surname", Firma = "Test Company" };
            var result = _contacts.Add(contact);
            Assert.True(result.Success);
        }

        [Fact]
        public void Test_03_Should_Add_New_ContactDetails_to_Test_Contact()
        {
            var contact = _contacts.GetById(testDataId).Data;
            if(contact != null)
            {
                var result = _contacts.AddDetail(new ContactDetail { ContactUUID = contact.UUID, BilgiTipi = BilgiTipi.TelefonNumarasi, BilgiIcerigi = "+90 224 3333333" });
                Assert.True(result.Success);
            }
        }

        [Fact]
        public void Test_04_Should_Get_Contact_With_Details()
        {
            var contact = _contacts.GetByIdWithDetails(testDataId).Data;
            if(contact != null) Assert.True(contact.IletisimBilgileri.Count == 3);
        }

        [Fact]
        public void Test_05_Should_Add_AnOther_New_Contact()
        {
            var contact = new Contact { Ad = "TestName 2", Soyad = "TestSurname 2", Firma = "TestCompany2" };
            var result = _contacts.Add(contact);
            Assert.True(result.Success);

            var count = _contacts.GetAll().Data.Count;
            Assert.True(count >= 2);
        }

        [Fact]
        public void Test_06_Should_Update_Test_Contact()
        {

            var contactToUpdate = _contacts.GetById(testDataId).Data;
            if (contactToUpdate != null)
            {
                contactToUpdate.Ad = "TestName Updated";
                contactToUpdate.Soyad = "TestSurname Updated";
                contactToUpdate.Firma = "TestCompany Updated";
                var result = _contacts.Update(contactToUpdate);
            }

            var checkUpdatedContact = _contacts.GetByName("TestName Updated", "TestSurname Updated");
            Assert.NotNull(checkUpdatedContact.Data);
            if(checkUpdatedContact.Data != null)
                Assert.True(checkUpdatedContact.Data.Ad == "TestName Updated" && checkUpdatedContact.Data.Soyad == "TestSurname Updated");
        }

        [Fact]
        public void Test_07_Should_Delete_Detail_From_Test_Contact()
        {
            var contact = _contacts.GetByIdWithDetails(testDataId).Data;
            if (contact != null)
            {
                var detail = contact.IletisimBilgileri.FirstOrDefault(x => x.BilgiTipi == BilgiTipi.TelefonNumarasi);
                if(detail != null)
                {
                    var result = _contacts.DeleteDetail(detail);
                    Assert.True(result.Success);
                } else Assert.True(false);
            }
        }

        [Fact]
        public void Test_08_Should_Delete_Test_Contact()
        {
            var contact = _contacts.GetById(testDataId).Data;
            if (contact != null) { 
                var result = _contacts.Delete(contact);
                Assert.True(result.Success);
            }
        }

    }
}