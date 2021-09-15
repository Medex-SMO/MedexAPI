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
    public class AssignmentManager : IAssignmentService
    {
        IAssignmentDal _assignmentDal;
        public AssignmentManager(IAssignmentDal assignmentDal)
        {
            _assignmentDal = assignmentDal;
        }
        [ValidationAspect(typeof(AssignmentValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IAssignmentService.Get")]
        public IResult Add(Assignment assignment)
        {
            _assignmentDal.Add(assignment);
            return new SuccessResult(Messages.AssignmentAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IAssignmentService.Get")]
        public IResult Delete(Assignment assignment)
        {
            _assignmentDal.Delete(assignment);
            return new SuccessResult(Messages.AssignmentDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Assignment>> GetAll()
        {
            return new SuccessDataResult<List<Assignment>>(_assignmentDal.GetAll(), Messages.AssignmentListed);
        }

        public IDataResult<List<AssignmentDetailDto>> GetAssignmentsDetails()
        {
            return new SuccessDataResult<List<AssignmentDetailDto>>(_assignmentDal.GetAssignmentsDetails());
        }

        [CacheAspect]
        public IDataResult<Assignment> GetById(int id)
        {
            return new SuccessDataResult<Assignment>(_assignmentDal.Get(b => b.Id == id));
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IAssignmentService.Get")]
        public IResult Update(Assignment assignment)
        {
            _assignmentDal.Update(assignment);
            return new SuccessResult(Messages.AssignmentUpdated);
        }
    }
}
