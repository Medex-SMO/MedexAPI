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
                             join cities in context.Cities
                             on sites.CityId equals cities.Id
                             select new SiteDetailDto
                             {
                                 Id = sites.Id,
                                 CityName = cities.Name,
                                 ProtocolCode = studies.ProtocolCode,
                                 StudyName = studies.StudyName,
                                 StudySponsorName = sponsors.Name,
                                 SiteNumber = sites.SiteNumber,
                                 SiteName = sites.SiteName,
                                 Department = sites.Department,
                                 Investigator = sites.Investigator,
                                 CraName = sites.CraName,
                                 CraMail = sites.CraMail,
                                 CraMobile = sites.CraMobile
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public SiteDetailDto GetSiteDetails(Expression<Func<SiteDetailDto, bool>> filter = null)
        {
            using (var context = new MedexDbContext())
            {
                var result = from sites in context.Sites
                             join studies in context.Studies
                                 on sites.StudyId equals studies.Id
                             join sponsors in context.Sponsors
                             on studies.SponsorId equals sponsors.Id
                             join cities in context.Cities
                             on sites.CityId equals cities.Id
                             select new SiteDetailDto
                             {
                                 Id = sites.Id,
                                 CityName = cities.Name,
                                 ProtocolCode = studies.ProtocolCode,
                                 StudyName = studies.StudyName,
                                 StudySponsorName = sponsors.Name,
                                 SiteNumber = sites.SiteNumber,
                                 SiteName = sites.SiteName,
                                 Department = sites.Department,
                                 Investigator = sites.Investigator,
                                 CraName = sites.CraName,
                                 CraMail = sites.CraMail,
                                 CraMobile = sites.CraMobile
                             };
                return filter == null ? result.FirstOrDefault() : result.Where(filter).FirstOrDefault();
            }
        }
    }
}
