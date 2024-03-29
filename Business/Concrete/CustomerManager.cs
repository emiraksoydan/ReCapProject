﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerdal;
        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerdal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult AddCustomer(Customer customer)
        {
            
            customerdal.Add(customer);
            return new SuccessResult();
        }

        public IResult DeleteCustomer(Customer customer)
        {
            customerdal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
           
            return new SuccessDataResult<List<Customer>>(customerdal.GetAll());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {

            return new SuccessDataResult<List<CustomerDetailDto>>(customerdal.GetCustomer());
        }

        public IResult UpdateCustomer(Customer customer)
        {
            customerdal.Update(customer);
            return new SuccessResult();
        }
    }
}
