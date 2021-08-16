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
    public class StudyManager : IStudyService
    {
        IStudyDal _studyDal;
        public StudyManager(IStudyDal studyDal)
        {
            _studyDal = studyDal;
        }
        [ValidationAspect(typeof(StudyValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IStudyService.Get")]
        public IResult Add(Study study)
        {
            _studyDal.Add(study);
            return new SuccessResult(Messages.StudyAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IStudyService.Get")]
        public IResult Delete(Study study)
        {
            _studyDal.Delete(study);
            return new SuccessResult(Messages.StudyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Study>> GetAll()
        {
            return new SuccessDataResult<List<Study>>(_studyDal.GetAll(), Messages.StudyListed);
        }

        [CacheAspect]
        public IDataResult<Study> GetById(int id)
        {
            return new SuccessDataResult<Study>(_studyDal.Get(b => b.Id == id));
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IStudyService.Get")]
        public IResult Update(Study study)
        {
            _studyDal.Update(study);
            return new SuccessResult(Messages.StudyUpdated);
        }
    }
}
