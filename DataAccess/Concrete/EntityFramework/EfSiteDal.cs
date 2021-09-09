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
    public class EfSiteDal : EfEntityRepositoryBase<Site, MedexDbContext>, ISiteDal
    {
        public List<SiteDetailDto> GetSitesDetails(Expression<Func<SiteDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from sites in context.Sites
                             join studies in context.Studies
                                 on sites.StudyId equals studies.Id
                             join sponsors in context.Sponsors
                             on studies.SponsorId equals sponsors.Id
                             select new SiteDetailDto
                             {
                                 Id = sites.Id,
                                 StudyCode = studies.Code,
                                 StudyName = studies.Name,
                                 StudySponsorName = sponsors.Name,
                                 Number = sites.Number,
                                 HospitalName = sites.HospitalName,
                                 Department = sites.Department,
                                 Investigator = sites.Investigator
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
