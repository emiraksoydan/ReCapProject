using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult UpdateUser(User user)
        {
            userDal.Update(user);
            return new SuccessResult(true);
        }
    }
}
