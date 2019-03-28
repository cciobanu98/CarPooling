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
PRINT N'Dropping [dbo].[EnrouteCity].[IX_EnrouteCity_RideId]...';


GO
DROP INDEX [IX_EnrouteCity_RideId]
    ON [dbo].[EnrouteCity];


GO
PRINT N'Dropping [dbo].[MembersCars].[IX_MembersCars_UserId]...';


GO
DROP INDEX [IX_MembersCars_UserId]
    ON [dbo].[MembersCars];


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
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190328114007_Initial', N'2.2.3-servicing-35854')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190328115851_v2', N'2.2.3-servicing-35854')
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (1, N'Audi', N'Red', 4, N'123')
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (2, N'BMW', N'Black', 4, N'432')
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (3, N'Ford', N'Blue', 3, N'243')
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (4, N'Reno', N'Red', 6, N'416')
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (5, N'Audi', N'Red', 4, N'689')
GO
INSERT [dbo].[Cars] ([Id], [Model], [Color], [Seats], [CarNumbers]) VALUES (6, N'Dacia', N'Black', 4, N'246')
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (1, N'Chisinau', N'Chisinau', N'Moldova')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (2, N'Ungheni', N'Ungheni', N'Moldova')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (3, N'Cornesti', N'Ungheni', N'Moldova')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (4, N'Strasani', N'Strasani', N'Moldova')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (5, N'Iasi', N'Iasi', N'Romania')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (7, N'Bucuresti', N'Bucuresti', N'Romania')
GO
INSERT [dbo].[Cities] ([Id], [CityName], [State], [Country]) VALUES (8, N'Timisoara', N'Timisoara', N'Romania')
GO
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
INSERT [dbo].[EnrouteCity] ([RideId], [CityId]) VALUES (10, 1)
GO
INSERT [dbo].[EnrouteCity] ([RideId], [CityId]) VALUES (10, 2)
GO
INSERT [dbo].[EnrouteCity] ([RideId], [CityId]) VALUES (10, 3)
GO
SET IDENTITY_INSERT [dbo].[Preferences] ON 
GO
INSERT [dbo].[Preferences] ([Id], [UserId], [Description], [Discriminator], [Talkative], [Allow_smoke], [Allow_pet], [Volume]) VALUES (3, 4, N'Test', N'ChatPreferences', 2, NULL, 0, NULL)
GO
INSERT [dbo].[Preferences] ([Id], [UserId], [Description], [Discriminator], [Talkative], [Allow_smoke], [Allow_pet], [Volume]) VALUES (5, 6, N'Tesyt', N'MusicPreferences', NULL, NULL, NULL, 6)
GO
INSERT [dbo].[Preferences] ([Id], [UserId], [Description], [Discriminator], [Talkative], [Allow_smoke], [Allow_pet], [Volume]) VALUES (13, 9, N'Tefggh', N'GeneralPreferences', NULL, 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Preferences] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 
GO
INSERT [dbo].[Requests] ([Id], [Status], [RideId], [EnrouteCityId], [CreatedDateTime], [RequesterId]) VALUES (1, NULL, 10, 1, CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), 4)
GO
INSERT [dbo].[Requests] ([Id], [Status], [RideId], [EnrouteCityId], [CreatedDateTime], [RequesterId]) VALUES (4, NULL, 27, 4, CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), 9)
GO
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
SET IDENTITY_INSERT [dbo].[Rides] ON 
GO
INSERT [dbo].[Rides] ([Id], [CarId], [TravelStartDateTime], [CreatedDateTime], [SourceCityId], [DestinationCityId], [Price]) VALUES (4, 1, CAST(N'2017-07-25T00:00:00.0000000' AS DateTime2), CAST(N'2017-12-25T00:00:00.0000000' AS DateTime2), 1, 2, 20)
GO
INSERT [dbo].[Rides] ([Id], [CarId], [TravelStartDateTime], [CreatedDateTime], [SourceCityId], [DestinationCityId], [Price]) VALUES (10, 1, CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), 2, 3, 25)
GO
INSERT [dbo].[Rides] ([Id], [CarId], [TravelStartDateTime], [CreatedDateTime], [SourceCityId], [DestinationCityId], [Price]) VALUES (17, 1, CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), 1, 2, 20)
GO
INSERT [dbo].[Rides] ([Id], [CarId], [TravelStartDateTime], [CreatedDateTime], [SourceCityId], [DestinationCityId], [Price]) VALUES (22, 3, CAST(N'2018-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), 4, 1, 27)
GO
INSERT [dbo].[Rides] ([Id], [CarId], [TravelStartDateTime], [CreatedDateTime], [SourceCityId], [DestinationCityId], [Price]) VALUES (27, 2, CAST(N'2018-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-09-01T00:00:00.0000000' AS DateTime2), 1, 4, 30)
GO
SET IDENTITY_INSERT [dbo].[Rides] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [FirstName], [LastName], [Password], [Date_created], [Phone], [Gender], [Age]) VALUES (4, N'Cris98', N'cristian.ciobanu1998@gmail.com', N'Ciobanu', N'Cristian', N'12345', CAST(N'1998-07-25T00:00:00.0000000' AS DateTime2), N'060232975', N'M', 20)
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [FirstName], [LastName], [Password], [Date_created], [Phone], [Gender], [Age]) VALUES (6, N'Angela99', N'angela.beregoi@gmail.com', N'Beregoi', N'Angela', N'12345', CAST(N'1998-07-25T00:00:00.0000000' AS DateTime2), N'060232975', N'F', 20)
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [FirstName], [LastName], [Password], [Date_created], [Phone], [Gender], [Age]) VALUES (8, N'Oleg98', N'baranov.oleg@gmail.com', N'Baranov', N'Oleg', N'12345', CAST(N'1998-10-01T00:00:00.0000000' AS DateTime2), N'254125447', N'M', 20)
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [FirstName], [LastName], [Password], [Date_created], [Phone], [Gender], [Age]) VALUES (9, N'slavic96', N'slavic.mocanu@gmail.com', N'Mocanu', N'Veceslav', N'12345', CAST(N'1996-10-01T00:00:00.0000000' AS DateTime2), N'213141561', N'M', 22)
GO
INSERT [dbo].[Users] ([Id], [Username], [Email], [FirstName], [LastName], [Password], [Date_created], [Phone], [Gender], [Age]) VALUES (10, N'vitali111', N'miron.vitalie', N'Miron', N'Vitalie', N'12345', CAST(N'1998-10-01T00:00:00.0000000' AS DateTime2), N'145454441', N'M', 21)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

GO
PRINT N'Update complete.';


GO
