USE [master]
GO
/****** Object:  Database [TimeSheetDB]    Script Date: 06-05-19 09:48:09 ******/
CREATE DATABASE [TimeSheetDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TimeSheetDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TimeSheetDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TimeSheetDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TimeSheetDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TimeSheetDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TimeSheetDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TimeSheetDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TimeSheetDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TimeSheetDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TimeSheetDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TimeSheetDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TimeSheetDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TimeSheetDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TimeSheetDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TimeSheetDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TimeSheetDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TimeSheetDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TimeSheetDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TimeSheetDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TimeSheetDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TimeSheetDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TimeSheetDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TimeSheetDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TimeSheetDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TimeSheetDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TimeSheetDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TimeSheetDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TimeSheetDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TimeSheetDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TimeSheetDB] SET  MULTI_USER 
GO
ALTER DATABASE [TimeSheetDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TimeSheetDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TimeSheetDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TimeSheetDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TimeSheetDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TimeSheetDB', N'ON'
GO
ALTER DATABASE [TimeSheetDB] SET QUERY_STORE = OFF
GO
USE [TimeSheetDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TimeSheetDB]
GO
/****** Object:  UserDefinedFunction [dbo].[HtmlDecode]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[HtmlDecode]
( @S VARCHAR(max) )

RETURNS VARCHAR(max)

AS

BEGIN

   DECLARE @R VARCHAR(max);



  
  
Select @S = replace(@S,MapFrom,MapTo)
 From  ( values
        ('&quot;','"'),('&amp;','&'),('&apos;',''''),('&lt;','<'),('&gt;','>'),('&nbsp;',' '),('&iexcl;','¡'),
        ('&cent;','¢'),('&pound;','£'),('&curren;','¤'),('&yen;','¥'),('&brvbar;','¦'),('&sect;','§'),('&uml;','¨'),
        ('&copy;','©'),('&ordf;','ª'),('&laquo;','«'),('&not;','¬'),('&reg;','®'),('&macr;','¯'),('&deg;','°'),
        ('&plusmn;','±'),('&sup2;','²'),('&sup3;','³'),('&acute;','´'),('&micro;','µ'),('&para;','¶'),('&middot;','·'),
        ('&cedil;','¸'),('&sup1;','¹'),('&ordm;','º'),('&raquo;','»'),('&frac14;','¼'),('&frac12;','½'),('&frac34;','¾'),
        ('&iquest;','¿'),('&Agrave;','À'),('&Aacute;','Á'),('&Acirc;','Â'),('&Atilde;','Ã'),('&Auml;','Ä'),('&Aring;','Å'),
        ('&AElig;','Æ'),('&Ccedil;','Ç'),('&Egrave;','È'),('&Eacute;','É'),('&Ecirc;','Ê'),('&Euml;','Ë'),('&Igrave;','Ì'),
        ('&Iacute;','Í'),('&Icirc;','Î'),('&Iuml;','Ï'),('&ETH;','Ð'),('&Ntilde;','Ñ'),('&Ograve;','Ò'),('&Oacute;','Ó'),
        ('&Ocirc;','Ô'),('&Otilde;','Õ'),('&Ouml;','Ö'),('&times;','×'),('&Oslash;','Ø'),('&Ugrave;','Ù'),('&Uacute;','Ú'),
        ('&Ucirc;','Û'),('&Uuml;','Ü'),('&Yacute;','Ý'),('&THORN;','Þ'),('&szlig;','ß'),('&agrave;','à'),('&aacute;','á'),
        ('&;','â'),('&atilde;','ã'),('&auml;','ä'),('&aring;','å'),('&aelig;','æ'),('&ccedil;','ç'),('&egrave;','è'),
        ('&eacute;','é'),('&ecirc;','ê'),('&euml;','ë'),('&igrave;','ì'),('&iacute;','í'),('&icirc;','î'),('&iuml;','ï'),
        ('&eth;','ð'),('&ntilde;','ñ'),('&ograve;','ò'),('&oacute;','ó'),('&ocirc;','ô'),('&otilde;','õ'),('&ouml;','ö'),
        ('&divide;','÷'),('&oslash;','ø'),('&ugrave;','ù'),('&uacute;','ú'),('&ucirc;','û'),('&uuml;','ü'),('&yacute;','ý'),
        ('&thorn;','þ'),('&yuml;','ÿ'),('&amp;','&'),('&deg;','°'),('&infin;','∞'),('&permil;','‰'),('&sdot;','⋅'),
        ('&plusmn;','±'),('&dagger;','†'),('&mdash;','—'),('&not;','¬'),('&micro;','µ'),('&euro;','€'),('&pound;','£'),
        ('&yen;','¥'),('&cent;','¢'),('&euro;','€'),('&pound;','£'),('&yen;','¥'),('&cent;','¢')
       ) A (MapFrom,MapTo)

	   SET @R = (SELECT @S)
   RETURN @R;

END;

--SELECT ReturnSite(8);
GO
/****** Object:  Table [dbo].[TaskType]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskType](
	[TaskTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskTypeName] [text] NOT NULL,
	[TaskTypeDescription] [text] NOT NULL,
	[TaskTypeTextColor] [varchar](20) NULL,
 CONSTRAINT [PK_TaskType] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VTaskType]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VTaskType]
AS
SELECT        TaskTypeId, TaskTypeName, TaskTypeDescription, TaskTypeTextColor
FROM            dbo.TaskType
GO
/****** Object:  Table [dbo].[TaskPriority]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskPriority](
	[TaskPriorityId] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskPriorityName] [text] NOT NULL,
	[TaskPriorityDescription] [text] NOT NULL,
	[TaskPriorityTextColor] [nchar](10) NULL,
	[TaskPriorityListOrder] [int] NULL,
 CONSTRAINT [PK_TaskPriority] PRIMARY KEY CLUSTERED 
(
	[TaskPriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VTaskPriority]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VTaskPriority]
AS
SELECT        TaskPriorityId, TaskPriorityName, TaskPriorityDescription, TaskPriorityDescriptionTextColor
FROM            dbo.TaskPriority
GO
/****** Object:  Table [dbo].[ToDo]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDo](
	[ToDoID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectTaskUserID] [bigint] NOT NULL,
	[ToDoName] [varchar](max) NOT NULL,
	[Description] [text] NULL,
	[IsFinished] [bit] NULL,
	[DateDeFinition] [datetime] NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_ToDo] PRIMARY KEY CLUSTERED 
(
	[ToDoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VToDo]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VToDo]
AS
SELECT        ToDoID, ProjectTaskUserID, ToDoName, Description, IsFinished, DateDeFinition, Priority
FROM            dbo.ToDo
GO
/****** Object:  Table [dbo].[Project]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[EstimateDurationProject] [real] NULL,
	[DurationProject] [real] NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[ModificationDate] [datetime] NULL,
	[Active] [bit] NULL,
	[CustomerName] [nvarchar](100) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Progression] [float] NULL,
	[Status] [nchar](10) NULL,
	[KeyWord] [nchar](20) NULL,
	[LastActionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTaskUser]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTaskUser](
	[ProjectTaskUserID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectID] [bigint] NULL,
	[TaskID] [bigint] NULL,
	[StartTask] [datetime] NULL,
	[EndTask] [datetime] NULL,
	[ExecutionTime] [real] NULL,
	[MapTaskStateID] [bigint] NULL,
	[UserName] [nvarchar](100) NULL,
	[BtPlay] [bit] NULL,
	[BtPause] [bit] NULL,
	[BtStop] [bit] NULL,
	[Exclude] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectTaskUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VProjectUsualTime]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VProjectUsualTime]
AS
SELECT        dbo.ProjectTaskUser.ExecutionTime, dbo.Project.ProjectID, dbo.Project.ProjectName, dbo.ProjectTaskUser.ProjectTaskUserID, dbo.ProjectTaskUser.StartTask, dbo.ProjectTaskUser.EndTask, 
                         dbo.ProjectTaskUser.MapTaskStateID
FROM            dbo.Project INNER JOIN
                         dbo.ProjectTaskUser ON dbo.Project.ProjectID = dbo.ProjectTaskUser.ProjectID

GO
/****** Object:  View [dbo].[VProject]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VProject]
AS
SELECT        ProjectID, ProjectName, Description, EstimateDurationProject, DurationProject, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Active, CustomerName, StartDate, EndDate, Progression
FROM            dbo.Project

GO
/****** Object:  Table [dbo].[Task]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TaskName] [nvarchar](100) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[ModificationDate] [datetime] NULL,
	[Active] [bit] NULL,
	[Description] [text] NULL,
	[TaskTypeId] [bigint] NULL,
	[TaskPriorityId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskUserTime]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskUserTime](
	[TaskUserTimeID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectTaskUserID] [bigint] NULL,
	[MapTaskStateName] [nvarchar](20) NULL,
	[startDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ExecutionTime] [real] NULL,
	[Active] [bit] NULL,
	[ProjectTaskUserProgression] [float] NULL,
	[ProjectProgression] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskUserTimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VTaskTime]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VTaskTime]
AS
SELECT        dbo.TaskUserTime.TaskUserTimeID, dbo.TaskUserTime.startDate, dbo.TaskUserTime.EndDate, dbo.Project.ProjectName, dbo.Task.TaskName, dbo.ProjectTaskUser.UserName, dbo.Project.ProjectID, 
                         dbo.TaskUserTime.ProjectTaskUserID, dbo.TaskUserTime.ProjectTaskUserProgression, dbo.TaskUserTime.ProjectProgression, dbo.TaskUserTime.ExecutionTime
FROM            dbo.TaskUserTime INNER JOIN
                         dbo.ProjectTaskUser ON dbo.TaskUserTime.ProjectTaskUserID = dbo.ProjectTaskUser.ProjectTaskUserID INNER JOIN
                         dbo.Project ON dbo.ProjectTaskUser.ProjectID = dbo.Project.ProjectID INNER JOIN
                         dbo.Task ON dbo.ProjectTaskUser.TaskID = dbo.Task.TaskID

GO
/****** Object:  Table [dbo].[ProjectTask]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTask](
	[ProjectTaskID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectID] [bigint] NULL,
	[TaskID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VProjectTask]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VProjectTask]
AS
SELECT        dbo.ProjectTask.ProjectID, dbo.ProjectTask.TaskID, dbo.Project.ProjectName, dbo.Task.TaskName, dbo.Task.CreatedBy, dbo.Task.CreationDate, dbo.Task.Active,TaskType.TaskTypeName,TaskPriority.TaskPriorityName,TaskType.TaskTypeDescription,TaskPriority.TaskPriorityDescription
FROM            dbo.Project INNER JOIN
                         dbo.ProjectTask ON dbo.Project.ProjectID = dbo.ProjectTask.ProjectID INNER JOIN
                         dbo.Task ON dbo.ProjectTask.TaskID = dbo.Task.TaskID LEFT JOIN
						 dbo.TaskType AS TaskType ON dbo.Task.TaskTypeId = TaskType.TaskTypeId LEFT JOIN
						 dbo.TaskPriority AS TaskPriority ON dbo.Task.TaskPriorityId = TaskPriority.TaskPriorityId
GO
/****** Object:  Table [dbo].[MapTaskState]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MapTaskState](
	[MapTaskStateID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[MapTaskStateName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MapTaskStateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VProjectTaskUser]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VProjectTaskUser]
AS
SELECT        dbo.ProjectTaskUser.ProjectID, dbo.ProjectTaskUser.TaskID, dbo.Project.ProjectName, dbo.Task.TaskName, dbo.Task.Description, dbo.MapTaskState.MapTaskStateName, dbo.ProjectTaskUser.StartTask, 
                         dbo.ProjectTaskUser.EndTask, dbo.ProjectTaskUser.ExecutionTime, dbo.ProjectTaskUser.UserName, dbo.ProjectTaskUser.ProjectTaskUserID, dbo.MapTaskState.MapTaskStateID, dbo.ProjectTaskUser.BtPlay, 
                         dbo.ProjectTaskUser.BtPause, dbo.ProjectTaskUser.BtStop, dbo.ProjectTaskUser.Exclude, dbo.Project.EstimateDurationProject, dbo.Project.DurationProject, LastStart.LastDate, ToDo.NemberOfFinishedToDo, ToDo.TotalToDo, 
                         CASE WHEN COALESCE (ToDo.NemberOfFinishedToDo, 0) = 0 AND COALESCE (ToDo.TotalToDo, 0) = 0 AND dbo.MapTaskState.MapTaskStateName = 'En pause' THEN 0 WHEN COALESCE (ToDo.NemberOfFinishedToDo, 0) 
                         = 0 AND COALESCE (ToDo.TotalToDo, 0) = 0 AND dbo.MapTaskState.MapTaskStateName = 'Terminé' THEN 1 ELSE ROUND(CAST(ToDo.NemberOfFinishedToDo AS float) / CAST(ToDo.TotalToDo AS float), 2) END AS Progression, 
                         TaskType.TaskTypeName, TaskPriority.TaskPriorityName, TaskType.TaskTypeDescription, TaskPriority.TaskPriorityDescription, TaskType.TaskTypeTextColor, TaskPriority.TaskPriorityTextColor, 
                         TaskPriority.TaskPriorityListOrder, dbo.Task.CreationDate AS TaskCreationDate
FROM            dbo.MapTaskState INNER JOIN
                         dbo.ProjectTaskUser ON dbo.MapTaskState.MapTaskStateID = dbo.ProjectTaskUser.MapTaskStateID INNER JOIN
                         dbo.Project ON dbo.ProjectTaskUser.ProjectID = dbo.Project.ProjectID INNER JOIN
                         dbo.Task ON dbo.ProjectTaskUser.TaskID = dbo.Task.TaskID LEFT OUTER JOIN
                             (SELECT        ProjectTaskUserID, MAX(startDate) AS LastDate
                               FROM            dbo.TaskUserTime
                               GROUP BY ProjectTaskUserID) AS LastStart ON LastStart.ProjectTaskUserID = dbo.ProjectTaskUser.ProjectTaskUserID LEFT OUTER JOIN
                             (SELECT        ProjectTaskUserID, COUNT(IsFinished) AS TotalToDo, COUNT(NULLIF (IsFinished, 0)) AS NemberOfFinishedToDo
                               FROM            dbo.ToDo AS ToDo_1
                               GROUP BY ProjectTaskUserID) AS ToDo ON ToDo.ProjectTaskUserID = dbo.ProjectTaskUser.ProjectTaskUserID LEFT OUTER JOIN
                         dbo.TaskType AS TaskType ON dbo.Task.TaskTypeId = TaskType.TaskTypeId LEFT OUTER JOIN
                         dbo.TaskPriority AS TaskPriority ON dbo.Task.TaskPriorityId = TaskPriority.TaskPriorityId
GO
/****** Object:  Table [dbo].[ProjectHistory]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectHistory](
	[ProjectHistoryID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectID] [bigint] NOT NULL,
	[LastTime] [real] NULL,
	[NewTime] [real] NULL,
	[ActionDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VProjectHistory]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VProjectHistory]
AS
SELECT        dbo.Project.ProjectID, dbo.Project.ProjectName, dbo.ProjectHistory.LastTime, dbo.ProjectHistory.ProjectHistoryID, dbo.ProjectHistory.ActionDate, dbo.ProjectHistory.CreatedBy, dbo.Project.ModifiedBy
FROM            dbo.Project INNER JOIN
                         dbo.ProjectHistory ON dbo.Project.ProjectID = dbo.ProjectHistory.ProjectID


GO
/****** Object:  View [dbo].[VTask]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VTask]
AS
SELECT        dbo.Task.TaskID, dbo.Task.TaskName, dbo.Task.CreatedBy, dbo.Task.CreationDate, dbo.Task.ModifiedBy, dbo.Task.ModificationDate, dbo.Task.Active, dbo.Task.Description, TaskType.TaskTypeName, 
                         TaskType.TaskTypeDescription, TaskPriority.TaskPriorityName, TaskPriority.TaskPriorityDescription, dbo.Task.TaskTypeId, dbo.Task.TaskPriorityId
FROM            dbo.Task LEFT OUTER JOIN
                         dbo.TaskType AS TaskType ON dbo.Task.TaskTypeId = TaskType.TaskTypeId LEFT OUTER JOIN
                         dbo.TaskPriority AS TaskPriority ON dbo.Task.TaskPriorityId = TaskPriority.TaskPriorityId
GO
/****** Object:  Table [dbo].[Document]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectID] [bigint] NOT NULL,
	[ProjectTaskUserID] [bigint] NULL,
	[Title] [text] NOT NULL,
	[Path] [nchar](500) NOT NULL,
	[Type] [nchar](20) NOT NULL,
	[AddBy] [nchar](50) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[EditedBy] [nchar](50) NULL,
	[ModifcationDate] [datetime] NULL,
	[IsMainDocument] [bit] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskUserTimeHistory]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskUserTimeHistory](
	[TaskUserTimeHistoryID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TaskUserTimeID] [bigint] NOT NULL,
	[startDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskUserTimeHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToDoNotLinked]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDoNotLinked](
	[ToDoNotLinkedID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProjectID] [bigint] NULL,
	[TaskID] [bigint] NULL,
	[ToDoName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ToDoNotLinked] PRIMARY KEY CLUSTERED 
(
	[ToDoNotLinkedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Project1] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Project1]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_ProjectTaskUser] FOREIGN KEY([ProjectTaskUserID])
REFERENCES [dbo].[ProjectTaskUser] ([ProjectTaskUserID])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_ProjectTaskUser]
GO
ALTER TABLE [dbo].[ProjectHistory]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
ALTER TABLE [dbo].[ProjectTaskUser]  WITH CHECK ADD FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
ALTER TABLE [dbo].[ProjectTaskUser]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTaskUser_MapTaskState] FOREIGN KEY([MapTaskStateID])
REFERENCES [dbo].[MapTaskState] ([MapTaskStateID])
GO
ALTER TABLE [dbo].[ProjectTaskUser] CHECK CONSTRAINT [FK_ProjectTaskUser_MapTaskState]
GO
ALTER TABLE [dbo].[ProjectTaskUser]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTaskUser_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectTaskUser] CHECK CONSTRAINT [FK_ProjectTaskUser_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskPriority] FOREIGN KEY([TaskPriorityId])
REFERENCES [dbo].[TaskPriority] ([TaskPriorityId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskPriority]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskType] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[TaskType] ([TaskTypeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskType]
GO
ALTER TABLE [dbo].[TaskUserTime]  WITH CHECK ADD  CONSTRAINT [FK_TaskUserTime_ProjectTaskUser] FOREIGN KEY([ProjectTaskUserID])
REFERENCES [dbo].[ProjectTaskUser] ([ProjectTaskUserID])
GO
ALTER TABLE [dbo].[TaskUserTime] CHECK CONSTRAINT [FK_TaskUserTime_ProjectTaskUser]
GO
ALTER TABLE [dbo].[TaskUserTimeHistory]  WITH CHECK ADD  CONSTRAINT [FK_TaskUserTimeHistory_TaskUserTime] FOREIGN KEY([TaskUserTimeID])
REFERENCES [dbo].[TaskUserTime] ([TaskUserTimeID])
GO
ALTER TABLE [dbo].[TaskUserTimeHistory] CHECK CONSTRAINT [FK_TaskUserTimeHistory_TaskUserTime]
GO
ALTER TABLE [dbo].[ToDo]  WITH CHECK ADD  CONSTRAINT [FK_ToDo_ProjectTaskUser] FOREIGN KEY([ProjectTaskUserID])
REFERENCES [dbo].[ProjectTaskUser] ([ProjectTaskUserID])
GO
ALTER TABLE [dbo].[ToDo] CHECK CONSTRAINT [FK_ToDo_ProjectTaskUser]
GO
/****** Object:  StoredProcedure [dbo].[sp_ProjectActualTime]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ProjectActualTime]
AS
BEGIN
	declare @temp table (ProjectTaskUserID BIGINT,ProjectID BIGINT,UserName nvarchar(100),ProjectName nvarchar(100),TaskID bigint,StartTask datetime,EndTask datetime,ExecutionTime real)
insert into @temp select ProjectTaskUserID,ProjectID,UserName,ProjectName,TaskID,StartTask,EndTask,ExecutionTime
        --from [R2D2].[TimeSheetDB].[dbo].[VProjectTaskUser] order by ProjectName,UserName;
		from [TimeSheetDB].[dbo].[VProjectTaskUser] order by ProjectName,UserName;

declare @ProjectTaskUserID bigint,@ProjetID bigint,@TaskID bigint;
declare @ProjectName nvarchar(100),@UserName nvarchar(100);
declare @StartTask datetime,@EndTask datetime,@StartDate datetime,@EndDate datetime;
declare @ExecutionTime real,@EstimateDurationProject real,@DurationProject real;

declare @resultFinal table (TProjectTaskUserID BIGINT,TProjectID BIGINT,TProjectName nvarchar(100),TUserName nvarchar(100),TTaskID BIGINT,TStartTask datetime,TEndTask datetime,TExecutionTime real,TStartDate datetime,TEndDate datetime,TEstimateDurationProject real,TDurationProject real)
  
declare @temptemp table (ProjectTaskUserID BIGINT,ProjectID BIGINT,ProjectName nvarchar(100),UserName nvarchar(100),TaskID BIGINT,StartTask datetime,EndTask datetime,ExecutionTime real,StartDate datetime,EndDate datetime,EstimateDurationProject real,DurationProject real)
  
insert into @temptemp 
select t.ProjectTaskUserID,p.ProjectID,P.ProjectName ,t.UserName,t.TaskID,t.StartTask,t.EndTask,t.ExecutionTime,p.StartDate ,p.EndDate,p.EstimateDurationProject,p.DurationProject
from Project p left outer join @temp t
on t.ProjectID = p.ProjectID
order by ProjectName,UserName;

DECLARE Cursos cursor for(select * from @temptemp);
open Cursos;
FETCH  Cursos INTO @ProjectTaskUserID,@ProjetID,@ProjectName,@UserName ,@TaskID,@StartTask ,@EndTask,@ExecutionTime,@StartDate,@EndDate,@EstimateDurationProject,@DurationProject;
WHILE @@FETCH_STATUS=0

BEGIN
	declare @somme real;
	set @somme=0;
	declare @tt table (ProjectTaskUserID bigint,startDate datetime,EndDate datetime,ExecutionTime real,Active bit);
	insert into @tt select ProjectTaskUserID,[startDate],[EndDate],[ExecutionTime],Active from TaskUserTime where ProjectTaskUserID = @ProjectTaskUserID;
	
	if(@ExecutionTime is not null)
	begin
		declare @active bit;
		select @active = Active from @tt where ProjectTaskUserID = @ProjectTaskUserID
		if(@active = 1)
		begin	
			declare @dt datetime ;
			if(@StartTask is not null)
			begin
				select @dt=[startDate] from @tt where Active=1
				set @somme = @ExecutionTime + CONVERT(NUMERIC(6, 2), (datediff(minute,@dt,GETDATE())/60) + (datediff(minute,@dt,GETDATE())%60)/100.0);
			end			
		end	
		else
		begin
			set @somme = @ExecutionTime ;
		end		
	end
	else
	begin
		set @somme =CONVERT(NUMERIC(6, 2), (datediff(minute,@StartTask,GETDATE())/60) + (datediff(minute,@StartTask,GETDATE())%60)/100.0)
	end
	
	insert into @resultFinal values(@ProjectTaskUserID,@ProjetID,@ProjectName,@UserName,@TaskID,@StartTask ,@EndTask,@somme,@StartDate,@EndDate,@EstimateDurationProject,@DurationProject)
	FETCH Cursos INTO @ProjectTaskUserID,@ProjetID,@ProjectName,@UserName ,@TaskID,@StartTask ,@EndTask,@ExecutionTime,@StartDate,@EndDate,@EstimateDurationProject,@DurationProject;
	END;
	CLOSE Cursos;
	DEALLOCATE Cursos;

	select TProjectID, TProjectName,TStartDate,TEndDate,TTaskID,TStartTask ,TEndTask,TUserName ,TExecutionTime,TEstimateDurationProject from @resultFinal order by TProjectName,TTaskID;
END


GO
/****** Object:  StoredProcedure [dbo].[SqlStoredProcedure1]    Script Date: 06-05-19 09:48:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SqlStoredProcedure1]
AS
BEGIN
    select * from [TimeSheetDB]
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Project"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 219
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Project"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 296
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProjectHistory"
            Begin Extent = 
               Top = 6
               Left = 293
               Bottom = 262
               Right = 468
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2595
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectHistory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectHistory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[15] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Project"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProjectTask"
            Begin Extent = 
               Top = 6
               Left = 293
               Bottom = 119
               Right = 502
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Task"
            Begin Extent = 
               Top = 6
               Left = 540
               Bottom = 240
               Right = 749
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 2235
         Width = 2730
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectTask'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectTask'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[18] 2[27] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "MapTaskState"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 117
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProjectTaskUser"
            Begin Extent = 
               Top = 6
               Left = 540
               Bottom = 209
               Right = 749
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Project"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 260
               Right = 502
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Task"
            Begin Extent = 
               Top = 6
               Left = 787
               Bottom = 193
               Right = 996
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "LastStart"
            Begin Extent = 
               Top = 120
               Left = 38
               Bottom = 216
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ToDo"
            Begin Extent = 
               Top = 102
               Left = 1034
               Bottom = 215
               Right = 1252
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TaskType"
            Begin Extent = 
               Top = 406
               Left = 38
               Bottom = 544
               Right = 237
            End
            DisplayFlag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectTaskUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N's = 280
            TopColumn = 0
         End
         Begin Table = "TaskPriority"
            Begin Extent = 
               Top = 406
               Left = 275
               Bottom = 567
               Right = 486
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectTaskUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectTaskUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Project"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 272
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProjectTaskUser"
            Begin Extent = 
               Top = 6
               Left = 293
               Bottom = 238
               Right = 477
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectUsualTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VProjectUsualTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Task"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 213
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "TaskType"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 119
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TaskPriority"
            Begin Extent = 
               Top = 6
               Left = 522
               Bottom = 119
               Right = 733
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTask'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTask'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TaskPriority"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 160
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TaskUserTime"
            Begin Extent = 
               Top = 3
               Left = 18
               Bottom = 248
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProjectTaskUser"
            Begin Extent = 
               Top = 5
               Left = 557
               Bottom = 252
               Right = 954
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Project"
            Begin Extent = 
               Top = 148
               Left = 235
               Bottom = 278
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Task"
            Begin Extent = 
               Top = 138
               Left = 1027
               Bottom = 268
               Right = 1208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TaskType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 175
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTaskType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -384
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ToDo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VToDo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VToDo'
GO
USE [master]
GO
ALTER DATABASE [TimeSheetDB] SET  READ_WRITE 
GO
