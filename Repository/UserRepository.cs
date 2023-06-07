using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
    public class UserRepository
    {
         public static IDataContext _context;
          public UserRepository(DataContext context)
          {
               _context = context;
          }

          public User Create(User user)
          {
               var qry = $"insert into user(Id, Name, Email, Pin, PhoneNumber, AddressId, IsDeleted) values('{user.Id}', {user.Name}, '{user.Email}', {user.Pin}, '{user.PhoneNumber}', '{user.AddressId}', {user.IsDeleted})";
               using(var connect = _context.Connection())
               {
                   var row = connect.Execute(qry);
                   if(row > 0)
                   {
                         return user;
                   }
                   return null;
               }  
          }

          public User Get(string id)
          {
               var qry = $"select * from user where Id = {id}";
               using(var connect = _context.Connection())
               {
                    var user = connect.QuerySingleOrDefault<User>(qry);
                    if(user != null)
                    {
                         return user;
                    }
                    return null;
                    
               }
          }

          public ICollection<User> GetAll()
          {
               var qry = $"select * from user";
               using(var connect = _context.Connection())
               {
                    var users = connect.Query<User>(qry);
                    return users.ToList();

               }
          }
    }
}