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
    public class EfAssignmentDal : EfEntityRepositoryBase<Assignment, MedexDbContext>, IAssignmentDal
    {
        public List<AssignmentDetailDto> GetAssignmentsDetails(Expression<Func<AssignmentDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from assignment in context.Assignments
                             join site in context.Sites
                                 on assignment.SiteId equals site.Id
                             join users in context.Users
                             on assignment.UserId equals users.Id
                             select new AssignmentDetailDto
                             {
                                 Id = assignment.Id,
                                 SiteNumber = site.SiteNumber,
                                 Email = users.Email,
                                 CraName = assignment.CraName,
                                 Status = assignment.Status
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
