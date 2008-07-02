SET IDENTITY_INSERT [dbo].[MasterTable] ON
GO

INSERT INTO [dbo].[MasterTable] ([Id], [Name])
VALUES 
  (1, N'Record_1')
GO

INSERT INTO [dbo].[MasterTable] ([Id], [Name])
VALUES 
  (2, N'Record_2')
GO

INSERT INTO [dbo].[MasterTable] ([Id], [Name])
VALUES 
  (3, N'Record_3')
GO

INSERT INTO [dbo].[MasterTable] ([Id], [Name])
VALUES 
  (4, N'Record_4')
GO

SET IDENTITY_INSERT [dbo].[MasterTable] OFF
GO

SET IDENTITY_INSERT [dbo].[DetailsTable] ON
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (1, 1, N'Details for Record_1')
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (2, 2, N'Details for Record_2')
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (3, 3, N'Details for Record_3')
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (4, 4, N'Details for Record_4')
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (5, 4, N'Details 2 for Record_4')
GO

INSERT INTO [dbo].[DetailsTable] ([Id], [IdMasterTable], [Details])
VALUES 
  (6, 4, N'Details 3 for Record_4')
GO

SET IDENTITY_INSERT [dbo].[DetailsTable] OFF
GO



