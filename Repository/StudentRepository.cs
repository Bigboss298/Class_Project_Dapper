using CLH_Dapper.Data;
using CLH_Dapper.Models;
using Dapper;

namespace CLH_Dapper.Repository
{
    public class StudentRepository
    {
        public static IDataContext _context;

         public StudentRepository(DataContext context)
        {
          _context = context;
        }

        public Student Create(Student student)
        {
          var qry = $"insert into student(userId,InstructorId,Instructor,Batch,IsDeleted) values({student.UserId},{student.InstructorId},{student.Instructor},{student.Batch},{student.IsDeleted})";
            using(var connect = _context.Connection())
               {
                   var row = connect.Execute(qry);
                   if(row > 0)
                   {
                         return student;
                   }
                   return null;
               }  
        }
        public Student Get(string id)
        {
          var qry = $"select * from student where id = {id}";
          using (var connect = _context.Connection())
          {
               var student = connect.QuerySingleOrDefault<Student>(qry);
               if (student != null)
               {
                    return student;
               }
               return null;
          }
        }

         public ICollection<Student> GetAll()
          {
               var qry = $"select * from Student";
               using(var connect = _context.Connection())
               {
                    var student = connect.Query<Student>(qry);
                    return student.ToList();
               }

          }
        
    }
}