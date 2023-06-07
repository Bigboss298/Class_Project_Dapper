using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace CLH_Dapper.Data
{
    public class DataContext : IDataContext
    {
        string connectionString = "Server = localhost; user = root; database = asd; password = B!gb055";

        public IDbConnection Connection()
        {
          return new MySqlConnection(connectionString);
        }

        public string CreateSchema()
        {
          var conn = "Server = localhost; user = root; password = B!gb055";
          var qry = "create schema if not exists asd";
          using(var connection = new MySqlConnection(conn))
          {
               var row = connection.Execute(qry);
               if(row > 0)
               {
                    return "successful";
               }
               return "not created";
          }
        }

        public void AddressTable()
        {
          var qry = "create table if not exists address (Id varchar(225), Number int, Street varchar(225), City varchar(225),IsDeleted tinyint, primary key(Id))";
          using(var connection = Connection())
          {
               connection.Query(qry);
          }

        }

        public void UserTable()
        {
          var qry = "create table if not exists user (Id varchar(225), Name varchar(20), Email varchar(20), Pin int, PhoneNumber varchar(16), AddressId varchar(20), IsDeleted tinyint)";
          using(var connection = Connection())
          {
               connection.Query(qry);
          }

        }

        public void StudentTable()
        {
               var qry = "create table if not exists student(Id varchar(20), UserId varchar(20), InstructorId varchar(20), Batch int)";
               using(var connect = Connection())
               {
                    connect.Query(qry);
               }
        }

        public void RoleTable()
        {
               var qry = "create table if not exists role(Id varchar(20), Name varchar(20), Description varchar(30), IsDeleted tinyint)";
               using(var connect = Connection())
               {
                    connect.Query(qry);
               }
        }

        public void InstructorTable()
        {
               var qry = "create table if not exists instructor(Id varchar(20), UserId varchar(20), IsDeleted tinyint)";
               using(var connect = Connection())
               {
                    connect.Query(qry);
               }
        }

        public void UserRoleTable()
        {
               var qry = "create table if not exists userrole(Id varchar(20), UserId varchar(29), RoleId varchar(20), IsDeleted tinyint)";
               using(var connect = Connection())
               {
                    connect.Query(qry);
               }
        }
    }
}