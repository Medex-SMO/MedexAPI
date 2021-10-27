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
    public class VisitManager : IVisitService
    {
        IVisitDal _visitDal;
        public VisitManager(IVisitDal visitDal)
        {
            _visitDal = visitDal;
        }
        [ValidationAspect(typeof(VisitValidator))]
        [SecuredOperation("visit.add,superuser")]
        [CacheRemoveAspect("IVisitService.Get")]
        public IResult Add(Visit visit)
        {
            _visitDal.Add(visit);
            return new SuccessResult(Messages.VisitAdded);
        }

        [SecuredOperation("visit.delete,superuser")]
        [CacheRemoveAspect("IVisitService.Get")]
        public IResult Delete(Visit visit)
        {
            _visitDal.Delete(visit);
            return new SuccessResult(Messages.VisitDeleted);
        }

        [CacheAspect]
        public IDataResult<List<VisitDetailDto>> GetVisitsDetails()
        { 
            return new SuccessDataResult<List<VisitDetailDto>>(_visitDal.GetVisitsDetails());
        }

        [CacheAspect]
        public IDataResult<List<Visit>> GetAll()
        {
            return new SuccessDataResult<List<Visit>>(_visitDal.GetAll(), Messages.VisitListed);
        }

        [CacheAspect]
        public IDataResult<Visit> GetById(int id)
        {
            return new SuccessDataResult<Visit>(_visitDal.Get(b => b.Id == id));
        }

        [SecuredOperation("visit.update,superuser")]
        [CacheRemoveAspect("IVisitService.Get")]
        public IResult Update(Visit visit)
        {
            _visitDal.Update(visit);
            return new SuccessResult(Messages.VisitUpdated);
        }

        public IDataResult<List<VisitDetailDto>> GetVisitsDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<VisitDetailDto>>(_visitDal.GetVisitsDetails(v => v.UserId == userId), Messages.VisitListed);
        }
    }
}
