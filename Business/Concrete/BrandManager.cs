using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Brand car)
        {
            _ibranddal.Add(car);
            return new Result(true);
        }

        public IResult Delete(Brand car)
        {
            _ibranddal.Delete(car);
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

        public IResult Update(Brand car)
        {
            _ibranddal.Update(car);
            return new Result(true);
        }
    }
}
