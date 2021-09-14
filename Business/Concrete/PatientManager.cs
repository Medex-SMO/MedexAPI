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
    public class PatientManager : IPatientService
    {
        IPatientDal _patientDal;
        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }
        [ValidationAspect(typeof(PatientValidator))]
        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IPatientService.Get")]
        public IResult Add(Patient patient)
        {
            _patientDal.Add(patient);
            return new SuccessResult(Messages.PatientAdded);
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IPatientService.Get")]
        public IResult Delete(Patient patient)
        {
            _patientDal.Delete(patient);
            return new SuccessResult(Messages.PatientDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Patient>> GetAll()
        {
            return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(), Messages.PatientListed);
        }

        [CacheAspect]
        public IDataResult<Patient> GetById(int id)
        {
            return new SuccessDataResult<Patient>(_patientDal.Get(b => b.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<PatientDetailDto>> GetPatientsDetails()
        {
            return new SuccessDataResult<List<PatientDetailDto>>(_patientDal.GetPatientsDetails());
        }

        [SecuredOperation("superuser")]
        [CacheRemoveAspect("IPatientService.Get")]
        public IResult Update(Patient patient)
        {
            _patientDal.Update(patient);
            return new SuccessResult(Messages.PatientUpdated);
        }
    }
}
