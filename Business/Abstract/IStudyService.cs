using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudyService
    {
        IResult Add(Study study);
        IResult Update(Study study);
        IResult Delete(Study study);
        IDataResult<Study> GetById(int id);
        IDataResult<List<Study>> GetAll();
        IDataResult<List<Study>> GetStudiesBySponsorId(int sponsorId);
        IDataResult<List<StudyDetailDto>> GetStudiesDetails();
    }
}
