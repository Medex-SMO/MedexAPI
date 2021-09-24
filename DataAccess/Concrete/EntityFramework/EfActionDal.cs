﻿using Core.DataAccess.EntityFramework;
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
                var result = from action in context.Visits
                             join patients in context.Patients
                             on action.PatientId equals patients.Id
                             select new ActionDetailDto
                             {
                                 Id = action.Id,
                                 SubjectNo = patients.SubjectNo,
                                 VisitNo = action.VisitNo,
                                 VisitDate = action.VisitDate,
                                 TimeSpent = action.TimeSpent,
                                 Description = action.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
