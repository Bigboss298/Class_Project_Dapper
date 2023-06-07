// See https://aka.ms/new-console-template for more information


using CLH_Dapper.Data;
using CLH_Dapper.Dto;
using CLH_Dapper.Models;
using CLH_Dapper.Repository;
using CLH_Dapper.Services;

// DataContext context = new DataContext();
// context.AddressTable();

// dynamic a = 7;
// a = "ade";

// System.Console.WriteLine(a);
// a = new Address();
// System.Console.WriteLine(a);
// a.City = "Abeokuta";
// System.Console.WriteLine(a.City);

 

var num = 8;
var strict = "gng";
var city = "abk";
var name = "adewale";
var email = "ade@gmail.com";
var pin = 1234;
var phone = "09876457";

var asd = new CreateInstructorRequestModel
{
     Number = num,
     Street = strict,
     City = city,
     Name = name,
     Email = email,
     Pin = pin,
     PhoneNumber = phone,
     
};

var dt = new DataContext();
var re = new InstructorRepository(dt);
var ty = new AddressRepository(dt);
var lp = new UserRepository(dt);
var rt = new RoleRepository(dt);
var qwe = new InstructorService(re,ty,lp,rt);
var uio = qwe.Create(asd);
System.Console.WriteLine($"{uio.Name}\t{uio.Email}");