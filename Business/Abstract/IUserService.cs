using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUser();
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
        IDataResult<User> CheckByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
