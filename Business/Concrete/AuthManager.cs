using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccesToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesstoken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accesstoken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var usertocheck = _userService.CheckByEmail(userForLoginDto.Email).Data;
            if(usertocheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPassword(userForLoginDto.Password, usertocheck.PasswordHash, usertocheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(usertocheck, Messages.SuccesfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordhash, passwordsalt;
            HashingHelper.CreatePasswordHash(password, out passwordhash, out passwordsalt);
            var user = new User { Email = userForRegisterDto.Email,FirstName = userForRegisterDto.FirstName,LastName = userForRegisterDto.LastName,PasswordHash = passwordhash,PasswordSalt = passwordsalt,Status = true};
            _userService.AddUser(user);

            return new SuccessDataResult<User>(user, Messages.SuccessRegister);
        }

        public IResult userExists(string email)
        {
            if(_userService.CheckByEmail(email) != null)
            {
                return new  ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
