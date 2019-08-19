USE [RF]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/19/2019 10:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[n_Usuario] [nchar](30) NOT NULL,
	[password] [nchar](20) NULL,
	[email] [nchar](40) NULL,
	[id_Perfil] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([id_Usuario], [n_Usuario], [password], [email], [id_Perfil]) VALUES (1, N'Admin                         ', N'123                 ', N'admin@rf.com                            ', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Perfiles]    Script Date: 08/19/2019 10:05:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[id_Perfil] [int] NOT NULL,
	[descripcion] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Perfiles] ([id_Perfil], [descripcion]) VALUES (1, N'Admins    ')
