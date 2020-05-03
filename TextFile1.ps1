public Boolean CreateDB(ServerConnection serverConnection, string DBName)
        {
            int a= 1;

                Microsoft.SqlServer.Management.Smo.Server srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                //Define a Database object variable by supplying the server and the database name arguments in the constructor.   
                Database db;
                db = new Microsoft.SqlServer.Management.Smo.Database(srv, DBName);
                //Create the database on the instance of SQL Server.   
                db.Create();
                return true;
            }
          
        