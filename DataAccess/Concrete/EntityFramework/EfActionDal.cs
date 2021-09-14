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
    public class EfActionDal : EfEntityRepositoryBase<Entities.Concrete.Action, MedexDbContext>, IActionDal
    {
        public List<ActionDetailDto> GetActionsDetails(Expression<Func<ActionDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from action in context.Actions
                             join assignment in context.Assignments
                                 on action.AssignId equals assignment.Id
                             join patients in context.Patients
                             on action.PatientId equals patients.Id
                             select new ActionDetailDto
                             {
                                 Id = action.Id,
                                 CraName = assignment.CraName,
                                 PatientNo = patients.No,
                                 VisitType = action.VisitType,
                                 ActionDate = action.ActionDate,
                                 PlanDate = action.PlanDate,
                                 Duration = action.Duration,
                                 Details = action.Details,
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
