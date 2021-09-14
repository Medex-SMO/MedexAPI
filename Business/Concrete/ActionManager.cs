using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ActionManager : IActionService
    {
        IActionDal _actionDal;
        public ActionManager(IActionDal actionDal)
        {
            _actionDal = actionDal;
        }
        [ValidationAspect(typeof(ActionValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IActionService.Get")]
        public IResult Add(Entities.Concrete.Action action)
        {
            _actionDal.Add(action);
            return new SuccessResult(Messages.ActionAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IActionService.Get")]
        public IResult Delete(Entities.Concrete.Action action)
        {
            _actionDal.Delete(action);
            return new SuccessResult(Messages.ActionDeleted);
        }

        [CacheAspect]
        public IDataResult<List<ActionDetailDto>> GetActionsDetails()
        { 
            return new SuccessDataResult<List<ActionDetailDto>>(_actionDal.GetActionsDetails());
        }

        [CacheAspect]
        public IDataResult<List<Entities.Concrete.Action>> GetAll()
        {
            return new SuccessDataResult<List<Entities.Concrete.Action>>(_actionDal.GetAll(), Messages.ActionListed);
        }

        [CacheAspect]
        public IDataResult<Entities.Concrete.Action> GetById(int id)
        {
            return new SuccessDataResult<Entities.Concrete.Action>(_actionDal.Get(b => b.Id == id));
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IActionService.Get")]
        public IResult Update(Entities.Concrete.Action action)
        {
            _actionDal.Update(action);
            return new SuccessResult(Messages.ActionUpdated);
        }
    }
}
