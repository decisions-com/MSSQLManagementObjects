
using DecisionsFramework.Design.Flow;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLManagementObjects
{

    [AutoRegisterMethodsOnClass(true, "MSSQL")]
    public class MSSQLManagementObjects
    {
        
        public ServerConnection CreateServerConnection(string servername, string username, string password)
        {
            return new ServerConnection(servername, username, password);
        }

        public Boolean CreateDB(ServerConnection serverConnection, string DBName)
        {
            try
            {

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                //Define a Database object variable by supplying the server and the database name arguments in the constructor.   
                Database db;
                db = new Microsoft.SqlServer.Management.Smo.Database(srv, DBName);
                //Create the database on the instance of SQL Server.   
                db.Create();
                return true;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                Console.WriteLine(ex2.InnerException);
                return false;
                throw;
            }
        }

        public Boolean DeleteDB(ServerConnection serverConnection, string DBName)
        {
            try
            {

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                //Define a Database object variable by supplying the server and the database name arguments in the constructor.   
                Database db;
                db = new Microsoft.SqlServer.Management.Smo.Database(srv, DBName);

                db.Drop();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool CreateSQLUser(ServerConnection serverConnection, string Username, string Password, string DBName)
        {
            try
            {
                

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);

                Database db = new Database(srv, DBName);
                // Creating Logins  
                Login login = new Login(srv, Username );
                login.LoginType = LoginType.SqlLogin;
                login.Name = Username;
                login.Create(Password);
                login.Enable();
                return true;
               

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

       




        public bool AssignSQLUser(ServerConnection serverConnection, string Username, string Password, string DBName)
        {
            try
            {
               

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                Database db = new Database(srv, DBName);
                var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


                var login = srv.Logins.OfType<Login>().Where(x => x.Name == Username).SingleOrDefault();
               
                var user = db.Users.OfType<User>()
                       .Where(u => u.Name == Username)
                       .SingleOrDefault();
                if (user == null)
                {
                    user = new User(database, Username);
                    user.Login = login.Name;



                    user.Create();
                    
                }
                return true;


            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool AssignRole(ServerConnection serverConnection, string Username, string Role, string DBName)
        {
            try
            {
                int f = 1;

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                Database db = new Database(srv, DBName);
                var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


                var login = srv.Logins.OfType<Login>().Where(x => x.Name == Username).SingleOrDefault();
                var user = new User(database, Username);
                user.Login = login.Name;
                user.AddToRole(Role);


                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UnAssignRole(ServerConnection serverConnection, string Username, string Role, string DBName)
        {
            try
            {
                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                Database db = new Database(srv, DBName);
                var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


                var login = srv.Logins.OfType<Login>().Where(x => x.Name == Username).SingleOrDefault();
                var user = new User(database, Username);
                user.Login = login.Name;
                user.Drop();

                return true;


            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}


// Creating Users in the database for the logins created  

