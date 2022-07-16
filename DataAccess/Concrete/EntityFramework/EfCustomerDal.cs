using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContextDal>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomer()
        {
            using(ReCapContextDal reCapContextDal = new ReCapContextDal())
            {
                var result = from c in reCapContextDal.Customers
                             join u in reCapContextDal.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto { CompanyName = c.CompanyName, CustomerId = c.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName };
                return result.ToList();


            }
           
        }
    }
}
