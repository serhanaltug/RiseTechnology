using RT.Contacts.Core.Utilities.Results;
using RT.Contacts.Domain.Entities;
using System.Linq.Expressions;

namespace RT.Contacts.Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);

        IResult Update(Contact contact);

        IResult Delete(Contact contact);

        IDataResult<List<Contact>> GetAll();

        IDataResult<Contact> GetById(int id);

        IDataResult<Contact> GetByName(string ad, string soyad);

        IDataResult<Contact> GetByIdWithDetails(int id);

        IResult AddDetail(ContactDetail detail);
        
        IResult UpdateDetail(ContactDetail detail);

        IResult DeleteDetail(ContactDetail detail);

        IDataResult<List<ContactDetail>> GetAllDetailsById(int id);

        IDataResult<ContactDetail> GetDetailById(int id);
    }
}
