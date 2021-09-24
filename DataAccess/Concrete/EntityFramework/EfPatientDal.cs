using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPatientDal : EfEntityRepositoryBase<Patient, MedexDbContext>, IPatientDal
    {
        public List<PatientDetailDto> GetPatientsDetails(Expression<Func<PatientDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from patients in context.Patients
                             join sites in context.Sites
                                 on patients.SiteId equals sites.Id
                             join studies in context.Studies
                             on sites.StudyId equals studies.Id
                             select new PatientDetailDto
                             {
                                 Id = patients.Id,
                                 SiteName = sites.SiteName,
                                 SiteNumber = sites.SiteNumber,
                                 ProtocolCode = studies.ProtocolCode,
                                 No = patients.No
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
