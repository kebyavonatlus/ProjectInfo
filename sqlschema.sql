/*
Run this script, database will be modified
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Employees]'
GO
CREATE TABLE [dbo].[Employees]
(
[EmployeeId] [int] NOT NULL IDENTITY(1, 1),
[EmployeeName] [nvarchar] (300) COLLATE Cyrillic_General_CI_AS NOT NULL,
[EmployeeSureName] [nvarchar] (300) COLLATE Cyrillic_General_CI_AS NOT NULL,
[EmployeePatronymic] [nvarchar] (300) COLLATE Cyrillic_General_CI_AS NULL,
[EmployeeEmail] [nvarchar] (max) COLLATE Cyrillic_General_CI_AS NULL,
[EmployeeStatus] [int] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK__Employee__7AD04F11B5BB2D81] on [dbo].[Employees]'
GO
ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [PK__Employee__7AD04F11B5BB2D81] PRIMARY KEY CLUSTERED  ([EmployeeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[ProjectEmployeeInfo]'
GO
CREATE TABLE [dbo].[ProjectEmployeeInfo]
(
[ProjectId] [int] NOT NULL,
[EmployeeId] [int] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK__ProjectE__71B7BA017EED5BBB] on [dbo].[ProjectEmployeeInfo]'
GO
ALTER TABLE [dbo].[ProjectEmployeeInfo] ADD CONSTRAINT [PK__ProjectE__71B7BA017EED5BBB] PRIMARY KEY CLUSTERED  ([ProjectId], [EmployeeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Projects]'
GO
CREATE TABLE [dbo].[Projects]
(
[ProjectId] [int] NOT NULL IDENTITY(1, 1),
[ProjectName] [nvarchar] (300) COLLATE Cyrillic_General_CI_AS NOT NULL,
[CustomerCompanyId] [int] NOT NULL,
[ExecutorCompanyId] [int] NOT NULL,
[Supervisor] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NULL,
[Comment] [nvarchar] (500) COLLATE Cyrillic_General_CI_AS NOT NULL,
[ProjectStatus] [int] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK__Projects__761ABEF05DA757FD] on [dbo].[Projects]'
GO
ALTER TABLE [dbo].[Projects] ADD CONSTRAINT [PK__Projects__761ABEF05DA757FD] PRIMARY KEY CLUSTERED  ([ProjectId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Companies]'
GO
CREATE TABLE [dbo].[Companies]
(
[CompanyId] [int] NOT NULL IDENTITY(1, 1),
[CompanyName] [nvarchar] (300) COLLATE Cyrillic_General_CI_AS NOT NULL,
[CompanyEmail] [nvarchar] (max) COLLATE Cyrillic_General_CI_AS NULL,
[CompanyStatus] [int] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK__Companie__2D971CACAF51FF1D] on [dbo].[Companies]'
GO
ALTER TABLE [dbo].[Companies] ADD CONSTRAINT [PK__Companie__2D971CACAF51FF1D] PRIMARY KEY CLUSTERED  ([CompanyId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Projects]'
GO
ALTER TABLE [dbo].[Projects] ADD CONSTRAINT [FK__Projects__Custom__3B75D760] FOREIGN KEY ([CustomerCompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
GO
ALTER TABLE [dbo].[Projects] ADD CONSTRAINT [FK__Projects__Execut__3C69FB99] FOREIGN KEY ([ExecutorCompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
GO
ALTER TABLE [dbo].[Projects] ADD CONSTRAINT [FK__Projects__Superv__3D5E1FD2] FOREIGN KEY ([Supervisor]) REFERENCES [dbo].[Employees] ([EmployeeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[ProjectEmployeeInfo]'
GO
ALTER TABLE [dbo].[ProjectEmployeeInfo] ADD CONSTRAINT [FK__ProjectEm__Emplo__412EB0B6] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[ProjectEmployeeInfo] ADD CONSTRAINT [FK__ProjectEm__Proje__403A8C7D] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ProjectId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
-- This statement writes to the SQL Server Log so SQL Monitor can show this deployment.
IF HAS_PERMS_BY_NAME(N'sys.xp_logevent', N'OBJECT', N'EXECUTE') = 1
BEGIN
    DECLARE @databaseName AS nvarchar(2048), @eventMessage AS nvarchar(2048)
    SET @databaseName = REPLACE(REPLACE(DB_NAME(), N'\', N'\\'), N'"', N'\"')
    SET @eventMessage = N'Redgate SQL Compare: { "deployment": { "description": "Redgate SQL Compare deployed to ' + @databaseName + N'", "database": "' + @databaseName + N'" }}'
    EXECUTE sys.xp_logevent 55000, @eventMessage
END
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
