USE [ppdai_invest]
GO

/****** Object:  Table [dbo].[DictionaryConfig]    Script Date: 2017/4/11 14:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DictionaryConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
	[KeyName] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](4000) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Expand] [nvarchar](4000) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[TypeId] [int] NOT NULL,
	[OwnerName] [varchar](50) NULL,
	[LastOpUserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [KeyName_unique] UNIQUE NONCLUSTERED 
(
	[KeyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[DictionaryConfig] ADD  DEFAULT (getdate()) FOR [InsertTime]
GO

ALTER TABLE [dbo].[DictionaryConfig] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO

ALTER TABLE [dbo].[DictionaryConfig] ADD  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[DictionaryConfig] ADD  DEFAULT ((0)) FOR [TypeId]
GO

ALTER TABLE [dbo].[DictionaryConfig] ADD  DEFAULT ((0)) FOR [LastOpUserId]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'GroupName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'KeyName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ֵ�Ե�ֵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'Value'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ֵ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��չ�ֶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'Expand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���÷���ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'TypeId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'OwnerName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����޸���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryConfig', @level2type=N'COLUMN',@level2name=N'LastOpUserId'
GO


