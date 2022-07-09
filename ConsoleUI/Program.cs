using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ICarManager icarmanager = new ICarManager(new EfCarDal());

Car carobject = new Car() { BrandId = 2,ColorId = 1,DailyPrice = 5000, Description = "Spor Araba",ModelYear = 2022};
Car carobject2 = new Car() {  BrandId = 3, ColorId = 2, DailyPrice = 15000, Description = "Klasik Araba", ModelYear = 2022 };

icarmanager.Add(carobject);

foreach (var car in icarmanager.GetCarsByBrandId(2))
{
    Console.WriteLine(car.Description);
}
icarmanager.Add(carobject2);
foreach (var car in icarmanager.GetCarsByColorId(2))
{
    Console.WriteLine(car.Description);
}