USE master ;
GO
IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'PortalRepRap')
BEGIN
	CREATE DATABASE PortalRepRap
	ON 
	( NAME = PortalRepRap_dat,
		FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\portalreprapdat.mdf',
		SIZE = 10,
		MAXSIZE = 50,
		FILEGROWTH = 5 )
	LOG ON
	( NAME = Sales_log,
		FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\portalrepraplog.ldf',
		SIZE = 5MB,
		MAXSIZE = 25MB,
		FILEGROWTH = 5MB ) ;
END
GO