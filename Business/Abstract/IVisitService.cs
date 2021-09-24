using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVisitService
    {
        IResult Add(Visit visit);
        IResult Update(Visit visit);
        IResult Delete(Visit visit);
        IDataResult<Visit> GetById(int id);
        IDataResult<List<Visit>> GetAll();
        IDataResult<List<VisitDetailDto>> GetVisitsDetails();
    }
}
