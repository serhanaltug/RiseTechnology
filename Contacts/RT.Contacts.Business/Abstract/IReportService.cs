﻿using RT.Contacts.Core.Utilities.Results;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.Business.Abstract
{
    public interface IReportService
    {
        IResult Add(Report report);

        IResult Update(Report report);

        IResult Delete(Report report);

        IDataResult<List<Report>> GetAll();

        IDataResult<Report> GetById(int id);

        IDataResult<Report> GetByLocation(string location);

        Task<IDataResult<string>> GetByLocationCount(string location);

    }
}
