using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
    public class InstructorRepository
    {
         public static IDataContext _context;
          public InstructorRepository(DataContext context)
          {
               _context = context;
               _context.InstructorTable();
          }
          public Instructor Create(Instructor instructor)
          {
               var qry = $"Insert into instructor (UserId) values ('{instructor.UserId}')";
                using(var connect = _context.Connection())
               {
                   var row = connect.Execute(qry);
                   if(row > 0)
                   {
                         return instructor;
                   }
                   return null;
               }  
          }
            public Instructor Get(string id)
          {
               var qry = $"select * from instructor where Id = {id}";
               using(var connect = _context.Connection())
               {
                    var instructor = connect.QuerySingleOrDefault<Instructor>(qry);
                    if(instructor != null)
                    {
                         return instructor;
                    }
                    return null;
                    
               }
          }

          public ICollection<Instructor> GetAll()
          {
               var qry = $"select * from instructor";
               using(var connect = _context.Connection())
               {
                    var instructor = connect.Query<Instructor>(qry);
                    return instructor.ToList();
               }

          }
    }
}