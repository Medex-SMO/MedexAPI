using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IStudyDal : IEntityRepository<Study>
    {
        List<StudyDetailDto> GetStudiesDetails(Expression<Func<StudyDetailDto, bool>> filter = null);
    }
}
