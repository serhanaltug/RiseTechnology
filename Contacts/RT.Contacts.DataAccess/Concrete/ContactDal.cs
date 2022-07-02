using Microsoft.EntityFrameworkCore;
using RT.Contacts.Core.DataAccess.EntityFramework;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.Domain.Entities;
using System.Linq.Expressions;

namespace RT.Contacts.DataAccess.Concrete
{
    public class ContactDal : EntityRepositoryBase<Contact, PostgreSqlEfDbContext>, IContactDal
    {
        public List<Contact> GetAllWithDetails(Expression<Func<Contact, bool>> filter = null)
        {
            using (var context = new PostgreSqlEfDbContext())
            {
                var result = from contacts in filter is null ? context.Contacts.Include(x => x.IletisimBilgileri) : context.Contacts.Where(filter).Include(x => x.IletisimBilgileri)
                             select contacts;
                return result.ToList();
            }

        }
    }

}
