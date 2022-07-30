﻿using Business.Abstract;
using Core.Business;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _icarimagedal;

        public CarImageManager(ICarImageDal icarimagedal)
        {
            _icarimagedal = icarimagedal;
        }

        public IResult Add(CarImage carimage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carimage.CarId));
            if(result != null)
            {
                return result;
            }
            _icarimagedal.Add(carimage);
            return new SuccessResult(true);
        }

        public IResult Delete(CarImage carimage)
        {
            _icarimagedal.Delete(carimage);
            return new SuccessResult(true);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_icarimagedal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carid)
        {
            var result = BusinessRules.Run(CheckCarImage(carid));
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(DefaultImage(carid).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_icarimagedal.GetAll(p=>p.CarId == carid));
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_icarimagedal.Get(p=>p.Id==id));
        }

        public IResult Update(CarImage carimage)
        {
            _icarimagedal.Update(carimage);
            return new SuccessResult(true);
        }

        private IResult CheckCarImageCount(int carid)
        {
            var result = _icarimagedal.GetAll(p=>p.CarId == carid).Count;
            if(result >= 5)
            {
                return new ErrorResult(false);
            }
            return new SuccessResult(true);
        }
        private IDataResult<List<CarImage>> DefaultImage(int carid)
        {
            List<CarImage> carimage = new List<CarImage>();
            carimage.Add(new CarImage { CarId = carid,Date = DateTime.Now,ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carimage);
           
        }
        private IResult CheckCarImage(int carid)
        {
            var result = _icarimagedal.GetAll(p => p.CarId == carid).Count;
            if(result > 0)
            {
                return new SuccessResult(true);
            }
            return new ErrorResult(false);
        }
    }
}