namespace CLH_Dapper.Models
{
    public class Role : BaseEntity
    {
        public string Name{get; set;}
        public string Description{get; set;}
        public ICollection<UserRole> UserRoles{get; set;} = new HashSet<UserRole>();
    }
}