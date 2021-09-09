using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISiteDal : IEntityRepository<Site>
    {
        List<SiteDetailDto> GetSitesDetails(Expression<Func<SiteDetailDto, bool>> filter = null);
    }
}
