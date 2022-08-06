using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult AddUser(User user)
        {
            userDal.Add(user);
            return new SuccessResult(true);
        }

        public IResult DeleteUser(User user)
        {
            userDal.Delete(user);
            return new SuccessResult(true);
        }

        public IDataResult<List<User>> GetAllUser()
        {
           ;
            return new SuccessDataResult<List<User>>(userDal.GetAll());
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(userDal.Get(p => p.Email == email));
        }

        public IDataResult<List<OperationClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaimDto>>(userDal.GetClaims(user));
        }

        public IResult UpdateUser(User user)
        {
            userDal.Update(user);
            return new SuccessResult(true);
        }
    }
}
