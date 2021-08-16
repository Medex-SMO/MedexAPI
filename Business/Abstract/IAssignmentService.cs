using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IResult Add(Assignment assignment);
        IResult Update(Assignment assignment);
        IResult Delete(Assignment assignment);
        IDataResult<Assignment> GetById(int id);
        IDataResult<List<Assignment>> GetAll();
    }
}
