using RT.Contacts.Core.DataAccess;
using RT.Contacts.Domain.Entities;
using System.Linq.Expressions;

namespace RT.Contacts.DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
        List<Contact> GetAllWithDetails(Expression<Func<Contact, bool>> filter = null);
    }
}
