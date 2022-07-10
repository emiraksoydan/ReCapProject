using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;




caroperations();
//Brandoperations();




void caroperations(){
    Car carobject = new Car() {Id = 4008 , BrandId = 2, ColorId = 1, DailyPrice = 5000, Description = "Heachback Araba", ModelYear = 2022 };
    Car carobject2 = new Car() {Id = 4010, BrandId = 4, ColorId = 2, DailyPrice = 15000, Description = "Klasik Araba", ModelYear = 2022 };
    CarManager icarmanager = new CarManager(new EfCarDal());
    //icarmanager.Add(carobject);
    //icarmanager.Add(carobject2);
    //icarmanager.Delete(carobject2);
    //icarmanager.Update(carobject);

    foreach (var car in icarmanager.GetCarDetails())
    {
        Console.WriteLine(car.CarId +""+ car.BrandName + " " + car.ColorName + " " + car.DailyPrice +"....");
    }
    foreach (var car in icarmanager.GetCarsByColorId(2))
    {
        Console.WriteLine(car.Description);
    }
}

void Brandoperations()
{
    Brand brandobject = new Brand() { BrandId = 4, BrandName = "Aston Martin"};
    Brand brandobject2 = new Brand() { BrandName = "TOGG" };
    BrandManager ibrandmanager = new BrandManager(new EfBrandDal());
    //ibrandmanager.Add(brandobject);
    //ibrandmanager.Add(brandobject2);
    //ibrandmanager.Delete(brandobject);
    ibrandmanager.Update(brandobject);

    foreach (var brand in ibrandmanager.GetAll())
    {
        Console.WriteLine(brand.BrandName);
    }
   
        //Console.WriteLine(ibrandmanager.GetBrandByBrandId(1003).BrandName);
    
}