namespace CLH_Dapper.Dto
{
    public class UserDto
    {
        public string Name{get; set;}
          public string Email{get; set;}
          public string PhoneNumber{get; set;}
          public string AddressId{get; set;}
          public ICollection<RoleDto> Roles{get; set;} = new HashSet<RoleDto>();
    }
}