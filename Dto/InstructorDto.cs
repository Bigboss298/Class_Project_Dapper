namespace CLH_Dapper.Dto
{
    public class InstructorDto
    {
        public string Id{get; set;}
        public string UserId{get; set;}
        public string Name{get; set;}
          public string Email{get; set;}
          public int Pin{get; set;}
          public string PhoneNumber{get; set;}
          public string AddressId{get; set;}
        public ICollection<StudentDto> Students = new HashSet<StudentDto>();
    }

    public class CreateInstructorRequestModel
    {
          public int Number{get; set;}
        public string Street{get; set;}
        public string City{get; set;}
        public string Name{get; set;}
          public string Email{get; set;}
          public int Pin{get; set;}
          public string PhoneNumber{get; set;}
    }
}