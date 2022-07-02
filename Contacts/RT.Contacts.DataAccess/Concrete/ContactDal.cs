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

        //protected static double getTotalWorkTime(int employeeId)
        //{
        //    double result = 0;
        //    using (var context = new DataContext())
        //    {
        //        var orders = context.Orders.Where(x => x.EmployeeId == employeeId && x.Status == 4).ToList();
        //        foreach (var order in orders)
        //        {
        //            result += (Convert.ToDateTime(order.DeliveredTime) - Convert.ToDateTime(order.DeliveringTime)).TotalMinutes;
        //        }
        //    }
        //    return result;
        //}

        //protected static double getMonthlyWorkTime(int employeeId)
        //{
        //    double result = 0;
        //    using (var context = new DataContext())
        //    {
        //        var orders = context.Orders.Where(x => x.EmployeeId == employeeId && x.Status == 4 && (x.OrderDate.Year == DateTime.Now.Year && x.OrderDate.Month == DateTime.Now.Month)).ToList();
        //        foreach (var order in orders)
        //        {
        //            result += (Convert.ToDateTime(order.DeliveredTime) - Convert.ToDateTime(order.DeliveringTime)).TotalMinutes;
        //        }
        //    }
        //    return result;
        //}
    }

}
