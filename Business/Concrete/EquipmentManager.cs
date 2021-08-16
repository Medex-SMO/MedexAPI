using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EquipmentManager : IEquipmentService
    {
        IEquipmentDal _equipmentDal;
        public EquipmentManager(IEquipmentDal equipmentDal)
        {
            _equipmentDal = equipmentDal;
        }
        [ValidationAspect(typeof(EquipmentValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IEquipmentService.Get")]
        public IResult Add(Equipment equipment)
        {
            _equipmentDal.Add(equipment);
            return new SuccessResult(Messages.EquipmentAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IEquipmentService.Get")]
        public IResult Delete(Equipment equipment)
        {
            _equipmentDal.Delete(equipment);
            return new SuccessResult(Messages.EquipmentDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Equipment>> GetAll()
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentDal.GetAll(), Messages.EquipmentListed);
        }

        [CacheAspect]
        public IDataResult<Equipment> GetById(int id)
        {
            return new SuccessDataResult<Equipment>(_equipmentDal.Get(b => b.Id == id));
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IEquipmentService.Get")]
        public IResult Update(Equipment equipment)
        {
            _equipmentDal.Update(equipment);
            return new SuccessResult(Messages.EquipmentUpdated);
        }
    }
}
