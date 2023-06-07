using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
    public class RoleRepository
    {
        public static IDataContext _context;

        public RoleRepository(DataContext context)
        {
          _context = context;
          _context.RoleTable();
        }

        public Role Create(Role role)
        {
          var qry = $"Insert into Role(Id,Name,Description,IsDeleted) values('{role.Id}','{role.Name}','{role.Description}',{role.IsDeleted})";
          using (var connect = _context.Connection())
          {
             var row = connect.Execute(qry); 
             if (row > 0)
             {
               return role;
             }
             return null;
          }
        }
        public Role Get(string id)
        {
          var qry = $"select * from Role where Id = {id}";
          using (var connect = _context.Connection())
          {
               var role = connect.QuerySingleOrDefault<Role>(qry);
               if (role != null)
               {
                    return role;
               }
               return null;
          }
        }

        public Role GetByName(string name)
        {
          var qry = $"select * from Role where Name = '{name}'";
          using (var connect = _context.Connection())
          {
               var role = connect.QuerySingleOrDefault<Role>(qry);
               if (role != null)
               {
                    return role;
               }
               return null;
          }
        }
        public ICollection<Role> GetAll()
          {
               var qry = $"select * from Role";
               using(var connect = _context.Connection())
               {
                    var role = connect.Query<Role>(qry);
                    return role.ToList();
               }

          }
    }
}