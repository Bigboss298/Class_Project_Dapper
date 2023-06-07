using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
    public class UserRoleRepository
    {
        public class UserRepository
    {
         public static IDataContext _context;
          public UserRepository(DataContext context)
          {
               _context = context;
          }

          public UserRole Create(UserRole userRole)
          {
               var qry = $"insert into user(Id, UserId, RoleId, IsDeleted) values('{userRole.Id}', '{userRole.UserId}', '{userRole.RoleId}', {userRole.IsDeleted})";
               using(var connect = _context.Connection())
               {
                   var row = connect.Execute(qry);
                   if(row > 0)
                   {
                         return userRole;
                   }
                   return null;
               }  
          }

          public UserRole Get(string id)
          {
               var qry = $"select * from userrole where Id = {id}";
               using(var connect = _context.Connection())
               {
                    var user = connect.QuerySingleOrDefault<UserRole>(qry);
                    if(user != null)
                    {
                         return user;
                    }
                    return null;
                    
               }
          }

          public ICollection<UserRole> GetAll()
          {
               var qry = $"select * from userrole";
               using(var connect = _context.Connection())
               {
                    var users = connect.Query<UserRole>(qry);
                    return users.ToList();

               }
          }
    }
}
}