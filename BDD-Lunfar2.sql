USE [BDD-Lunfar2]
GO
/****** Object:  User [alumno]    Script Date: 29/11/2019 11:16:46 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Definicion]    Script Date: 29/11/2019 11:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Definicion](
	[IdDefinicion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Palabra] [varchar](50) NOT NULL,
	[FkPais] [int] NOT NULL,
	[Likes] [int] NOT NULL,
	[Dislikes] [int] NOT NULL,
	[Oficial] [bit] NOT NULL,
 CONSTRAINT [PK_Definicion] PRIMARY KEY CLUSTERED 
(
	[IdDefinicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 29/11/2019 11:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Palabras] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 29/11/2019 11:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Uusarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[Contraseña] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearUsuarios]    Script Date: 29/11/2019 11:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearUsuarios]
@NombreUsuario varchar(50),
@Contraseña varchar(50),
@Mail varchar(50)
as 
begin

insert into Usuarios(NombreUsuario,Contraseña,Mail)values(@NombreUsuario,@Contraseña,@Mail)

end
GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarUsuario]    Script Date: 29/11/2019 11:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[sp_VerificarUsuario]
@NombreUsuario varchar(50),
@Contraseña varchar(50)
as 
begin
select * from Usuarios where NombreUsuario=@NombreUsuario and Contraseña=@Contraseña
end
GO
