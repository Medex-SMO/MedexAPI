using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISiteService
    {
        IResult Add(Site site);
        IResult Update(Site site);
        IResult Delete(Site site);
        IDataResult<Site> GetById(int id);
        IDataResult<List<Site>> GetAll();
        IDataResult<List<SiteDetailDto>> GetSitesDetails();
    }
}
