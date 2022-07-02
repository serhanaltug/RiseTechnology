using RT.Contacts.Business.Abstract;
using RT.Contacts.Core.Utilities.Results;
using RT.Contacts.DataAccess.Abstract;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reports;

        public ReportManager(IReportDal reports)
        {
            _reports = reports; 
        }

        public IResult Add(Report report)
        {
            _reports.Add(report);
            return new SuccessResult("Added");
        }

        public IResult Update(Report report)
        {
            _reports.Update(report);
            return new SuccessResult("Updated");
        }

        public IResult Delete(Report report)
        {
            _reports.Delete(report);
            return new SuccessResult("Deleted");
        }

        public IDataResult<List<Report>> GetAll()
        {
            return new SuccessDataResult<List<Report>>(_reports.GetAll());
        }

        public IDataResult<Report> GetById(int id)
        {
            return new SuccessDataResult<Report>(_reports.Get(x => x.UUID == id));
        }

        public IDataResult<Report> GetByLocation(string location)
        {
            return new SuccessDataResult<Report>(_reports.Get(x => x.Konum == location));
        }

        public async Task<IDataResult<string>> GetByLocationCount(string location)
        {
            var result = await _reports.getTotalContactsCount(location);
            return new SuccessDataResult<string>(result.ToString());
        }
    }
}
