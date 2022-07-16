using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand car);
        IResult Update(Brand car);
        IResult Delete(Brand car);
        IDataResult<Brand> GetBrandByBrandId(int id);
       
    }
}
