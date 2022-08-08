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
    public class ColorManager : IColorService
    {
        IColorDal _icolordal;

        public ColorManager(IColorDal icolordal)
        {
            _icolordal = icolordal;
        }

        public IResult Add(Color color)
        {
            _icolordal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _icolordal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_icolordal.GetAll());
        }

        public IDataResult<Color> GetBrandByBrandId(int id)
        {
            return new SuccessDataResult<Color>(_icolordal.Get(p=>p.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _icolordal.Update(color);
            return new SuccessResult();
        }
    }
}
