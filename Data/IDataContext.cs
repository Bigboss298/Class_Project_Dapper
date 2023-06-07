using System.Data;

namespace CLH_Dapper.Data
{
    public interface IDataContext
    {
          IDbConnection Connection();
          string CreateSchema();
          void AddressTable();
          void UserTable();
          void StudentTable();
          void RoleTable();
          void InstructorTable();
          void UserRoleTable();
     
    }
}