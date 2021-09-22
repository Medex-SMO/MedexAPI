using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICityService
    {
        IResult Add(City city);
        IResult Update(City city);
        IResult Delete(City city);
        IDataResult<City> GetById(int id);
        IDataResult<List<City>> GetAll();
    }
}
