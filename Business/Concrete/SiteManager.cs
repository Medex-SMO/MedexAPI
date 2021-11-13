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
        IAssignmentDal _assignmentDal;
        public SiteManager(ISiteDal siteDal, IAssignmentDal assignmentDal)
        {
            _siteDal = siteDal;
            _assignmentDal = assignmentDal;
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

        [CacheAspect]
        public IDataResult<Site> GetBySiteNumber(string siteNumber)
        {
            return new SuccessDataResult<Site>(_siteDal.Get(b => b.SiteNumber == siteNumber));
        }

        [CacheAspect]
        public IDataResult<List<Site>> GetSitesByStudyId(int studyId)
        {
            return new SuccessDataResult<List<Site>>(_siteDal.GetAll(s => s.StudyId == studyId));
        }

        [CacheAspect]
        public IDataResult<List<SiteDetailDto>> GetSitesDetails()
        {
            return new SuccessDataResult<List<SiteDetailDto>>(_siteDal.GetSitesDetails());
        }

        [CacheAspect]
        public IDataResult<List<SiteDetailDto>> GetSitesDetailsBySiteNumber(string siteNumber)
        {
            return new SuccessDataResult<List<SiteDetailDto>>(_siteDal.GetSitesDetails(s => s.SiteNumber == siteNumber));
        }

        [CacheAspect]
        public IDataResult<List<SiteDetailDto>> GetSitesDetailsByUserId(int userId)
        {
            List<AssignmentDetailDto> assignment = _assignmentDal.GetAssignmentsDetails(a => a.UserId == userId);
            List<SiteDetailDto> sites = new List<SiteDetailDto>();

            foreach (var item in assignment)
            {
                sites.Add(_siteDal.GetSiteDetails(s => s.SiteNumber == item.SiteNumber));
            }

            return new SuccessDataResult<List<SiteDetailDto>>(sites);
        }

        [SecuredOperation("site.update,superuser,sitecoordinator")]
        [CacheRemoveAspect("ISiteService.Get,IPatientService.Get,IAssignmentService.Get,IVisitService.Get")]
        public IResult Update(Site site)
        {
            _siteDal.Update(site);
            return new SuccessResult(Messages.SiteUpdated);
        }
    }
}
