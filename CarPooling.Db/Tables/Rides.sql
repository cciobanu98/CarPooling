CREATE TABLE [dbo].[Rides](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[TravelStartDateTime] [datetime2](7) NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[SourceCityId] [int] NULL,
	[DestinationCityId] [int] NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Rides] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [FK_Rides_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO

ALTER TABLE [dbo].[Rides] CHECK CONSTRAINT [FK_Rides_Cars_CarId]
GO

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [FK_Rides_Cities_DestinationCityId] FOREIGN KEY([DestinationCityId])
REFERENCES [dbo].[Cities] ([Id])
GO

ALTER TABLE [dbo].[Rides] CHECK CONSTRAINT [FK_Rides_Cities_DestinationCityId]
GO

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [FK_Rides_Cities_SourceCityId] FOREIGN KEY([SourceCityId])
REFERENCES [dbo].[Cities] ([Id])
GO

ALTER TABLE [dbo].[Rides] CHECK CONSTRAINT [FK_Rides_Cities_SourceCityId]
GO
