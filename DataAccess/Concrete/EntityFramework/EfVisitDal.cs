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
    public class EfVisitDal : EfEntityRepositoryBase<Visit, MedexDbContext>, IVisitDal
    {
        public List<VisitDetailDto> GetVisitsDetails(Expression<Func<VisitDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from visit in context.Visits
                             join patients in context.Patients
                             on visit.PatientId equals patients.Id
                             join user in context.Users
                             on visit.UserId equals user.Id
                             select new VisitDetailDto
                             {
                                 Id = visit.Id,
                                 UserId = user.Id,
                                 Name = user.FirstName + " " + user.LastName,
                                 SubjectNo = patients.SubjectNo,
                                 VisitNo = visit.VisitNo,
                                 VisitDate = visit.VisitDate,
                                 TimeSpent = visit.TimeSpent,
                                 Description = visit.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
