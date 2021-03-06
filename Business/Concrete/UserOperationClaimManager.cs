using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IOperationClaimService operationClaimService,
            IUserOperationClaimDal userOperationClaimDal
        )
        {
            _operationClaimService = operationClaimService;
            _userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("superuser")]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        [SecuredOperation("superuser")]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IResult AddUserClaim(User user)
        {
            var operationClaim = _operationClaimService.GetByName("user").Data;
            var userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = user.Id };
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("superuser")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("superuser")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        [SecuredOperation("superuser")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        [SecuredOperation("superuser")]
        public IDataResult<UserOperationClaim> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.UserId == userId));
        }
    }
}