USE [KataContestDb]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetailsTable_MasterTable]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetailsTable]'))
ALTER TABLE [dbo].[DetailsTable] DROP CONSTRAINT [FK_DetailsTable_MasterTable]
GO
USE [KataContestDb]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetailsTable]') AND type in (N'U'))
DROP TABLE [dbo].[DetailsTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MasterTable]') AND type in (N'U'))
DROP TABLE [dbo].[MasterTable]
