using CLH_Dapper.Dto;
using CLH_Dapper.Models;
using CLH_Dapper.Repository;

namespace CLH_Dapper.Services
{
    public class InstructorService
    {
        public static InstructorRepository _instRepo;
        public static AddressRepository _adRepo;
        public static UserRepository _userRepo;
        public static RoleRepository _roleRepo;

          public InstructorService(InstructorRepository instRepo, AddressRepository adRepo,UserRepository userRepo,RoleRepository roleRepo)
          {
               _instRepo = instRepo;
               _adRepo = adRepo;
               _userRepo = userRepo;
               _roleRepo = roleRepo;

          }

          public InstructorDto Create(CreateInstructorRequestModel model)
          {
               var address = new Address
               {
                    Number = model.Number,
                    Street = model.Street,
                    City = model.City,
               };

               _adRepo.Create(address);

               var user = new User
               {
                    AddressId = address.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Pin = model.Pin,
                    PhoneNumber = model.PhoneNumber,
               };
               _userRepo.Create(user);

               var role = _roleRepo.GetByName("Instructor");

               var userRole = new UserRole
               {
                    RoleId = role.Id,
                    UserId = user.Id,
               };

               user.UserRoles.Add(userRole);

               var instructor = new Instructor
               {
                    UserId = user.Id,
               };

               
               return new InstructorDto
               {

               };




          }
     }
}