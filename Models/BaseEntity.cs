namespace CLH_Dapper.Models
{
    public class BaseEntity
    {
        public string Id {get; set;} = Guid.NewGuid().ToString().Substring(0,4);
        public bool IsDeleted{get; set;}
    }
}