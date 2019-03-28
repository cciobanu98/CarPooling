﻿CREATE TABLE [dbo].[EnrouteCity](
	[RideId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_EnrouteCity] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC,
	[RideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EnrouteCity]  WITH CHECK ADD  CONSTRAINT [FK_EnrouteCity_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EnrouteCity] CHECK CONSTRAINT [FK_EnrouteCity_Cities_CityId]
GO

ALTER TABLE [dbo].[EnrouteCity]  WITH CHECK ADD  CONSTRAINT [FK_EnrouteCity_Rides_RideId] FOREIGN KEY([RideId])
REFERENCES [dbo].[Rides] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EnrouteCity] CHECK CONSTRAINT [FK_EnrouteCity_Rides_RideId]
GO
