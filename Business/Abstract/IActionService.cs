using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IActionService
    {
        IResult Add(Entities.Concrete.Action action);
        IResult Update(Entities.Concrete.Action action);
        IResult Delete(Entities.Concrete.Action action);
        IDataResult<Entities.Concrete.Action> GetById(int id);
        IDataResult<List<Entities.Concrete.Action>> GetAll();
        IDataResult<List<ActionDetailDto>> GetActionsDetails();
    }
}
