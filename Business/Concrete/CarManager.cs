using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService 
    {
        ICarDal icardal;
        public CarManager(ICarDal icardal)
        {
            this.icardal = icardal;
        }
        [ValidationAspect(typeof (CarValidator))]
        public IResult Add(Car car)
        {

            icardal.Add(car);
            return new SuccessResult(true,Messages.SuccessAdd);
        }
        public IResult Delete(Car car)
        {
            
            icardal.Delete(car);
            return new SuccessResult(true,Messages.SuccessDelete);
            
        }
        public IResult Update(Car car)
        {

            icardal.Update(car);
            return new SuccessResult(true,Messages.SuccessUpdate);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(icardal.GetAll(),Messages.SuccessGetCarList);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Brandid)
        {
            return new SuccessDataResult<List<Car>>(icardal.GetAll(p=>p.BrandId == Brandid).OrderByDescending(p=>p.Description).ToList(),Messages.SuccessGetCarList);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Colorid)
        {
            return new SuccessDataResult<List<Car>>(icardal.GetAll(p => p.ColorId == Colorid),Messages.SuccessGetCarListByColorId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(icardal.GetAllCarDetails(),Messages.SuccessGetCarList);
        }
    }
}
