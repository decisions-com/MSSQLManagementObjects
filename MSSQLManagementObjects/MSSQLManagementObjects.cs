
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
    public class MSSQLManagementObjectsClass
    {
        
        public ServerConnection CreateServerConnection(string servername, string username, string password)
        {
            return new ServerConnection(servername, username, password);
        }

        public bool CreateDB(string servername, string username, string password, string DBName)
        {
            try
            {
                var serverconnection = CreateServerConnection(servername, username, password);
                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);
                //Define a Database object variable by supplying the server and the database name arguments in the constructor.   
                Database db;
                db = new Microsoft.SqlServer.Management.Smo.Database(srv, DBName);
                //Create the database on the instance of SQL Server.   
                db.Create();
                serverconnection.Disconnect();
                return true;
            }
            catch (Exception)
            {
              
                return false;
                throw;
            }
        }

        public bool DeleteDB(string servername, string username, string password, string DBName)
        {
            try
            {
                var serverconnection = CreateServerConnection(servername, username, password);
                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);
                //Define a Database object variable by supplying the server and the database name arguments in the constructor.   
                Database db;
                db = new Microsoft.SqlServer.Management.Smo.Database(srv, DBName);

                db.Drop();
                serverconnection.Disconnect();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool CreateSQLUser(string servername, string username, string password, string LoginUsername, string LoginPassword, string DBName)
        {
            try
            {

                var serverconnection = CreateServerConnection(servername, username, password);
                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);

                Database db = new Database(srv, DBName);
                // Creating Logins  
                Login login = new Login(srv, LoginUsername);
                login.LoginType = LoginType.SqlLogin;
                login.Name = LoginUsername;
                login.Create(LoginPassword);
                login.Enable();
                serverconnection.Disconnect();
                return true;
               

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

       




        public bool AssignSQLUser(string servername, string username, string password, string LoginUsername, string LoginPassword, string DBName)
        {
            try
            {
                var serverconnection = CreateServerConnection(servername, username, password);

                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);
                Database db = new Database(srv, DBName);
                var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


                var login = srv.Logins.OfType<Login>().Where(x => x.Name == LoginUsername).SingleOrDefault();
               
                var user = db.Users.OfType<User>()
                       .Where(u => u.Name == LoginUsername)
                       .SingleOrDefault();
                if (user == null)
                {
                    user = new User(database, LoginUsername);
                    user.Login = login.Name;



                    user.Create();
                    
                }
                serverconnection.Disconnect();
                return true;


            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool AssignRole(string servername, string username, string password, string LoginUsername, string Role, string DBName)
        {
            try
            {

                var serverconnection = CreateServerConnection(servername, username, password);
                var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);
                Database db = new Database(srv, DBName);
                var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


                var login = srv.Logins.OfType<Login>().Where(x => x.Name == LoginUsername).SingleOrDefault();
                var user = new User(database, LoginUsername);
                user.Login = login.Name;
                user.AddToRole(Role);


                return true;

                serverconnection.Disconnect();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public bool UnAssignRole(string servername, string username, string password, string Username, string DBName)
        //{
        //    try
        //    {
        //        var serverconnection = CreateServerConnection(servername, username, password);
        //        var srv = new Microsoft.SqlServer.Management.Smo.Server(serverconnection);
        //        Database db = new Database(srv, DBName);
        //        var database = srv.Databases.OfType<Database>().Where(x => x.Name == DBName).Single();


        //        var login = srv.Logins.OfType<Login>().Where(x => x.Name == Username).SingleOrDefault();
        //        var user = new User(database, Username);
        //        user.Login = login.Name;
        //        user.Drop();

        //        return true;


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}



    }
}


// Creating Users in the database for the logins created  

