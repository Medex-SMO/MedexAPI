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
                             join sponsors in context.Sponsors
                                 on assignment.SponsorId equals sponsors.Id
                             join studies in context.Studies
                                 on assignment.StudyId equals studies.Id
                             join sites in context.Sites
                                 on assignment.SiteId equals sites.Id
                             join users in context.Users
                             on assignment.UserId equals users.Id
                             select new AssignmentDetailDto
                             {
                                 Id = assignment.Id,
                                 UserId = users.Id,
                                 SponsorName = sponsors.Name,
                                 ProtocolCode = studies.ProtocolCode,
                                 SiteName = sites.SiteName,
                                 SiteNumber = sites.SiteNumber,
                                 Email = users.Email,
                                 Status = assignment.Status
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
