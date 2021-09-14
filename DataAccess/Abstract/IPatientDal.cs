using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPatientDal : IEntityRepository<Patient>
    {
        List<PatientDetailDto> GetPatientsDetails(Expression<Func<PatientDetailDto, bool>> filter = null);
    }
}
