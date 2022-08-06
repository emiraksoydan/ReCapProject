using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContextDal>, IUserDal
    {
        public List<OperationClaimDto> GetClaims(User user)
        {
            using (var context = new ReCapContextDal())
            {
                var result = from operationclaim in context.OperationClaims
                             join useroperationclaim in context.UserOperationClaims
                             on operationclaim.Id equals useroperationclaim.OperationClaimId
                             where useroperationclaim.UserId == user.Id
                             select new OperationClaimDto { Name = operationclaim.Name,Email = user.Email,FirstName = user.FirstName,LastName = user.LastName,Status = user.Status,UserId = useroperationclaim.UserId };
                return result.ToList();
            }
        }
    }
}
