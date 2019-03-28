CREATE TABLE [dbo].[Table1]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](32) NOT NULL,
	[Email] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](32) NOT NULL,
	[LastName] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Date_created] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](64) NULL,
	[Gender] [nvarchar](1) NULL,
	[Age] [int] NULL)
