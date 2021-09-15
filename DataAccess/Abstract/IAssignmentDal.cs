using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAssignmentDal : IEntityRepository<Assignment>
    {
        List<AssignmentDetailDto> GetAssignmentsDetails(Expression<Func<AssignmentDetailDto, bool>> filter = null);
    }
}
