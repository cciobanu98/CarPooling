CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NULL,
	[RideId] [int] NOT NULL,
	[EnrouteCityId] [int] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[RequesterId] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Cities_EnrouteCityId] FOREIGN KEY([EnrouteCityId])
REFERENCES [dbo].[Cities] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Cities_EnrouteCityId]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Rides_RideId] FOREIGN KEY([RideId])
REFERENCES [dbo].[Rides] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Rides_RideId]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users_RequesterId] FOREIGN KEY([RequesterId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO