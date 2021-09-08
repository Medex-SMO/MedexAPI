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
    public class EfStudyDal : EfEntityRepositoryBase<Study, MedexDbContext>, IStudyDal
    {
        public List<StudyDetailDto> GetStudiesDetails(Expression<Func<StudyDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from studies in context.Studies
                             join sponsors in context.Sponsors
                                 on studies.SponsorId equals sponsors.Id
                             select new StudyDetailDto
                             {
                                 Id = studies.Id,
                                 SponsorName = sponsors.Name,
                                 Code = studies.Code,
                                 Name = studies.Name,
                                 Indication = studies.Indication
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
