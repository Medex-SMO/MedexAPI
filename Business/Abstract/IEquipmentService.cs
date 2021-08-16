using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEquipmentService
    {
        IResult Add(Equipment equipment);
        IResult Update(Equipment equipment);
        IResult Delete(Equipment equipment);
        IDataResult<Equipment> GetById(int id);
        IDataResult<List<Equipment>> GetAll();
    }
}
