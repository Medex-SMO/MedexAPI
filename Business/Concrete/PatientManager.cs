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
        [SecuredOperation("patient.add,superuser")]
        [CacheRemoveAspect("IPatientService.Get")]
        public IResult Add(Patient patient)
        {
            _patientDal.Add(patient);
            return new SuccessResult(Messages.PatientAdded);
        }

        [SecuredOperation("patient.delete,superuser")]
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

        public IDataResult<List<Patient>> GetPatientsBySiteId(int siteId)
        {
            return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(s => s.SiteId == siteId));
        }

        [CacheAspect]
        public IDataResult<List<PatientDetailDto>> GetPatientsDetails()
        {
            return new SuccessDataResult<List<PatientDetailDto>>(_patientDal.GetPatientsDetails());
        }

        [SecuredOperation("patient.update,superuser")]
        [CacheRemoveAspect("IPatientService.Get")]
        public IResult Update(Patient patient)
        {
            _patientDal.Update(patient);
            return new SuccessResult(Messages.PatientUpdated);
        }
    }
}
