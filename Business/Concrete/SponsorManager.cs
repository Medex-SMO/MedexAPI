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
    public class SponsorManager : ISponsorService
    {
        ISponsorDal _sponsorDal;
        public SponsorManager(ISponsorDal sponsorDal)
        {
            _sponsorDal = sponsorDal;
        }
        [ValidationAspect(typeof(SponsorValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("ISponsorService.Get")]
        public IResult Add(Sponsor sponsor)
        {
            _sponsorDal.Add(sponsor);
            return new SuccessResult(Messages.SponsorAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("ISponsorService.Get")]
        public IResult Delete(Sponsor sponsor)
        {
            _sponsorDal.Delete(sponsor);
            return new SuccessResult(Messages.SponsorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Sponsor>> GetAll()
        {
            return new SuccessDataResult<List<Sponsor>>(_sponsorDal.GetAll(), Messages.SponsorListed);
        }

        [CacheAspect]
        public IDataResult<Sponsor> GetById(int id)
        {
            return new SuccessDataResult<Sponsor>(_sponsorDal.Get(b => b.Id == id));
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("ISponsorService.Get")]
        public IResult Update(Sponsor sponsor)
        {
            _sponsorDal.Update(sponsor);
            return new SuccessResult(Messages.SponsorUpdated);
        }
    }
}
