namespace CLH_Dapper.Models
{
    public class Student : BaseEntity
    {
        public string UserId{get; set;}
        public string InstructorId{get; set;}
        public Instructor Instructor{get; set;}
        public int Batch{get; set;}
    }
}