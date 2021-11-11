using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISponsorService
    {
        IResult Add(Sponsor sponsor);
        IResult Update(Sponsor sponsor);
        IResult Delete(Sponsor sponsor);
        IDataResult<Sponsor> GetById(int id);
        IDataResult<Sponsor> GetByName(string name);
        IDataResult<List<Sponsor>> GetAll();
    }
}
