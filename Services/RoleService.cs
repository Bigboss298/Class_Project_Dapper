using CLH_Dapper.Dto;
using CLH_Dapper.Models;
using CLH_Dapper.Repository;

namespace CLH_Dapper.Services
{
    public class RoleService
    {
        public static RoleRepository _roleRepo;
        
        public RoleService(RoleRepository roleRepo)
        {
          _roleRepo = roleRepo;
        }

        public RoleDto Create(CreateRoleRequestModel model)
        {
          var role = new Role
          {
               Name = model.Name,
               Description = model.Description,
               
          };

          _roleRepo.Create(role);

          return new RoleDto
          {
               Id = role.Id,
               Name = role.Name,
               Description = role.Description,
               
          };
        }
    }
}