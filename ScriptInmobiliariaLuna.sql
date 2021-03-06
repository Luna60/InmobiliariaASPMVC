USE [master]
GO
/****** Object:  Database [InmobiliariaASPMVCLuna.M.I]    Script Date: 04/04/2021 20:38:54 ******/
CREATE DATABASE [InmobiliariaASPMVCLuna.M.I]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InmobiliariaASPMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\InmobiliariaASPMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InmobiliariaASPMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\InmobiliariaASPMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InmobiliariaASPMVCLuna.M.I].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ARITHABORT OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET RECOVERY FULL 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET  MULTI_USER 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InmobiliariaASPMVCLuna.M.I', N'ON'
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET QUERY_STORE = OFF
GO
USE [InmobiliariaASPMVCLuna.M.I]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](100) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propiedades]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propiedades](
	[PropiedadId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionP] [nvarchar](100) NOT NULL,
	[TipoPropiedadId] [int] NOT NULL,
	[TipoOperacionId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[Disponible] [bit] NOT NULL,
	[Ambientes] [int] NOT NULL,
	[SuperficieTerreno] [int] NULL,
	[SuperficieEdificada] [int] NULL,
	[Direccion] [nvarchar](120) NOT NULL,
	[Departamento] [nvarchar](10) NULL,
	[Jardin] [bit] NULL,
	[Garage] [bit] NULL,
	[Cochera] [nvarchar](10) NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[CostoOperacion] [decimal](18, 2) NOT NULL,
	[Observaciones] [nvarchar](250) NULL,
	[Imagen] [nvarchar](120) NULL,
 CONSTRAINT [PK_Propiedades] PRIMARY KEY CLUSTERED 
(
	[PropiedadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[TipoDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTD] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[TipoDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposOperaciones]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposOperaciones](
	[TipoOperacionId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTO] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposOperaciones] PRIMARY KEY CLUSTERED 
(
	[TipoOperacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposPropiedades]    Script Date: 04/04/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposPropiedades](
	[TipoPropiedadId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTP] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TiposPropiedades] PRIMARY KEY CLUSTERED 
(
	[TipoPropiedadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (1, N'Fernando', N'Perez', 1, N'50989066', N'Calle 13 E/40 y 42', 1, 9, NULL, N'2226897868', NULL)
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (3, N'Borrame', N'Borratin', 1, N'09080709', N'Calle comodoro, Nº 123', 1, 9, NULL, N'9032 299093', N'PapasFrancesas@gmail,com')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (10, N'aaa', N'ssss', 1, N'77777', N'fffff', 8, 9, N'5679876', N'0097778', N'freadsd')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (11, N'qqq', N'ee', 1, N'098709', N'fffff', 1, 9, NULL, N'0097778', N'LibreSoy@gmail.com')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1, N'Mercedes', 9)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (2, N'Cañuelas', 9)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (8, N'Lujan', 9)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (9, N'Colorado', 9)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (12, N'Manzana', 5)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Propiedades] ON 

INSERT [dbo].[Propiedades] ([PropiedadId], [DescripcionP], [TipoPropiedadId], [TipoOperacionId], [ClienteId], [FechaIngreso], [Disponible], [Ambientes], [SuperficieTerreno], [SuperficieEdificada], [Direccion], [Departamento], [Jardin], [Garage], [Cochera], [LocalidadId], [ProvinciaId], [CostoOperacion], [Observaciones], [Imagen]) VALUES (1, N'Casa Grande', 2, 1, 1, CAST(N'2018-09-19T00:00:00.000' AS DateTime), 1, 3, NULL, NULL, N'Calle 120 E/ 31 y 33', NULL, 1, 1, NULL, 2, 9, CAST(50000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[Propiedades] ([PropiedadId], [DescripcionP], [TipoPropiedadId], [TipoOperacionId], [ClienteId], [FechaIngreso], [Disponible], [Ambientes], [SuperficieTerreno], [SuperficieEdificada], [Direccion], [Departamento], [Jardin], [Garage], [Cochera], [LocalidadId], [ProvinciaId], [CostoOperacion], [Observaciones], [Imagen]) VALUES (2, N'Buena', 2, 1, 3, CAST(N'2019-01-22T00:00:00.000' AS DateTime), 1, 3, 0, 0, N'Cascada al 234', NULL, 1, 1, NULL, 8, 9, CAST(30000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[Propiedades] ([PropiedadId], [DescripcionP], [TipoPropiedadId], [TipoOperacionId], [ClienteId], [FechaIngreso], [Disponible], [Ambientes], [SuperficieTerreno], [SuperficieEdificada], [Direccion], [Departamento], [Jardin], [Garage], [Cochera], [LocalidadId], [ProvinciaId], [CostoOperacion], [Observaciones], [Imagen]) VALUES (6, N'ddd', 1, 1, 1, CAST(N'2020-02-15T00:00:00.000' AS DateTime), 1, 3, 0, 0, N'Coronel', NULL, 0, 0, NULL, 1, 9, CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[Propiedades] ([PropiedadId], [DescripcionP], [TipoPropiedadId], [TipoOperacionId], [ClienteId], [FechaIngreso], [Disponible], [Ambientes], [SuperficieTerreno], [SuperficieEdificada], [Direccion], [Departamento], [Jardin], [Garage], [Cochera], [LocalidadId], [ProvinciaId], [CostoOperacion], [Observaciones], [Imagen]) VALUES (8, N'Confortable', 2, 1, 1, CAST(N'2020-11-09T00:00:00.000' AS DateTime), 1, 0, 0, 0, N'Coronel', NULL, 1, 1, NULL, 1, 9, CAST(56000.00 AS Decimal(18, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Propiedades] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (9, N'Buenos Aires')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (5, N'Catamarca')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (6, N'Entre Rios')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (3, N'Formosa')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Jujuy')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (8, N'La Pampa')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (4, N'Misiones')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (10, N'Neuquen')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2, N'Nubesita')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (20, N'Roma')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET IDENTITY_INSERT [dbo].[TiposDocumentos] ON 

INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [DescripcionTD]) VALUES (1, N'DNI')
INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [DescripcionTD]) VALUES (2, N'LC')
INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [DescripcionTD]) VALUES (3, N'LD')
INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [DescripcionTD]) VALUES (4, N'Pasaporte')
SET IDENTITY_INSERT [dbo].[TiposDocumentos] OFF
SET IDENTITY_INSERT [dbo].[TiposOperaciones] ON 

INSERT [dbo].[TiposOperaciones] ([TipoOperacionId], [DescripcionTO]) VALUES (2, N'Alquiler')
INSERT [dbo].[TiposOperaciones] ([TipoOperacionId], [DescripcionTO]) VALUES (1, N'Venta')
SET IDENTITY_INSERT [dbo].[TiposOperaciones] OFF
SET IDENTITY_INSERT [dbo].[TiposPropiedades] ON 

INSERT [dbo].[TiposPropiedades] ([TipoPropiedadId], [DescripcionTP]) VALUES (1, N'Casa')
INSERT [dbo].[TiposPropiedades] ([TipoPropiedadId], [DescripcionTP]) VALUES (2, N'Casa Quinta')
INSERT [dbo].[TiposPropiedades] ([TipoPropiedadId], [DescripcionTP]) VALUES (3, N'Departamento')
INSERT [dbo].[TiposPropiedades] ([TipoPropiedadId], [DescripcionTP]) VALUES (4, N'Local')
INSERT [dbo].[TiposPropiedades] ([TipoPropiedadId], [DescripcionTP]) VALUES (5, N'Parking')
SET IDENTITY_INSERT [dbo].[TiposPropiedades] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Localidades_NombreLocalidad]    Script Date: 04/04/2021 20:38:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Localidades_NombreLocalidad] ON [dbo].[Localidades]
(
	[NombreLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Provincias_NombreProvincia]    Script Date: 04/04/2021 20:38:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Provincias_NombreProvincia] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDocumentos_Descripcion]    Script Date: 04/04/2021 20:38:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDocumentos_Descripcion] ON [dbo].[TiposDocumentos]
(
	[DescripcionTD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposOperaciones_Descripcion]    Script Date: 04/04/2021 20:38:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposOperaciones_Descripcion] ON [dbo].[TiposOperaciones]
(
	[DescripcionTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposPropiedades_Descripcion]    Script Date: 04/04/2021 20:38:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposPropiedades_Descripcion] ON [dbo].[TiposPropiedades]
(
	[DescripcionTP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Propiedades] ADD  CONSTRAINT [DF_Propiedades_Disponible]  DEFAULT ((1)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Propiedades] ADD  CONSTRAINT [DF_Propiedades_Ambientes]  DEFAULT ((1)) FOR [Ambientes]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Provincias]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDocumentos] FOREIGN KEY([TipoDocumentoId])
REFERENCES [dbo].[TiposDocumentos] ([TipoDocumentoId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDocumentos]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
ALTER TABLE [dbo].[Propiedades]  WITH CHECK ADD  CONSTRAINT [FK_Propiedades_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Propiedades] CHECK CONSTRAINT [FK_Propiedades_Clientes]
GO
ALTER TABLE [dbo].[Propiedades]  WITH CHECK ADD  CONSTRAINT [FK_Propiedades_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Propiedades] CHECK CONSTRAINT [FK_Propiedades_Localidades]
GO
ALTER TABLE [dbo].[Propiedades]  WITH CHECK ADD  CONSTRAINT [FK_Propiedades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Propiedades] CHECK CONSTRAINT [FK_Propiedades_Provincias]
GO
ALTER TABLE [dbo].[Propiedades]  WITH CHECK ADD  CONSTRAINT [FK_Propiedades_TiposOperaciones] FOREIGN KEY([TipoOperacionId])
REFERENCES [dbo].[TiposOperaciones] ([TipoOperacionId])
GO
ALTER TABLE [dbo].[Propiedades] CHECK CONSTRAINT [FK_Propiedades_TiposOperaciones]
GO
ALTER TABLE [dbo].[Propiedades]  WITH CHECK ADD  CONSTRAINT [FK_Propiedades_TiposPropiedades] FOREIGN KEY([TipoPropiedadId])
REFERENCES [dbo].[TiposPropiedades] ([TipoPropiedadId])
GO
ALTER TABLE [dbo].[Propiedades] CHECK CONSTRAINT [FK_Propiedades_TiposPropiedades]
GO
USE [master]
GO
ALTER DATABASE [InmobiliariaASPMVCLuna.M.I] SET  READ_WRITE 
GO
