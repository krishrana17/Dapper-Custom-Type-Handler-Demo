
DROP TABLE [dbo].[WebSiteMaster]
GO


CREATE TABLE [dbo].[WebSiteMaster](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[SIteName] [varchar](50) NOT NULL,
	[ClientId] [int] NOT NULL,
	[SiteConfiguration] [varchar](500) NULL,
	[EntryDate] [date] NOT NULL CONSTRAINT [DF_WebSiteMaster_EntryDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_WebSiteMaster] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Insert dummy date in the table
SET IDENTITY_INSERT [dbo].[WebSiteMaster] ON 

GO
INSERT [dbo].[WebSiteMaster] ([SiteId], [SIteName], [ClientId], [SiteConfiguration], [EntryDate]) VALUES (1, N'https://bharatkeveer.gov.in/', 1, N'AspNet-Version=4.0|Server=Microsoft-IIS 7|Remote-Address=164.100.58.27|Encoding=SHA256|Domain=Public|IsHttps=Yes', CAST(N'2018-05-07' AS Date))
GO
INSERT [dbo].[WebSiteMaster] ([SiteId], [SIteName], [ClientId], [SiteConfiguration], [EntryDate]) VALUES (2, N'https://krishnrajrana.wordpress.com/', 7, N'Wordpress-Version=5.5|Server=Apache|Remote-Address=159.100.58.27|Encoding=SHA128|Domain=Private|IsHttps=Yes', CAST(N'2018-05-07' AS Date))
GO
SET IDENTITY_INSERT [dbo].[WebSiteMaster] OFF
GO
