namespace CLH_Dapper.Models
{
    public class Instructor : BaseEntity
    {
        public string UserId{get; set;}
        public ICollection<Student> Students = new HashSet<Student>();
    }
}