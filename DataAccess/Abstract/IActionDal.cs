using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IActionDal : IEntityRepository<Entities.Concrete.Action>
    {
        List<ActionDetailDto> GetActionsDetails(Expression<Func<ActionDetailDto, bool>> filter = null);
    }
}
