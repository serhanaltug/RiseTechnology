using RT.Contacts.Business.Abstract;
using RT.Contacts.Core.Utilities.Results;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.Business.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contacts;
        IContactDetailDal _details;

        public ContactManager(IContactDal contacts, IContactDetailDal details)
        {
            _contacts = contacts;
            _details = details;
        }

        public IResult Add(Contact contact)
        {
            _contacts.Add(contact);
            return new SuccessResult("Added");
        }

        public IResult Update(Contact contact)
        {
            _contacts.Update(contact);
            return new SuccessResult("Updated");
        }

        public IResult Delete(Contact contact)
        {
            _contacts.Delete(contact);
            return new SuccessResult("Deleted");
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contacts.GetAll());
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contacts.Get(x => x.UUID == id));
        }

        public IDataResult<Contact> GetByName(string ad, string soyad)
        {
            return new SuccessDataResult<Contact>(_contacts.Get(x => x.Ad == ad && x.Soyad == soyad));
        }

        public IDataResult<Contact> GetByIdWithDetails(int id)
        {
            return new SuccessDataResult<Contact>(_contacts.GetAllWithDetails(x => x.UUID == id).FirstOrDefault());
        }

        public IResult AddDetail(ContactDetail contactDetail)
        {
            _details.Add(contactDetail);
            return new SuccessResult("Detail added");
        }

        public IResult UpdateDetail(ContactDetail contactDetail)
        {
            _details.Update(contactDetail);
            return new SuccessResult("Detail updated");
        }

        public IResult DeleteDetail(ContactDetail contactDetail)
        {
            _details.Delete(contactDetail);
            return new SuccessResult("Detail deleted");
        }

        public IDataResult<List<ContactDetail>> GetAllDetailsById(int id)
        {
            return new SuccessDataResult<List<ContactDetail>>(_details.GetAll(x => x.ContactUUID == id));
        }

        public IDataResult<ContactDetail> GetDetailById(int id)
        {
            return new SuccessDataResult<ContactDetail>(_details.Get(x => x.Id == id));
        }

    }
}
