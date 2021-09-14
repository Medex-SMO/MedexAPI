using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPatientService
    {
        IResult Add(Patient patient);
        IResult Update(Patient patient);
        IResult Delete(Patient patient);
        IDataResult<Patient> GetById(int id);
        IDataResult<List<Patient>> GetAll();
        IDataResult<List<PatientDetailDto>> GetPatientsDetails();
    }
}
