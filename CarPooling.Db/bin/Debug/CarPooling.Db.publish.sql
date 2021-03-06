﻿/*
Deployment script for CarPoolingEF

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CarPoolingEF"
:setvar DefaultFilePrefix "CarPoolingEF"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
/*
The table [dbo].[MembersCars] is being dropped and re-created since all non-computed columns within the table have been redefined.
*/

IF EXISTS (select top 1 1 from [dbo].[MembersCars])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[EnrouteCity].[IX_EnrouteCity_RideId]...';


GO
DROP INDEX [IX_EnrouteCity_RideId]
    ON [dbo].[EnrouteCity];


GO
PRINT N'Dropping [dbo].[Preferences].[IX_Preferences_UserId]...';


GO
DROP INDEX [IX_Preferences_UserId]
    ON [dbo].[Preferences];


GO
PRINT N'Dropping [dbo].[Requests].[IX_Requests_EnrouteCityId]...';


GO
DROP INDEX [IX_Requests_EnrouteCityId]
    ON [dbo].[Requests];


GO
PRINT N'Dropping [dbo].[Requests].[IX_Requests_RequesterId]...';


GO
DROP INDEX [IX_Requests_RequesterId]
    ON [dbo].[Requests];


GO
PRINT N'Dropping [dbo].[Requests].[IX_Requests_RideId]...';


GO
DROP INDEX [IX_Requests_RideId]
    ON [dbo].[Requests];


GO
PRINT N'Dropping [dbo].[Rides].[IX_Rides_CarId]...';


GO
DROP INDEX [IX_Rides_CarId]
    ON [dbo].[Rides];


GO
PRINT N'Dropping [dbo].[Rides].[IX_Rides_DestinationCityId]...';


GO
DROP INDEX [IX_Rides_DestinationCityId]
    ON [dbo].[Rides];


GO
PRINT N'Dropping [dbo].[Rides].[IX_Rides_SourceCityId]...';


GO
DROP INDEX [IX_Rides_SourceCityId]
    ON [dbo].[Rides];


GO
PRINT N'Dropping [dbo].[FK_MembersCars_Cars_CarId]...';


GO
ALTER TABLE [dbo].[MembersCars] DROP CONSTRAINT [FK_MembersCars_Cars_CarId];


GO
PRINT N'Dropping [dbo].[FK_MembersCars_Users_UserId]...';


GO
ALTER TABLE [dbo].[MembersCars] DROP CONSTRAINT [FK_MembersCars_Users_UserId];


GO
PRINT N'Dropping [dbo].[MembersCars].[IX_MembersCars_UserId]...';


GO
DROP INDEX [IX_MembersCars_UserId]
    ON [dbo].[MembersCars];


GO
PRINT N'Dropping [dbo].[PK_MembersCars]...';


GO
ALTER TABLE [dbo].[MembersCars] DROP CONSTRAINT [PK_MembersCars];


GO
PRINT N'Dropping [dbo].[MembersCars]...';


GO
DROP TABLE [dbo].[MembersCars];


GO
PRINT N'Creating [dbo].[MembersCars]...';


GO
CREATE TABLE [dbo].[MembersCars] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Update complete.';


GO
