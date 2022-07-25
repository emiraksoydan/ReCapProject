using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _ibranddal;

        public BrandManager(IBrandDal ibranddal)
        {
            _ibranddal = ibranddal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            
            _ibranddal.Add(brand);
            return new Result(true);
        }

        public IResult Delete(Brand brand)
        {
            _ibranddal.Delete(brand);
            return new Result(true);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_ibranddal.GetAll(),Messages.SuccessGetCarBrandList);
        }

        public IDataResult<Brand> GetBrandByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_ibranddal.Get(b=>b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            _ibranddal.Update(brand);
            return new Result(true);
        }
    }
}
