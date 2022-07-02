using Microsoft.EntityFrameworkCore;
using RT.Contacts.Core.DataAccess.EntityFramework;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.Domain.Entities;
using System.Linq.Expressions;

namespace RT.Contacts.DataAccess.Concrete
{
    public class ReportDal : EntityRepositoryBase<Report, PostgreSqlEfDbContext>, IReportDal
    {
        public List<Report> GetAllWithDetails(Expression<Func<Report, bool>> filter = null)
        {
            using (var context = new PostgreSqlEfDbContext())
            {
                var result = from reports in filter is null ? context.Reports : context.Reports.Where(filter)
                             select reports;
                return result.ToList();
            }
        }


        public async Task<int> getTotalContactsCount(string location)
        {
            int result = 0;
            using (var context = new PostgreSqlEfDbContext())
            {
                result = await context.Contacts.Include(x => x.IletisimBilgileri.Where(x => x.BilgiTipi == BilgiTipi.Konum && x.BilgiIcerigi.ToLower() == location.ToLower())).CountAsync();
            }
            return result;
        }

        public async Task<int> getTotalPhoneNumberCount(string location)
        {
            int result = 0;
            using (var context = new PostgreSqlEfDbContext())
            {
                var contacts = await context.Contacts.Include(x => x.IletisimBilgileri.Where(x => x.BilgiTipi == BilgiTipi.Konum && x.BilgiIcerigi.ToLower() == location.ToLower())).ToListAsync();
                foreach (var contact in contacts) { 
                    result += contact.IletisimBilgileri.Count(x => x.BilgiTipi == BilgiTipi.TelefonNumarasi);
                }
            }
            return result;
        }


    }

}
