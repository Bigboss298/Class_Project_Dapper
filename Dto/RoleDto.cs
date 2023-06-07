namespace CLH_Dapper.Dto
{
    public class RoleDto
    {
          public string Id{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public ICollection<UserDto> Users{get; set;} = new HashSet<UserDto>();
    }

    public class CreateRoleRequestModel
    {
      public string Name{get; set;}
        public string Description{get; set;}
    }
}