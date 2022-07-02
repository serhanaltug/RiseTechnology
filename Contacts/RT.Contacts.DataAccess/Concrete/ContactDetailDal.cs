using RT.Contacts.Core.DataAccess.EntityFramework;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.DataAccess.Concrete
{
    public class ContactDetailDal : EntityRepositoryBase<ContactDetail, PostgreSqlEfDbContext>, IContactDetailDal
    {

    }

}
