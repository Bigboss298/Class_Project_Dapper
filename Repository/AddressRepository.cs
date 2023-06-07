using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
     public class AddressRepository
     {
          public static IDataContext _context;
          public AddressRepository(DataContext context)
          {
               _context = context;
               _context.AddressTable();
          }

          public Address Create(Address address)
          {
               var qry = $"insert into address(Id, Number, Street, City, IsDeleted) values('{address.Id}', {address.Number}, '{address.Street}', '{address.City}', {address.IsDeleted})";
               using(var connect = _context.Connection())
               {
                   var row = connect.Execute(qry);
                   if(row > 0)
                   {
                         return address;
                   }
                   return null;
               }  
          }

          public Address Get(string id)
          {
               var qry = $"select * from address where Id = {id}";
               using(var connect = _context.Connection())
               {
                    var address = connect.QuerySingleOrDefault<Address>(qry);
                    if(address != null)
                    {
                         return address;
                    }
                    return null;
                    
               }
          }

          public ICollection<Address> GetAll()
          {
               var qry = $"select * from address";
               using(var connect = _context.Connection())
               {
                    var addresses = connect.Query<Address>(qry);
                    return addresses.ToList();

               }
          }
     }
}