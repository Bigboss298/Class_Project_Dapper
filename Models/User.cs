namespace CLH_Dapper.Models
{
    public class User : BaseEntity
    {
          public string Name{get; set;}
          public string Email{get; set;}
          public int Pin{get; set;}
          public string PhoneNumber{get; set;}
          public string AddressId{get; set;}
          public ICollection<UserRole> UserRoles{get; set;} = new HashSet<UserRole>();
    }
}