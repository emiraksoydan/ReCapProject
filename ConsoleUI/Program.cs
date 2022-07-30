using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;




//caroperations();
//Brandoperations();
UserAndRentOperation();


void UserAndRentOperation()
{
    User user = new User() { Email = "asdasd", FirstName = "emir", LastName = "asda", Password = "3434abc" };
    User user2 = new User() { Email = "asdasasdd", FirstName = "emirasd", LastName = "asasdda", Password = "3434abcasd" };

    Customer customer = new Customer() { CompanyName = "asda", UserId = 1 };
    Customer customer2 = new Customer() { CompanyName = "asda", UserId = 2 };
    Customer customer3 = new Customer() { CompanyName = "asdaasdasd", UserId = 4 };


    UserManager userManager = new UserManager(new EfUserDal());
    //userManager.AddUser(user);
    //userManager.AddUser(user2);

    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    //customerManager.AddCustomer(customer);
    //customerManager.AddCustomer(customer2);
    //customerManager.AddCustomer(customer3);
    Rental rental = new Rental() { CarId = 4008,CustomerId = 1, RentDate = new DateTime(2022, 07, 15), ReturnDate = new DateTime(2022, 07, 22) };
    Rental rental2 = new Rental() { CarId = 1, CustomerId = 2,  RentDate = new DateTime(2022, 07, 18), ReturnDate = new DateTime(2022, 07, 29) };
    Rental rental4 = new Rental() { CarId = 5002, CustomerId = 3, RentDate = new DateTime(2022, 08, 18), ReturnDate = new DateTime(2022, 08, 30) };
    Car carobject2 = new Car() {  BrandId = 4, ColorId = 2, DailyPrice = 15000, Description = "Klasik Araba", ModelYear = 2022 };
    Car carobject3 = new Car() { BrandId = 4, ColorId = 2, DailyPrice = 20000, Description = "Klassadasdik Araba", ModelYear = 2023 };
    Car carobject4 = new Car() { BrandId = 1003, ColorId = 3, DailyPrice = 120000, Description = "TOGG sedan", ModelYear = 2023 };

    //CarManager carManager = new CarManager(new EfCarDal());
    //carManager.Add(carobject4);

    RentalManager rentalManager = new RentalManager(new EfRentalDal());
   //// rentalManager.AddRental(rental);
   // rentalManager.AddRental(rental4);


    //var result = customerManager.GetCustomerDetail();
    //if(result.Success == true)
    //{
    //    foreach (var item in result.Data)
    //    {
    //        Console.WriteLine(item.FirstName +""+ item.LastName + "" + item.Email +""+ item.CompanyName);
    //    }
    //}


    var result = rentalManager.GetRentalDetail();
    if(result.Success == true)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(" Return Date: " + item.ReturnDate + " Rent Date: " + item.RentDate + " " + item.BrandName + " " + item.FirstName + " " + item.ColorName + " " + item.Email + " " + item.CompanyName + " " + item.DailyPrice + " " + item.Description);
        }
    }
}




void caroperations(){
    Car carobject = new Car() {Id = 4008 , BrandId = 2, ColorId = 1, DailyPrice = 5000, Description = "Heachback Araba", ModelYear = 2022 };
    Car carobject2 = new Car() {Id = 4010, BrandId = 4, ColorId = 2, DailyPrice = 15000, Description = "Klasik Araba", ModelYear = 2022 };
    CarManager icarmanager = new CarManager(new EfCarDal());
    //icarmanager.Add(carobject);
    //icarmanager.Add(carobject2);
    //icarmanager.Delete(carobject2);
    //icarmanager.Update(carobject);
    var result = icarmanager.GetCarDetails();
    var result2 = icarmanager.GetCarsByColorId(2);
    if (result.Success == true && result2.Success == true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarId + "" + car.BrandName + " " + car.ColorName + " " + car.DailyPrice + "....");
        }
        Console.WriteLine(result.Message);
        foreach (var car in result2.Data)
        {
            Console.WriteLine(car.ColorId);
        }
        Console.WriteLine(result2.Message);

    }
    else
    {
        Console.WriteLine(result.Message);
    }

   
}

//void Brandoperations()
//{
//    Brand brandobject = new Brand() { BrandId = 4, BrandName = "Aston Martin"};
//    Brand brandobject2 = new Brand() { BrandName = "TOGG" };
//    BrandManager ibrandmanager = new BrandManager(new EfBrandDal());
//    //ibrandmanager.Add(brandobject);
//    //ibrandmanager.Add(brandobject2);
//    //ibrandmanager.Delete(brandobject);
//    ibrandmanager.Update(brandobject);
//    var result = ibrandmanager.GetAll();
//    if(result.Success == true)
//    {
//        foreach (var brand in result.Data)
//        {
//            Console.WriteLine(brand.BrandName);
//        }
//        Console.WriteLine(result.Message);

//    }
//    else
//    {
//        Console.WriteLine(result.Message);
//    }

//    //Console.WriteLine(ibrandmanager.GetBrandByBrandId(1003).BrandName);

//}