CREATE TABLE [dbo].[Preferences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Talkative] [int] NULL,
	[Allow_smoke] [bit] NULL,
	[Allow_pet] [bit] NULL,
	[Volume] [int] NULL,
 CONSTRAINT [PK_Preferences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Preferences]  WITH CHECK ADD  CONSTRAINT [FK_Preferences_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Preferences] CHECK CONSTRAINT [FK_Preferences_Users_UserId]
GO