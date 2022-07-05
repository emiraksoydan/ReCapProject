using Business.Concrete;
using DataAccess.Concrete.InMemory;

ICarManager icarmanager = new ICarManager(new InMemoryCarDal());

foreach (var car in icarmanager.getall())
{
    Console.WriteLine(car.Description);
}