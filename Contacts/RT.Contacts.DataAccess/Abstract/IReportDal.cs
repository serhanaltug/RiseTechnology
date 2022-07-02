using RT.Contacts.Core.DataAccess;
using RT.Contacts.Domain.Entities;
using System.Linq.Expressions;

namespace RT.Contacts.DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<Report>
    {
        List<Report> GetAllWithDetails(Expression<Func<Report, bool>> filter = null);

        Task<int> getTotalContactsCount(string location);

        Task<int> getTotalPhoneNumberCount(string location);
    }
}
