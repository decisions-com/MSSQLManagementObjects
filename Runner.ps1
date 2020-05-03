[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.SqlClrProvider.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.ConnectionInfo.dll")
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.Smo")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.SqlClrProvider.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.Management.Sdk.Sfc.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.Smo.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.SqlServer.SqlEnum.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\MSSQLManagementObjects.dll")
[Reflection.Assembly]::LoadFile("C:\code\MSSQLManagementObjects\MSSQLManagementObjects\bin\Debug\Microsoft.Data.Tools.Sql.BatchParser.dll")
New-Object MSSQLManagementObjects.MSSQLManagementObjects

$s = New-Object MSSQLManagementObjects.MSSQLManagementObjects
$server = $s.CreateServerConnection("localhost", "sa3", "sa")
$sdbCreate = $s.CreateDB($server, "Hello1");