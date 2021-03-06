USE [KataContestDb]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MasterTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MasterTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MasterTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetailsTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DetailsTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMasterTable] [int] NOT NULL,
	[Details] [varchar](max) NULL,
 CONSTRAINT [PK_DetailsTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetailsTable_MasterTable]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetailsTable]'))
ALTER TABLE [dbo].[DetailsTable]  WITH CHECK ADD  CONSTRAINT [FK_DetailsTable_MasterTable] FOREIGN KEY([IdMasterTable])
REFERENCES [dbo].[MasterTable] ([Id])
GO
ALTER TABLE [dbo].[DetailsTable] CHECK CONSTRAINT [FK_DetailsTable_MasterTable]
