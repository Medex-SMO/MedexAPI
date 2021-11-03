using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IResult Add(Assignment assignment);
        IResult Update(Assignment assignment);
        IResult Delete(Assignment assignment);
        IDataResult<Assignment> GetById(int id);
        IDataResult<List<AssignmentDetailDto>> GetSponsorsByUserId(int userId);
        IDataResult<List<AssignmentDetailDto>> GetStudiesByUserIdAndSponsorName(int userId, string sponsorName);
        IDataResult<List<AssignmentDetailDto>> GetSitesByUserIdAndSponsorNameAndProtocolCode(int userId, string sponsorName, string protocolCode);
        IDataResult<List<Assignment>> GetAll();
        IDataResult<List<AssignmentDetailDto>> GetAssignmentsDetails();
    }
}
