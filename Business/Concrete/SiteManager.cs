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
    public class SiteManager : ISiteService
    {
        ISiteDal _siteDal;
        public SiteManager(ISiteDal siteDal)
        {
            _siteDal = siteDal;
        }
        [ValidationAspect(typeof(SiteValidator))]
        [SecuredOperation("site.add,superuser")]
        [CacheRemoveAspect("ISiteService.Get,IPatientService.Get,IAssignmentService.Get,IVisitService.Get")]
        public IResult Add(Site site)
        {
            _siteDal.Add(site);
            return new SuccessResult(Messages.SiteAdded);
        }

        [SecuredOperation("site.delete,superuser")]
        [CacheRemoveAspect("ISiteService.Get,IPatientService.Get,IAssignmentService.Get,IVisitService.Get")]
        public IResult Delete(Site site)
        {
            _siteDal.Delete(site);
            return new SuccessResult(Messages.SiteDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Site>> GetAll()
        {
            return new SuccessDataResult<List<Site>>(_siteDal.GetAll(), Messages.SiteListed);
        }

        [CacheAspect]
        public IDataResult<Site> GetById(int id)
        {
            return new SuccessDataResult<Site>(_siteDal.Get(b => b.Id == id));
        }

        public IDataResult<List<Site>> GetSitesByStudyId(int studyId)
        {
            return new SuccessDataResult<List<Site>>(_siteDal.GetAll(s => s.StudyId == studyId));
        }

        [CacheAspect]
        public IDataResult<List<SiteDetailDto>> GetSitesDetails()
        {
            return new SuccessDataResult<List<SiteDetailDto>>(_siteDal.GetSitesDetails());
        }

        [SecuredOperation("site.update,superuser")]
        [CacheRemoveAspect("ISiteService.Get,IPatientService.Get,IAssignmentService.Get,IVisitService.Get")]
        public IResult Update(Site site)
        {
            _siteDal.Update(site);
            return new SuccessResult(Messages.SiteUpdated);
        }
    }
}
