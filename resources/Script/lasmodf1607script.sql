USE [master]
GO
/****** Object:  Database [CRM]    Script Date: 17/6/2025 09:08:45 ******/
CREATE DATABASE [CRM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Longo-Carpeta-IS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Longo-Carpeta-IS.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Longo-Carpeta-IS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Longo-Carpeta-IS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CRM] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRM] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRM] SET  MULTI_USER 
GO
ALTER DATABASE [CRM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CRM] SET QUERY_STORE = ON
GO
ALTER DATABASE [CRM] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CRM]
GO
/****** Object:  Table [dbo].[administrador]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administrador](
	[administrador_id] [uniqueidentifier] NOT NULL,
	[usuario_id] [uniqueidentifier] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[administrador_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Backups]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Backups](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[FilePath] [nvarchar](500) NOT NULL,
	[PerformedBy] [nvarchar](100) NOT NULL,
	[MachineName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bandeja_tickets_detalle]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bandeja_tickets_detalle](
	[detalle_id] [int] IDENTITY(1,1) NOT NULL,
	[bandeja_id] [int] NOT NULL,
	[ticket_id] [uniqueidentifier] NOT NULL,
	[fecha_asignacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[detalle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bandejas_tickets]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bandejas_tickets](
	[bandeja_id] [int] IDENTITY(1,1) NOT NULL,
	[grupo_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bandeja_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [uniqueidentifier] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[UsuarioId] [uniqueidentifier] NOT NULL,
	[UsuarioNombre] [nvarchar](100) NOT NULL,
	[Clase] [nvarchar](100) NOT NULL,
	[Accion] [nvarchar](100) NOT NULL,
	[InfoAdicional] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[group_id] [int] NULL,
	[tipo_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[creador_id] [uniqueidentifier] NULL,
	[descripcion] [nvarchar](500) NULL,
	[aprobador_requerido] [bit] NULL,
	[departamento_id] [int] NULL,
	[prioridad_id] [int] NULL,
	[eliminado] [bit] NOT NULL,
	[cliente_aprobador_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[usuario_id] [uniqueidentifier] NOT NULL,
	[departamento_id] [int] NOT NULL,
	[fecha_registro] [datetime] NULL,
	[telefono] [nvarchar](20) NULL,
	[direccion] [nvarchar](255) NULL,
	[email_contacto] [nvarchar](255) NULL,
	[fecha_ultima_interaccion] [datetime] NULL,
	[preferencia_contacto] [nvarchar](50) NULL,
	[estado] [bit] NOT NULL,
	[observaciones] [nvarchar](500) NULL,
	[es_aprobador] [bit] NOT NULL,
	[cliente_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[cliente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente_tecnicos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_tecnicos](
	[cliente_tecnico_id] [int] NOT NULL,
	[cliente_id] [int] NOT NULL,
	[tecnico_id] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cliente_tecnico_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comentario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comentario](
	[comentario_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [uniqueidentifier] NOT NULL,
	[usuario_id] [uniqueidentifier] NOT NULL,
	[texto] [nvarchar](1000) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[eliminado] [bit] NOT NULL,
	[comentario_padre_id] [int] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[comentario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlDeCambios]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlDeCambios](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[Tabla] [nvarchar](100) NOT NULL,
	[EntityId] [uniqueidentifier] NOT NULL,
	[Propiedad] [nvarchar](100) NULL,
	[ValorViejo] [nvarchar](max) NULL,
	[ValorNuevo] [nvarchar](max) NULL,
	[CambiadoPor] [uniqueidentifier] NOT NULL,
	[FechaCambio] [datetime2](7) NOT NULL,
	[TipoOperacion] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[departamento_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cliente_lider_id] [int] NULL,
	[fecha_creacion] [datetime] NULL,
	[codigo_departamento] [varchar](10) NOT NULL,
	[descripcion] [nvarchar](500) NULL,
	[estado] [bit] NOT NULL,
	[ubicacion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[departamento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificadorV]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificadorV](
	[tabla] [nvarchar](100) NOT NULL,
	[valor_dv] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[etiquetas]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etiquetas](
	[etiqueta_id] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[form] [nvarchar](255) NULL,
	[texto] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[etiqueta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo_tecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo_tecnico](
	[grupo_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[tecnico_lider_id] [int] NULL,
	[eliminado] [bit] NOT NULL,
	[fecha_creacion] [datetime2](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[grupo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo_tecnico_tecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo_tecnico_tecnico](
	[grupo_id] [int] NOT NULL,
	[tecnico_id] [int] NOT NULL,
 CONSTRAINT [PK_grupo_tecnico_tecnico] PRIMARY KEY CLUSTERED 
(
	[grupo_id] ASC,
	[tecnico_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[idioma_id] [uniqueidentifier] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idioma_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_permisos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permisos](
	[permiso_padre_id] [int] NULL,
	[permiso_hijo_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permisos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permisos](
	[nombre] [varchar](100) NULL,
	[permiso_id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](500) NULL,
 CONSTRAINT [PK_permiso_1] PRIMARY KEY CLUSTERED 
(
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prioridad]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prioridad](
	[prioridad_id] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[prioridad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[rol_id] [int] NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol_permiso]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_permiso](
	[id_rol] [int] NOT NULL,
	[permiso_rol] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[permiso_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sesion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sesion](
	[session_id] [uniqueidentifier] NOT NULL,
	[usuario_id] [uniqueidentifier] NOT NULL,
	[fecha_inicio] [datetime] NOT NULL,
	[fecha_fin] [datetime] NULL,
	[estado] [bit] NOT NULL,
	[ultimo_idioma] [uniqueidentifier] NULL,
	[ultimo_rol_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[session_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tecnico](
	[tecnico_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [uniqueidentifier] NOT NULL,
	[activo] [bit] NOT NULL,
	[fecha_alta] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tecnico_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket](
	[ticket_id] [uniqueidentifier] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[fecha_ultima_modif] [datetime] NOT NULL,
	[fecha_cierre] [datetime] NULL,
	[eliminado] [bit] NOT NULL,
	[asunto] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](150) NOT NULL,
	[cliente_creador_id] [int] NOT NULL,
	[categoria_id] [int] NOT NULL,
	[prioridad_id] [int] NOT NULL,
	[estado_id] [int] NOT NULL,
	[usuario_aprobador_id] [int] NULL,
	[grupo_tecnico_id] [int] NULL,
	[tecnico_id] [int] NULL,
	[digito_verificador_h] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket_estados]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket_estados](
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[ticket_estado_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_estado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket_historico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket_historico](
	[ticket_historial_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [uniqueidentifier] NOT NULL,
	[usuario_id] [uniqueidentifier] NOT NULL,
	[fecha_cambio] [datetime] NOT NULL,
	[comentario] [nvarchar](500) NULL,
	[TipoEvento] [nvarchar](100) NOT NULL,
	[ValorAnteriorId] [int] NULL,
	[ValorNuevoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_historial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_categoria]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_categoria](
	[tipo_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[descripcion] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[tipo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos_clientes]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos_clientes](
	[tipo_cliente_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[tipo_cliente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[traducciones]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[traducciones](
	[traduccion_id] [uniqueidentifier] NOT NULL,
	[idioma_id] [uniqueidentifier] NOT NULL,
	[etiqueta_id] [uniqueidentifier] NOT NULL,
	[texto] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[traduccion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ubicaciones]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ubicaciones](
	[ubicacion_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[direccion] [nvarchar](255) NULL,
	[piso] [nvarchar](50) NULL,
	[ciudad] [nvarchar](100) NULL,
	[pais] [nvarchar](100) NULL,
	[codigo_postal] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ubicacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[usuario_id] [uniqueidentifier] NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[nombre_usuario] [nvarchar](100) NOT NULL,
	[legajo] [int] NOT NULL,
	[fecha_alta] [datetime] NULL,
	[ultimo_inicio_sesion] [datetime] NULL,
	[idioma_id] [uniqueidentifier] NULL,
	[digito_verificador_h] [nvarchar](10) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_permisos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_permisos](
	[usuario_id] [uniqueidentifier] NOT NULL,
	[permiso_id] [int] NOT NULL,
 CONSTRAINT [PK_usuario_permisos] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_roles]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_roles](
	[usuario_id] [uniqueidentifier] NOT NULL,
	[rol_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[administrador] ([administrador_id], [usuario_id], [fecha_creacion], [estado]) VALUES (N'110104e8-80ff-43d4-a71e-34b6ee9b4e62', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-03-10T20:50:55.670' AS DateTime), 1)
INSERT [dbo].[administrador] ([administrador_id], [usuario_id], [fecha_creacion], [estado]) VALUES (N'9730585a-def0-46e6-83c0-68cccc004054', N'c62603c5-2d56-4dcf-bb30-35948eb2e202', CAST(N'2025-06-03T15:06:27.607' AS DateTime), 1)
INSERT [dbo].[administrador] ([administrador_id], [usuario_id], [fecha_creacion], [estado]) VALUES (N'437ca217-c366-4877-b1e0-8dbb34d8308a', N'4551b9cb-32b3-498b-9457-30aadf224def', CAST(N'2025-06-03T15:06:23.817' AS DateTime), 1)
GO
INSERT [dbo].[Backups] ([Id], [Description], [CreatedAt], [FilePath], [PerformedBy], [MachineName]) VALUES (N'935d65db-e421-4250-adff-aa76ec9e96f1', N'pruebaDeUsuario_20250615', CAST(N'2025-06-15T21:30:21.080' AS DateTime), N'C:\Backups\db_backup_pruebaDeUsuario_20250615_213021.bak', N'javie', N'JAVIYLIGI')
INSERT [dbo].[Backups] ([Id], [Description], [CreatedAt], [FilePath], [PerformedBy], [MachineName]) VALUES (N'b7c83edb-be30-40b7-b683-e07ce4e845cd', N'primer_bk_de_prueba_20250615', CAST(N'2025-06-15T20:58:57.580' AS DateTime), N'C:\Backups\db_backup_primer_bk_de_prueba_20250615_205658.bak', N'javie', N'JAVIYLIGI')
GO
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2865c385-cfb0-4380-b385-031cf7924f7b', CAST(N'2025-06-16T22:17:42.073' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9e012b9d-daa2-45fb-8776-05b2f3ecf07c', CAST(N'2025-06-15T17:42:50.567' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c81fcd7c-aa5a-4a6c-8c13-09d45bff0dc9', CAST(N'2025-06-12T21:42:55.477' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'754e048a-7214-4e0e-afb9-09f3b0ca28a4', CAST(N'2025-06-12T00:09:39.157' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'96999e9a-84fb-4849-98dc-0a9fe254b8dd', CAST(N'2025-06-16T17:25:49.020' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'df7a137c-eb7f-4e2f-bac6-0b0c1feb904f', CAST(N'2025-06-16T21:30:37.880' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8dc1d7dc-993c-4e2a-8f5b-0b5a1807a6aa', CAST(N'2025-06-16T13:33:34.897' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b90071f3-8e72-4a73-a865-0d3fa49378d4', CAST(N'2025-06-16T21:20:40.403' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ba520a4c-0ad1-4638-90ed-0e1d07b0d2dd', CAST(N'2025-06-16T19:55:27.147' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3eb8db0e-95b1-41c0-a1fe-0f8546449408', CAST(N'2025-06-16T15:11:10.037' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'569b0d90-3e76-401c-844b-109a40d50591', CAST(N'2025-06-16T23:12:41.757' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'edfc713f-4c79-4a1a-a054-125f24e16e42', CAST(N'2025-06-15T16:16:55.013' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'89ec1441-8bb0-4235-951a-13262fab0c21', CAST(N'2025-06-14T14:43:46.767' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ea3287b9-85c2-4a5f-8346-132722714361', CAST(N'2025-06-16T16:02:39.437' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'89adeb5c-c365-4575-98d8-13637f9ae8d9', CAST(N'2025-06-16T19:21:22.210' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b1e06611-4af9-4a22-84d1-13e3dce5406c', CAST(N'2025-06-16T20:28:19.910' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'78bf1880-0899-4937-a634-14ca25678e62', CAST(N'2025-06-16T18:10:05.380' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'65e5dee2-c3af-41a8-b924-16b4305b2439', CAST(N'2025-06-12T22:12:45.573' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ea565116-c5ea-481a-b833-17505ad31800', CAST(N'2025-06-16T21:34:33.880' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6fcf36ea-4999-40b8-9d82-1758c9dd1d6e', CAST(N'2025-06-16T15:16:07.310' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6d0f63bf-c0ac-416d-ac08-183bdfd676c1', CAST(N'2025-06-16T19:47:41.253' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'13d598fc-7a9d-4573-add7-187b746b607c', CAST(N'2025-06-16T14:50:47.020' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'84efaed8-be06-4133-aa80-19807f804fe5', CAST(N'2025-06-16T20:30:30.007' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd45d64a7-8f21-44d1-bb3e-19cef9422f24', CAST(N'2025-06-17T00:56:23.597' AS DateTime), N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', N'tp_220', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9311e43c-92c2-46a4-803c-1bef5fdd9539', CAST(N'2025-06-16T21:51:47.460' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1565d6ad-6ac4-499a-8ef8-1cf562b296e1', CAST(N'2025-06-16T23:29:09.757' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'26034e38-cc0f-4bda-b725-1dd5087d157a', CAST(N'2025-06-15T17:41:59.633' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bdefb80a-4dca-4fdb-8f45-21c6b79ac42b', CAST(N'2025-06-10T20:37:33.753' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c9e2a29b-cdbc-4e6e-b015-2697226ff28b', CAST(N'2025-06-10T14:53:25.627' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c17ba60f-5c1c-4204-9a0f-27a374f8f710', CAST(N'2025-06-17T00:55:51.000' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'771f0d41-616d-43fe-a183-281f1149b2a6', CAST(N'2025-06-16T19:04:45.757' AS DateTime), N'4551b9cb-32b3-498b-9457-30aadf224def', N'SA_44', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'eb3ad5c7-1c87-41fc-9417-28b7c6ecb440', CAST(N'2025-06-16T23:18:56.603' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'5fe5e237-e94f-4d17-814a-2a1f8cb3e481', CAST(N'2025-06-15T23:12:41.060' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'fb56087d-9ef5-4640-ba91-2a76ef3e8764', CAST(N'2025-06-10T20:53:32.950' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e5fc0d2a-af2f-4f69-b113-2ae80d05bd29', CAST(N'2025-06-12T22:18:11.560' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'eae2a092-3d1a-4cb3-8be6-2d890a2f985d', CAST(N'2025-06-16T21:25:27.407' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'68b91c24-3960-4b85-b53e-2db57ba123fe', CAST(N'2025-06-04T22:14:30.280' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'aa2cf75a-2555-4ab5-a85b-2db6ff928e95', CAST(N'2025-06-16T14:51:03.140' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'5ca5859b-7b87-4482-ad12-2dccfe2c2eed', CAST(N'2025-06-16T13:22:45.490' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'0ef78b5d-4404-4024-940c-2e8ee1a6bb9d', CAST(N'2025-06-10T22:06:10.110' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'be694e94-ae43-472e-808a-324bae498e73', CAST(N'2025-06-16T22:26:19.680' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'926fc602-220d-4b72-b4a6-32a9ff349d39', CAST(N'2025-06-17T00:09:43.890' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'456fc964-df09-46c4-9add-33897c70ad62', CAST(N'2025-06-16T23:11:29.113' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b10e4338-308f-45af-9bcc-37e39e5a94a6', CAST(N'2025-06-16T22:17:13.367' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'87b2d230-8994-440a-be0d-3a00eab59957', CAST(N'2025-06-16T23:44:56.353' AS DateTime), N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', N'pp_2222', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a5327147-5824-4ded-933f-3b7b66458755', CAST(N'2025-06-15T21:48:27.727' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bcf8f6b8-f8ea-4838-b6a9-3b7e13b57188', CAST(N'2025-06-17T00:22:13.887' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4313146f-0704-44bd-9fc6-3d9410c0df30', CAST(N'2025-06-10T20:51:56.357' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'11f6e768-e682-41df-abde-3dc0206fe2f8', CAST(N'2025-06-10T20:44:42.990' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'57c6ca5a-bdbe-40c0-a214-434bfc847e74', CAST(N'2025-06-16T14:53:22.757' AS DateTime), N'e4d68b97-50de-47fd-a129-153af2b205b9', N'ad_333', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8e722550-4970-4e29-9661-43db56e46ca2', CAST(N'2025-06-16T16:02:57.347' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'adbf6168-d903-46ac-9d2f-44c35fdde43c', CAST(N'2025-06-12T00:27:19.023' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'fd0c77dc-e08a-4944-9b47-46bb44c71bb7', CAST(N'2025-06-16T13:35:04.250' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1a9f001e-626a-40e3-b3ae-4a53bd348ec1', CAST(N'2025-06-16T21:23:09.373' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd1c2e88f-29ed-46dd-b0fc-4baedce100e0', CAST(N'2025-06-16T23:09:24.213' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3eb8328f-902b-480b-a801-4d349c661b18', CAST(N'2025-06-15T23:17:48.353' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'57a8cd0f-c133-4d7e-9afc-4d9b0c6c0707', CAST(N'2025-06-16T18:02:01.510' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'7aaeec5c-092d-42f1-ac18-4e7a7393dd62', CAST(N'2025-06-16T22:27:20.443' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1590f3dc-9f22-4dee-8e3e-4ee3bf683a4d', CAST(N'2025-06-17T00:45:15.170' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1804c2b7-6c31-482f-a6cc-4fedb9348b4b', CAST(N'2025-06-16T14:23:06.767' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a34aaa25-40f0-459f-9260-5261953df50c', CAST(N'2025-06-12T22:40:55.963' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd2caa017-077d-44c3-87e9-53422703ad62', CAST(N'2025-06-04T22:17:17.563' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'906ce982-4cc5-4e7d-ba34-53b59b24ccf8', CAST(N'2025-06-11T19:00:47.093' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bd81f031-48b5-4f66-90b4-551d4d1ed158', CAST(N'2025-06-14T13:06:27.350' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'7c475fc9-9057-4f1f-a4ea-556f9ea4cae3', CAST(N'2025-06-16T22:04:52.740' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c7bb17f6-1c7e-4852-9773-57cfd89a4a8c', CAST(N'2025-06-16T19:29:49.863' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e0213cf1-00da-4774-8a94-5a8f30ff2b46', CAST(N'2025-06-17T00:20:53.790' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3d300396-0de5-4447-8f0e-5c93c77abd6a', CAST(N'2025-06-16T14:25:17.003' AS DateTime), N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'cc_23230', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4ebb2454-dc62-47bd-bd58-5dc88f8d0858', CAST(N'2025-06-04T22:19:27.887' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'55fa7e7c-fd51-4728-87db-5f4a16786b5e', CAST(N'2025-06-17T00:02:37.203' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'dca41692-bef9-41b2-8b71-606d0050e283', CAST(N'2025-06-14T14:29:39.473' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'175b7692-6b0a-4c8a-a52d-6076c1e4f9f7', CAST(N'2025-06-15T17:39:56.500' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'178c8f7b-fb06-49b0-a2cf-63c3987a3ed9', CAST(N'2025-06-16T21:45:27.683' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2fb5e189-944e-4538-8466-646ed407b73a', CAST(N'2025-06-16T20:34:21.730' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1cfee1fa-c3df-4bd1-9a9d-6606cfe42ba4', CAST(N'2025-06-16T20:30:04.577' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'513afbb9-1a1d-429e-9421-6607655d25ee', CAST(N'2025-06-15T16:24:29.887' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c0c26082-833f-4095-b5a6-6cdedf2a0a17', CAST(N'2025-06-16T21:39:02.287' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'73330086-7da7-4095-8a62-6ce0e66defb6', CAST(N'2025-06-14T14:55:33.570' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f5274671-6f7a-4864-963b-6d148603fb61', CAST(N'2025-06-11T15:23:55.593' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4fab1c77-15b7-47fc-bb32-6d4ce7b394f7', CAST(N'2025-06-16T19:54:03.713' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'42b94395-a739-49f8-8031-6e5389f7fc87', CAST(N'2025-06-16T18:44:13.297' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd79c218d-a8b4-4d0e-be1d-6fbcc16c795d', CAST(N'2025-06-16T22:02:31.343' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3afd4084-add5-42e9-b637-6fe7a994d590', CAST(N'2025-06-16T21:14:12.870' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bd6c1057-bcae-484e-bc80-731d6148b8b0', CAST(N'2025-06-15T16:31:22.373' AS DateTime), N'b9d228df-8d04-4d84-a662-2913efa491e1', N'MB_33302', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'93de6750-17c8-41c9-9820-73d2244c8e21', CAST(N'2025-06-04T20:17:36.997' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'0ac7e9e8-0d1e-44e5-8d7c-758ab3be0ae9', CAST(N'2025-06-16T19:19:08.093' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bff4c809-7c60-483d-b25c-7704c75eed69', CAST(N'2025-06-10T20:56:03.487' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'90828e2b-f105-487b-8d65-778f17852ee5', CAST(N'2025-06-16T12:51:22.660' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd41c3032-a4b5-4b27-849a-7897a6b2bcf6', CAST(N'2025-06-16T23:35:09.710' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'7d2478f0-2b66-495d-ae62-78f9dcb19c2c', CAST(N'2025-06-16T22:08:03.543' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'cc845fab-f4a1-41f4-a399-79f477a873fb', CAST(N'2025-06-15T23:10:45.890' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'423a3568-1de6-4682-8171-7a9d22234a40', CAST(N'2025-06-16T17:45:34.223' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8becc3c5-f682-42ce-a4ba-7abe7c1c14ab', CAST(N'2025-06-10T22:56:49.517' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'555bf9cd-6fa3-4a2f-9bd5-7ac3f2f07808', CAST(N'2025-06-12T22:39:52.530' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3a5286c2-9497-4362-9c63-7afc89fee061', CAST(N'2025-06-17T00:32:26.083' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8384db07-7f8d-4ffc-8e2c-7b6e9fd0f413', CAST(N'2025-06-15T17:38:12.857' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'35464652-20bb-441b-bc10-7cebfbfb9789', CAST(N'2025-06-16T13:29:37.190' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'68ab42ab-32d8-471e-b231-7dcd079b3361', CAST(N'2025-06-15T23:12:10.203' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4bbe1a2e-5a51-48e5-a0aa-7e17c12717e5', CAST(N'2025-06-16T22:07:17.443' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ab90fcfd-f392-4c66-96d2-7ed090a890e1', CAST(N'2025-06-12T22:25:23.497' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
GO
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a4d10d84-c941-48cd-8f56-7f33f6c5401b', CAST(N'2025-06-16T21:55:13.433' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f477c13b-55ed-40d1-95be-82b8a92e44be', CAST(N'2025-06-15T18:29:49.393' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6086116a-0f64-46c6-b961-82fda68fa871', CAST(N'2025-06-12T22:24:49.960' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'082893ba-dec5-4424-9b92-842a8342620d', CAST(N'2025-06-17T00:37:20.120' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'71792f9d-8f39-4723-8f8a-85e04e77681a', CAST(N'2025-06-12T22:18:42.470' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd1ed36e2-910d-491b-b9b4-86106036c633', CAST(N'2025-06-16T18:18:56.740' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e1e4e77c-44f6-4a71-bc5f-8761bc982a20', CAST(N'2025-06-16T13:34:43.633' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8033cbb2-960d-42b4-89ff-881567e8d5e9', CAST(N'2025-06-17T00:23:55.937' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'26568965-b7f1-4785-a017-8ab713bb5ff1', CAST(N'2025-06-16T17:22:02.323' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'38603436-208a-41b7-a249-8b275c435829', CAST(N'2025-06-16T21:41:19.507' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'841bb776-90b9-42a0-b020-8def8705faf2', CAST(N'2025-06-16T16:18:59.727' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9e6056d8-4cbd-48ae-a4e5-8e1c3c651190', CAST(N'2025-06-16T21:13:32.730' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'adee0cd8-2c54-4b69-be17-8f1838d8eac7', CAST(N'2025-06-15T16:47:30.127' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'0024c65c-22e2-4d34-afed-8f314364931f', CAST(N'2025-06-14T13:29:50.663' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f19a08cc-0090-47b6-ad19-905f5c931776', CAST(N'2025-06-16T20:25:37.590' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'382d985c-7fd1-457d-acd7-9165ba2dd108', CAST(N'2025-06-16T21:05:07.480' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'32bb4d5f-ba73-4292-a64c-919ac81e1bab', CAST(N'2025-06-10T21:50:33.650' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2ed3edcd-8c97-4489-85d3-9275a8b60c75', CAST(N'2025-06-17T00:34:13.987' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3a5bb326-4187-4780-b6b0-92dad049b8a4', CAST(N'2025-06-16T13:17:07.683' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e257a2e8-a750-4d6b-b6b0-92e440bf2e45', CAST(N'2025-06-16T21:43:14.740' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8f60d050-784c-459f-bb78-93dee257e06e', CAST(N'2025-06-15T16:31:47.323' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'191a8f03-f907-4fa9-91f9-961fa1ba590d', CAST(N'2025-06-17T00:47:31.453' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b26297da-5e47-4268-9c8d-96ddaa87afec', CAST(N'2025-06-14T14:51:22.240' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'af4b480b-5246-43bc-8716-980e74957469', CAST(N'2025-06-12T22:52:00.540' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4e8019fb-3131-4f74-af4e-985d29cae875', CAST(N'2025-06-10T20:39:37.350' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'4835ef16-fcad-48b3-a932-9862de67c8aa', CAST(N'2025-06-16T19:50:49.470' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a77c3951-2492-4484-80fd-986719d7ac1b', CAST(N'2025-06-17T00:31:32.383' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd4cc2110-709c-4a4b-9545-989c67c4bba4', CAST(N'2025-06-16T21:37:02.093' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'313065e8-1587-4f79-94bb-9ac6ffac788c', CAST(N'2025-06-16T23:07:08.520' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'354e42a7-c99f-4fad-ac17-9c7faa78b14a', CAST(N'2025-06-14T13:28:17.330' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'019f2bad-c9ca-4b5b-a891-9cac6d3c8133', CAST(N'2025-06-12T22:41:41.897' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3537a000-b594-48fa-b90e-9e908e44c12c', CAST(N'2025-06-16T13:23:01.617' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'7677203a-afc0-4b88-8ede-9eaba7bed40d', CAST(N'2025-06-10T14:35:18.110' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'da1898ae-fd5a-4329-a24b-9ece39065827', CAST(N'2025-06-16T17:23:30.963' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'5eb13b9e-4c37-43d8-ac79-9f941b3b3575', CAST(N'2025-06-16T13:22:31.733' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6236c436-7659-4c0a-9028-9fa022267e30', CAST(N'2025-06-05T19:42:57.260' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a10f7eb2-daaa-4d33-b820-a06fdc1f7d4a', CAST(N'2025-06-17T00:38:31.523' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a899df61-f2d8-4cdc-ac50-a2354406bc50', CAST(N'2025-06-04T22:16:31.897' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'784284ef-94eb-407c-89b7-a2aa5bca6281', CAST(N'2025-06-15T15:59:56.293' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8e7e2f0c-e94b-49c7-9de1-a543a00926e9', CAST(N'2025-06-17T00:24:19.303' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bd8df64e-3e5c-4657-aea3-a5d52f19610b', CAST(N'2025-06-16T21:12:49.367' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9261ce05-bc20-4089-b8c4-a5ea9423d827', CAST(N'2025-06-17T00:28:11.873' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6292400c-f885-4bd7-a46c-a68be001cf6d', CAST(N'2025-06-16T23:32:39.407' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f39e5f7e-0ca2-48ad-9498-a7f44ab9d5ae', CAST(N'2025-06-16T18:19:15.163' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'be3a9d33-e30c-4136-91ac-a97411597b5f', CAST(N'2025-06-11T15:24:49.450' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bf95e8ab-3d64-46ae-a3c0-a9b1e628f3ea', CAST(N'2025-06-16T23:22:57.707' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'51a804cd-5409-4c0e-a31f-a9e811d05413', CAST(N'2025-06-16T21:35:40.447' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'420def1e-992a-4c27-b1db-aba9dfeb92b3', CAST(N'2025-06-12T00:26:32.710' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a45aee7b-3c56-48da-aaa0-b0f9fb11934b', CAST(N'2025-06-16T17:13:54.273' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'010eaa58-7357-43d2-8ce6-b36ceabe39b4', CAST(N'2025-06-17T00:40:32.570' AS DateTime), N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', N'tp_220', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd68c3b98-29f9-4aa6-8f99-b639af9a11a5', CAST(N'2025-06-16T13:16:45.490' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a33f2b3b-a285-43bc-81fa-b6f31136ed9e', CAST(N'2025-06-10T21:17:04.217' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'adc715e0-00bc-4097-b353-b7bc1ddf0468', CAST(N'2025-06-17T00:53:53.873' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9a02c864-ae8c-4d7d-bc4a-baf995402524', CAST(N'2025-06-10T14:55:44.983' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2c057bf0-db95-4a9d-907e-bf018a0fddaa', CAST(N'2025-06-16T19:52:49.557' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e0e86257-93e3-424e-ae5e-bf1f0625d681', CAST(N'2025-06-17T00:49:28.817' AS DateTime), N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', N'tp_220', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'221312d8-c06d-4103-a4e2-c1199385e79c', CAST(N'2025-06-16T21:59:04.083' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a3f69fb3-d253-4b0b-ad95-c64911eefb01', CAST(N'2025-06-11T15:27:21.657' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b5a760e7-77cc-4c41-ad87-c6bf183707df', CAST(N'2025-06-10T14:50:22.777' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'facb2f0d-16d7-4243-969e-cd094e013b7f', CAST(N'2025-06-15T17:44:49.930' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a4b327d1-4a55-4fd2-951e-cd50fb0ab7f6', CAST(N'2025-06-16T23:15:04.157' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'bda5385a-2031-4134-9f9a-ce421be6361d', CAST(N'2025-06-16T12:51:00.300' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'90a1055a-87f3-45a0-ba87-ce7074d77827', CAST(N'2025-06-16T16:23:11.017' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3d3131ad-1f9b-4b25-96e7-d08d41f971ae', CAST(N'2025-06-14T15:19:47.427' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2a3c67cd-337a-46f7-850b-d109def21a07', CAST(N'2025-06-17T00:55:13.283' AS DateTime), N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', N'tp_220', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'992a6984-245a-4cab-a769-d3748b28e19e', CAST(N'2025-06-17T00:38:01.453' AS DateTime), N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'ad_103', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e213bf05-c393-4be2-9ffe-d468fd5aa368', CAST(N'2025-06-14T15:21:56.400' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'54e448ae-9a94-4ad1-85a2-d4caf159cede', CAST(N'2025-06-16T19:55:45.033' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ba991449-63e9-44aa-be5b-d74e643f620f', CAST(N'2025-06-17T00:35:08.253' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'ae9a6198-41c6-4482-88bf-d758dba1abbe', CAST(N'2025-06-17T00:29:12.800' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'97998a92-6ad3-42af-9997-d7cdd0366917', CAST(N'2025-06-04T21:58:31.240' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'1881bf34-3e87-47bb-8553-d7cf55632020', CAST(N'2025-06-16T22:38:48.683' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'5d5a62e1-92fd-4058-9a11-d942dd708214', CAST(N'2025-06-12T22:30:06.230' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'a1899d2f-f9ff-47b6-bbe3-d9c0ccc07f09', CAST(N'2025-06-16T19:28:34.863' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f9d1f3e4-f946-4a21-b126-db5d56b1364c', CAST(N'2025-06-16T13:17:19.653' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'd2e2be17-8139-4068-ada3-db7319304b43', CAST(N'2025-06-16T19:20:34.227' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9a9ac45f-9ce7-4032-96db-dce6c67e3d75', CAST(N'2025-06-16T21:53:37.860' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e1e74557-5bfe-4042-903c-de0b96471747', CAST(N'2025-06-17T00:25:34.993' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'72e131ba-da8e-4a4f-b235-e0f1af911bcd', CAST(N'2025-06-16T23:12:02.067' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'98fab57f-ca9a-4127-be68-e25fc7b6fb5e', CAST(N'2025-06-15T17:22:06.553' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'deb5335c-2721-4178-9d26-e3b8b132d32e', CAST(N'2025-06-14T14:09:15.970' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'407da60c-e47d-4c8c-86ce-eb5214f5ad0e', CAST(N'2025-06-17T00:26:10.827' AS DateTime), N'75823e87-7292-4817-bef7-8d73f2137f1c', N'LD_9', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'161d058c-a14d-4a33-a7e2-eb7e676c217f', CAST(N'2025-06-16T22:00:25.890' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'316a7ba5-862f-4acf-9499-ebe0341f5b36', CAST(N'2025-06-16T22:29:26.317' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'7acd395c-fbb6-4afb-812d-ec7e114d8f01', CAST(N'2025-06-15T21:47:47.233' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'286536b2-353c-4a12-b239-eeed86289788', CAST(N'2025-06-15T16:28:36.307' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'e7718970-7d7f-4fd6-8d56-ef4d3b6904f3', CAST(N'2025-06-16T19:45:50.700' AS DateTime), N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'cr_107', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'cf8da9fc-5736-46b5-9142-f09b8f865ffa', CAST(N'2025-06-16T23:41:05.763' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'c062be0c-de13-4138-86a1-f105af8e31b1', CAST(N'2025-06-16T12:49:01.933' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9af976f0-5b72-44f0-af96-f274466fd060', CAST(N'2025-06-16T21:32:33.693' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'3c9050c4-7ae7-41dc-b55d-f4ab30749c55', CAST(N'2025-06-16T12:48:24.527' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f6d4785f-a66c-4c6e-b550-f77d57de01e4', CAST(N'2025-06-15T17:56:00.223' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'2ed794a7-9038-4aca-a9d4-f7afda94fe61', CAST(N'2025-06-16T15:11:43.310' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9a06888f-61ab-49fe-bf9a-f9bdcbba5552', CAST(N'2025-06-16T21:47:46.760' AS DateTime), N'da102f82-03b9-4092-a804-47741b42f4de', N'cr_105', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'f66b88b0-b3d2-4a50-83cd-f9df4e03f6d6', CAST(N'2025-06-14T14:49:59.637' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'8429276f-6c21-42ba-a68a-faa31699464d', CAST(N'2025-06-12T22:13:46.313' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'68b9955c-9ced-46a3-8f21-fca78070d40a', CAST(N'2025-06-15T23:19:32.603' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'6eafebbb-db41-4be0-9116-fe97a414c24a', CAST(N'2025-06-15T21:48:05.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'b805a254-f7ac-428c-9507-ff6e49f3d197', CAST(N'2025-06-16T18:14:08.887' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'jg_112', N'UsuarioBLL', N'Login', NULL)
INSERT [dbo].[Bitacora] ([Id], [FechaHora], [UsuarioId], [UsuarioNombre], [Clase], [Accion], [InfoAdicional]) VALUES (N'9d87f821-eab8-4260-86ea-ffcf85fafd58', CAST(N'2025-06-16T23:05:55.370' AS DateTime), N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'td_4444', N'UsuarioBLL', N'Login', NULL)
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (11, N'Solicitud de Dispositivos Finales', 1, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.', 0, 1, 1, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (12, N'Auditoría Financiera Anual', 2, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Auditoría exhaustiva de los registros financieros y cumplimiento de las normativas contables.', 0, 2, 2, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (13, N'Campañas de Publicidad en Redes Sociales', 3, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Planificación y ejecución de campañas de marketing en redes sociales para impulsar productos y servicios.', 0, 3, 3, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (14, N'Gestión de Ventas por Canal Digital', 4, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Gestión de ventas online, seguimiento de pedidos y atención al cliente en el canal digital.', 0, 4, 4, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (15, N'Control de Calidad de Productos Fabricados', 5, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Supervisión y control de calidad de los productos fabricados en la línea de producción.', 0, 5, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (16, N'Actualización de Software y Sistemas Internos', 6, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Instalación de actualizaciones y mantenimiento de los sistemas de software de la empresa.', 0, 6, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (17, N'Investigación de Nuevas Tecnologías Emergentes', 7, 2, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Investigación y análisis de nuevas tecnologías para su posible implementación en la empresa.', 0, 7, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (18, N'Manejo de Consultas y Quejas de Clientes', 8, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Manejo y resolución de consultas, quejas y solicitudes de los clientes para mejorar la experiencia del cliente.', 0, 8, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (19, N'Revisión de Contratos Legales y Compliance', 9, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Revisión de contratos legales y políticas internas para garantizar el cumplimiento de las regulaciones.', 0, 9, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (20, N'Planificación de Distribución de Productos', 10, 1, CAST(N'2024-09-28T11:39:32.347' AS DateTime), N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'Planificación de la logística y distribución de productos a los distintos puntos de venta.', 0, 10, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (21, N'prueba1', 1, 1, CAST(N'2025-05-02T01:56:05.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'', 0, 1, 1, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (22, N'prueba 2', 1, 1, CAST(N'2025-05-02T12:08:41.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'', 0, 1, 4, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (23, N'prueba 3', 4, 3, CAST(N'2025-05-02T12:22:58.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'', 0, 8, 5, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (24, N'prueba4', 6, 1, CAST(N'2025-05-02T12:24:47.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba4 de descripcion', 0, 13, 3, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (25, N'prueba4', 1, 1, CAST(N'2025-05-03T11:15:28.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba4', 0, 1, 4, 0, NULL)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (26, N'prueba 12', 1, 1, CAST(N'2025-05-04T21:40:20.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba 12', 1, 1, 1, 0, 2)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (27, N'crear vnets', 3, 1, CAST(N'2025-05-05T20:06:12.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'crear vnets', 1, 9, 3, 0, 3)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (28, N'prueba 22', 1, 1, CAST(N'2025-05-10T23:25:03.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba 22', 1, 6, 1, 1, 3)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (29, N'prueba 25', 1, 1, CAST(N'2025-05-11T00:01:44.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba 25', 1, 4, 1, 1, 2)
INSERT [dbo].[categoria] ([categoria_id], [nombre], [group_id], [tipo_id], [fecha_creacion], [creador_id], [descripcion], [aprobador_requerido], [departamento_id], [prioridad_id], [eliminado], [cliente_aprobador_id]) VALUES (30, N'categoriaParaProbar', 12, 1, CAST(N'2025-06-16T21:59:50.000' AS DateTime), N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'categoriaParaProbar', 1, 6, 1, 0, 3)
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'da102f82-03b9-4092-a804-47741b42f4de', 2, CAST(N'2025-05-04T18:48:07.220' AS DateTime), N'011-4567890', N'Calle Falsa 123', N'carla.ruiz@crm.com', CAST(N'2024-09-28T10:30:00.000' AS DateTime), N'Email', 1, N'Alta automática por rol Cliente.', 0, 1)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'f574033a-cd6a-426f-a35e-4dfdcc22568c', 4, CAST(N'2025-05-04T18:48:07.223' AS DateTime), N'011-6789012', N'Av. Siempreviva 742', N'claudia.ramirez@crm.com', CAST(N'2024-09-28T12:00:00.000' AS DateTime), N'Teléfono', 1, N'Alta automática por rol Cliente.', 1, 2)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', 6, CAST(N'2025-05-04T18:48:07.227' AS DateTime), N'011-2345678', N'Pasaje Lunar 456', N'andres.diaz@crm.com', CAST(N'2024-09-28T14:30:00.000' AS DateTime), N'Email', 1, N'Alta automática por rol Cliente.', 1, 3)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'3361ff0a-ed4e-48f8-9134-9102e51da531', 8, CAST(N'2025-05-04T18:48:07.227' AS DateTime), N'011-9998888', N'Calle Estrella 999', N'aprobador.gomez@crm.com', CAST(N'2024-09-28T15:30:00.000' AS DateTime), N'Teléfono', 1, N'Alta automática por rol Cliente.', 0, 4)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 16, CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL, N'Florida 1070', N'javier.gomez@crm.com', CAST(N'2024-09-28T08:30:00.000' AS DateTime), NULL, 1, NULL, 0, 5)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 1, CAST(N'2025-06-03T09:15:54.000' AS DateTime), N'ada', N'asda', N'adas', NULL, N'asdsa', 1, N'asdasd', 1, 6)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 1, CAST(N'2025-06-03T09:25:17.000' AS DateTime), N'asdas', N'asdas', N'asda', NULL, N'asd', 0, N'asas', 0, 7)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', 4, CAST(N'2025-06-16T14:24:49.000' AS DateTime), N'113044444', N'UAI', N'aa', NULL, N'a', 1, N'a', 1, 8)
INSERT [dbo].[cliente] ([usuario_id], [departamento_id], [fecha_registro], [telefono], [direccion], [email_contacto], [fecha_ultima_interaccion], [preferencia_contacto], [estado], [observaciones], [es_aprobador], [cliente_id]) VALUES (N'75823e87-7292-4817-bef7-8d73f2137f1c', 4, CAST(N'2025-06-17T00:25:04.000' AS DateTime), N'11333222323', N'Lavalle 322', N'ligimat.dugarte@crm.com', NULL, N'-', 1, N'-', 0, 9)
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[comentario] ON 

INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (1, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'se debe agregar un comentario', CAST(N'2025-05-31T21:20:45.553' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (2, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'asdasdas', CAST(N'2025-05-31T21:31:11.560' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (3, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'podrian acelerar el proceso?', CAST(N'2025-06-01T15:34:24.103' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (4, N'6d98ba02-b051-4294-a51d-836371344aad', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'se cancela el ticket porque me equivoque', CAST(N'2025-06-01T15:41:10.333' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (5, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'hola ligi', CAST(N'2025-06-01T18:10:22.910' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (6, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'ESTO ES UNA PRUEBA', CAST(N'2025-06-01T19:03:52.517' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (7, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'ESTI', CAST(N'2025-06-01T19:12:24.027' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (8, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'ESTO ES UNA PRUEBA', CAST(N'2025-06-01T20:12:23.150' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (9, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'ASDASDAS', CAST(N'2025-06-01T20:18:20.663' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (10, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'AADA', CAST(N'2025-06-01T20:19:30.137' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (11, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'eli es un cachudo', CAST(N'2025-06-01T20:23:22.983' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (12, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'eli es un cachon de mierda', CAST(N'2025-06-01T20:28:05.413' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (13, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'aprobar con urgencia', CAST(N'2025-06-01T21:35:31.933' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (14, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba de aprobacion', CAST(N'2025-06-01T21:36:01.487' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (15, N'892fa66e-2290-4f9f-9514-258ec9dd9bd4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'esto es otra prueba', CAST(N'2025-06-01T21:43:03.373' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (16, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba', CAST(N'2025-06-01T21:52:46.053' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (17, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba 2', CAST(N'2025-06-01T21:53:03.853' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (18, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'ultima prueba', CAST(N'2025-06-02T21:30:56.460' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (19, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'pepe', CAST(N'2025-06-10T22:07:33.257' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (20, N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'arisk', CAST(N'2025-06-11T15:28:07.473' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (21, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'estoper', CAST(N'2025-06-14T13:29:35.537' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (22, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'QASASDSA', CAST(N'2025-06-16T16:23:49.380' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (23, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'jhg,vjghjgkh', CAST(N'2025-06-16T17:48:32.417' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (24, N'7cd9bc46-4bed-4afd-a3f0-7ca0f5a935e4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'eaaaa', CAST(N'2025-06-16T18:14:39.760' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (25, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'forro', CAST(N'2025-06-16T20:31:29.767' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (26, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'se resuelve', CAST(N'2025-06-16T23:07:30.773' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (27, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'en espera', CAST(N'2025-06-16T23:13:24.363' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (28, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'en espera', CAST(N'2025-06-16T23:13:41.943' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (29, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'prueba123', CAST(N'2025-06-16T23:15:30.533' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (30, N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'esto es una prueba', CAST(N'2025-06-17T00:13:32.750' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (31, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'darle celeridad al pedido', CAST(N'2025-06-17T00:33:17.330' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (32, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'se resuelve', CAST(N'2025-06-17T00:41:46.680' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (33, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'solo es una prueba', CAST(N'2025-06-17T00:47:59.103' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (34, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'se deja en espera', CAST(N'2025-06-17T00:50:03.783' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (35, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'DARLE CELERIDAD AL ASUNTO', CAST(N'2025-06-17T00:54:47.600' AS DateTime), 0, NULL)
INSERT [dbo].[comentario] ([comentario_id], [ticket_id], [usuario_id], [texto], [fecha], [eliminado], [comentario_padre_id]) VALUES (36, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'CERRADO', CAST(N'2025-06-17T00:56:50.383' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[comentario] OFF
GO
SET IDENTITY_INSERT [dbo].[ControlDeCambios] ON 

INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (316, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaCreacion', NULL, N'14/6/2025 15:20:34', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (317, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', NULL, N'14/6/2025 15:20:34', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (318, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (319, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Asunto', NULL, N'test 1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (320, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Descripcion', NULL, N'<test 1>', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (321, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (322, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"112","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (323, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:34.9966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (324, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (325, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (326, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (327, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0133333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (328, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (329, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (330, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:20:35.0233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (331, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'14/6/2025 15:20:34', N'14/6/2025 15:21:40', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:21:40.3266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (332, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Asunto', N'test 1', N'test 1<>', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T18:21:40.3300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (333, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Asunto', N'test 1<>', N'test 1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T18:28:54.0933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (334, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'14/6/2025 15:21:40', N'15/6/2025 15:28:54', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T18:28:54.1100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (335, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'15/6/2025 15:28:54', N'15/6/2025 15:28:56', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T18:28:56.9533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (336, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Permisos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (337, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Email', NULL, N'christian.chamulla@crm.com', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (338, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Nombre', NULL, N'christian', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (339, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Apellido', NULL, N'chamulla', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (340, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Password', NULL, N'123', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (341, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Legajo', NULL, N'23230', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (342, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'FechaAlta', NULL, N'16/6/2025 14:23:38', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (343, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'Roles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (344, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'NombreDeLosRoles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (345, N'Usuario', N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'UltimoRolId', NULL, N'0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:38.0800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (346, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Permisos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (347, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Email', NULL, N'ale.duran@crm.com', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (348, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Nombre', NULL, N'ale', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (349, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Apellido', NULL, N'duran', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (350, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Password', NULL, N'123', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (351, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Legajo', NULL, N'333', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (352, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'FechaAlta', NULL, N'16/6/2025 14:51:53', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (353, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'Roles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (354, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'NombreDeLosRoles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (355, N'Usuario', N'e4d68b97-50de-47fd-a129-153af2b205b9', N'UltimoRolId', NULL, N'0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:51:53.2900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (356, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'FechaCreacion', NULL, N'16/6/2025 15:16:28', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (357, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'FechaUltimaModif', NULL, N'16/6/2025 15:16:28', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (358, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5133333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (359, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Asunto', NULL, N'adsada', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (360, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Descripcion', NULL, N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (361, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (362, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (363, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (364, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (365, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (366, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (367, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (368, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (369, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (370, N'Ticket', N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:29.5533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (371, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'FechaCreacion', NULL, N'16/6/2025 15:16:33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9133333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (372, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'FechaUltimaModif', NULL, N'16/6/2025 15:16:33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (373, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (374, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Asunto', NULL, N'adsada', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (375, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Descripcion', NULL, N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (376, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (377, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (378, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (379, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (380, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (381, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (382, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (383, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (384, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (385, N'Ticket', N'd498d095-90c2-4a6d-ab44-481674399f34', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:16:33.9500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (386, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'FechaCreacion', NULL, N'16/6/2025 15:19:01', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (387, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'FechaUltimaModif', NULL, N'16/6/2025 15:19:01', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (388, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (389, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Asunto', NULL, N'adsada', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (390, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Descripcion', NULL, N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (391, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (392, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (393, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (394, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (395, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (396, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (397, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (398, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (399, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (400, N'Ticket', N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:01.5533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (401, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'FechaCreacion', NULL, N'16/6/2025 15:20:33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (402, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'FechaUltimaModif', NULL, N'16/6/2025 15:20:33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (403, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (404, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Asunto', NULL, N'adsada', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (405, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Descripcion', NULL, N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (406, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (407, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (408, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (409, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (410, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (411, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (412, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (413, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (414, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4666667' AS DateTime2), N'I')
GO
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (415, N'Ticket', N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:20:33.4700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (416, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaCreacion', NULL, N'16/6/2025 15:21:41', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.7900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (417, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaUltimaModif', NULL, N'16/6/2025 15:21:41', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.7966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (418, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.7966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (419, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Asunto', NULL, N'adsada', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (420, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Descripcion', NULL, N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (421, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (422, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8133333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (423, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (424, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (425, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (426, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (427, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (428, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (429, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (430, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:34:49.8433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (431, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'FechaCreacion', NULL, N'16/6/2025 16:03:57', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (432, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'FechaUltimaModif', NULL, N'16/6/2025 16:03:57', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (433, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (434, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Asunto', NULL, N'ppp', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (435, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Descripcion', NULL, N'ppp', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (436, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (437, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (438, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'CategoriaId', NULL, N'11', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (439, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (440, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'PrioridadId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (441, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (442, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (443, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'GrupoTecnicoId', NULL, N'1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (444, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.3966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (445, N'Ticket', N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:03:57.4000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (446, N'Ticket', N'25272a61-3926-44cf-9246-3f77ed0faed2', N'FechaUltimaModif', N'14/6/2025 14:41:47', N'16/6/2025 16:23:49', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T19:23:49.5266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (447, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'FechaCreacion', NULL, N'16/6/2025 17:14:21', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (448, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'FechaUltimaModif', NULL, N'16/6/2025 17:14:21', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (449, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (450, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Asunto', NULL, N'prueba 333', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (451, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Descripcion', NULL, N'prueba444', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (452, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (453, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (454, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'CategoriaId', NULL, N'17', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (455, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Categoria', NULL, N'{"CategoriaId":"17","Nombre":"Investigación de Nuevas Tecnologías Emergentes","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Investigación y análisis de nuevas tecnologías para su posible implementación en la empresa.","tipoCategoria":"Incidente","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (456, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'PrioridadId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0933333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (457, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Prioridad', NULL, N'{"Id":"5","Nombre":"Urgente","Descripcion":"Prioridad urgente: situación excepcionalmente prioritaria"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.0966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (458, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'EstadoId', NULL, N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.1000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (459, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'GrupoTecnicoId', NULL, N'7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.1033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (460, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.1066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (461, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:14:21.1100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (462, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'FechaUltimaModif', N'16/6/2025 17:14:21', N'16/6/2025 17:16:08', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:16:08.3533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (463, N'Ticket', N'baff0091-3608-45f9-841c-b487e390cca4', N'PrioridadId', N'5', N'3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:16:08.3566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (464, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'FechaUltimaModif', N'10/6/2025 20:41:17', N'16/6/2025 17:24:33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:24:33.3700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (465, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'FechaCreacion', NULL, N'16/6/2025 17:48:09', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (466, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'FechaUltimaModif', NULL, N'16/6/2025 17:48:09', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (467, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Eliminado', NULL, N'False', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (468, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Asunto', NULL, N'fdsbfdbxdfsb', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (469, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Descripcion', NULL, N'hgjfgfhgfhgfhghcv', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (470, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'ClienteCreadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (471, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'ClienteCreador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (472, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'CategoriaId', NULL, N'14', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (473, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Categoria', NULL, N'{"CategoriaId":"14","Nombre":"Gestión de Ventas por Canal Digital","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Gestión de ventas online, seguimiento de pedidos y atención al cliente en el canal digital.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (474, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'PrioridadId', NULL, N'4', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (475, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Prioridad', NULL, N'{"Id":"4","Nombre":"Crítica","Descripcion":"Prioridad crítica: acción inmediata requerida"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (476, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'EstadoId', NULL, N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (477, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'GrupoTecnicoId', NULL, N'4', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (478, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Comentarios', NULL, N'[]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.8966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (479, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Historicos', NULL, N'[]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:09.9000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (480, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'FechaUltimaModif', N'16/6/2025 17:48:09', N'16/6/2025 17:48:44', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:44.3200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (481, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'CategoriaId', N'14', N'12', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:44.3266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (482, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'PrioridadId', N'4', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:48:44.3300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (483, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'FechaUltimaModif', N'16/6/2025 17:48:44', N'16/6/2025 17:59:11', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:59:11.5800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (484, N'Ticket', N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'Descripcion', N'hgjfgfhgfhgfhghcv', N'hgjfgfhgfhgfhghcvasdsa', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:59:11.5833333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (485, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'FechaUltimaModif', N'1/6/2025 19:01:17', N'16/6/2025 18:11:16', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:11:16.9400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (486, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Asunto', N'p', N'pelotudo', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:11:16.9466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (487, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Descripcion', N'p', N'pelotudopelotudo', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:11:16.9500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (488, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'CategoriaId', N'27', N'15', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:11:16.9566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (489, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'PrioridadId', N'4', N'2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:11:16.9600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (490, N'Ticket', N'7cd9bc46-4bed-4afd-a3f0-7ca0f5a935e4', N'FechaUltimaModif', N'19/5/2025 23:23:03', N'16/6/2025 18:14:44', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:14:44.7966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (491, N'Ticket', N'7cd9bc46-4bed-4afd-a3f0-7ca0f5a935e4', N'Descripcion', N'prueba ligimat es buena', N'sdfds', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:14:44.8033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (492, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'DigitoVerificadorH', NULL, N'84', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (493, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'FechaCreacion', N'1/1/0001 00:00:00', N'1/6/2025 21:49:57', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (494, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 19:54:15', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (495, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Asunto', NULL, N'test', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (496, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Descripcion', NULL, N'test', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (497, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'ClienteCreadorId', N'0', N'5', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (498, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (499, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'CategoriaId', N'0', N'26', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (500, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Categoria', NULL, N'{"CategoriaId":"26","Nombre":"prueba 12","FechaCreacion":"4/5/2025 21:40:20","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"prueba 12","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Ramírez, Claudia","Eliminado":"False","Estado":"False"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (501, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'PrioridadId', N'0', N'1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (502, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (503, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'EstadoId', N'6', N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (504, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (505, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'UsuarioAprobadorId', NULL, N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (506, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'UsuarioAprobador', NULL, N'{"ClienteId":"2","Telefono":"011-6789012","Direccion":"Av. Siempreviva 742","EmailContacto":"claudia.ramirez@crm.com","PreferenciaContacto":"Teléfono","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Claudia Ramírez","NombreListado":"Ramírez, Claudia","Email":"claudia.ramirez@crm.com","Nombre":"Claudia","Apellido":"Ramírez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"cr_107","Legajo":"107","FechaAlta":"8/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"f574033a-cd6a-426f-a35e-4dfdcc22568c"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (507, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'GrupoTecnicoId', NULL, N'1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (508, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'GrupoTecnico', NULL, N'{"GrupoId":"1","Nombre":"Grupo Helpdesk Nivel 1","Descripcion":"Grupo especializado en soporte de primer nivel","TecnicoLiderId":"1","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (509, N'Ticket', N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'Comentarios', N'[]', N'[{"ComentarioId":"16","TicketId":"316a64ea-e572-4c9e-95b2-5c7d405a8339","UsuarioId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Texto":"prueba","Fecha":"1/6/2025 21:52:46","Eliminado":"False"},{"ComentarioId":"17","TicketId":"316a64ea-e572-4c9e-95b2-5c7d405a8339","UsuarioId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Texto":"prueba 2","Fecha":"1/6/2025 21:53:03","Eliminado":"False"}]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:54:15.9766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (510, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'FechaCreacion', NULL, N'16/6/2025 20:26:07', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (511, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'FechaUltimaModif', NULL, N'16/6/2025 20:26:07', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (512, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Eliminado', NULL, N'False', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (513, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Asunto', NULL, N'pruebadeAprobador1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (514, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Descripcion', NULL, N'pruebadeAprobador1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1500000' AS DateTime2), N'I')
GO
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (515, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'ClienteCreadorId', NULL, N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (516, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'ClienteCreador', NULL, N'{"ClienteId":"2","Telefono":"011-6789012","Direccion":"Av. Siempreviva 742","EmailContacto":"claudia.ramirez@crm.com","PreferenciaContacto":"Teléfono","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Claudia Ramírez","NombreListado":"Ramírez, Claudia","Email":"claudia.ramirez@crm.com","Nombre":"Claudia","Apellido":"Ramírez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"cr_107","Legajo":"107","FechaAlta":"8/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"f574033a-cd6a-426f-a35e-4dfdcc22568c"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (517, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'CategoriaId', NULL, N'11', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (518, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Categoria', NULL, N'{"CategoriaId":"11","Nombre":"Solicitud de Dispositivos Finales","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Proceso de solicitud y entrega de dispositivos tecnológicos para empleados y áreas de trabajo.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (519, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'PrioridadId', NULL, N'1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (520, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (521, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'EstadoId', NULL, N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (522, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'GrupoTecnicoId', NULL, N'1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (523, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Comentarios', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (524, N'Ticket', N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'Historicos', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:26:07.1900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (525, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'FechaCreacion', NULL, N'16/6/2025 20:27:38', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (526, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'FechaUltimaModif', NULL, N'16/6/2025 20:27:38', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (527, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Eliminado', NULL, N'False', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (528, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Asunto', NULL, N'aprobame Andres', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (529, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Descripcion', NULL, N'aprobame Andres', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (530, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'ClienteCreadorId', NULL, N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3933333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (531, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'ClienteCreador', NULL, N'{"ClienteId":"2","Telefono":"011-6789012","Direccion":"Av. Siempreviva 742","EmailContacto":"claudia.ramirez@crm.com","PreferenciaContacto":"Teléfono","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Claudia Ramírez","NombreListado":"Ramírez, Claudia","Email":"claudia.ramirez@crm.com","Nombre":"Claudia","Apellido":"Ramírez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"cr_107","Legajo":"107","FechaAlta":"8/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"f574033a-cd6a-426f-a35e-4dfdcc22568c"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.3966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (532, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'CategoriaId', NULL, N'27', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (533, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (534, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'PrioridadId', NULL, N'3', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (535, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (536, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'EstadoId', NULL, N'6', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (537, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'UsuarioAprobadorId', NULL, N'3', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (538, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"null","Direccion":"null","EmailContacto":"null","PreferenciaContacto":"null","Estado":"False","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (539, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'GrupoTecnicoId', NULL, N'3', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (540, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Comentarios', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (541, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Historicos', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T23:27:38.4333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (542, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'DigitoVerificadorH', NULL, N'79', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (543, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'FechaCreacion', N'1/1/0001 00:00:00', N'16/6/2025 20:27:38', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (544, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:29:10', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (545, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'FechaCierre', NULL, N'16/6/2025 20:29:10', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (546, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Asunto', NULL, N'aprobame Andres', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (547, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Descripcion', NULL, N'aprobame Andres', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (548, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'ClienteCreadorId', N'0', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (549, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'ClienteCreador', NULL, N'{"ClienteId":"2","Telefono":"011-6789012","Direccion":"Av. Siempreviva 742","EmailContacto":"claudia.ramirez@crm.com","PreferenciaContacto":"Teléfono","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Claudia Ramírez","NombreListado":"Ramírez, Claudia","Email":"claudia.ramirez@crm.com","Nombre":"Claudia","Apellido":"Ramírez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"cr_107","Legajo":"107","FechaAlta":"8/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"f574033a-cd6a-426f-a35e-4dfdcc22568c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (550, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (551, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (552, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (553, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (554, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'EstadoId', N'6', N'7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (555, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (556, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (557, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (558, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (559, N'Ticket', N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:29:10.8733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (560, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'DigitoVerificadorH', NULL, N'67', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (561, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'FechaCreacion', N'1/1/0001 00:00:00', N'18/5/2025 00:59:29', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (562, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:34:53', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (563, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Asunto', NULL, N'pelotudo', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (564, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Descripcion', NULL, N'pelotudopelotudo', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (565, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'ClienteCreadorId', N'0', N'5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (566, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (567, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'CategoriaId', N'0', N'15', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (568, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Categoria', NULL, N'{"CategoriaId":"15","Nombre":"Control de Calidad de Productos Fabricados","FechaCreacion":"28/9/2024 11:39:32","CreadorId":"d54f071e-4db5-4d4f-9f4b-ff2ac5bdf738","Descripcion":"Supervisión y control de calidad de los productos fabricados en la línea de producción.","tipoCategoria":"Requerimiento","AprobadorRequerido":"False","NombreClienteAprobador":"","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (569, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'PrioridadId', N'0', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (570, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Prioridad', NULL, N'{"Id":"2","Nombre":"Media","Descripcion":"Prioridad media: impacto y urgencia moderados"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (571, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (572, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (573, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (574, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:53.6433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (575, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'DigitoVerificadorH', NULL, N'93', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (576, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'FechaCreacion', N'1/1/0001 00:00:00', N'18/5/2025 01:00:25', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (577, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:34:56', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7833333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (578, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Asunto', NULL, N'prueba de aprobador 2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7833333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (579, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Descripcion', NULL, N'prueba de aprobador', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (580, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'ClienteCreadorId', N'0', N'5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (581, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (582, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (583, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.7966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (584, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (585, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (586, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (587, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (588, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (589, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (590, N'Ticket', N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'Comentarios', N'[]', N'[{"ComentarioId":"13","TicketId":"687ee4c4-ed4e-4b64-bc0b-1c988dc661aa","UsuarioId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Texto":"aprobar con urgencia","Fecha":"1/6/2025 21:35:31","Eliminado":"False"},{"ComentarioId":"14","TicketId":"687ee4c4-ed4e-4b64-bc0b-1c988dc661aa","UsuarioId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Texto":"prueba de aprobacion","Fecha":"1/6/2025 21:36:01","Eliminado":"False"}]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:34:56.8133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (591, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'DigitoVerificadorH', NULL, N'57', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (592, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'FechaCreacion', N'1/1/0001 00:00:00', N'18/5/2025 01:11:35', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (593, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:35:00', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (594, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'FechaCierre', NULL, N'16/6/2025 20:35:00', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (595, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'Asunto', NULL, N'Prueba', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (596, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'Descripcion', NULL, N'marico', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (597, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'ClienteCreadorId', N'0', N'5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (598, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (599, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (600, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (601, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (602, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (603, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'EstadoId', N'6', N'7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (604, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (605, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (606, N'Ticket', N'b7827297-7f2f-47c1-87b4-960581366ba5', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:00.3500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (607, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'DigitoVerificadorH', NULL, N'74', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (608, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'FechaCreacion', N'1/1/0001 00:00:00', N'18/5/2025 12:49:35', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (609, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:35:03', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (610, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'FechaCierre', NULL, N'16/6/2025 20:35:03', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (611, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'Asunto', NULL, N'Crear una Vnet', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (612, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'Descripcion', NULL, N'necesito crear una vnet porque la mia no existe', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7833333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (613, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'ClienteCreadorId', N'0', N'5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (614, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7900000' AS DateTime2), N'U')
GO
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (615, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (616, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (617, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (618, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.7966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (619, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'EstadoId', N'6', N'7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (620, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (621, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (622, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (623, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (624, N'Ticket', N'48910441-4d2d-45c4-9109-778abca1f347', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:03.8100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (625, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'DigitoVerificadorH', NULL, N'37', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (626, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'FechaCreacion', N'1/1/0001 00:00:00', N'18/5/2025 01:18:22', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (627, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'16/6/2025 20:35:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (628, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'FechaCierre', NULL, N'16/6/2025 20:35:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (629, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'Asunto', NULL, N'Prueba 14', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (630, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'Descripcion', NULL, N'Prueba 14', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.2966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (631, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'ClienteCreadorId', N'0', N'5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (632, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (633, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (634, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (635, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (636, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (637, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'EstadoId', N'6', N'7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (638, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (639, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (640, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (641, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (642, N'Ticket', N'8f678b46-76fc-4207-bacc-e321287441b8', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T23:35:04.3200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (643, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'FechaCreacion', NULL, N'16/6/2025 22:07:40', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.1700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (644, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'FechaUltimaModif', NULL, N'16/6/2025 22:07:40', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.1833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (645, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Eliminado', NULL, N'False', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.1866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (646, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Asunto', NULL, N'pruebadebandeja', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.1900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (647, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Descripcion', NULL, N'pruebadebandeja', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.1966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (648, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'ClienteCreadorId', NULL, N'2', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (649, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'ClienteCreador', NULL, N'{"ClienteId":"2","Telefono":"011-6789012","Direccion":"Av. Siempreviva 742","EmailContacto":"claudia.ramirez@crm.com","PreferenciaContacto":"Teléfono","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Claudia Ramírez","NombreListado":"Ramírez, Claudia","Email":"claudia.ramirez@crm.com","Nombre":"Claudia","Apellido":"Ramírez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"cr_107","Legajo":"107","FechaAlta":"8/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"f574033a-cd6a-426f-a35e-4dfdcc22568c"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (650, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'CategoriaId', NULL, N'30', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (651, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Categoria', NULL, N'{"CategoriaId":"30","Nombre":"categoriaParaProbar","FechaCreacion":"16/6/2025 21:59:50","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"categoriaParaProbar","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (652, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'PrioridadId', NULL, N'1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (653, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Prioridad', NULL, N'{"Id":"1","Nombre":"Baja","Descripcion":"Prioridad baja: bajo impacto y urgencia"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (654, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'EstadoId', NULL, N'6', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (655, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'UsuarioAprobadorId', NULL, N'3', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (656, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"null","Direccion":"null","EmailContacto":"null","PreferenciaContacto":"null","Estado":"False","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2333333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (657, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'GrupoTecnicoId', NULL, N'12', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (658, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Comentarios', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (659, N'Ticket', N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'Historicos', NULL, N'[]', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-17T01:07:40.2466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (660, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'15/6/2025 15:28:56', N'16/6/2025 23:07:30', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:07:30.9366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (661, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'TecnicoId', NULL, N'1', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:07:30.9500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (662, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:07:30', N'16/6/2025 23:07:48', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:07:48.1733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (663, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:07:48', N'16/6/2025 23:09:57', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:09:57.5433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (664, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaUltimaModif', N'16/6/2025 15:21:41', N'16/6/2025 23:13:24', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:13:24.4800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (665, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'TecnicoId', NULL, N'23', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:13:24.4866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (666, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:09:57', N'16/6/2025 23:13:42', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:13:42.1000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (667, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:13:42', N'16/6/2025 23:14:08', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:14:08.1000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (668, N'Ticket', N'25272a61-3926-44cf-9246-3f77ed0faed2', N'FechaUltimaModif', N'16/6/2025 16:23:49', N'16/6/2025 23:15:30', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:15:30.6300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (669, N'Ticket', N'25272a61-3926-44cf-9246-3f77ed0faed2', N'TecnicoId', NULL, N'1', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:15:30.6366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (670, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:14:08', N'16/6/2025 23:16:36', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:16:36.5966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (671, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:16:36', N'16/6/2025 23:25:40', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:25:43.9166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (672, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:25:40', N'16/6/2025 23:36:19', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:36:31.0933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (673, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"1","Nombre":"En espera","Descripcion":"El ticket está en espera de revisión"}', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:36:31.1100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (674, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:36:19', N'16/6/2025 23:41:35', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:41:49.3633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (675, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"1","Nombre":"En espera","Descripcion":"El ticket está en espera de revisión"}', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-17T02:41:49.3733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (676, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:41:35', N'16/6/2025 23:45:30', N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', CAST(N'2025-06-17T02:45:39.0566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (677, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'EstadoId', N'2', N'1', N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', CAST(N'2025-06-17T02:45:39.0700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (678, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"1","Nombre":"En espera","Descripcion":"El ticket está en espera de revisión"}', N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', CAST(N'2025-06-17T02:45:39.0766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (679, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'16/6/2025 23:45:30', N'17/6/2025 00:03:30', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:03:37.2066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (680, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'17/6/2025 00:03:30', N'17/6/2025 00:03:45', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:03:45.0800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (681, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'17/6/2025 00:03:45', N'17/6/2025 00:06:16', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:06:16.7766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (682, N'Ticket', N'a1225313-28fd-42de-8a75-220dbc6cb574', N'FechaUltimaModif', N'17/6/2025 00:06:16', N'17/6/2025 00:06:18', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:06:18.8066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (683, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'FechaUltimaModif', N'16/6/2025 20:34:53', N'17/6/2025 00:13:36', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:36.1133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (684, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Asunto', N'pelotudo', N'prueba de ticket', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:36.1200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (685, N'Ticket', N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'Descripcion', N'pelotudopelotudo', N'prueba de ticket', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:36.1233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (686, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaUltimaModif', N'16/6/2025 23:13:24', N'17/6/2025 00:13:54', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:54.9266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (687, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Asunto', N'adsada', N'hola', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:54.9300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (688, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Descripcion', N'asdsadsa', N'hola', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:13:54.9366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (689, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'Descripcion', N'hola', N'asdsadsa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:14:24.1400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (690, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaUltimaModif', N'17/6/2025 00:13:54', N'17/6/2025 00:14:24', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:14:24.1466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (691, N'Ticket', N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'FechaUltimaModif', N'17/6/2025 00:14:24', N'17/6/2025 00:14:25', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:14:25.9133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (692, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'FechaUltimaModif', N'16/6/2025 17:24:33', N'17/6/2025 00:15:52', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:15:52.1700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (693, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'Asunto', N'javier.gomez@crm.com', N'Asunto Generico', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:15:52.1733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (694, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'Descripcion', N'javier.gomez@crm.com', N'Descripcion Generica', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:15:52.1800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (695, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'Descripcion', N'Descripcion Generica', N'javier.gomez@crm.com', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:16:15.5666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (696, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'FechaUltimaModif', N'17/6/2025 00:15:52', N'17/6/2025 00:16:15', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:16:15.5700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (697, N'Ticket', N'ef97b23b-9e20-4c09-8b1d-209d9747d402', N'FechaUltimaModif', N'17/6/2025 00:16:15', N'17/6/2025 00:16:16', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:16:16.9233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (698, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'FechaCreacion', NULL, N'17/6/2025 00:18:00', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (699, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'FechaUltimaModif', NULL, N'17/6/2025 00:18:00', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (700, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Eliminado', NULL, N'False', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (701, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Asunto', NULL, N'crear Vnet para la IP 192.168.1.', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7433333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (702, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Descripcion', NULL, N'se solicita crear la vnet del asunto', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7466667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (703, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'ClienteCreadorId', NULL, N'5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (704, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'ClienteCreador', NULL, N'{"ClienteId":"5","Telefono":"null","Direccion":"Florida 1070","EmailContacto":"javier.gomez@crm.com","PreferenciaContacto":"null","Estado":"True","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Javier Gomez","NombreListado":"Gomez, Javier","Email":"javier.gomez@crm.com","Nombre":"Javier","Apellido":"Gomez","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"jg_112","Legajo":"1222","FechaAlta":"1/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7500000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (705, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'CategoriaId', NULL, N'27', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7533333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (706, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7566667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (707, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'PrioridadId', NULL, N'3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (708, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7633333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (709, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'EstadoId', NULL, N'6', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (710, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'UsuarioAprobadorId', NULL, N'3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (711, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"null","Direccion":"null","EmailContacto":"null","PreferenciaContacto":"null","Estado":"False","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (712, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'GrupoTecnicoId', NULL, N'3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (713, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Comentarios', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (714, N'Ticket', N'ce57938b-8daf-4817-acb8-fe470abb480b', N'Historicos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:18:00.7900000' AS DateTime2), N'I')
GO
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (715, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Permisos', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (716, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Email', NULL, N'ligimat.dugarte@crm.com', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (717, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Nombre', NULL, N'Ligimat', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (718, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Apellido', NULL, N'Dugarte', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (719, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Password', NULL, N'123', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (720, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Legajo', NULL, N'9', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (721, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'FechaAlta', NULL, N'17/6/2025 00:21:21', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (722, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'Roles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (723, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'NombreDeLosRoles', NULL, N'[]', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7366667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (724, N'Usuario', N'75823e87-7292-4817-bef7-8d73f2137f1c', N'UltimoRolId', NULL, N'0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T03:21:21.7400000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (725, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaCreacion', NULL, N'17/6/2025 00:27:04', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.6866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (726, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', NULL, N'17/6/2025 00:27:04', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.6900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (727, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Eliminado', NULL, N'False', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.6900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (728, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Asunto', NULL, N'Se necesita crear la vnet del puerto 808', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.6933333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (729, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Descripcion', NULL, N'revisar asunto', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.6966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (730, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreadorId', NULL, N'9', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (731, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (732, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'CategoriaId', NULL, N'27', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (733, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (734, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'PrioridadId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7133333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (735, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (736, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', NULL, N'6', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (737, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobadorId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (738, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"null","Direccion":"null","EmailContacto":"null","PreferenciaContacto":"null","Estado":"False","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (739, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnicoId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7266667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (740, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Comentarios', NULL, N'[]', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (741, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Historicos', NULL, N'[]', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:27:04.7300000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (742, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'DigitoVerificadorH', NULL, N'72', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (743, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaCreacion', N'1/1/0001 00:00:00', N'17/6/2025 00:27:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (744, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'17/6/2025 00:28:43', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (745, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Asunto', NULL, N'Se necesita crear la vnet del puerto 808', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (746, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Descripcion', NULL, N'revisar asunto', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (747, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreadorId', N'0', N'9', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (748, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (749, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (750, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.6933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (751, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (752, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (753, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (754, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (755, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (756, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (757, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (758, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:28:43.7300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (759, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:28:43', N'17/6/2025 00:33:28', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:33:28.1966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (760, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'2', N'6', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:33:28.2133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (761, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'DigitoVerificadorH', NULL, N'58', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.6833333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (762, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaCreacion', N'1/1/0001 00:00:00', N'17/6/2025 00:27:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.6866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (763, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'17/6/2025 00:34:38', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.6933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (764, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Asunto', NULL, N'Se necesita crear la vnet del puerto 808', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.6966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (765, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Descripcion', NULL, N'revisar asunto', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (766, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreadorId', N'0', N'9', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7033333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (767, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (768, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (769, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (770, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (771, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (772, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (773, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (774, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (775, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (776, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (777, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (778, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Comentarios', N'[]', N'[{"ComentarioId":"31","TicketId":"3bed5285-ea4f-4775-b79c-3c25c12f4449","UsuarioId":"75823e87-7292-4817-bef7-8d73f2137f1c","Texto":"darle celeridad al pedido","Fecha":"17/6/2025 00:33:17","Eliminado":"False"}]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:34:38.7533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (779, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:34:38', N'17/6/2025 00:35:52', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:35:52.1100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (780, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'2', N'6', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:35:52.1166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (781, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'DigitoVerificadorH', NULL, N'74', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (782, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaCreacion', N'1/1/0001 00:00:00', N'17/6/2025 00:27:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (783, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'17/6/2025 00:38:09', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (784, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Asunto', NULL, N'Se necesita crear la vnet del puerto 808', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (785, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Descripcion', NULL, N'revisar asunto', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (786, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreadorId', N'0', N'9', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (787, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (788, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (789, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (790, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (791, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (792, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (793, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (794, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (795, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (796, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (797, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (798, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Comentarios', N'[]', N'[{"ComentarioId":"31","TicketId":"3bed5285-ea4f-4775-b79c-3c25c12f4449","UsuarioId":"75823e87-7292-4817-bef7-8d73f2137f1c","Texto":"darle celeridad al pedido","Fecha":"17/6/2025 00:33:17","Eliminado":"False"}]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:38:09.1800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (799, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:38:09', N'17/6/2025 00:41:49', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:41:49.9633333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (800, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'2', N'6', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:41:49.9666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (801, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"4","Nombre":"Resuelto","Descripcion":"El ticket ha sido resuelto"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:41:49.9733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (802, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'TecnicoId', NULL, N'23', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:41:49.9766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (803, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:41:49', N'17/6/2025 00:42:21', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:21.6866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (804, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'{"EstadoId":"4","Nombre":"Resuelto","Descripcion":"El ticket ha sido resuelto"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:21.6933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (805, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:42:21', N'17/6/2025 00:42:41', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:41.1400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (806, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'{"EstadoId":"4","Nombre":"Resuelto","Descripcion":"El ticket ha sido resuelto"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:41.1433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (807, N'Ticket', N'352457fc-7575-461c-b9af-9effc0fbbcff', N'FechaUltimaModif', N'18/5/2025 12:26:25', N'17/6/2025 00:42:58', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:58.1066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (808, N'Ticket', N'352457fc-7575-461c-b9af-9effc0fbbcff', N'EstadoId', N'2', N'4', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:58.1100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (809, N'Ticket', N'352457fc-7575-461c-b9af-9effc0fbbcff', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"4","Nombre":"Resuelto","Descripcion":"El ticket ha sido resuelto"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:58.1133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (810, N'Ticket', N'352457fc-7575-461c-b9af-9effc0fbbcff', N'TecnicoId', NULL, N'23', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:42:58.1166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (811, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:42:41', N'17/6/2025 00:43:25', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:43:25.7733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (812, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'{"EstadoId":"4","Nombre":"Resuelto","Descripcion":"El ticket ha sido resuelto"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:43:25.7800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (813, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'DigitoVerificadorH', NULL, N'68', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (814, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaCreacion', N'1/1/0001 00:00:00', N'17/6/2025 00:27:04', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0066667' AS DateTime2), N'U')
GO
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (815, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'17/6/2025 00:45:25', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (816, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Asunto', NULL, N'Se necesita crear la vnet del puerto 808', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (817, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Descripcion', NULL, N'revisar asunto', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (818, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreadorId', N'0', N'9', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (819, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (820, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (821, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (822, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (823, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (824, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (825, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (826, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (827, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0500000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (828, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0533333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (829, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0566667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (830, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'TecnicoId', NULL, N'23', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (831, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'TecnicoAsignado', NULL, N'{"TecnicoId":"23","DepartamentoId":"0","EstaActivo":"True","FechaIngreso":"1/6/2025 23:46:47","Especialidad":"null","NombreCompleto":"pruebadetecnico2 pruebadetecnico2","Email":"pruebadetecnico2@crm.com","Nombre":"pruebadetecnico2","Apellido":"pruebadetecnico2","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","NombreListado":"pruebadetecnico2, pruebadetecnico2","DigitoVerificadorH":"null","Id":"fed36346-aed4-48fb-b3aa-f5ead9f0b7e4"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (832, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Comentarios', N'[]', N'[{"ComentarioId":"31","TicketId":"3bed5285-ea4f-4775-b79c-3c25c12f4449","UsuarioId":"75823e87-7292-4817-bef7-8d73f2137f1c","Texto":"darle celeridad al pedido","Fecha":"17/6/2025 00:33:17","Eliminado":"False"},{"ComentarioId":"32","TicketId":"3bed5285-ea4f-4775-b79c-3c25c12f4449","UsuarioId":"75823e87-7292-4817-bef7-8d73f2137f1c","Texto":"se resuelve","Fecha":"17/6/2025 00:41:46","Eliminado":"False"}]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:45:26.0733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (833, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:45:25', N'17/6/2025 00:50:30', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:30.2300000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (834, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'EstadoId', N'2', N'6', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:30.2400000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (835, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"2","Nombre":"Derivado","Descripcion":"El ticket ha sido derivado a otro departamento"}', N'{"EstadoId":"1","Nombre":"En espera","Descripcion":"El ticket está en espera de revisión"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:30.2433333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (836, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'TecnicoId', N'23', N'22', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:30.2466667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (837, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'FechaUltimaModif', N'17/6/2025 00:50:30', N'17/6/2025 00:50:47', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:47.5333333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (838, N'Ticket', N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'Estado', N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'{"EstadoId":"1","Nombre":"En espera","Descripcion":"El ticket está en espera de revisión"}', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:50:47.5366667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (839, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'FechaCreacion', NULL, N'17/6/2025 00:54:21', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1600000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (840, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'FechaUltimaModif', NULL, N'17/6/2025 00:54:21', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1666667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (841, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Eliminado', NULL, N'False', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1700000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (842, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Asunto', NULL, N'puerto 4949', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1733333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (843, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Descripcion', NULL, N'puerto 4949', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1766667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (844, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'ClienteCreadorId', NULL, N'9', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1800000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (845, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1833333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (846, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'CategoriaId', NULL, N'27', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1866667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (847, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1900000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (848, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'PrioridadId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.1966667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (849, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2000000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (850, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'EstadoId', NULL, N'6', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2033333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (851, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'UsuarioAprobadorId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2066667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (852, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"null","Direccion":"null","EmailContacto":"null","PreferenciaContacto":"null","Estado":"False","Observaciones":"null","EsAprobador":"False","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"null","NombreUsuario":"null","Legajo":"0","FechaAlta":"1/1/0001 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2100000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (853, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'GrupoTecnicoId', NULL, N'3', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2166667' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (854, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Comentarios', NULL, N'[]', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2200000' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (855, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Historicos', NULL, N'[]', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T03:54:21.2233333' AS DateTime2), N'I')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (856, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'DigitoVerificadorH', NULL, N'78', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3600000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (857, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'FechaCreacion', N'1/1/0001 00:00:00', N'17/6/2025 00:54:21', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3666667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (858, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'FechaUltimaModif', N'1/1/0001 00:00:00', N'17/6/2025 00:56:02', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3700000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (859, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Asunto', NULL, N'puerto 4949', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3733333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (860, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Descripcion', NULL, N'puerto 4949', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3766667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (861, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'ClienteCreadorId', N'0', N'9', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (862, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'ClienteCreador', NULL, N'{"ClienteId":"9","Telefono":"11333222323","Direccion":"Lavalle 322","EmailContacto":"ligimat.dugarte@crm.com","PreferenciaContacto":"-","Estado":"True","Observaciones":"-","EsAprobador":"False","NombreCompleto":"Ligimat Dugarte","NombreListado":"Dugarte, Ligimat","Email":"ligimat.dugarte@crm.com","Nombre":"Ligimat","Apellido":"Dugarte","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"LD_9","Legajo":"9","FechaAlta":"17/6/2025 00:21:21","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"75823e87-7292-4817-bef7-8d73f2137f1c"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (863, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'CategoriaId', N'0', N'27', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3900000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (864, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Categoria', NULL, N'{"CategoriaId":"27","Nombre":"crear vnets","FechaCreacion":"5/5/2025 20:06:12","CreadorId":"2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6","Descripcion":"crear vnets","tipoCategoria":"Requerimiento","AprobadorRequerido":"True","NombreClienteAprobador":"Díaz, Andrés","Eliminado":"False","Estado":"False"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3933333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (865, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'PrioridadId', N'0', N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.3966667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (866, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Prioridad', NULL, N'{"Id":"3","Nombre":"Alta","Descripcion":"Prioridad alta: alto impacto y necesidad inmediata"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4000000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (867, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'EstadoId', N'6', N'2', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4066667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (868, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Estado', NULL, N'{"EstadoId":"6","Nombre":"En Aprobacion","Descripcion":"El ticket está en proceso de aprobación"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4100000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (869, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'UsuarioAprobadorId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4133333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (870, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'UsuarioAprobador', NULL, N'{"ClienteId":"3","Telefono":"011-2345678","Direccion":"Pasaje Lunar 456","EmailContacto":"andres.diaz@crm.com","PreferenciaContacto":"Email","Estado":"True","Observaciones":"Alta automática por rol Cliente.","EsAprobador":"True","NombreCompleto":"Andrés Díaz","NombreListado":"Díaz, Andrés","Email":"andres.diaz@crm.com","Nombre":"Andrés","Apellido":"Díaz","Password":"pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=","NombreUsuario":"ad_103","Legajo":"103","FechaAlta":"13/1/2024 00:00:00","UltimoRolId":"0","DigitoVerificadorH":"null","Id":"4f926bcd-3858-4ac9-a310-8715fdd04858"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4166667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (871, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'GrupoTecnicoId', NULL, N'3', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4200000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (872, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'GrupoTecnico', NULL, N'{"GrupoId":"3","Nombre":"Grupo Aplicaciones","Descripcion":"Soporte funcional y técnico de sistemas internos","TecnicoLiderId":"3","Activo":"True","Eliminado":"False","FechaCreacion":"12/5/2025 00:49:45"}', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4233333' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (873, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'Comentarios', N'[]', N'[{"ComentarioId":"35","TicketId":"f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7","UsuarioId":"75823e87-7292-4817-bef7-8d73f2137f1c","Texto":"DARLE CELERIDAD AL ASUNTO","Fecha":"17/6/2025 00:54:47","Eliminado":"False"}]', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T03:56:02.4266667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (874, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'FechaUltimaModif', N'17/6/2025 00:56:02', N'17/6/2025 00:56:55', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:56:55.5800000' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (875, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'EstadoId', N'2', N'4', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:56:55.5866667' AS DateTime2), N'U')
INSERT [dbo].[ControlDeCambios] ([LogId], [Tabla], [EntityId], [Propiedad], [ValorViejo], [ValorNuevo], [CambiadoPor], [FechaCambio], [TipoOperacion]) VALUES (876, N'Ticket', N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'TecnicoId', NULL, N'22', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T03:56:55.5900000' AS DateTime2), N'U')
SET IDENTITY_INSERT [dbo].[ControlDeCambios] OFF
GO
SET IDENTITY_INSERT [dbo].[departamento] ON 

INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (1, N'Recursos Humanos', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'RH-001', N'Gestiona los procesos de reclutamiento, selección y capacitación del personal.', 1, N'Edificio Central - Piso 2')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (2, N'Finanzas', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'FN-002', N'Se encarga de la gestión financiera, auditorías y análisis de presupuestos.', 1, N'Torre Administrativa - Piso 5')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (3, N'Marketing', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'MK-003', N'Crea y ejecuta campañas publicitarias para aumentar la visibilidad de la marca.', 1, N'Anexo Creativo - Piso 1')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (4, N'Ventas', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'VT-004', N'Gestiona las ventas de productos y servicios, tanto de forma presencial como digital.', 1, N'Oficina Comercial - Piso 3')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (5, N'Operaciones', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'OP-005', N'Supervisa y controla los procesos de producción para garantizar la calidad y eficiencia.', 1, N'Planta Principal - Piso 1')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (6, N'Tecnología', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'TI-006', N'Desarrolla y mantiene sistemas tecnológicos para optimizar procesos internos.', 1, N'Edificio IT - Piso 4')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (7, N'Investigación y Desarrollo', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'ID-007', N'Realiza investigación y desarrollo de nuevas tecnologías y productos innovadores.', 1, N'Laboratorio I+D - Piso 2')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (8, N'Atención al Cliente', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'AC-008', N'Ofrece soporte y atención al cliente, gestionando quejas y consultas.', 1, N'Centro de Atención - Piso 1')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (9, N'Legal', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'LG-009', N'Proporciona servicios legales y asegura el cumplimiento normativo.', 1, N'Torre Legal - Piso 6')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (10, N'Logística', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'LG-010', N'Coordina la logística de distribución, almacenamiento y transporte de productos.', 1, N'Depósito General - Zona B')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (11, N'Calidad', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'CL-011', N'Garantiza la calidad de los productos mediante inspecciones y pruebas rigurosas.', 1, N'Planta Principal - Piso 2')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (12, N'Compras', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'CM-012', N'Gestiona la adquisición de productos y servicios necesarios para la empresa.', 1, N'Torre Administrativa - Piso 3')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (13, N'Seguridad', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'SG-013', N'Vela por la seguridad de las instalaciones y el cumplimiento de las normas de seguridad.', 1, N'Puesto de Seguridad - Acceso Norte')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (14, N'Mantenimiento', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'MT-014', N'Realiza el mantenimiento preventivo y correctivo de los equipos y las instalaciones.', 1, N'Taller Técnico - Subsuelo')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (15, N'Proyectos', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'PR-015', N'Dirige y supervisa proyectos para asegurar su correcta ejecución y éxito.', 1, N'Oficina Ejecutiva - Piso 4')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (16, N'Contabilidad', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'CT-016', N'Gestiona la contabilidad de la empresa, realizando registros y análisis financieros.', 1, N'Torre Financiera - Piso 5')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (17, N'Relaciones Públicas', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'RP-017', N'Se encarga de la comunicación y relaciones públicas de la empresa.', 1, N'Sala de Prensa - Piso 1')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (18, N'Sistemas', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'SI-018', N'Administra y mantiene los sistemas de información y la infraestructura tecnológica.', 1, N'Edificio IT - Piso 3')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (19, N'Capacitación', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'CP-019', N'Coordina programas de capacitación y desarrollo para el personal de la empresa.', 1, N'Aula de Formación - Piso 2')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (20, N'Almacén', NULL, CAST(N'2024-09-27T22:30:31.337' AS DateTime), N'AL-020', N'Administra el almacenamiento de productos y coordina su distribución.', 1, N'Almacén Central - Zona A')
INSERT [dbo].[departamento] ([departamento_id], [nombre], [cliente_lider_id], [fecha_creacion], [codigo_departamento], [descripcion], [estado], [ubicacion]) VALUES (21, N'DepartamentoDePrueba', 2, CAST(N'2025-06-03T15:27:11.000' AS DateTime), N'1313', N'asaa', 1, N'ea')
SET IDENTITY_INSERT [dbo].[departamento] OFF
GO
INSERT [dbo].[DigitoVerificadorV] ([tabla], [valor_dv]) VALUES (N'Ticket', N'22')
INSERT [dbo].[DigitoVerificadorV] ([tabla], [valor_dv]) VALUES (N'Usuario', N'37')
GO
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'aaaaToolStripMenuItem1', N'frmPpalTecnico', N'aaaa')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'59254406-fca8-48cd-9ede-08b064febf0a', N'iconBtnAdministracion', N'frmPpalAdmin', N'Administracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'iconBtnConfiguracion', N'frmPpalAdmin', N'Configuracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'bbbbToolStripMenuItem', N'frmPpalTecnico', N'bbbb')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'648f4ddd-7753-46ee-a08a-201e210945b9', N'ddToolStripMenuItem1', N'frmPpalTecnico', N'dd')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'ddToolStripMenuItem2', N'frmPpalTecnico', N'dd')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'iconBtnAdministracion', N'frmPpalCliente', N'Administracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'lblTitulo', N'frmPpalTecnico', N'DASHBOARD')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'14efcf16-895a-46f6-a576-31860315bc12', N'ddToolStripMenuItem', N'frmPpalTecnico', N'dd')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'iconBtnConfiguracion', N'frmPpalCliente', N'Configuracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'inventarioToolStripMenuItem', N'frmPpalAdmin', N'Inventario')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'aaaToolStripMenuItem', N'frmPpalTecnico', N'aaa')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'69afc5e5-b0a1-4522-810d-354602018f4f', N'eeeToolStripMenuItem1', N'frmPpalTecnico', N'eee')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'lblTitulo', N'frmPpalCliente', N'DASHBOARD')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'iconBtnTickets', N'frmPpalAdmin', N'Tickets')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'borrarElementosToolStripMenuItem', N'frmPpalAdmin', N'Borrar elementos')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'miPerfilToolStripMenuItem', N'frmPpalAdmin', N'Mi Perfil')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'iconBtnDesloguear', N'frmPpalAdmin', N'Desloguear')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'cargarElementosToolStripMenuItem', N'frmPpalAdmin', N'Cargar elementos')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'iconBtnConfiguracion', N'frmPpalTecnico', N'Configuracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'cambiarRolToolStripMenuItem', N'frmPpalAdmin', N'Cambiar Rol')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'iconBtnDesloguear', N'frmPpalCliente', N'Desloguear')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'contactoSoporteToolStripMenuItem', N'frmPpalCliente', N'Contacto Soporte')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'iconBtnDepartamentos', N'frmPpalAdmin', N'Dashboard')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'ccccToolStripMenuItem', N'frmPpalTecnico', N'cccc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'cccToolStripMenuItem1', N'frmPpalTecnico', N'ccc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'339c85b1-5c87-456a-b254-6d5101949924', N'ccccToolStripMenuItem1', N'frmPpalTecnico', N'cccc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'cambiarRolToolStripMenuItem', N'frmPpalTecnico', N'Cambiar Rol')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'38bda55c-e4a4-4060-969c-71b22d100203', N'iconBtnTickets', N'frmPpalTecnico', N'Tickets')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'iconBtnGeneral', N'frmPpalTecnico', N'General')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'dddToolStripMenuItem', N'frmPpalTecnico', N'ddd')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'1f32ebdf-4407-407c-81a3-8090b4219408', N'MiCuentaToolStripMenuItem', N'frmPpalCliente', N'Mi cuenta')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'iconBtnDesloguear', N'frmPpalTecnico', N'Desloguear')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'dddToolStripMenuItem1', N'frmPpalTecnico', N'ddd')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9a585655-3017-482e-badd-87868b8e9aec', N'iconBtnAdministracion', N'frmPpalTecnico', N'Administracion')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'eeeToolStripMenuItem', N'frmPpalTecnico', N'eee')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'bbbToolStripMenuItem', N'frmPpalTecnico', N'bbb')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'cambiarRolToolStripMenuItem', N'frmPpalCliente', N'Cambiar Rol')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'lblTitulo', N'frmPpalAdmin', N'DASHBOARD')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'58164282-7f7a-4886-9f24-9809330e1b06', N'cToolStripMenuItem', N'frmPpalTecnico', N'c')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'4867bda0-5924-4216-bc24-987c351fd47a', N'ccToolStripMenuItem', N'frmPpalTecnico', N'cc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'datosPersonalesToolStripMenuItem', N'frmPpalCliente', N'Datos personales')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'cccToolStripMenuItem', N'frmPpalTecnico', N'ccc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'datosPersonalesToolStripMenuItem', N'frmPpalTecnico', N'Datos personales')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'ccccToolStripMenuItem2', N'frmPpalTecnico', N'cccc')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'bbbToolStripMenuItem1', N'frmPpalTecnico', N'bbb')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'verInventarioToolStripMenuItem', N'frmPpalAdmin', N'Ver inventario')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'miPerfilToolStripMenuItem', N'frmPpalTecnico', N'Mi Perfil')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'iconBtnDepartamentos', N'frmPpalCliente', N'Dashboard')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'3298851c-b245-4d6c-99dc-c0f293146edd', N'datosPersonalesToolStripMenuItem', N'frmPpalAdmin', N'Datos personales')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'iconBtnDepartamentos', N'frmPpalTecnico', N'Dashboard')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'modificarIdiomaToolStripMenuItem', N'frmPpalAdmin', N'Modificar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'ayudaToolStripMenuItem', N'frmPpalCliente', N'Ayuda')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'cambiarIdiomaToolStripMenuItem', N'frmPpalCliente', N'Cambiar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'cambiarIdiomaToolStripMenuItem', N'frmPpalAdmin', N'Cambiar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'266477e2-f731-4d0f-be49-db30ab16da35', N'iconBtnTickets', N'frmPpalCliente', N'Tickets')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'modificarElementosToolStripMenuItem', N'frmPpalAdmin', N'Modificar elementos')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'aaaToolStripMenuItem', N'frmPpalAdmin', N'Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'4be67089-ffab-431a-9964-e655278c3200', N'iconBtnGeneral', N'frmPpalAdmin', N'General')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'iconBtnGeneral', N'frmPpalCliente', N'General')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'miPerfilToolStripMenuItem', N'frmPpalCliente', N'Mi Perfil')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'borrarIdiomaToolStripMenuItem', N'frmPpalAdmin', N'Borrar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'43555468-80ed-4e22-9de2-f066f8bfc831', N'cambiarIdiomaToolStripMenuItem', N'frmPpalTecnico', N'Cambiar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'bbbbbToolStripMenuItem', N'frmPpalTecnico', N'bbbbb')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'aaaaToolStripMenuItem', N'frmPpalTecnico', N'aaaa')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'aaaaToolStripMenuItem', N'frmPpalAdmin', N'Agregar Idioma')
INSERT [dbo].[etiquetas] ([etiqueta_id], [nombre], [form], [texto]) VALUES (N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'miPerfilToolStripMenuItem1', N'frmPpalCliente', N'Mi Perfil')
GO
SET IDENTITY_INSERT [dbo].[grupo_tecnico] ON 

INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (1, N'Grupo Helpdesk Nivel 1', N'Grupo especializado en soporte de primer nivel', 1, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (2, N'Grupo Redes', N'Manejo de infraestructura de red y conectividad', 2, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (3, N'Grupo Aplicaciones', N'Soporte funcional y técnico de sistemas internos', 3, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (4, N'Grupo Seguridad', N'Gestión de incidentes de ciberseguridad y políticas', 4, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (5, N'Grupo Base de Datos', N'Administración de bases de datos y recuperación', 5, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (6, N'Grupo Infraestructura', N'Mantenimiento de servidores y hardware', 6, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (7, N'Grupo Soporte VIP', N'Atención a usuarios críticos y alta gerencia', 7, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (8, N'Grupo QA', N'Aseguramiento de calidad y pruebas de software', 8, 0, CAST(N'2025-05-12T00:49:45.6330000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (9, N'Grupo DevOps', N'Gestión de pipelines CI/CD, automatización de despliegues y monitoreo de aplicaciones', 14, 0, CAST(N'2025-05-12T01:06:59.5650000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (10, N'Grupo Cloud', N'Administración de servicios en la nube, infraestructura escalable y gestión de recursos cloud', 13, 0, CAST(N'2025-05-12T01:06:59.5650000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (11, N'grupodeprueba2006', N'grupodeprueba2006', 2, 0, CAST(N'2025-06-03T23:07:32.3230000' AS DateTime2))
INSERT [dbo].[grupo_tecnico] ([grupo_id], [nombre], [descripcion], [tecnico_lider_id], [eliminado], [fecha_creacion]) VALUES (12, N'grupodeprueba234', N'grupodeprueba234 20_46', 5, 0, CAST(N'2025-06-03T23:47:10.5800000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[grupo_tecnico] OFF
GO
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (1, 23)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (1, 24)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (1, 25)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (2, 22)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (2, 23)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (2, 24)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (2, 25)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (3, 22)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (4, 23)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 5)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 10)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 11)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 12)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 13)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 14)
INSERT [dbo].[grupo_tecnico_tecnico] ([grupo_id], [tecnico_id]) VALUES (12, 21)
GO
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'60ab7ada-b479-4a73-880d-36db0f899af1', N'aaa', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'4abb4abd-9fe9-4590-ba70-426026968d66', N'Inglés', 1)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'portugues', 1)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'7848fd8d-604a-412d-a4ea-53d14e431620', N'orueba', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'a2c103da-01c8-46b7-9b6a-54bfbc987ed6', N'test', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'37c99bde-5a59-48e2-96d3-971d578f4815', N'Español', 1)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'6f61a195-33b2-42b5-8e07-99a16bdc2981', N'esto', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'pruebadeidioma', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'pruebadeidioma', 0)
INSERT [dbo].[idioma] ([idioma_id], [nombre], [activo]) VALUES (N'6146e65f-7984-4c0f-8503-f891700e552d', N'chino', 0)
GO
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (1, 3)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (1, 2)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (84, 13)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (84, 22)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (1, 81)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (82, 1)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (3, 30)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (3, 31)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (3, 32)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (2, 20)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (2, 21)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (2, 22)
INSERT [dbo].[permiso_permisos] ([permiso_padre_id], [permiso_hijo_id]) VALUES (2, 23)
GO
SET IDENTITY_INSERT [dbo].[permisos] ON 

INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'administrador', 1, NULL)
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'cliente', 2, NULL)
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'tecnico', 3, NULL)
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'borrar tickets', 10, N'Permite eliminar tickets del sistema')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'borrar clientes', 11, N'Permite eliminar registros de clientes')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'borrar tecnicos', 12, N'Permite eliminar registros de técnicos')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'ver dashboard', 13, N'Permite visualizar el panel de control')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'gestionar idiomas', 14, N'Permite administrar los idiomas disponibles')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'crear ticket', 20, N'Permite crear un nuevo ticket de soporte')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'ver ticket de departamento', 21, N'Permite visualizar tickets asignados a su departamento')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'ver idioma actual', 22, N'Permite ver el idioma configurado en el sistema')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'ver perfil', 23, N'Permite acceder al perfil del usuario')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'asignar ticket', 30, N'Permite asignar tickets a técnicos')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'cambiar de estado ticket', 31, N'Permite actualizar el estado de un ticket')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'ver bandeja de tickets', 32, N'Permite visualizar la bandeja de tickets asignados')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'crear categoria', 81, N'Permite agregar una categoria nueva')
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'Administrador- Nivel 1', 82, NULL)
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'familiaDePrueba', 83, NULL)
INSERT [dbo].[permisos] ([nombre], [permiso_id], [descripcion]) VALUES (N'familiaDeSeguridad', 84, NULL)
SET IDENTITY_INSERT [dbo].[permisos] OFF
GO
INSERT [dbo].[prioridad] ([prioridad_id], [nombre], [descripcion]) VALUES (1, N'Baja', N'Prioridad baja: bajo impacto y urgencia')
INSERT [dbo].[prioridad] ([prioridad_id], [nombre], [descripcion]) VALUES (2, N'Media', N'Prioridad media: impacto y urgencia moderados')
INSERT [dbo].[prioridad] ([prioridad_id], [nombre], [descripcion]) VALUES (3, N'Alta', N'Prioridad alta: alto impacto y necesidad inmediata')
INSERT [dbo].[prioridad] ([prioridad_id], [nombre], [descripcion]) VALUES (4, N'Crítica', N'Prioridad crítica: acción inmediata requerida')
INSERT [dbo].[prioridad] ([prioridad_id], [nombre], [descripcion]) VALUES (5, N'Urgente', N'Prioridad urgente: situación excepcionalmente prioritaria')
GO
INSERT [dbo].[rol] ([rol_id], [nombre], [descripcion]) VALUES (1, N'Administrador', N'Tiene acceso a todas las funcionalidades del sistema')
INSERT [dbo].[rol] ([rol_id], [nombre], [descripcion]) VALUES (2, N'Cliente', N'Puede crear y ver sus propios tickets')
INSERT [dbo].[rol] ([rol_id], [nombre], [descripcion]) VALUES (3, N'Tecnico', N'Puede gestionar tickets asignados y cambiar su estado')
GO
INSERT [dbo].[rol_permiso] ([id_rol], [permiso_rol]) VALUES (1, N'1')
INSERT [dbo].[rol_permiso] ([id_rol], [permiso_rol]) VALUES (2, N'2')
INSERT [dbo].[rol_permiso] ([id_rol], [permiso_rol]) VALUES (3, N'3')
GO
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e82748c6-a55c-462f-a6d9-008f0404e28b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:52:17.997' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bc48811d-a2df-4311-9098-013586a4b164', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:36:52.767' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'86438c73-6764-48c6-a550-017cb4765492', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:41:41.877' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5ddcf1cd-23c9-44cf-a634-01ebdc4efb2f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-21T20:13:16.903' AS DateTime), CAST(N'2025-05-21T20:14:10.177' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cebce027-2f7d-45e8-abeb-04bea8910683', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:45:27.663' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5d15e7ad-2d9f-4607-9524-04f89794443b', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:39:02.270' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f6b104b4-fbb7-4a68-b2f2-0547671a539b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:54:07.250' AS DateTime), CAST(N'2025-05-25T19:54:10.903' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'56165177-b734-44e5-99f8-05a9114977b4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T16:47:30.100' AS DateTime), CAST(N'2025-06-15T16:47:54.547' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'16e36425-79b9-4c6a-8729-05e68e7cd868', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T18:07:19.403' AS DateTime), CAST(N'2025-06-01T18:10:07.020' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c42bc9bf-3663-4600-81ac-06f6efbdb40a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T11:13:30.613' AS DateTime), CAST(N'2025-06-03T11:13:44.307' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9404d53f-e1d8-480b-8b08-074040308c43', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T22:14:30.233' AS DateTime), CAST(N'2025-06-04T22:14:33.833' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'34a144a8-95d5-4239-9ce0-086b40b448e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T22:52:41.360' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7d2ab48f-eb2e-4e92-ac52-088c12996925', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:36:29.560' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'12d722bb-514f-428d-b1a6-08c1e26b84a2', N'e0934566-989e-4c9d-b568-7c57fccefb93', CAST(N'2025-06-03T21:07:56.427' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0719c9c4-94e8-4b13-babd-0917c65e6f0b', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T22:08:03.523' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'41af169e-ed9d-43b0-b5fb-0ac71f6b8663', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T13:33:34.877' AS DateTime), CAST(N'2025-06-16T13:33:42.567' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7662fb7b-5ddd-4ebe-9369-0e363f99bedf', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:20:22.453' AS DateTime), CAST(N'2025-05-31T21:20:27.227' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd3e859e0-5559-4fe0-a4f6-0ee9cded1134', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:44:42.970' AS DateTime), CAST(N'2025-06-10T20:44:54.547' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5867871b-fad8-4863-a248-0f6e8e0027a2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:02:57.343' AS DateTime), CAST(N'2025-06-16T16:03:08.347' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9e362094-6308-44ef-a47c-100d69c379aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:55:44.967' AS DateTime), CAST(N'2025-06-10T14:55:55.247' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'81bf50b8-da9f-4587-89f5-10a76d17ac1d', N'e4d68b97-50de-47fd-a129-153af2b205b9', CAST(N'2025-06-16T14:53:22.733' AS DateTime), CAST(N'2025-06-16T15:09:51.027' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'21bea4dd-8863-4ad9-9a87-1119bf8d44da', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:30:48.443' AS DateTime), CAST(N'2025-05-31T21:30:52.923' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4a2b4eb6-f050-48dc-b574-12137ae50b1d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T22:16:31.860' AS DateTime), CAST(N'2025-06-04T22:16:58.227' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'24943003-46c1-4e2d-af8d-13721dd333b5', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:32:39.380' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'509ede66-cca4-4388-85eb-13a46cafaf29', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:51:56.343' AS DateTime), CAST(N'2025-06-10T20:52:00.197' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b5313cfa-eaa9-4f29-ab99-13d6fdb69d2e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T21:42:55.447' AS DateTime), CAST(N'2025-06-12T21:43:15.430' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'537d897c-6593-476d-a51d-1621ee279e1e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:07.283' AS DateTime), CAST(N'2025-06-16T15:16:12.900' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'76d616ab-d3ae-4026-a909-18aaf43b31f6', N'c62603c5-2d56-4dcf-bb30-35948eb2e202', CAST(N'2025-06-03T15:07:03.640' AS DateTime), CAST(N'2025-06-03T15:07:08.087' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd56280c2-d62a-475a-8a88-19310a7910ac', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:30:29.983' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'38f94480-0ed3-43d4-9ec2-197f48694fba', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:41:05.700' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'54279555-0f5b-44b5-bbe6-1ae2b46ed63c', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:53:53.823' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'815566fe-96cb-410b-b7c6-1b3a5488083e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T09:00:40.903' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'440adca5-2baf-4e4e-8ca3-1c15a0fb94df', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:43:46.740' AS DateTime), CAST(N'2025-06-14T14:46:15.640' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0c3847dc-1ada-4fc1-9c85-1cd1f3b9ed70', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T14:45:08.467' AS DateTime), CAST(N'2025-06-01T14:45:13.940' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd5451741-f25c-46ce-a9b6-1ce05aa50e39', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:23:10.997' AS DateTime), CAST(N'2025-06-16T16:23:19.210' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0994ef00-51d6-4e02-b95b-1ce9ec415a13', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:41:59.610' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cac60e8e-42ff-44eb-b7e1-1e02a2c8e5e6', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:52:49.543' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9b501551-3b08-4ab8-b683-1f7ea57e82a1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:47:41.233' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e6e55027-9757-4af9-8a4a-2012729d881e', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:35:40.430' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'65477879-4742-4889-8fde-2032214676d3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:55:33.550' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'6b1fd52a-35b0-40b5-b9bf-208a2529305c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:52:00.510' AS DateTime), CAST(N'2025-06-12T22:53:37.080' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'2ae4aca4-8096-4ee3-94f9-217aeefe36a8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T20:58:27.873' AS DateTime), CAST(N'2025-06-03T20:58:51.267' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'12b30d04-b646-42e8-b0db-2180b43f6a2d', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:55:27.117' AS DateTime), CAST(N'2025-06-16T19:55:34.470' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cd5b0e7d-7bd8-442f-b985-21a1fe59f532', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:50:49.453' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'765ff8dc-66dd-4077-8f0e-263440b1266a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:55:13.393' AS DateTime), CAST(N'2025-06-16T21:58:42.820' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'2f6dc71f-5980-4897-b27e-27c2a3d6a641', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:13:01.143' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bab1171c-8c0d-49d5-b920-27c49d574108', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:00:52.333' AS DateTime), CAST(N'2025-06-01T19:00:58.323' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a10fd861-1aeb-44f8-bca6-27d5f7382be5', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:23:09.350' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd769cffc-5e33-41aa-8835-281e6b3555fe', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:27:21.637' AS DateTime), CAST(N'2025-06-11T15:27:27.563' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'6e8bd071-6d66-4db8-9dc6-28b3f207f103', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T14:44:08.033' AS DateTime), CAST(N'2025-06-01T14:44:15.167' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e6c970ba-8bc4-4be0-a42d-2ab9879ba7d7', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:21:22.193' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cbac73ee-6037-4119-8787-2b58f237830d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T20:05:01.673' AS DateTime), CAST(N'2025-06-03T20:05:39.207' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8c88a56e-97eb-4ed8-ab8b-2cfc11c169a7', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:54:03.697' AS DateTime), CAST(N'2025-06-16T19:55:12.437' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'62dbe470-af29-4bce-b434-2d9ca6b7d1db', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:38:31.493' AS DateTime), CAST(N'2025-06-17T00:40:09.247' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1940f450-f6c9-4804-ba34-2dbd12e1d743', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:41:19.487' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'605a95c1-d692-4162-b15a-301b2071d3c3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T20:23:50.673' AS DateTime), CAST(N'2025-05-31T20:23:57.380' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'66352f4a-dc29-43df-9f5c-3082a1923454', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:28:19.893' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1fd1aa5f-45e0-4a15-96f8-30e78ca5ed0f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:26:22.177' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'02fcf118-e822-4089-bb07-315600ad97a2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:30:06.210' AS DateTime), CAST(N'2025-06-12T22:30:59.427' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'602cf3f4-3f7f-41ca-8293-3235b6769810', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:14:08.860' AS DateTime), CAST(N'2025-06-16T18:14:14.910' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e6b304a6-ef2e-43b9-bdf6-328ab19f317e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-02T21:34:31.617' AS DateTime), CAST(N'2025-06-02T21:35:29.167' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4ef43da5-68aa-4475-8267-32f3020631af', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:55:13.267' AS DateTime), CAST(N'2025-06-17T00:55:39.207' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0579f9f6-76b9-454a-bb65-34dcf9f30668', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:47:46.730' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ea43139a-8add-4739-a6e9-35167eec6272', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T14:51:03.123' AS DateTime), CAST(N'2025-06-16T14:52:47.047' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3f565651-8960-4cb7-b91b-351931af6134', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:11:10.020' AS DateTime), CAST(N'2025-06-16T15:11:18.080' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c63f0900-93bf-48a6-99df-363c0a1e1ea4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T11:15:39.670' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e835c520-0853-4335-a70b-377801244f5e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:44:49.903' AS DateTime), CAST(N'2025-06-15T17:45:27.520' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'111bd1f6-9451-4908-b18f-384f6fae383b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:31:20.157' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'97648398-63b7-402e-987e-3947b573829b', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:34:13.970' AS DateTime), CAST(N'2025-06-17T00:34:41.690' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9a5ecb79-060f-466a-95f6-39fdf30e68f2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:17:18.707' AS DateTime), CAST(N'2025-05-25T19:17:22.347' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'04ffbe1c-610e-4f9e-903d-3a65d20d74e9', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:45:50.683' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'12915e50-d48b-497c-8951-3a79b6972050', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T09:03:04.287' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bc649d33-6b3c-4956-849a-3bb53a2895cb', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:44:55.380' AS DateTime), CAST(N'2025-06-01T15:44:59.773' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0b408de0-fd47-4c73-92dd-3c5ed4112b91', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:28:17.310' AS DateTime), CAST(N'2025-06-14T13:28:28.380' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd758851b-9bb1-4a5c-bdcd-3dc16e09a05c', N'b9d228df-8d04-4d84-a662-2913efa491e1', CAST(N'2025-06-15T16:31:22.363' AS DateTime), CAST(N'2025-06-15T16:31:32.853' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'727002ef-5e50-40f6-92a7-3f2a29651acb', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:50:22.760' AS DateTime), CAST(N'2025-06-10T14:50:27.130' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'74807fda-e98c-4034-b6aa-3f7a61bbc89c', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:51:47.437' AS DateTime), CAST(N'2025-06-16T21:52:40.093' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b2abefea-9e03-4ea8-ab57-3ff408ecf45b', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:37:02.073' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b957a6d9-4427-4e04-9c50-41b582e8e1d0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:22:02.303' AS DateTime), CAST(N'2025-06-16T17:22:07.807' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f3818b99-a8c6-4ebb-9b4d-42a5faf176bd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:40:21.683' AS DateTime), CAST(N'2025-06-01T15:40:25.163' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c348d657-f52b-4d64-803d-44a2c25b7ec9', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:35:09.680' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'88b0ae32-c026-412f-aac8-45c783323486', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:37:33.727' AS DateTime), CAST(N'2025-06-10T20:37:42.410' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd9e5505e-fc5f-4f64-b2bc-466f49ba4793', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:28:11.853' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'60373096-e64e-4e40-b42d-46affc91de7d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:16:50.390' AS DateTime), CAST(N'2025-05-25T19:16:53.370' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'70d9aeb7-5b93-4fe5-92f4-46ca62ef82a5', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:40:32.557' AS DateTime), CAST(N'2025-06-17T00:44:34.943' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'53ddaeca-b27a-49ed-b98a-46e4eeb0e484', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:23:01.373' AS DateTime), CAST(N'2025-06-01T20:23:05.517' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'17bb258c-181f-431e-ab4e-4a6cfc2e6c44', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:07:17.397' AS DateTime), CAST(N'2025-06-16T22:07:45.387' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5f03c565-f781-4204-9d5b-4ae611e9d615', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:23:55.563' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1df8238a-6442-409c-8cc8-4b77445f8feb', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T18:29:49.363' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd7b72583-39a8-436f-97b7-4c834f5c627b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T15:21:56.377' AS DateTime), CAST(N'2025-06-15T15:29:05.247' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'83fba4ae-f8bf-46a8-80bc-50f695ef0bbc', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:10:09.430' AS DateTime), CAST(N'2025-05-31T21:10:16.360' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'79c7307b-a036-4fa1-92ac-513a3930e849', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:25:34.980' AS DateTime), CAST(N'2025-06-17T00:25:46.010' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'fc315203-aebc-4df9-992c-51a611c80735', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:13:46.290' AS DateTime), CAST(N'2025-06-12T22:14:18.297' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'28bd2f74-a122-4bee-8776-53d46a58d01f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:18:42.450' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8b13697d-61da-4359-888a-561c82d2ee89', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:27:18.123' AS DateTime), CAST(N'2025-06-01T20:27:27.573' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3e5da08a-b1f7-4ee1-9710-567746d5e765', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T16:16:54.980' AS DateTime), CAST(N'2025-06-15T16:17:27.500' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd1a06d9d-5b63-4a7d-b1c6-56ebd33989ff', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:51:22.223' AS DateTime), CAST(N'2025-06-14T14:53:59.470' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9ffd683c-67a9-42d5-acfa-57200b7ff56e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T08:59:39.320' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'2a0e0b7a-aa04-4a30-9fe9-5815f48dcf2f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:12:08.093' AS DateTime), CAST(N'2025-06-01T19:12:12.160' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'da9da2f9-b7e4-4efd-983e-58652f0dc06d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:02:13.917' AS DateTime), CAST(N'2025-06-01T20:02:19.650' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
GO
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'61d143bd-8735-475b-894e-58b22547894d', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:17:13.340' AS DateTime), CAST(N'2025-06-16T22:17:21.517' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e1f57ea0-f664-430f-beef-59ded48b3453', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:12:02.047' AS DateTime), CAST(N'2025-06-16T23:12:14.780' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd92d5fd9-5c6f-492e-93d6-5a7d12ba9314', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:45:15.150' AS DateTime), CAST(N'2025-06-17T00:45:40.310' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'881a4281-2a06-4332-a04f-5b22693a3704', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:52:52.593' AS DateTime), CAST(N'2025-05-25T19:52:56.223' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5f8bf1f4-1f31-4761-9a72-5b5adec85073', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T20:17:36.943' AS DateTime), CAST(N'2025-06-04T20:18:00.747' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'735f7649-21bc-4fc8-bfce-5b6a2eecf70b', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:55:45.010' AS DateTime), CAST(N'2025-06-16T19:55:57.507' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5446d1b5-a4ed-4518-8ff7-5e527ebb607c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T14:23:06.733' AS DateTime), CAST(N'2025-06-16T14:24:54.760' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'18b29992-bae0-4949-a3b5-5e71f19e79c6', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:20:53.760' AS DateTime), CAST(N'2025-06-17T00:21:55.520' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'458fbf08-cbb2-4239-884d-6160ceeca6f1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:19:08.080' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bc773520-968e-4059-8f44-617a74cb815b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T18:30:00.047' AS DateTime), CAST(N'2025-06-01T18:30:04.253' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'acb52ba6-3874-43a3-b905-620782488f7a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:09:15.940' AS DateTime), CAST(N'2025-06-14T14:29:04.753' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ec8292e3-554d-4648-93a2-6246d797d40d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-29T19:51:48.130' AS DateTime), CAST(N'2025-05-29T19:52:37.797' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8abf711d-59b8-4b9f-acba-63a229cfa859', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-02T19:10:10.450' AS DateTime), CAST(N'2025-06-02T21:30:31.370' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3b778c7d-8263-4aef-9de5-64435f38f95b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T15:47:41.930' AS DateTime), CAST(N'2025-06-03T15:48:17.557' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1dc6fa2e-543d-4436-ad9a-6458e37e91a8', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:09:24.197' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8b4ab7dc-85a9-4deb-9f1b-647a843a7286', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T14:37:48.023' AS DateTime), CAST(N'2025-06-01T14:37:54.173' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'fb060890-a58a-480c-9295-65f2304a44d6', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:53:32.937' AS DateTime), CAST(N'2025-06-10T20:53:43.413' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4888da84-7c6c-46f8-9e27-66006d507912', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:18:39.940' AS DateTime), CAST(N'2025-06-01T23:19:41.747' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'becc1dcb-cd7b-4d3a-bf7c-66812600963f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:12:45.550' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7c4de74f-27ad-4e13-8e6b-66fa9c8b3c06', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:27:20.417' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5d6be247-5a64-4033-a07b-67aee784b8a2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:04:52.720' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0c12700f-8852-4880-bbfb-67bbcee6426a', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:20:34.207' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0043c887-4494-44c4-a4e7-687f22f25e11', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:28:34.840' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bc337c72-5fb2-4f6f-b7d8-6b038b77d7a3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:15:53.663' AS DateTime), CAST(N'2025-06-01T19:15:56.770' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'19360a93-f014-432f-9e87-6b78f8479c55', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:53:37.847' AS DateTime), CAST(N'2025-06-16T21:53:59.973' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1c43fbeb-0a99-4032-943a-6b89ca86550e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:22:06.510' AS DateTime), CAST(N'2025-06-15T17:22:53.230' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'49847f1d-f066-470d-b558-6cf536c551c9', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:45:53.230' AS DateTime), CAST(N'2025-06-01T15:45:57.413' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'994af197-d158-499c-b52c-6ded9d7ad574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T15:46:49.363' AS DateTime), CAST(N'2025-06-03T15:46:57.523' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'33533eb7-ae14-483a-8dd5-6df6e48c7a30', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:34:21.707' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1f694f66-c0d4-4082-8c67-6e8f51527ab2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:15:44.557' AS DateTime), CAST(N'2025-06-01T15:15:49.063' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a6209301-838b-41cd-9761-707eaa7e55ca', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:24:49.450' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'20a46963-a0d7-4795-b9f8-7102280097ba', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:54:08.200' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f86c50b3-a9e8-4614-ab79-7135285deb50', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:11:29.093' AS DateTime), CAST(N'2025-06-16T23:11:43.130' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bb4ea16f-9a4f-407a-af74-714fb6d6cb02', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:12:53.693' AS DateTime), CAST(N'2025-06-01T19:12:57.407' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4d7590be-080c-4b24-a3a5-715f122249a1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:11:33.240' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b78835d5-ba70-4906-9c91-71d7f36d3324', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:57:54.907' AS DateTime), CAST(N'2025-06-01T19:57:59.850' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8644c4eb-5f80-4b7e-a233-72efe61f26e1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:06:10.093' AS DateTime), CAST(N'2025-06-10T22:06:15.680' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ed0c14e0-7fcb-48e9-9a6e-731cdad4ec97', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:12:41.743' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'6f52bae4-d926-4022-ad7a-73c58025db53', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T23:17:48.323' AS DateTime), CAST(N'2025-06-15T23:18:09.563' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'62be7142-79d2-4f40-93f6-7427e83f77c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:02:54.910' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'dfa98427-d4b2-462f-bbc4-749a048f61d3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:45:52.220' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bc26a47c-8ba8-4914-a31a-7663e2d30320', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T22:19:27.843' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'456dd452-7d5a-4593-8fa5-7756d14a1ff9', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:29:26.293' AS DateTime), CAST(N'2025-06-16T22:30:21.530' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'82cca5cd-4d99-44ea-958e-779b72efd87c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:13:44.727' AS DateTime), CAST(N'2025-06-01T19:13:48.037' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'05777175-b4cc-445c-b81a-78620fe72437', N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', CAST(N'2025-06-16T23:44:56.340' AS DateTime), CAST(N'2025-06-16T23:45:57.267' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5eeaa025-4f5a-4d88-a742-7893f739fdb5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T21:50:33.627' AS DateTime), CAST(N'2025-06-10T21:50:37.710' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c9a00d9b-83bb-41e7-ab21-78bad93020cf', N'277c00c6-a926-41c9-a114-c6118cab788f', CAST(N'2025-05-21T20:31:17.537' AS DateTime), CAST(N'2025-05-21T20:31:28.720' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'07129fa6-a941-4468-87a4-797b43a26526', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:12:14.110' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ebc9791a-38d7-4e2e-b3b3-79e65ba2aac9', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:19:53.300' AS DateTime), CAST(N'2025-06-01T23:21:19.003' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f1b65a5a-51f9-4e47-8b61-7a649996dd84', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:17:00.647' AS DateTime), CAST(N'2025-06-03T14:17:10.923' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7e84f9b1-3308-4838-85f8-7b1bff29cc55', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T22:38:48.670' AS DateTime), CAST(N'2025-06-16T22:44:04.027' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'41225a37-4ff3-41fd-a637-7ca5d4fbbcbe', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:22:13.877' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'78d49a09-d210-4158-8a9c-7cdaf80977c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T21:01:17.577' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7bbece07-4256-4ab8-b00f-7ddf1e631d33', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T00:09:39.137' AS DateTime), CAST(N'2025-06-12T00:09:43.373' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'adac79cb-68c1-4b12-9fbf-81f9403b4b06', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:49:59.600' AS DateTime), CAST(N'2025-06-14T14:50:23.870' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cfeb2e0e-b680-4652-9519-823c68a686a5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:01:40.543' AS DateTime), CAST(N'2025-06-01T19:01:44.500' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ad70e77c-449d-476d-b96e-82a1cebdde69', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:18:56.587' AS DateTime), CAST(N'2025-06-16T23:19:00.993' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ac1a63b6-aed5-4ccf-b11f-82f5d5a53153', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T11:30:59.803' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'71f55a15-be29-4eaa-8e09-866e02323b91', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:23:55.913' AS DateTime), CAST(N'2025-06-17T00:24:02.280' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd5a71c98-c3c0-4171-be78-879bb5ab4f16', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T20:00:08.540' AS DateTime), CAST(N'2025-05-31T20:00:13.200' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'86173680-7c45-4bfa-81bc-8817577d3e23', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T23:10:45.853' AS DateTime), CAST(N'2025-06-15T23:11:00.647' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'68103a3a-baef-4555-8629-89c85ba20f92', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:31:32.350' AS DateTime), CAST(N'2025-06-17T00:32:07.023' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'18235a03-f36b-4b66-8204-8a10a6a4f3ab', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:11:43.297' AS DateTime), CAST(N'2025-06-16T15:11:49.213' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'834aa748-a28c-4f9c-9273-8af2ba74b5d4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:58:16.420' AS DateTime), CAST(N'2025-06-01T15:58:22.510' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a98b3a28-f4a3-49f1-b728-8bf3a1005d44', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:34:33.223' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c44c05ea-1b17-46cf-8bcc-8d202bbbe30c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:34:28.083' AS DateTime), CAST(N'2025-05-31T21:34:32.543' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'12bc96ae-25aa-4381-b492-8db85f2eb152', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T20:22:17.567' AS DateTime), CAST(N'2025-05-31T20:22:24.003' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'77002f5e-7639-4aee-8898-8e1e547ba96b', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:35:08.237' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ce654f80-e1a4-4912-aac7-912272165657', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T16:28:36.280' AS DateTime), CAST(N'2025-06-15T16:29:07.793' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'492aa067-fb20-4b23-ab4a-91603340474b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T15:19:47.363' AS DateTime), CAST(N'2025-06-14T15:21:20.517' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1ed56a63-0b92-4540-853d-91b263506f18', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:40:55.947' AS DateTime), CAST(N'2025-06-12T22:41:14.410' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7ad53078-751c-44ed-99eb-91f5805f08f8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T11:33:29.530' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'6916176d-92b7-45ed-b934-9232d1403c2e', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:29:12.783' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'2d31a1e1-e8f6-48c1-8c5c-92431abf9ced', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:45:34.210' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f7a720ad-f40f-4a0b-93a7-932e3d1b76bd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T21:48:27.700' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'6f115ca3-4b10-4a98-929a-940ae7be2818', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T21:17:04.193' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'385f9656-2676-405f-90b8-9438e1b627ba', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T22:17:17.523' AS DateTime), CAST(N'2025-06-04T22:17:34.523' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ff6b9ffa-2f90-4026-bc54-963f95a665e8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:02:24.773' AS DateTime), CAST(N'2025-06-01T19:02:28.973' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1aef39db-6298-4790-9f86-96b561dda1e6', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:29:09.733' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a04ddd0b-4e82-46e2-b381-99056fd6d345', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:56:03.470' AS DateTime), CAST(N'2025-06-10T20:56:07.373' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1a4e9085-f6b8-40b1-9825-9abd6d218643', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:34:14.113' AS DateTime), CAST(N'2025-06-01T21:34:18.573' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'692ec6b8-e34a-4be0-83f9-9cfaecaf98f5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:02:31.313' AS DateTime), CAST(N'2025-06-16T22:03:19.430' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'290eb5f9-26ac-4106-b27f-9d014e96fb2b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T08:49:28.123' AS DateTime), CAST(N'2025-06-03T08:49:35.290' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'fc967008-8263-4027-b99c-9e533bb94787', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T19:00:47.073' AS DateTime), CAST(N'2025-06-11T19:00:52.500' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9292d5e1-b2de-451c-9eff-a00ce0f55fac', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T15:27:07.373' AS DateTime), CAST(N'2025-06-03T15:27:59.913' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a274d189-4685-4485-ad8b-a0e4bef3d2ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T11:35:58.447' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cf2bb0cc-f1ab-4f61-9489-a198ab7cb0d1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:14:44.553' AS DateTime), CAST(N'2025-06-01T19:14:47.997' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7350e4f4-d6ba-4fb3-992b-a3466b1e3fa8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:10:05.353' AS DateTime), CAST(N'2025-06-16T18:10:23.800' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a386cfa7-af28-42b9-9ae7-a425db2fa6be', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:39:56.470' AS DateTime), CAST(N'2025-06-15T17:40:29.533' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a128a29a-82d2-4892-a4b7-a4391da67f40', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:25:37.553' AS DateTime), CAST(N'2025-06-16T20:28:10.300' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'578f0070-2c14-4582-8335-a60c5f7d2f5d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:19:15.143' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'edbe99b9-96f0-4d48-abad-a64ac92cd3db', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:03:28.367' AS DateTime), CAST(N'2025-06-01T19:03:33.967' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9f32b1ed-587a-4705-b434-a7552dc92faf', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T14:36:33.123' AS DateTime), CAST(N'2025-06-01T14:36:42.143' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0164aa28-3acf-40e5-8d88-a77411d7e5c3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:13:54.257' AS DateTime), CAST(N'2025-06-16T17:14:01.303' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'715b4d71-964b-4488-a6f9-a845ec60c22f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:37:34.517' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0dc32e08-66fa-49f0-a109-a860b783d871', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:39:37.327' AS DateTime), CAST(N'2025-06-10T20:41:06.553' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5ab3e33e-9ce9-47e9-8f05-a99d50fe7e86', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:29:39.443' AS DateTime), CAST(N'2025-06-14T14:40:48.037' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3bcf0871-d275-4470-8248-a9d40b59d47e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T08:51:04.483' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f51e36cc-ccf6-44d5-a830-aae2ae4827a4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T00:26:32.673' AS DateTime), CAST(N'2025-06-12T00:26:37.317' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b41198cb-5f57-43e1-a074-ad2ff08f648c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:10:31.187' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
GO
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'60fbf87c-76c3-4101-96de-add43027a151', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T21:47:47.200' AS DateTime), CAST(N'2025-06-15T21:47:56.400' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f5c0fc1b-2981-45cf-94f1-aeed05d6cdc8', N'277c00c6-a926-41c9-a114-c6118cab788f', CAST(N'2025-05-21T20:31:44.417' AS DateTime), CAST(N'2025-05-21T20:31:53.153' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'13667ac1-cb12-412b-9c27-af2df5f651f3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T13:35:04.227' AS DateTime), CAST(N'2025-06-16T13:35:07.093' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a9dc8971-c3c4-45f3-b62f-b168b7f4e026', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T20:30:04.560' AS DateTime), CAST(N'2025-06-16T20:30:09.300' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a537adeb-7006-4bd2-a862-b183a56bb91c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:56:49.493' AS DateTime), CAST(N'2025-06-10T22:56:54.160' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cf61e99b-037f-417c-8b13-b1878da91551', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T21:48:04.987' AS DateTime), CAST(N'2025-06-15T21:48:09.553' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ec3dbb14-a8da-4778-9962-b249d49e5374', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:32:26.063' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c561b4ed-79da-4b36-adfa-b2f83d390ed8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T09:15:44.460' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3a07c50a-7381-4cfa-8776-b33f4f2a0caf', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:24:49.940' AS DateTime), CAST(N'2025-06-12T22:25:08.567' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ba23569e-7a5a-4772-83be-b3e059680dbe', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:22:57.690' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'fa46b3c3-8dfc-4894-a33c-b55d6f496be9', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T15:20:54.037' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4b24528c-bf47-48c9-942a-b68fb7f13e80', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:29:50.643' AS DateTime), CAST(N'2025-06-14T14:08:43.013' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e9f6d163-de4b-4670-872a-b7c2f739a5a3', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:32:33.667' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'02cad2bd-5af9-48ae-b506-bbabdcb21d1b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T18:58:44.703' AS DateTime), CAST(N'2025-06-01T18:58:47.810' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'39c4a263-3b3c-4df4-80b1-bbbe1d3df4e7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:55:50.970' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9c7aaabf-4143-4aed-8a83-bbcf66b32a75', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:47:31.417' AS DateTime), CAST(N'2025-06-17T00:48:16.300' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'24780d2b-91b7-40c5-bf76-bc6bc73b1044', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T23:12:41.037' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd47048ca-edec-4910-807b-bdafca014a77', N'e0934566-989e-4c9d-b568-7c57fccefb93', CAST(N'2025-06-03T21:08:38.300' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bf09a37a-3690-4503-ad34-be3e687d893e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T21:06:10.040' AS DateTime), CAST(N'2025-06-03T21:07:47.373' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cd0c4e6a-255c-46e8-8ff2-bf20fb24788b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:23:22.810' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9521ecdd-7c33-468b-ad0d-bf33d0b31def', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:38:12.817' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5bbb1142-30dc-4b0b-92b5-c08c7ef0df00', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:17:42.057' AS DateTime), CAST(N'2025-06-16T22:18:06.073' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0af88936-3d6a-4509-abbd-c09d86af0ab1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:17:21.360' AS DateTime), CAST(N'2025-06-01T20:17:25.477' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b3ad09d5-2db6-4640-aa5a-c169596acf56', N'277c00c6-a926-41c9-a114-c6118cab788f', CAST(N'2025-05-21T20:17:23.583' AS DateTime), CAST(N'2025-05-21T20:30:10.290' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3fb22b8d-1aa8-4c5c-9064-c1a72d5f2649', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T23:14:51.413' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'374bbc28-5595-4eee-aece-c367f1a649c2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T13:29:37.163' AS DateTime), CAST(N'2025-06-16T13:32:41.790' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5965ba21-d07e-402e-ae9b-c387563a4863', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:43:14.713' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'cd5ba7e2-87b7-4025-a3f4-c40672020526', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:14:02.643' AS DateTime), CAST(N'2025-05-31T21:14:08.260' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'adc5c00d-3e48-4cbd-a62d-c455900fd5c1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T23:19:32.580' AS DateTime), CAST(N'2025-06-15T23:19:36.887' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'97b38cf5-25a0-48c7-aeed-c90bee0c2a5b', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:14:12.857' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'91556d36-b185-4085-a7c3-caf6c9904d03', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:12:49.303' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'd82d11e4-bc4b-4e08-8cff-cb3a3b7d720e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T18:58:13.327' AS DateTime), CAST(N'2025-05-25T18:58:20.080' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'051f1bcf-b407-465c-88b9-cba7e1d5a51e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:22:43.153' AS DateTime), CAST(N'2025-05-25T19:22:46.177' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'8882a1eb-732a-49a0-8359-cd0109d36679', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:15:04.137' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'91e36f04-8cc5-4437-b8e1-cd3ec46968ca', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T21:58:31.170' AS DateTime), CAST(N'2025-06-04T21:58:49.913' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'05574570-6449-4f6b-b42a-cd7490ee2a12', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T15:51:21.730' AS DateTime), CAST(N'2025-06-01T15:51:25.963' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bf117c0f-6991-4995-9618-ce25024c001c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:39:52.510' AS DateTime), CAST(N'2025-06-12T22:40:10.917' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'475b86fd-40c6-4ee9-ba91-ce45fea7b68a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:25:48.983' AS DateTime), CAST(N'2025-06-16T17:25:54.120' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'66b6093d-4bef-4283-9c7b-ceae8bfe1029', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:19:53.843' AS DateTime), CAST(N'2025-06-01T19:19:57.330' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'4e8b4f7b-fa7a-4b5f-95d7-cf2d7074c67b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:48:09.760' AS DateTime), CAST(N'2025-06-01T21:50:34.327' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a17af6ed-7d60-4394-81c7-d04c953a0a6d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:35:18.080' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1d8ee500-96c9-4d9a-9090-d0c7fcf9322c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-21T20:14:58.117' AS DateTime), CAST(N'2025-05-21T20:17:04.450' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'01f3f865-77b5-44f4-8fe3-d1845dda2ab7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:24:19.277' AS DateTime), CAST(N'2025-06-17T00:25:09.133' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f4da42e1-0f22-4018-8444-d34d56c50a8a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:02:01.487' AS DateTime), CAST(N'2025-06-16T18:02:08.130' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'7e171c35-2647-46eb-af93-d61db5eee3ea', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:05:07.447' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'86e72da6-355f-4ab7-9f1e-d718813bdb06', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:19:08.320' AS DateTime), CAST(N'2025-06-01T20:19:12.147' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9da92520-3eb9-4d3a-87a4-d75d367867c1', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:07:08.503' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9353ef72-ade6-4597-875b-d7817e1b05ae', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:49:28.800' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3edda0f7-c15f-493d-8341-d7f4f336e299', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T16:24:29.863' AS DateTime), CAST(N'2025-06-15T16:24:57.867' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0ad155e7-4015-4516-92b4-d8b21ae0c778', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T20:46:26.383' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1bb7184c-23cd-499a-899a-d8bebc904b1c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T00:27:19.007' AS DateTime), CAST(N'2025-06-12T00:27:23.023' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'16bbef63-299d-4411-a856-d9c98ab87599', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:05:55.357' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'21f274b4-100f-402e-b05d-dbe71ff2e49a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:56:00.190' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'55b88d50-551d-4c9f-8a93-dbe7b85f5d41', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-31T21:27:08.620' AS DateTime), CAST(N'2025-05-31T21:27:13.787' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9e72c616-456f-422f-b551-dcda20702cca', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:37:20.070' AS DateTime), CAST(N'2025-06-17T00:37:50.877' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'24516fd2-6db2-4c84-99cb-dd2feb87adbf', N'06200641-6fc0-4e22-a1c5-9e9f82e23e53', CAST(N'2025-06-03T20:59:03.257' AS DateTime), CAST(N'2025-06-03T20:59:18.547' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c2695e0f-2987-4a97-be25-de697221c7cb', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:01:37.367' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e29c5375-c8b9-45f8-bed1-de95ad51f92e', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:30:37.867' AS DateTime), CAST(N'2025-06-16T21:30:52.947' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'495bde80-16a9-48c9-a744-e07358b9b31d', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T15:59:56.257' AS DateTime), CAST(N'2025-06-15T16:00:02.220' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'5810eb8f-37bd-48d5-9296-e167ce8f4609', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:13:32.713' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'987cc05d-df80-44bb-924b-e30913a6e580', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:25:23.473' AS DateTime), CAST(N'2025-06-12T22:25:37.823' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'fa74224e-eb2d-4d52-9b75-e41b6eb92159', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:29:49.840' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a3f37682-8af2-4f39-82c2-e42620ab26ba', N'4551b9cb-32b3-498b-9457-30aadf224def', CAST(N'2025-06-16T19:04:45.740' AS DateTime), CAST(N'2025-06-16T19:04:52.477' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f53f91c7-daad-42dc-839f-e4f76c12cffa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:09:43.810' AS DateTime), CAST(N'2025-06-17T00:16:28.087' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e84f56ba-be45-4517-b9ae-e65c120e46ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T15:06:18.690' AS DateTime), CAST(N'2025-06-03T15:06:43.470' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'ad0e0b3a-f4c3-4810-a2f1-e6d27f6ab691', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:02:37.183' AS DateTime), CAST(N'2025-06-17T00:06:37.830' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'73a43985-eaab-45c9-9fbe-e6f8539ed31b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-12T22:18:11.523' AS DateTime), CAST(N'2025-06-12T22:18:22.773' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'bb0c3eb4-914b-41ca-88f2-e7155f3199a1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-04T20:11:17.800' AS DateTime), CAST(N'2025-06-04T20:11:24.070' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'44bf2eef-2a73-48b4-b4fe-e822c84a26ff', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:18:59.707' AS DateTime), CAST(N'2025-06-16T16:19:34.160' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1006b0bd-0d90-4e02-9918-e87da468f467', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T16:31:47.297' AS DateTime), CAST(N'2025-06-15T16:32:50.267' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'188fad98-3286-491f-8f0a-e98418158149', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-02T21:32:40.357' AS DateTime), CAST(N'2025-06-02T21:34:17.880' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'87eac239-dadb-42ea-8340-ea0986826d99', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T17:42:50.547' AS DateTime), CAST(N'2025-06-15T17:43:09.730' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b406b851-b5a9-47bf-9678-eaa24c99a42a', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:56:36.883' AS DateTime), CAST(N'2025-06-01T19:56:41.187' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c2c55cf5-0f1f-47e2-b7a6-eb2c08730eb5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:38:01.430' AS DateTime), CAST(N'2025-06-17T00:38:13.397' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9008e82c-745e-49ec-a683-ebe5d9048f64', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T18:56:38.103' AS DateTime), CAST(N'2025-06-01T18:56:42.217' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'b1cbfcc8-ac84-4ce8-bd24-ec216d19c2b7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T20:06:21.820' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c8879b15-4727-4f0f-a82e-ecd124c94f5d', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:00:25.867' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 3)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f1cba37e-9068-4624-a812-ef83696f1b90', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T09:25:05.687' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'005b206a-2f1b-411f-95ef-f0bb817e6297', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:06:27.283' AS DateTime), CAST(N'2025-06-14T13:06:32.290' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'2259f516-d9c0-4daf-89a9-f174b17b30b1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-21T20:32:13.503' AS DateTime), CAST(N'2025-05-21T20:32:38.783' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'89c3f6c9-76a0-412c-8cde-f349bcf577c0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:23:30.947' AS DateTime), CAST(N'2025-06-16T17:23:46.620' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'a1df1469-20f4-40a8-a45f-f34e32eb9a00', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:56:23.580' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'e169b17b-b646-48f4-a136-f3bbe46ca5b9', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:26:10.813' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'624c98b2-1351-4b7d-a417-f40df5492e62', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T21:26:09.527' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9692034a-eebf-4210-b440-f411a30751b1', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T21:59:04.057' AS DateTime), CAST(N'2025-06-16T21:59:56.123' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'0b3d96d3-a93a-40b5-96f0-f5c7feb5d60e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T22:26:19.650' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1453713e-49da-4cd6-a664-f6cac215ec2b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-15T23:12:10.183' AS DateTime), CAST(N'2025-06-15T23:12:20.150' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'dacdcbf7-b830-432d-873c-f76df00e4c91', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:21:57.657' AS DateTime), CAST(N'2025-05-25T19:22:05.767' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'48b26bef-3c18-414a-a71a-f7bd9c8884b8', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:15:55.260' AS DateTime), CAST(N'2025-05-25T19:16:00.270' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'1a39c67f-1ea0-4cd2-8742-f841acb8e3ce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:53:25.607' AS DateTime), CAST(N'2025-06-10T14:53:29.353' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'9fade543-9ebc-4987-97d9-fa6c75148c57', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:44:13.273' AS DateTime), CAST(N'2025-06-16T18:44:20.660' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'3f9d2a1a-ff9f-461b-b2c7-fbdc41c80950', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:20:40.377' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c4f65800-8ae5-438f-be0c-fbe1191795aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T13:52:06.987' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'484d2340-ddf3-4e20-91f9-fd2b807f2642', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-03T14:06:18.677' AS DateTime), CAST(N'2025-06-03T14:06:39.677' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'f0992f05-5ec6-4e28-b376-fd5614762886', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-05-25T19:25:23.483' AS DateTime), CAST(N'2025-05-25T19:25:27.853' AS DateTime), 0, N'37c99bde-5a59-48e2-96d3-971d578f4815', 1)
INSERT [dbo].[sesion] ([session_id], [usuario_id], [fecha_inicio], [fecha_fin], [estado], [ultimo_idioma], [ultimo_rol_id]) VALUES (N'c5b18b5a-6c4f-4a1f-ae43-ff1187e0b725', N'da102f82-03b9-4092-a804-47741b42f4de', CAST(N'2025-06-16T21:25:27.390' AS DateTime), NULL, 1, N'37c99bde-5a59-48e2-96d3-971d578f4815', 2)
GO
SET IDENTITY_INSERT [dbo].[tecnico] ON 

INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (1, N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (2, N'c62603c5-2d56-4dcf-bb30-35948eb2e202', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (3, N'62a7e2a0-1fd3-400e-8ad3-37e56118da67', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (4, N'6af09799-054a-4b1a-b143-40c259570a12', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (5, N'da102f82-03b9-4092-a804-47741b42f4de', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (6, N'86f95524-adc2-4609-844c-4ac2f642867c', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (7, N'd316d289-aaa4-47bc-a199-4b9122303973', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (8, N'f574033a-cd6a-426f-a35e-4dfdcc22568c', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (9, N'78d32d5b-6476-4bfe-af21-53deecf5f633', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (10, N'942561f1-7941-4d6e-a278-566f0e7bde38', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (11, N'2b8bf3dc-516c-4006-a16e-592367eae274', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (12, N'30f87abb-be23-4dcd-9379-7a8266bf1199', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (13, N'4f926bcd-3858-4ac9-a310-8715fdd04858', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (14, N'b1d25d5b-e9be-4d81-b60c-88bde24c24b4', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (15, N'cce4cd43-763d-4c9c-871e-e6bec7c96157', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (16, N'eae6a861-2362-41e8-b268-ee74e71ada22', 1, CAST(N'2025-05-02T01:35:00.460' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (17, N'4551b9cb-32b3-498b-9457-30aadf224def', 1, CAST(N'2025-06-01T23:01:21.933' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (18, N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', 1, CAST(N'2025-06-01T23:10:51.580' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (21, N'3361ff0a-ed4e-48f8-9134-9102e51da531', 1, CAST(N'2025-06-01T23:15:02.480' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (22, N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', 1, CAST(N'2025-06-01T23:28:25.783' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (23, N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', 1, CAST(N'2025-06-01T23:46:47.530' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (24, N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', 1, CAST(N'2025-06-02T21:35:21.477' AS DateTime))
INSERT [dbo].[tecnico] ([tecnico_id], [usuario_id], [activo], [fecha_alta]) VALUES (25, N'e4d68b97-50de-47fd-a129-153af2b205b9', 1, CAST(N'2025-06-16T14:52:38.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[tecnico] OFF
GO
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'873c5b0e-be3a-400c-bf27-12ad568c06aa', CAST(N'2025-05-31T20:00:30.267' AS DateTime), CAST(N'2025-06-16T18:10:45.153' AS DateTime), NULL, 0, N'prueba 12345', N'prueba 12345', 5, 16, 1, 7, NULL, 3, NULL, N'64')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', CAST(N'2025-05-18T01:00:25.073' AS DateTime), CAST(N'2025-06-16T20:34:56.777' AS DateTime), NULL, 0, N'prueba de aprobador 2', N'prueba de aprobador', 5, 27, 3, 2, 3, NULL, NULL, N'06')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'ef97b23b-9e20-4c09-8b1d-209d9747d402', CAST(N'2025-06-10T20:41:17.247' AS DateTime), CAST(N'2025-06-17T00:16:16.913' AS DateTime), NULL, 0, N'Asunto Generico', N'javier.gomez@crm.com', 5, 16, 5, 2, NULL, 6, NULL, N'67')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'a1225313-28fd-42de-8a75-220dbc6cb574', CAST(N'2025-06-14T15:20:34.950' AS DateTime), CAST(N'2025-06-17T00:06:18.797' AS DateTime), NULL, 0, N'test 1', N'<test 1>', 5, 11, 1, 1, NULL, 1, 1, N'40')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', CAST(N'2025-05-18T00:59:29.663' AS DateTime), CAST(N'2025-06-17T00:13:36.097' AS DateTime), NULL, 0, N'prueba de ticket', N'prueba de ticket', 5, 15, 2, 2, 3, NULL, NULL, N'53')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'892fa66e-2290-4f9f-9514-258ec9dd9bd4', CAST(N'2025-05-18T13:21:48.620' AS DateTime), CAST(N'2025-06-01T21:43:03.400' AS DateTime), NULL, 0, N'prueba 12345', N'prueba 12345', 5, 17, 5, 2, NULL, 7, NULL, N'02')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', CAST(N'2025-06-17T00:54:21.143' AS DateTime), CAST(N'2025-06-17T00:56:55.567' AS DateTime), NULL, 0, N'puerto 4949', N'puerto 4949', 9, 27, 3, 4, 3, 3, 22, N'17')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'13538a3c-6beb-477a-8d5d-272eb53e7e37', CAST(N'2025-06-14T13:06:58.183' AS DateTime), CAST(N'2025-06-14T13:07:19.437' AS DateTime), NULL, 0, N'pruebaDeCCSDSDS', N'pruebaDeCCSSDS', 5, 14, 3, 2, NULL, 4, NULL, N'67')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'3488ef91-4dc3-46e6-a6a3-294bfe79e72c', CAST(N'2025-06-10T20:38:00.973' AS DateTime), CAST(N'2025-06-10T20:38:00.973' AS DateTime), NULL, 0, N'prueba de CC 3', N'prueba de CC 3', 5, 19, 5, 2, NULL, 9, NULL, N'45')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'70fa69bd-fc97-4d81-849e-2abef81737cd', CAST(N'2025-06-16T15:21:41.100' AS DateTime), CAST(N'2025-06-17T00:14:25.890' AS DateTime), NULL, 0, N'hola', N'asdsadsa', 5, 11, 1, 2, NULL, 1, 23, N'33')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', CAST(N'2025-06-16T17:48:09.823' AS DateTime), CAST(N'2025-06-16T17:59:11.567' AS DateTime), NULL, 0, N'fdsbfdbxdfsb', N'hgjfgfhgfhgfhghcvasdsa', 3, 12, 2, 2, NULL, 4, NULL, N'34')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', CAST(N'2025-06-16T22:07:40.153' AS DateTime), CAST(N'2025-06-16T22:07:40.153' AS DateTime), NULL, 0, N'pruebadebandeja', N'pruebadebandeja', 2, 30, 1, 6, 3, 12, NULL, N'23')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'a8aca0e6-d96c-47ac-99af-395c24cac3db', CAST(N'2025-06-16T20:27:38.363' AS DateTime), CAST(N'2025-06-16T20:29:10.790' AS DateTime), NULL, 0, N'aprobame Andres', N'aprobame Andres', 2, 27, 3, 7, 3, 3, NULL, N'37')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'b94d9e3c-a405-49a4-874c-3998bfa7c1e9', CAST(N'2025-05-18T00:44:13.507' AS DateTime), CAST(N'2025-05-18T00:44:13.507' AS DateTime), NULL, 0, N'4444', N'444', 5, 11, 1, 2, NULL, NULL, NULL, N'43')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'3bed5285-ea4f-4775-b79c-3c25c12f4449', CAST(N'2025-06-17T00:27:04.673' AS DateTime), CAST(N'2025-06-17T00:50:47.520' AS DateTime), NULL, 0, N'Se necesita crear la vnet del puerto 808', N'revisar asunto', 9, 27, 3, 6, 3, 3, 22, N'48')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', CAST(N'2025-06-10T14:53:53.573' AS DateTime), CAST(N'2025-06-10T20:56:26.417' AS DateTime), NULL, 0, N'ASDA', N'ASDA', 5, 18, 3, 2, NULL, 8, NULL, N'35')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'25272a61-3926-44cf-9246-3f77ed0faed2', CAST(N'2025-06-14T14:31:45.523' AS DateTime), CAST(N'2025-06-16T23:15:30.620' AS DateTime), NULL, 0, N'prueba de control de cambios - PRIMERA Segunda Ite', N'prueba de control de cambios - PRIMERA ITERACION', 5, 11, 1, 2, NULL, 1, 1, N'00')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', CAST(N'2025-06-16T15:16:28.750' AS DateTime), CAST(N'2025-06-16T15:16:28.750' AS DateTime), NULL, 0, N'adsada', N'asdsadsa', 5, 11, 1, 2, NULL, 1, NULL, N'31')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'2cf0d30d-7619-4194-abcb-42627eb8efea', CAST(N'2025-06-16T15:20:33.410' AS DateTime), CAST(N'2025-06-16T15:20:33.410' AS DateTime), NULL, 0, N'adsada', N'asdsadsa', 5, 11, 1, 2, NULL, 1, NULL, N'76')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'c127d461-4ad8-48b7-be38-429abc640ea2', CAST(N'2025-06-10T21:50:49.607' AS DateTime), CAST(N'2025-06-10T21:53:30.193' AS DateTime), NULL, 0, N'ole stopper', N'ole stopper', 5, 15, 5, 2, NULL, 5, NULL, N'05')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'd498d095-90c2-4a6d-ab44-481674399f34', CAST(N'2025-06-16T15:16:33.907' AS DateTime), CAST(N'2025-06-16T15:16:33.907' AS DateTime), NULL, 0, N'adsada', N'asdsadsa', 5, 11, 1, 2, NULL, 1, NULL, N'09')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'0207593e-7c42-4e7e-a105-48736e33c831', CAST(N'2025-05-18T00:46:53.117' AS DateTime), CAST(N'2025-05-18T00:46:53.117' AS DateTime), NULL, 0, N'aaa', N'aaa', 5, 11, 1, 2, NULL, NULL, NULL, N'76')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'eeb568eb-881e-4174-8013-4aafaf152bf0', CAST(N'2025-05-18T01:50:12.560' AS DateTime), CAST(N'2025-05-18T01:50:12.560' AS DateTime), NULL, 0, N'Necesito cambiar los auriculares', N'prueba', 5, 15, 5, 2, NULL, 5, NULL, N'41')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'316a64ea-e572-4c9e-95b2-5c7d405a8339', CAST(N'2025-06-01T21:49:57.833' AS DateTime), CAST(N'2025-06-16T19:54:15.870' AS DateTime), NULL, 0, N'test', N'test', 5, 26, 1, 2, 2, 1, NULL, N'07')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'b25e7fc1-3dd5-4768-826f-6012576a0ca7', CAST(N'2025-06-14T14:52:10.687' AS DateTime), CAST(N'2025-06-14T14:55:04.157' AS DateTime), NULL, 0, N'Modificacion de Asunto de ejemplo de BUG Control d', N'Descripcion de ejemplo de BUG Control de Cambios', 5, 11, 1, 2, NULL, 1, NULL, N'50')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'48910441-4d2d-45c4-9109-778abca1f347', CAST(N'2025-05-18T12:49:35.733' AS DateTime), CAST(N'2025-06-16T20:35:03.770' AS DateTime), NULL, 0, N'Crear una Vnet', N'necesito crear una vnet porque la mia no existe', 5, 27, 3, 7, 3, 3, NULL, N'51')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'7cd9bc46-4bed-4afd-a3f0-7ca0f5a935e4', CAST(N'2025-05-19T23:23:03.187' AS DateTime), CAST(N'2025-06-16T18:14:44.787' AS DateTime), NULL, 0, N'Necesito que se cree una campana', N'sdfds', 5, 13, 3, 2, NULL, 3, NULL, N'01')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'cf1e4d0d-c6fd-4f58-ad9d-80caf5000934', CAST(N'2025-05-18T00:45:41.993' AS DateTime), CAST(N'2025-05-18T00:45:41.993' AS DateTime), NULL, 0, N'dddd', N'ddd', 5, 11, 1, 2, NULL, NULL, NULL, N'35')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'6d98ba02-b051-4294-a51d-836371344aad', CAST(N'2025-05-18T13:51:44.807' AS DateTime), CAST(N'2025-06-01T15:41:10.390' AS DateTime), NULL, 0, N'quiero una compu', N'quiero una compu', 5, 19, 2, 2, NULL, 2, NULL, N'05')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', CAST(N'2025-06-16T15:19:01.510' AS DateTime), CAST(N'2025-06-16T15:19:01.510' AS DateTime), NULL, 0, N'adsada', N'asdsadsa', 5, 11, 1, 2, NULL, 1, NULL, N'92')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', CAST(N'2025-06-11T15:27:46.607' AS DateTime), CAST(N'2025-06-11T15:28:07.570' AS DateTime), NULL, 0, N'pepe barrigon', N'pepe barrigon', 5, 15, 5, 2, NULL, 5, NULL, N'26')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'b7827297-7f2f-47c1-87b4-960581366ba5', CAST(N'2025-05-18T01:11:35.667' AS DateTime), CAST(N'2025-06-16T20:35:00.303' AS DateTime), NULL, 0, N'Prueba', N'marico', 5, 27, 3, 7, 3, NULL, NULL, N'39')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'352457fc-7575-461c-b9af-9effc0fbbcff', CAST(N'2025-05-18T12:26:25.163' AS DateTime), CAST(N'2025-06-17T00:42:58.103' AS DateTime), NULL, 0, N'prueba de creación de ticket', N'esto es una prueba', 5, 12, 2, 4, NULL, 2, 23, N'93')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', CAST(N'2025-06-14T13:28:58.153' AS DateTime), CAST(N'2025-06-14T13:34:43.320' AS DateTime), NULL, 0, N'estoSeriaUnaPruebaCC1 LO CAMBIE A INV', N'estoSeriaUnaPruebaCC1', 5, 15, 5, 2, NULL, 5, NULL, N'25')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'baff0091-3608-45f9-841c-b487e390cca4', CAST(N'2025-06-16T17:14:21.050' AS DateTime), CAST(N'2025-06-16T17:16:08.333' AS DateTime), NULL, 0, N'prueba 333', N'prueba444', 5, 17, 3, 2, NULL, 7, NULL, N'66')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'9c8ce5ae-a6fe-466c-b822-c9de50be6973', CAST(N'2025-05-18T00:58:58.183' AS DateTime), CAST(N'2025-05-18T00:58:58.183' AS DateTime), NULL, 0, N'3', N'3', 5, 27, 3, 6, NULL, NULL, NULL, N'20')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', CAST(N'2025-06-16T20:26:07.113' AS DateTime), CAST(N'2025-06-16T20:26:07.113' AS DateTime), NULL, 0, N'pruebadeAprobador1', N'pruebadeAprobador1', 2, 11, 1, 2, NULL, 1, NULL, N'77')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', CAST(N'2025-05-25T18:58:43.313' AS DateTime), CAST(N'2025-06-01T21:48:48.580' AS DateTime), NULL, 0, N'all in one prueba', N'all in one prueba desc', 5, 11, 5, 2, NULL, 6, NULL, N'25')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'5d407d90-678c-4c26-aee3-e127e2526f77', CAST(N'2025-06-10T20:45:06.897' AS DateTime), CAST(N'2025-06-10T20:54:24.157' AS DateTime), NULL, 0, N'DD', N'CCCDDD', 5, 15, 3, 2, NULL, 5, NULL, N'15')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'8f678b46-76fc-4207-bacc-e321287441b8', CAST(N'2025-05-18T01:18:22.753' AS DateTime), CAST(N'2025-06-16T20:35:04.283' AS DateTime), NULL, 0, N'Prueba 14', N'Prueba 14', 5, 27, 3, 7, 3, 3, NULL, N'36')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'cfcb2395-06d0-4733-8693-e661b3a9a375', CAST(N'2025-06-10T14:50:46.210' AS DateTime), CAST(N'2025-06-10T14:51:25.820' AS DateTime), NULL, 0, N'cambio esto', N'cambio aquello', 5, 17, 3, 2, NULL, 7, NULL, N'73')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', CAST(N'2025-06-10T22:06:33.023' AS DateTime), CAST(N'2025-06-10T22:07:33.427' AS DateTime), NULL, 0, N'55555555555555555', N'55555555555555555555', 5, 15, 2, 2, NULL, 8, NULL, N'69')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'1e81e027-a09c-4512-9d19-eb865ef739f4', CAST(N'2025-05-21T20:33:09.533' AS DateTime), CAST(N'2025-05-21T20:33:09.533' AS DateTime), NULL, 0, N'crear una venta', N'prueba de venta', 5, 14, 4, 2, NULL, 4, NULL, N'92')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'a528d096-ff9c-43cf-a715-ec4506aba6ed', CAST(N'2025-05-18T13:19:46.007' AS DateTime), CAST(N'2025-05-18T13:19:46.007' AS DateTime), NULL, 0, N'prueba 123', N'prueba 123', 5, 11, 1, 2, NULL, 1, NULL, N'00')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', CAST(N'2025-06-16T16:03:57.313' AS DateTime), CAST(N'2025-06-16T16:03:57.313' AS DateTime), NULL, 0, N'ppp', N'ppp', 5, 11, 1, 2, NULL, 1, NULL, N'31')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', CAST(N'2025-06-01T20:11:54.323' AS DateTime), CAST(N'2025-06-01T20:28:36.450' AS DateTime), NULL, 0, N'ELI PRUEBA asd', N'ELI PRUEBAasd', 5, 14, 1, 2, NULL, 4, NULL, N'88')
INSERT [dbo].[ticket] ([ticket_id], [fecha_creacion], [fecha_ultima_modif], [fecha_cierre], [eliminado], [asunto], [descripcion], [cliente_creador_id], [categoria_id], [prioridad_id], [estado_id], [usuario_aprobador_id], [grupo_tecnico_id], [tecnico_id], [digito_verificador_h]) VALUES (N'ce57938b-8daf-4817-acb8-fe470abb480b', CAST(N'2025-06-17T00:18:00.717' AS DateTime), CAST(N'2025-06-17T00:18:00.717' AS DateTime), NULL, 0, N'crear Vnet para la IP 192.168.1.', N'se solicita crear la vnet del asunto', 5, 27, 3, 6, 3, 3, NULL, N'96')
GO
SET IDENTITY_INSERT [dbo].[ticket_estados] ON 

INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'En espera', N'El ticket está en espera de revisión', 1)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'Derivado', N'El ticket ha sido derivado a otro departamento', 2)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'En Proceso', N'El ticket está actualmente en proceso de resolución', 3)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'Resuelto', N'El ticket ha sido resuelto', 4)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'Cerrado', N'El ticket ha sido cerrado definitivamente', 5)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'En Aprobacion', N'El ticket está en proceso de aprobación', 6)
INSERT [dbo].[ticket_estados] ([nombre], [descripcion], [ticket_estado_id]) VALUES (N'Cancelado', N'El ticket ha sido cancelado', 7)
SET IDENTITY_INSERT [dbo].[ticket_estados] OFF
GO
SET IDENTITY_INSERT [dbo].[ticket_historico] ON 

INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (3, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T19:56:49.050' AS DateTime), N'Ticket cancelado', N'Estado', 7, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (4, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:11:54.323' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (5, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:11:54.323' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (6, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:11:54.323' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (7, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:12:23.167' AS DateTime), N'Cambia prioridad de 4 a 1', N'Prioridad', 4, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (8, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:12:23.197' AS DateTime), N'Prioridad cambiada de Id 4 a Id 1', N'Prioridad', 4, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (9, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:18:20.683' AS DateTime), N'Reasignado de grupo 3 a 6', N'GrupoTécnico', 3, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (10, N'bbb6a013-1a3b-497f-9b31-fdbe97e3a2e3', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T20:28:05.427' AS DateTime), N'Se agregó comentario: "eli es un cachon de mierda"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (11, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:34:51.003' AS DateTime), N'Reasignado de grupo  a 3', N'GrupoTécnico', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (12, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:35:31.943' AS DateTime), N'Se agregó comentario: "aprobar con urgencia"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (13, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:35:32.000' AS DateTime), N'Reasignado de grupo  a 3', N'GrupoTécnico', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (14, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:36:01.493' AS DateTime), N'Se agregó comentario: "prueba de aprobacion"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (15, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:36:01.510' AS DateTime), N'Reasignado de grupo  a 3', N'GrupoTécnico', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (16, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:37:09.277' AS DateTime), N'Reasignado de grupo  a 3', N'GrupoTécnico', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (17, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:39:57.223' AS DateTime), N'Reasignado de grupo  a 3', N'GrupoTécnico', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (18, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:42:36.200' AS DateTime), N'Reasignado de grupo 3 a 6', N'GrupoTécnico', 3, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (19, N'892fa66e-2290-4f9f-9514-258ec9dd9bd4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:43:03.383' AS DateTime), N'Se agregó comentario: "esto es otra prueba"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (20, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:43:44.423' AS DateTime), N'Cambia categoría de 16 a 11', N'Categoría', 16, 11)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (21, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:43:44.430' AS DateTime), N'Reasignado de grupo 6 a 1', N'GrupoTécnico', 6, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (22, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:48:26.770' AS DateTime), N'Cambia categoría de 11 a 17', N'Categoría', 11, 17)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (23, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:48:26.777' AS DateTime), N'Reasignado de grupo 6 a 7', N'GrupoTécnico', 6, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (24, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:48:48.563' AS DateTime), N'Cambia categoría de 17 a 11', N'Categoría', 17, 11)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (25, N'00f2fac1-09ab-4146-b7f6-db6f8ef9cbce', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:48:48.570' AS DateTime), N'Reasignado de grupo 6 a 1', N'GrupoTécnico', 6, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (26, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:49:57.833' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (27, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:49:57.833' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (28, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:49:57.833' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (29, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:51:37.423' AS DateTime), N'Cambia categoría de 11 a 26', N'Categoría', 11, 26)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (30, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:52:46.063' AS DateTime), N'Se agregó comentario: "prueba"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (31, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-01T21:53:03.863' AS DateTime), N'Se agregó comentario: "prueba 2"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (32, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-02T21:30:56.483' AS DateTime), N'Se agregó comentario: "ultima prueba"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (33, N'873c5b0e-be3a-400c-bf27-12ad568c06aa', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-02T21:30:56.527' AS DateTime), N'Reasignado de grupo 3 a 6', N'GrupoTécnico', 3, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (34, N'cfcb2395-06d0-4733-8693-e661b3a9a375', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:50:46.210' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (35, N'cfcb2395-06d0-4733-8693-e661b3a9a375', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:50:46.210' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (36, N'cfcb2395-06d0-4733-8693-e661b3a9a375', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:50:46.210' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (37, N'cfcb2395-06d0-4733-8693-e661b3a9a375', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:51:25.800' AS DateTime), N'Cambia prioridad de 5 a 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (38, N'cfcb2395-06d0-4733-8693-e661b3a9a375', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:51:25.817' AS DateTime), N'Prioridad cambiada de Id 5 a Id 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (39, N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:53:53.573' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (40, N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:53:53.573' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (41, N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:53:53.573' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 8)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (42, N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:54:38.223' AS DateTime), N'Cambia prioridad de 5 a 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (43, N'1d76638e-4b96-46aa-a59b-3d126e28c6c7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T14:54:38.240' AS DateTime), N'Prioridad cambiada de Id 5 a Id 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (44, N'3488ef91-4dc3-46e6-a6a3-294bfe79e72c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:38:00.973' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (45, N'3488ef91-4dc3-46e6-a6a3-294bfe79e72c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:38:00.973' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (46, N'3488ef91-4dc3-46e6-a6a3-294bfe79e72c', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:38:00.973' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 9)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (47, N'5d407d90-678c-4c26-aee3-e127e2526f77', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:45:06.897' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (48, N'5d407d90-678c-4c26-aee3-e127e2526f77', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:45:06.897' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (49, N'5d407d90-678c-4c26-aee3-e127e2526f77', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:45:06.897' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 5)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (50, N'5d407d90-678c-4c26-aee3-e127e2526f77', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:50:50.720' AS DateTime), N'Cambia prioridad de 5 a 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (51, N'5d407d90-678c-4c26-aee3-e127e2526f77', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T20:50:50.737' AS DateTime), N'Prioridad cambiada de Id 5 a Id 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (52, N'c127d461-4ad8-48b7-be38-429abc640ea2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T21:50:49.607' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (53, N'c127d461-4ad8-48b7-be38-429abc640ea2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T21:50:49.607' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (54, N'c127d461-4ad8-48b7-be38-429abc640ea2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T21:50:49.607' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 5)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (55, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:06:33.023' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (56, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:06:33.023' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (57, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:06:33.023' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 8)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (58, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:07:33.267' AS DateTime), N'Se agregó comentario: "pepe"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (59, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:07:33.373' AS DateTime), N'Cambia prioridad de 5 a 2', N'Prioridad', 5, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (60, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:07:33.380' AS DateTime), N'Cambia categoría de 18 a 15', N'Categoría', 18, 15)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (61, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:07:33.383' AS DateTime), N'Reasignado de grupo 8 a 5', N'GrupoTécnico', 8, 5)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (62, N'346f1c3a-3715-4cb5-80cd-e84e2e28274e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-10T22:07:33.417' AS DateTime), N'Prioridad cambiada de Id 5 a Id 2', N'Prioridad', 5, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (63, N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:27:46.607' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (64, N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:27:46.607' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (65, N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:27:46.607' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 5)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (66, N'6c553f7f-67fd-4d4e-93da-92ec2b3bd378', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-11T15:28:07.490' AS DateTime), N'Se agregó comentario: "arisk"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (67, N'13538a3c-6beb-477a-8d5d-272eb53e7e37', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:06:58.183' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (68, N'13538a3c-6beb-477a-8d5d-272eb53e7e37', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:06:58.183' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (69, N'13538a3c-6beb-477a-8d5d-272eb53e7e37', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:06:58.183' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (70, N'13538a3c-6beb-477a-8d5d-272eb53e7e37', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:07:19.393' AS DateTime), N'Cambia prioridad de 4 a 3', N'Prioridad', 4, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (71, N'13538a3c-6beb-477a-8d5d-272eb53e7e37', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:07:19.433' AS DateTime), N'Prioridad cambiada de Id 4 a Id 3', N'Prioridad', 4, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (72, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:28:58.153' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (73, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:28:58.153' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (74, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:28:58.153' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 5)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (75, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:29:35.547' AS DateTime), N'Se agregó comentario: "estoper"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (76, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:29:35.657' AS DateTime), N'Cambia categoría de 15 a 17', N'Categoría', 15, 17)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (77, N'2ca8db6a-7f92-4004-a56d-b3e269d5f0ae', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T13:29:35.663' AS DateTime), N'Reasignado de grupo 5 a 7', N'GrupoTécnico', 5, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (78, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:31:45.523' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (79, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:31:45.523' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (80, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:31:45.523' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (81, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:34:29.787' AS DateTime), N'Ticket cancelado', N'Estado', 2, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (82, N'b25e7fc1-3dd5-4768-826f-6012576a0ca7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:52:10.687' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (83, N'b25e7fc1-3dd5-4768-826f-6012576a0ca7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:52:10.687' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (84, N'b25e7fc1-3dd5-4768-826f-6012576a0ca7', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T14:52:10.687' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (85, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T15:20:34.950' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (86, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T15:20:34.950' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (87, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-14T15:20:34.950' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (88, N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:28.750' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (89, N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:28.750' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (90, N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:28.750' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (91, N'd498d095-90c2-4a6d-ab44-481674399f34', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:33.907' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (92, N'd498d095-90c2-4a6d-ab44-481674399f34', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:33.907' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (93, N'd498d095-90c2-4a6d-ab44-481674399f34', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:16:33.907' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (94, N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:19:01.510' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (95, N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:19:01.510' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (96, N'928d5706-6eec-4053-ad8c-8a50ccdc0ac0', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:19:01.510' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (97, N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:20:33.410' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (98, N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:20:33.410' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (99, N'2cf0d30d-7619-4194-abcb-42627eb8efea', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:20:33.410' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (100, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:21:41.100' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (101, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:21:41.100' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
GO
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (102, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T15:21:41.100' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (103, N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:03:57.313' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (104, N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:03:57.313' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (105, N'32955359-fdd5-4dee-9ee5-fb2d31d2bc5e', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:03:57.313' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (106, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T16:23:49.387' AS DateTime), N'Se agregó comentario: "QASASDSA"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (107, N'baff0091-3608-45f9-841c-b487e390cca4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:14:21.050' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (108, N'baff0091-3608-45f9-841c-b487e390cca4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:14:21.050' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (109, N'baff0091-3608-45f9-841c-b487e390cca4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:14:21.050' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (110, N'baff0091-3608-45f9-841c-b487e390cca4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:16:08.250' AS DateTime), N'Cambia prioridad de 5 a 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (111, N'baff0091-3608-45f9-841c-b487e390cca4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T17:16:08.330' AS DateTime), N'Prioridad cambiada de Id 5 a Id 3', N'Prioridad', 5, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (112, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:48:09.823' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (113, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:48:09.823' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (114, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:48:09.823' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (115, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:48:32.423' AS DateTime), N'Se agregó comentario: "jhg,vjghjgkh"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (116, N'a3cac672-6385-48e2-bf18-2d7bdbb3816f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T17:48:44.297' AS DateTime), N'Prioridad cambiada de Id 4 a Id 2', N'Prioridad', 4, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (117, N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:11:16.913' AS DateTime), N'Prioridad cambiada de Id 4 a Id 2', N'Prioridad', 4, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (118, N'7cd9bc46-4bed-4afd-a3f0-7ca0f5a935e4', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T18:14:39.770' AS DateTime), N'Se agregó comentario: "eaaaa"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (119, N'316a64ea-e572-4c9e-95b2-5c7d405a8339', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T19:54:15.887' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (120, N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:26:07.113' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (121, N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:26:07.113' AS DateTime), N'Apertura automática', N'Estado', NULL, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (122, N'8c2c62ae-5afa-4044-949f-cc7fd377be1b', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:26:07.113' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (123, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:27:38.363' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (124, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:27:38.363' AS DateTime), N'Enviado a aprobación', N'Estado', NULL, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (125, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:27:38.363' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (126, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:29:10.797' AS DateTime), N'Ticket rechazado y cancelado', N'Cancelación', 6, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (127, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:31:29.773' AS DateTime), N'Se agregó comentario: "forro"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (128, N'a8aca0e6-d96c-47ac-99af-395c24cac3db', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T20:31:39.910' AS DateTime), N'Ticket cancelado', N'Estado', 7, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (129, N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:34:53.597' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (130, N'687ee4c4-ed4e-4b64-bc0b-1c988dc661aa', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:34:56.777' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (131, N'b7827297-7f2f-47c1-87b4-960581366ba5', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:35:00.307' AS DateTime), N'Ticket rechazado y cancelado', N'Cancelación', 6, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (132, N'48910441-4d2d-45c4-9109-778abca1f347', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:35:03.773' AS DateTime), N'Ticket rechazado y cancelado', N'Cancelación', 6, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (133, N'8f678b46-76fc-4207-bacc-e321287441b8', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-16T20:35:04.287' AS DateTime), N'Ticket rechazado y cancelado', N'Cancelación', 6, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (134, N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:07:40.153' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (135, N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:07:40.153' AS DateTime), N'Enviado a aprobación', N'Estado', NULL, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (136, N'89b9bd7a-a01d-4c0f-94ca-34e15224acb1', N'f574033a-cd6a-426f-a35e-4dfdcc22568c', CAST(N'2025-06-16T22:07:40.153' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 12)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (137, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:07:30.783' AS DateTime), N'Se agregó comentario: "se resuelve"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (138, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:07:30.883' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (139, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:07:48.007' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (140, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:09:57.423' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (141, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:13:24.370' AS DateTime), N'Se agregó comentario: "en espera"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (142, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:13:24.427' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 23)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (143, N'70fa69bd-fc97-4d81-849e-2abef81737cd', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:13:24.427' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (144, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:13:41.953' AS DateTime), N'Se agregó comentario: "en espera"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (145, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:14:07.910' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (146, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-16T23:15:30.540' AS DateTime), N'Se agregó comentario: "prueba123"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (147, N'25272a61-3926-44cf-9246-3f77ed0faed2', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:15:30.583' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (148, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:16:36.453' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (149, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:24:42.843' AS DateTime), N'Estado cambiado', N'Estado', 2, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (150, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:30:16.707' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (151, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:33:21.300' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (152, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:35:40.970' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (153, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:41:25.673' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (154, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', CAST(N'2025-06-16T23:42:05.947' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (155, N'a1225313-28fd-42de-8a75-220dbc6cb574', N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', CAST(N'2025-06-16T23:45:26.353' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (156, N'be3b4ea2-1f4e-4b2e-b19b-22a769076d9f', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:13:32.757' AS DateTime), N'Se agregó comentario: "esto es una prueba"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (157, N'a4ef84e4-4ab8-455c-bdde-4119bc7096d5', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:15:19.757' AS DateTime), N'Ticket cancelado', N'Estado', 2, 7)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (158, N'ce57938b-8daf-4817-acb8-fe470abb480b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:18:00.717' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (159, N'ce57938b-8daf-4817-acb8-fe470abb480b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:18:00.717' AS DateTime), N'Enviado a aprobación', N'Estado', NULL, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (160, N'ce57938b-8daf-4817-acb8-fe470abb480b', N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', CAST(N'2025-06-17T00:18:00.717' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (161, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:27:04.673' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (162, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:27:04.673' AS DateTime), N'Enviado a aprobación', N'Estado', NULL, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (163, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:27:04.673' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (164, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:28:43.647' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (165, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:33:17.340' AS DateTime), N'Se agregó comentario: "darle celeridad al pedido"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (166, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:34:38.673' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (167, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:38:09.120' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (168, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:41:46.690' AS DateTime), N'Se agregó comentario: "se resuelve"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (169, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:41:49.903' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 23)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (170, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:41:49.907' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (171, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:42:21.603' AS DateTime), N'Estado cambiado', N'Estado', 6, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (172, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:42:41.023' AS DateTime), N'Estado cambiado', N'Estado', 6, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (173, N'352457fc-7575-461c-b9af-9effc0fbbcff', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:42:58.077' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 23)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (174, N'352457fc-7575-461c-b9af-9effc0fbbcff', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:42:58.077' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (175, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:43:25.663' AS DateTime), N'Estado cambiado', N'Estado', 6, 4)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (176, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:45:25.993' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (177, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:47:59.113' AS DateTime), N'Se agregó comentario: "solo es una prueba"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (178, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:50:03.793' AS DateTime), N'Se agregó comentario: "se deja en espera"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (179, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:50:30.103' AS DateTime), N'Técnico cambiado', N'Técnico', 23, 22)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (180, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:50:30.110' AS DateTime), N'Estado cambiado', N'Estado', 2, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (181, N'3bed5285-ea4f-4775-b79c-3c25c12f4449', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:50:47.423' AS DateTime), N'Estado cambiado', N'Estado', 6, 1)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (182, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:54:21.143' AS DateTime), N'Ticket creado', N'Creación', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (183, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:54:21.143' AS DateTime), N'Enviado a aprobación', N'Estado', NULL, 6)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (184, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:54:21.143' AS DateTime), N'Asignado automáticamente según categoría', N'Grupo', NULL, 3)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (185, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:54:47.607' AS DateTime), N'Se agregó comentario: "DARLE CELERIDAD AL ASUNTO"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (186, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'4f926bcd-3858-4ac9-a310-8715fdd04858', CAST(N'2025-06-17T00:56:02.353' AS DateTime), N'Ticket aprobado y derivado', N'Aprobación', 6, 2)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (187, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'75823e87-7292-4817-bef7-8d73f2137f1c', CAST(N'2025-06-17T00:56:50.393' AS DateTime), N'Se agregó comentario: "CERRADO"', N'Comentario', NULL, NULL)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (188, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:56:55.507' AS DateTime), N'Técnico cambiado', N'Técnico', 0, 22)
INSERT [dbo].[ticket_historico] ([ticket_historial_id], [ticket_id], [usuario_id], [fecha_cambio], [comentario], [TipoEvento], [ValorAnteriorId], [ValorNuevoId]) VALUES (189, N'f9b80ce4-7c6e-498b-ba1d-25dd91aad9b7', N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', CAST(N'2025-06-17T00:56:55.513' AS DateTime), N'Estado cambiado', N'Estado', 2, 4)
SET IDENTITY_INSERT [dbo].[ticket_historico] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_categoria] ON 

INSERT [dbo].[tipo_categoria] ([tipo_id], [nombre], [descripcion]) VALUES (1, N'Requerimiento', N'Solicitud de un nuevo servicio o funcionalidad.')
INSERT [dbo].[tipo_categoria] ([tipo_id], [nombre], [descripcion]) VALUES (2, N'Incidente', N'Problema inesperado que interfiere con el servicio.')
INSERT [dbo].[tipo_categoria] ([tipo_id], [nombre], [descripcion]) VALUES (3, N'Problema', N'Un error conocido que causa incidentes recurrentes.')
SET IDENTITY_INSERT [dbo].[tipo_categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[tipos_clientes] ON 

INSERT [dbo].[tipos_clientes] ([tipo_cliente_id], [nombre], [descripcion]) VALUES (1, N'Interno', N'Cliente interno, asociado a un departamento de la empresa.')
INSERT [dbo].[tipos_clientes] ([tipo_cliente_id], [nombre], [descripcion]) VALUES (2, N'Externo', N'Cliente externo, personas físicas o empresas.')
INSERT [dbo].[tipos_clientes] ([tipo_cliente_id], [nombre], [descripcion]) VALUES (3, N'Proveedor', N'Proveedores que ofrecen servicios o productos.')
SET IDENTITY_INSERT [dbo].[tipos_clientes] OFF
GO
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'211e625a-cf4f-41c9-91f2-00626972ff8e', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'09e8f2c7-26a3-4a32-9893-00ceda63479a', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3e431f49-c50f-41a9-9f3a-039900b2ecdb', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'10d8737c-595b-47fd-8db3-044e7a0240ec', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'14c5b3a2-f585-4f4e-a32b-04675137e052', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f0c4ca74-e29b-4d7c-963f-049b90a63047', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a927d694-cc67-4655-aa16-057c2340f566', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'255836d5-ca53-46be-83e9-058676c18b96', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'10cf3284-6ca9-4d22-8c49-05da6b57abab', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'Modificar elementos')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0a0efa20-249d-4c2b-8af0-0698a9800f80', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5e824f28-8463-414e-8e37-08e65f14a7b1', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd45e15cc-f95c-4b9c-a5b9-0a3c899be268', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'Mi cuenta')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8d1969f6-9c0e-4756-a089-0a516e122552', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'bbbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'27ce6f8c-0762-4bb7-982c-0ae99818fa3a', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'aaaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8e908cd6-e7c6-4145-b3b6-0b79ca420e5e', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'Modify items')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'729176dd-8c33-4800-b09e-0bc6620dbe71', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'Cambiar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f7126a16-e521-420b-bb74-0bf84a8dafd4', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'My account')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ba6fe726-e761-4ecd-9421-0c58dc2d69f9', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'339c85b1-5c87-456a-b254-6d5101949924', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e58cf312-3b93-4b51-a8da-0c59c9ec1713', N'6146e65f-7984-4c0f-8503-f891700e552d', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5eccbfdd-a3c6-4f66-9547-0c9156a4c196', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3b4af9de-043c-44a5-a26b-0d6bcd58a20f', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6f640dd8-5ca7-40fb-93a3-0dad75b4908d', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'adb6a3ed-936f-4e64-90e9-0ed2526f9f01', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'577183bf-a770-49f4-a8a5-0f8273f104fe', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'36835d61-04fe-4e9d-8691-0fedc1c59be1', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3b1ae90e-fef1-4c20-9959-1011d10801ef', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'647bddf6-3de0-4233-99ac-1077494980ad', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'Mi Perfil')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'76342f4f-2e6d-4063-b074-10dc9e61aeb2', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c5c8deef-b086-47a4-9d03-14dd4e5237b8', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'aa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8a71f92f-f4fd-444b-88fe-154a71b44ba6', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd4b8078f-e683-4aee-a335-15a20279323a', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'Mi Perfil')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'57f1aa29-291b-4d4c-bc73-1621c0f2023d', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N's')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3a3dd390-619d-48eb-a3e9-164a646b34b1', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9f62b028-dfb1-448f-8741-17ac2ef2beab', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'acd41904-e810-47eb-9617-1894978f2d7a', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'625aedc9-df03-462e-9545-192bb38e75bb', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4d44778c-a4f1-4309-b668-19b21d252264', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5f0075e9-afa7-4939-a6d5-1a1e80ef112c', N'6146e65f-7984-4c0f-8503-f891700e552d', N'38bda55c-e4a4-4060-969c-71b22d100203', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6604461e-d544-496a-b003-1a3f3c10fbdf', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4289749a-1f36-4f6c-b1a6-1a49c02a6dfe', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8f6b445b-8848-450f-a739-1a9b8810e093', N'6146e65f-7984-4c0f-8503-f891700e552d', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ff6b43a0-ab20-4284-b1a9-1adef27cada4', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'97b55aee-5718-41e3-a038-1b5a74dca76c', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'69bc132c-9333-4cba-9103-1c0741694b68', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'4be67089-ffab-431a-9964-e655278c3200', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6baa25b0-1eb1-4615-8a80-1c2e78b733bf', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'63bd7e87-bf5d-4930-8bda-1c47697c80ea', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'58164282-7f7a-4886-9f24-9809330e1b06', N'c')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7121c30e-28b7-4ec2-82e2-1c78f5b57d43', N'6146e65f-7984-4c0f-8503-f891700e552d', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'be03f9ef-2ed3-460c-a81b-1c93a94f90f4', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'116bd9d8-13e2-40b5-86b7-1dd6cb829d0d', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'266477e2-f731-4d0f-be49-db30ab16da35', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ae66d739-c99e-4103-810c-1e278ff7f433', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'Change Role')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'061895e9-e2a8-4b31-834b-1e9829317593', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'Borrar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'24abcf60-4bcd-4eb4-8738-1ea742dae633', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'aa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'804a739e-70e9-4b63-bf31-1f78404236ef', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1ef3aba2-1498-47de-88ab-208af73b6e7a', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'aaaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'65d9a70d-4244-4076-a3c7-20ab0a02b32b', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'05f11c72-647f-438f-b87f-20def7b1a393', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'4867bda0-5924-4216-bc24-987c351fd47a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'91adf0bb-b97f-419a-874b-20e5e4916d51', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f09ee893-20a8-4f9e-b523-20fdbf65a043', N'6146e65f-7984-4c0f-8503-f891700e552d', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a99c94ec-528b-4112-b512-2218ffbb602d', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'734783c2-65ea-4a65-8154-2342d7129359', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'14efcf16-895a-46f6-a576-31860315bc12', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5508ab72-f966-4c73-847b-252a94539795', N'6146e65f-7984-4c0f-8503-f891700e552d', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd15b2136-9b6d-4198-a65c-2653e3110a24', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'Change Role')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'aef9fdcb-60b2-4412-be9b-26a5ee197176', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b4113ac0-391c-479d-9949-277d26ae99c9', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'Datos personales')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd2064027-980e-46e2-9a14-279791e6966b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3173a52c-9479-445d-9f34-285023927765', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'153bdbe4-5c54-4d2c-9bbf-2852e8ab97ce', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'59254406-fca8-48cd-9ede-08b064febf0a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3b5aca35-c082-4506-b4ac-29dbc884accd', N'6146e65f-7984-4c0f-8503-f891700e552d', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2a7da106-c402-45c2-bd3f-2a1b0d5d0c8e', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f89dac58-b643-4916-a0ed-2ab3461ba907', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'58c25260-6bb0-4005-ad69-2ad875123ff6', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'Change Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1bce03ee-32ad-4ea6-84f6-2b37c017ead1', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'26d462f6-f4ed-43f5-a500-2d3457be9c0c', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'435f9591-6f1d-47aa-ad08-2f0c54b7f28a', N'6146e65f-7984-4c0f-8503-f891700e552d', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c1be3512-b56b-4d2b-b61f-2f7ca7261214', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'339c85b1-5c87-456a-b254-6d5101949924', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'91d82ab5-27ed-4059-bd5c-2fb606dcbbc5', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'My Profile')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3e43bb32-49f2-4b94-a08c-313dea57dee1', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a35a6f30-db2c-4bff-a19f-31610cef1243', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0c3a364a-bcef-4edb-a40b-327c1bd8fd91', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0c88e388-f84f-4fb3-becf-32e7bb4b2020', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8f3accd9-c679-4ad4-97d0-33678dfd20c9', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e4e9c1b7-a0ba-4f07-81dd-3477cfb1e11f', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b8f6211b-8fe2-4a6e-9a7d-348f445223cf', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'db5aff88-bcbc-4a1e-bc81-34acc9bd81aa', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'aa8c86fe-9fc0-446f-a691-351c818937ca', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'427678c9-000a-4dd4-8948-352b7202ab9d', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'95ff37f2-bbcc-4da2-a7c7-35b440c4a177', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5f9f9868-be69-4ccf-9de8-35bec04baa1e', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'Configuracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fdb8e84a-f302-4f20-bcd6-35f94a8a7bb3', N'6146e65f-7984-4c0f-8503-f891700e552d', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd2bb0374-3ea8-4f82-b754-360434875c9e', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'ddd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1f94a7e7-b402-4d6e-a93f-36d838c34d96', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd14b6e81-c12b-4ae0-815f-37178fa1329e', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'015f4eb0-4f83-4d7a-9a1f-3794ed0409ef', N'6146e65f-7984-4c0f-8503-f891700e552d', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b51c4940-18ec-486c-a61c-37d8e9cb49c6', N'6146e65f-7984-4c0f-8503-f891700e552d', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fd2afa50-edff-4ce5-af73-38b46df66599', N'6146e65f-7984-4c0f-8503-f891700e552d', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'39c49deb-3cd4-4058-9006-38d1c7f4cc2a', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'266477e2-f731-4d0f-be49-db30ab16da35', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'65930b55-fce4-4438-a622-3a7700d00244', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'852725e2-f997-4a11-8921-3dfc43d8bccc', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'813efd46-eefc-4c78-a33f-3e18a10679ee', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'14efcf16-895a-46f6-a576-31860315bc12', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a52f557d-4ace-46e1-bd03-3e827c19c2b9', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'')
GO
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9bef59d1-8733-4912-b971-3e8b41d02cf4', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'Delete items')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b4bf3683-fc2c-4859-a959-3f4d317a3a13', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'Borrar elementos')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'47fac778-d62b-4ed7-b46f-3f6e7dd3edbb', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5cd251c5-22f6-4436-9769-40014e583d64', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'eee')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'586fc594-216b-4b3d-90ae-408c1c2c3c89', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'69daec47-57ba-45cb-8b8d-40a56a91e945', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9a585655-3017-482e-badd-87868b8e9aec', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bf76c204-86d2-446b-ba24-414bada0e175', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3ce02f1c-d36b-4be9-a1ea-41d45c3ab5dc', N'6146e65f-7984-4c0f-8503-f891700e552d', N'59254406-fca8-48cd-9ede-08b064febf0a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1fad9eda-e9e1-4f77-abd1-42760f4c0fa5', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'My Profile')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'471f1c16-55be-4133-8848-42874a6c6a92', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b5e7a49b-e0df-47f8-9327-42ec56ce2ba4', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9bec6bde-6065-448c-89c3-42ff5ad0e8c4', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'Administracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'650e0b36-2d59-477d-ad77-4457dc815ed1', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'Agregar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4921bae8-8990-4c22-9150-44971a87d71c', N'6146e65f-7984-4c0f-8503-f891700e552d', N'14efcf16-895a-46f6-a576-31860315bc12', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'29e394c8-3990-4c02-b129-44aba5948c37', N'6146e65f-7984-4c0f-8503-f891700e552d', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'71fa702a-137e-4d60-af17-44b2e4ba1da4', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ddbf444a-e135-47aa-aa9f-44b943e2a193', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'Delete Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a7716cdc-9027-4e20-9df2-44ddf63ff58d', N'6146e65f-7984-4c0f-8503-f891700e552d', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'163e03b3-ed34-4381-b8b4-453a36bd61e3', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'67a041f9-018c-496e-8820-4552010e61e0', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'60ab106e-3054-4b58-bc2c-475eac55614b', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b21f9590-4c34-42f6-b155-48abcebcd643', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'008d0b0d-9f53-4bb2-b160-49959502b112', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e754edf3-be9f-4dcf-8464-49fe54cd4fa2', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'43556e52-06ed-4c0e-b59b-4c4297eb006a', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b4080431-21e1-4376-9fb4-4ceef7cbf9ae', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'Help')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ef229c5c-17c2-4f21-8004-4d55c5cdb893', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c3a06fde-9da5-4a82-abfd-4dab125c8774', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'339c85b1-5c87-456a-b254-6d5101949924', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'208f1614-316b-4a7e-b6e7-4de2efb18444', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b541c557-2a62-49d8-8fd3-4e1013eb4b31', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'4867bda0-5924-4216-bc24-987c351fd47a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0c59380b-3f13-4369-a0d7-4efb2b994fea', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'579f49cf-b329-4298-a9c2-4f7c99086ed7', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'4be67089-ffab-431a-9964-e655278c3200', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'13b7c543-7b66-47e9-a446-50689bd0082d', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'09bb3796-89d1-4620-90a0-50e322b02902', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5491f9bb-0785-48be-a6de-51b7af493796', N'6146e65f-7984-4c0f-8503-f891700e552d', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'83e6badd-2104-43b8-b251-51d0e6db2fce', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'85456cb1-d02d-471f-b5de-523855491b4e', N'6146e65f-7984-4c0f-8503-f891700e552d', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bf0f2eab-2992-48bd-a121-5275e192ca7c', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b5bdc81f-2c02-44ff-9846-5298e0fa442f', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e6a32a06-8960-4ec5-8396-5471b2188b97', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'Ver inventario')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9116e397-70d7-44dc-866b-55750f28daae', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'g')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e5bdeb31-3460-4fc3-a505-557ce17138d2', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'63a9adcd-d15f-4a93-9dd3-561cd81c51f9', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bb8b22d7-5d2b-4da9-b801-5702564b27a0', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c53af49f-3840-4933-991c-572610fdcc2b', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'Desloguear')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8ba1a141-4c4f-4c1c-9b17-579cc8625e67', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'562813ea-9113-4242-a361-58417f4a782d', N'6146e65f-7984-4c0f-8503-f891700e552d', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eb5502fc-8fbd-4beb-9762-58ed71c95134', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'801488ce-1366-414f-89c1-59768a0e1600', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'db09a0cb-3b94-46f4-b4f8-59c6a110e21f', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'22068064-56e6-40e7-8f10-5a69aa79394b', N'6146e65f-7984-4c0f-8503-f891700e552d', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2c2f9364-ab84-40bd-a516-5a847bcc4572', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'38f1499a-cf90-4e0e-9efd-5c1f6e4b97e3', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c9c046b9-cc9a-4328-869a-5c84074ae322', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1bc652dc-0a43-4079-a5b7-5caa811191cb', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'eee')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'362ec532-9046-4a1b-89c7-5d9295102e15', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'Mi Perfil')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4b8af7a4-723a-43fd-a677-5dc5be899657', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6bfcca10-426b-4991-94ab-5dfa44a3254a', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'14efcf16-895a-46f6-a576-31860315bc12', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd7a6b253-424c-4f66-9e04-5e17144bb61f', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'339c85b1-5c87-456a-b254-6d5101949924', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8edeaccf-2674-451b-830f-5ee0f7606ab9', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fed7a189-1bea-4f54-a63f-5f396f8865f7', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'020249e8-affe-494b-8cab-5f7f0ab93960', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'38bda55c-e4a4-4060-969c-71b22d100203', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c486b8a1-20ed-428f-a13a-5ffdf10a81fd', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'Personal data')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b2c2dfd7-9ac8-4259-965d-618da7efc6a0', N'6146e65f-7984-4c0f-8503-f891700e552d', N'266477e2-f731-4d0f-be49-db30ab16da35', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b7296d4b-284a-47b0-8804-61fa6ae94db6', N'6146e65f-7984-4c0f-8503-f891700e552d', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8f9bf9b3-2403-44ec-828f-622dce082e8b', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c73e4976-9fcb-4a22-9cb9-628f688f4564', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9a585655-3017-482e-badd-87868b8e9aec', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a048bf66-edd7-46c3-a44b-62bc17fcd784', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'27c073e1-7f32-4a3f-b26d-63315c793503', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'38bda55c-e4a4-4060-969c-71b22d100203', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'13be4456-8fdc-48cf-9e0d-635c93cd0d79', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2cdc5cd2-afd7-4ccd-91d7-6391a06fc965', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'38bda55c-e4a4-4060-969c-71b22d100203', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bf025375-a520-4890-a2a1-63a857e724a4', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0cc1fa8b-aa9a-462c-ad0c-63c803e7e8ab', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b9307e65-2cb7-49b0-94ee-64081674891a', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd13a5e08-79b0-4372-95a9-64990c36d2b4', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9b26a84a-45ec-4116-963f-649b11f1aa68', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a39f959c-ceaa-4294-9f62-64ec2e1a9763', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9a585655-3017-482e-badd-87868b8e9aec', N'Administration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7dee050d-a182-4515-828c-6620e10ef976', N'6146e65f-7984-4c0f-8503-f891700e552d', N'4be67089-ffab-431a-9964-e655278c3200', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5cfbbadb-b53f-47a9-94da-663f1e73fa49', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fc277bf5-ed3b-497f-8bcd-687b604fc1e3', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'aaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8ba1b70c-a5d0-415d-be1c-688679353a8c', N'6146e65f-7984-4c0f-8503-f891700e552d', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fa48ac65-0e81-4656-a061-68bcf505bb2b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fcd31718-5dbb-477f-95df-692fce887253', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'05f7e4f8-a0ab-410d-be61-69623cf02afa', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'379a72e2-0481-4e22-b302-6adad0c38176', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0fab01e9-34ba-465a-a59c-6b78a2a58b9e', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5705d3c4-bcc2-40de-9bc3-6b9652987b40', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'Modificar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'141ba4dd-13da-45b4-9ba3-6cb791681cd3', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'092d5b79-41f4-4ef7-92c0-6ce07df5c148', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'My Profile')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ea0c5a7c-0716-4baf-a71f-6d3451f4b4c3', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'g')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'57c351a7-9522-410b-ba82-6d5acf4ba560', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b1e2e058-fcb5-47ca-8163-6d923a984873', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2b8a486a-14ed-4ff6-9cde-6da9ed437bb2', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1ad72f25-71b7-4211-b618-6e9a2e394159', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'92a76d63-b68f-46a1-8b33-6ef7a5a01144', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'58164282-7f7a-4886-9f24-9809330e1b06', N'c')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ce5e3610-a8e6-48cd-ba30-6f4e3bc20c2b', N'6146e65f-7984-4c0f-8503-f891700e552d', N'58164282-7f7a-4886-9f24-9809330e1b06', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5609bd10-d478-4866-bdf9-7112581d00ab', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a24d3d41-b4ca-4aa2-aca2-71519ed79db2', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b2c611e9-7b98-4f2f-800d-721667ffa443', N'6146e65f-7984-4c0f-8503-f891700e552d', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c3567612-f830-4eea-9ac5-72338203e661', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'')
GO
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'dc81f475-d2aa-4ff1-b0fd-72c1bacbfa8b', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9a585655-3017-482e-badd-87868b8e9aec', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8c76cf29-a5d6-4bc5-ada6-730e6a3d6d46', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8c2ab191-bf6f-42c4-bceb-73378628f333', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0a34630f-cb35-4585-818a-73b2d4432b5e', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2d3060b6-b011-4653-886e-73d1b28c1daf', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1640fcbf-b635-4d38-be25-742392c92a21', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'Desloguear')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'557fbdfb-dbed-41f8-9e47-74baa46682d3', N'6146e65f-7984-4c0f-8503-f891700e552d', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8ff55bcb-72e6-4667-b4b5-74dbaba2cf3a', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'Cambiar Rol')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2e929ced-893b-43d7-b5c2-7661214adcfe', N'6146e65f-7984-4c0f-8503-f891700e552d', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'767a28f5-5eac-4d32-b6ee-7664b04ab3d7', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'28830738-8379-48b1-a3fb-76e17c288376', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'acc7a0e7-4903-4263-bf34-7743e7ba33cf', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'Inventory')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'054cae10-ab63-4850-b41c-792a9f789583', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c5acbaa7-5e50-4645-8633-797a29504cce', N'6146e65f-7984-4c0f-8503-f891700e552d', N'f7cefca3-f761-4fa9-ae15-ed349208ce46', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8798a54d-aa81-4cdf-9ed2-79850f165e99', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'4be67089-ffab-431a-9964-e655278c3200', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'65539b2e-3fa0-428e-b0ca-79c9845f7997', N'6146e65f-7984-4c0f-8503-f891700e552d', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'844474ab-79d8-4a94-8647-79eded60da7f', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'Personal data')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9b042c0c-61b6-4e05-a40f-7a3a4aef06f6', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f5499f3a-bbe7-466a-be00-7a772ba87648', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'339c85b1-5c87-456a-b254-6d5101949924', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'35e989c3-f500-4372-b25b-7ae7b421618f', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'Load items')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ff4807fb-4a96-439b-a414-7b074bf8b5e3', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fa1d876f-5386-42c8-9a8d-7b262ae68ceb', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bda29f17-169a-4546-8689-7c2eee9aed55', N'6146e65f-7984-4c0f-8503-f891700e552d', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4489e671-cde8-4a17-9b8a-7c8627fc41d0', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'cd6d52ae-d874-49ae-8ba0-7cdfcab2c3f1', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'bbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b0b6bb0c-3db7-42d6-9516-7e055a0939b8', N'6146e65f-7984-4c0f-8503-f891700e552d', N'4867bda0-5924-4216-bc24-987c351fd47a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6765042c-56cd-42fd-856b-7e5a2ebab359', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'4be67089-ffab-431a-9964-e655278c3200', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7bdd424d-250f-4010-8f7a-7ed9d0c42aa1', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'dbe00ce8-f855-4b9d-8998-80876ed1c024', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'Datos personales')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0a9175f1-41d9-4e1c-b415-816443c72b61', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'ddd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e4923f47-8e73-49ec-b14c-81b44c82ea7b', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'36bf0e3f-0032-43c4-961c-82be6a672ff3', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0420b3c9-f0cc-4b2a-9bb7-848921302130', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'266477e2-f731-4d0f-be49-db30ab16da35', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e3138e63-fb54-4a8f-8dd5-84a6ea22f13d', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'bbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eafc5f39-d9d3-4fe3-adf9-85400b1a7154', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd718cf6c-e7d6-4e4f-b24d-8549fa5b1346', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'Change Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b06594ea-3c47-4a72-88fc-856a22a73683', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'Logout')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd055a6a7-ab82-43e7-9785-87ded529fc5d', N'6146e65f-7984-4c0f-8503-f891700e552d', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e299398b-2778-433e-a738-881406dad7d3', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'aaaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4b430ddb-6eb5-4fc4-92a7-887725ee4696', N'6146e65f-7984-4c0f-8503-f891700e552d', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'06abf639-f5db-4779-ab10-8a2d2a66c4ec', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'Configuration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a9ad4cb8-c4f8-4bd6-8d58-8b4cbdd83be8', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7180fd45-3199-4192-867d-8bdc4d913079', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'58164282-7f7a-4886-9f24-9809330e1b06', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'994c35a1-e5bd-46a2-ba7c-8d24013f2a13', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'Desloguear')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e2d84e61-4834-4e8d-846c-8e10d8500028', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'32423a68-1aa8-4a84-a38a-8e2d0eef09fa', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'14efcf16-895a-46f6-a576-31860315bc12', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2625ee58-e158-47f7-86f2-8ec6bde7d711', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'20d41642-7cc5-4ac8-90e1-8fe56179faf1', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'Personal data')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1d2a1515-b6f5-463a-8488-901bb7658ed3', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'Change Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'43472649-ab53-4ba2-8abc-911ddfb0a3ec', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'053f54d0-7cb0-4fc5-8a11-92a28a261248', N'6146e65f-7984-4c0f-8503-f891700e552d', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'cd6ee24f-146c-4cbb-960b-939de9ae7060', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8b0d1878-362d-4d53-bed4-93dde9ae0eb6', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6c85ba5d-e059-49e2-b84f-951f982d3b0a', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'97606c63-ae5d-4595-9934-9578076b9ae5', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1222fef8-b47b-4f72-b38b-96c9de9fff81', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'59254406-fca8-48cd-9ede-08b064febf0a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f026258e-b3f6-437d-8d84-972caf189c0a', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'809fb036-e440-44ff-97f8-975360ed2360', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'62dce9fc-98f8-44a0-9203-982e769401b6', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fb7755dd-0a83-42ba-ac24-98561fdedde7', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'98a73a56-3ef8-4895-bc4a-986d063834b3', N'6146e65f-7984-4c0f-8503-f891700e552d', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'fdaa15eb-7487-4f3d-824e-992bd5759dea', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'871a8d17-23f0-46c1-8e48-9940161034fb', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'bbbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'69a803d9-95db-484f-9b57-994f2cc147ad', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'56237c38-9fba-47d8-8250-99a43fd495e3', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'ccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'601a177e-d7a8-4f51-9bee-9a2785284a0e', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'36f7f5c4-9304-4b0c-af9c-9a7a2e7fb7dd', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'de9ebf8b-6ffe-463f-be2b-9a9bb7ea1d0b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'Configuration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'06a0b838-fa81-4a43-83ae-9c0bf17c6862', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'fd4739c3-5194-41e6-a42d-8580fbe7010a', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'39644c47-501f-47ea-91eb-9c745d3f7b76', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'422d7f30-af86-42a2-b821-9d1fee8aea4a', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'eee')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2ebdd6b5-5bec-46c1-a667-9d3e1df33d0d', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a9d5effd-f982-4128-8d89-9db8ded9f539', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eb51b2da-fc89-4afb-9ff3-9f01c9f63a39', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2d881cbf-ddfb-45b5-a9de-a0106351ff53', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'43555468-80ed-4e22-9de2-f066f8bfc831', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1db04ea7-bfcb-4443-a8a1-a0635d6d6e78', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7b90ca41-ae85-4f65-b3f0-a0666406d10d', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'38bda55c-e4a4-4060-969c-71b22d100203', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b4443ec4-f155-4d47-b6e3-a0e0cfcb63aa', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eccb1394-06d6-4b54-80dd-a117f15a2282', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'ddd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e7e619b7-45fb-45dd-a352-a1cb07505bc4', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f6ab4da0-69db-4922-86d0-a2e0c75142dc', N'6146e65f-7984-4c0f-8503-f891700e552d', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ea82c6ad-66e6-4e30-9e89-a2f51eac5be0', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c77ce376-7ec9-4ea0-87db-a3615681b670', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'Administration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b5d2cdb2-be51-4c4c-921f-a37118a025d6', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N's')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f6034345-2495-4515-b211-a39d685b0b2b', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c1feb351-5e8d-424d-9d83-a5b3fd6bceed', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'4867bda0-5924-4216-bc24-987c351fd47a', N'cc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'845e9242-5e27-46f6-9613-a5cd8891d2b9', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'efb9e725-5ee9-430d-a000-a635a526467b', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'aaa06951-1fb9-430c-958a-a74726df1e70', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'38bda55c-e4a4-4060-969c-71b22d100203', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'af002c0c-c830-4d67-8e6c-a83989737dee', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'aa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1640a25e-ace9-423a-81d3-a85556e076a8', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4d70d624-9023-4822-916b-a8698d63b9d5', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5f23f890-9903-4ef0-88dc-a9a4327d6a4c', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'95c4bf93-b54b-4ba7-b25b-347cd50b6b84', N'aaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b621884c-2366-4f3e-a370-a9c0757ce6a1', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'f3aaae08-3286-463a-aecc-88633b6a04f6', N'eee')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'78dc1e14-22a6-4304-8a8e-a9f8c976c672', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'875109a6-c896-41a7-a6ef-aa0e99332764', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'266477e2-f731-4d0f-be49-db30ab16da35', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'232e9b38-c195-4f9b-b770-aa8afabd4213', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'bbbbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'61d74977-ce5a-44ce-8b50-ab798fd56517', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'Logout')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b25ba173-02e4-4204-a23d-ae267ecc37fe', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'30eac8fe-7358-4d17-bc35-ae7fea0e007e', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'bbb')
GO
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'395f1c0c-fc1f-490e-a9cd-aea23daa442a', N'6146e65f-7984-4c0f-8503-f891700e552d', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8a33c14a-34ea-4953-8fed-af1c1b3766b4', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9438b15d-cf08-4d45-8890-144f1ce40ff9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'822a4a58-8ea9-4234-8c81-af99ce09bc65', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'38bda55c-e4a4-4060-969c-71b22d100203', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2e23eb10-3462-4d85-8ab9-b0b989683083', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9ff4416e-413f-4f4c-a27f-b0d6d7c4a97f', N'6146e65f-7984-4c0f-8503-f891700e552d', N'69afc5e5-b0a1-4522-810d-354602018f4f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'adf91f60-3656-4dd1-9548-b0ebf7fba944', N'6146e65f-7984-4c0f-8503-f891700e552d', N'b32297ac-344b-4da8-80bf-3acaae7a8c94', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8a5f3691-7807-449d-b270-b14cfccd33b9', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e382db5c-6614-4f1e-8fd5-b285dab7c650', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e38bb6f6-e30b-45a4-8465-b2febd257e5e', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a2b6a344-ab95-4a19-9ff7-b323fe08b01a', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3a87b501-39bd-40d6-8acc-b36627460912', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e2d82ccc-5c83-4d23-8024-b49c04e429e5', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9a585655-3017-482e-badd-87868b8e9aec', N'Administracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3a8b8db4-4770-41b3-afaa-b4b25f9d5ad5', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'cfa386bc-c324-4285-9162-b4b3d226aaa8', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'92d093c3-4064-4ba3-9d51-b4cea3a6a933', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ebf1402e-630a-4b07-9330-b4f8e587d68b', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eeec9e6f-037a-4af0-9f06-b5f9151d4d4e', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'1f32ebdf-4407-407c-81a3-8090b4219408', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5949fac3-a556-4c2a-ae0d-b63c5d9f1a8b', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'52cb48fc-02fe-4a95-8e0e-b6b4b85482d8', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0efe4ea3-8d21-449a-a7a2-b79bd294a95d', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9d1bdf42-34c4-49bf-8d59-b7dd6d71bbea', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a0d4bc81-c0aa-44fb-a70a-b7e4a14190d1', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'69e42f4f-1e3a-4069-8db0-b8d14efeb7c3', N'6146e65f-7984-4c0f-8503-f891700e552d', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1a9252ba-4ce3-4ac9-acd6-b93665cf6dcd', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e43bf93a-b737-4b90-a7b1-b9e1274280a9', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'18186949-a367-4dcd-99f4-ba0569eaacc0', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'4be67089-ffab-431a-9964-e655278c3200', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2bfbb3da-fb4a-4e13-92e2-ba24b67bf8d5', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9a585655-3017-482e-badd-87868b8e9aec', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1bcf54b0-b78d-4525-84cc-ba47fb8aca3e', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'Datos personales')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1d5bc20a-df78-4d98-b758-bb9727506f3f', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3696f2d6-27cf-44bb-ba45-bbb0006332d1', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'Ayuda')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'16a859d8-13cf-4248-9a0a-bcc0ee0276da', N'6146e65f-7984-4c0f-8503-f891700e552d', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'dd9f9125-3574-47b7-89dc-bcdf36f74be6', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bea29653-5091-47d3-90ad-bf6398f00517', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7626a5dd-3566-4166-9829-c02ce8c59dc9', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2bc25604-8032-4411-a067-c0f5081b90ae', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b3c447fb-1a6e-4839-9721-c138cdf74071', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'Cambiar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5625c030-d4f2-4750-8862-c2692bbcc74b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'Support Contact')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd3436f32-41a4-4f5c-a38f-c295e82f4dfe', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'6fda55b4-3e70-40b2-9adf-e4af4dea4784', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c06999e1-0b9f-4b23-a213-c2eddcbae417', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'324342c7-24fb-474a-8d8f-472a379b3cf3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3868bd2f-68aa-40fd-bdda-c30264ebae88', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b3de2465-301d-4d76-8783-c3098133c70c', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e6bf80da-bb83-467a-a6c0-c3311b38aabc', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f409ff9e-2832-4207-93b2-c61992f36a50', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'58164282-7f7a-4886-9f24-9809330e1b06', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1cf1c872-49f8-45b4-8aee-c6b8b498ea0c', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'bbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd6f4d0f1-eb1f-4b4f-90c2-c6bb3692863e', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c8ee95da-e4f7-45f4-a223-c74878176fde', N'6146e65f-7984-4c0f-8503-f891700e552d', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd527ac5e-60ff-44b5-b186-c7540bdad421', N'6146e65f-7984-4c0f-8503-f891700e552d', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'32d6e168-d98c-416a-b278-c85893bc3203', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'27826eb4-d172-44cb-9f18-44a197e0f2a8', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'31a95c7b-789b-4dc6-8639-c86267060298', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'Configuration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1417faba-4302-4601-83e5-c86bb5bc6af7', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'4867bda0-5924-4216-bc24-987c351fd47a', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ce9f7f43-51f5-4714-9b75-c877d83ca2e4', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'Change Role')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8017b266-9b5e-4c6b-b050-c88800c4aed4', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e548d1c8-239e-4f86-8785-c89fd3a6f6aa', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'Inventario')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'35ce3636-baa8-498b-81f9-c8a71180c3ad', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'59254406-fca8-48cd-9ede-08b064febf0a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f95ffb43-790c-40d5-9853-c8bdf291c099', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8254a93d-ddac-49fc-875b-c8c9e9c5a81d', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a9d71c42-19e1-47bf-a04e-c904d1320182', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'266477e2-f731-4d0f-be49-db30ab16da35', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'400bace6-5a90-4a89-9b5d-c947aff2ac2d', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'Cambiar Idioma')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'44d8463b-aadb-4335-b1c4-c967057a3faf', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'27970b63-fc1d-4ae8-b658-cb00ab1a29c4', N'6146e65f-7984-4c0f-8503-f891700e552d', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'33c5b22d-9301-4ccc-a6cb-cb788b4a29bb', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'x')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd895b174-4d3e-40f8-ab26-cbd37e743b0c', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'4be67089-ffab-431a-9964-e655278c3200', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2db6c268-4c5c-42c8-9928-cc4cb3123455', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c52748a7-52d8-4ff7-b627-cd00a54d1484', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'83dd419e-ab74-4a33-98e0-cdbcb47ecbc3', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'2d1dc078-aef5-401a-9724-567e6f8d6f49', N'Cambiar Rol')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'aed8bb9f-175b-4314-ba83-cdc440198989', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'9cdfac27-ee85-4a52-9a66-31f576c730e1', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9fe99041-4ada-4b1d-b27d-ce4656527dbd', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'ca2f81a0-3f05-4a0c-b843-a9b13ba6e15b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'11a061b2-cb09-491d-92ca-ce6cc279690d', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'Add Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'85463d43-9acd-4598-a84f-ce8993e45c8e', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'efb6f12d-c030-4e83-95b0-faf9f28223de', N'f')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eae32abe-36db-4d28-92db-ceb4e2fb09ea', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9049aa31-7f02-41e3-aa3d-cee43d38f0bb', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5e9775da-5caf-4e28-a1d6-cef795c53268', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd81c24c6-bcfc-45e3-b4f7-cf1c7f374414', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b8402dd6-06f5-4c15-80a8-d00508ea25b1', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'806a8e4d-6692-4aa0-9787-d082973a7b9f', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2451f979-78dc-4049-8b57-d0848d74c055', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7cf6681f-59c6-49ec-8abe-d1d211ed7104', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'59254406-fca8-48cd-9ede-08b064febf0a', N'Administracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b1dab7e0-b333-4d74-abb7-d25c93270cc1', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'14efcf16-895a-46f6-a576-31860315bc12', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'07d8715c-fd4b-4a78-879c-d3f519498749', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'eae1280c-119c-48ad-9448-d45776da8b27', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'ccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3785e1cf-9f14-4a42-a879-d48bf372ac43', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9a585655-3017-482e-badd-87868b8e9aec', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1dff72b7-c614-4ecf-aa7f-d490f15d20d8', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'308423b1-2366-452d-a4b2-d4f3c3a36fe0', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'1cc2d454-bf48-43bd-bfe1-2bcd28ba0a2e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2b0fa2a6-976e-43d9-9aa7-d51b7165488b', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a7d8b473-d2fb-4ff7-8a23-d672b8562f2a', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2c001d42-fc45-46bf-9264-d690b5161ec2', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6a1cd656-6a59-40b4-baf1-d7c1ea0b9470', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'59254406-fca8-48cd-9ede-08b064febf0a', N'Administration')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8f149ad2-f2c1-4ead-8d0f-d7d97f364144', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1f12655a-e010-409f-b914-d84dad82c20e', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'058ad919-aa28-48bf-897c-68e0ca1cfa0d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6b5c3b4e-f592-4656-8ba7-d8d39f172407', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3e5993d8-6651-4871-a5f4-d94c0a82f3b7', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f959f15c-2688-4dd7-967d-d9fe8a277b1a', N'6146e65f-7984-4c0f-8503-f891700e552d', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7f052f69-3e84-4c6d-91ec-db6e48e4b273', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'14efcf16-895a-46f6-a576-31860315bc12', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'759af0de-c15c-4967-8148-dbcb83a19e96', N'6146e65f-7984-4c0f-8503-f891700e552d', N'ed044f76-b6e9-45d4-ad11-7123d8b2a59c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7289eecb-4718-4563-8997-dbcf3b829794', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'f2b3e8db-3786-4b84-866e-8d588c3dcf4c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4620af94-6ea2-49ce-ae8b-dc04103af4ee', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'150495e7-fefb-4041-a29a-61dbdfd71b0e', N'Contacto Soporte')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'90912e98-dedc-4636-91e0-dc3498673522', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'1cbe43bb-6946-4f5d-a58b-c16670f03ccc', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6dbfc5d6-a786-4180-9d2a-dd70434fa1f5', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'58164282-7f7a-4886-9f24-9809330e1b06', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f8adb8f9-9f86-4359-adf8-df714bd644cb', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'3d67c0b5-0234-420e-a3f4-72ea6577c888', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'5036fe36-8bb5-4179-8700-e036ff46a3a1', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'')
GO
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'363750ed-d049-4ea6-8604-e070da70c586', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'ccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3362c40b-cfc7-4f2d-b484-e0d89f26d868', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'3298851c-b245-4d6c-99dc-c0f293146edd', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'80cf7ccf-cb91-449a-9e69-e0e11e834c46', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'010b1d99-2c0d-4ecc-adf1-e11c959ffc28', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'dcc5ffb1-9c8a-4272-9910-e2280cf6177f', N'6146e65f-7984-4c0f-8503-f891700e552d', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9f5333aa-858c-4ece-b1e9-e24a61ba3114', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'Cargar elementos')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1afb48b1-6626-4cc4-8fd7-e2c7382d8c8f', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'd86b1252-5e08-42f6-aba3-bf8058d53f04', N'Dashboard')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7fcf5448-b046-47e4-985a-e3c1ae337ecb', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'19e879cd-c6c9-475b-82b7-85e52e3ea7b7', N'ddd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'1c612f34-ff72-4cd3-a14d-e3e39ef12b7f', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'DASHBOARD')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'2579de8a-2681-46c4-bd5a-e3fa0ad3317c', N'6146e65f-7984-4c0f-8503-f891700e552d', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f569aae5-dec1-404a-b24c-e4074e9282ed', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'29ee9672-f7a2-414b-97b0-4bccb310f4b4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'911fb11b-cc66-42f9-8b74-e47a3e9b87dc', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e073c767-4535-4716-be71-e483bb6f5880', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'890b4a41-1e1c-4375-8a27-e56546f8b34e', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'58164282-7f7a-4886-9f24-9809330e1b06', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4343163a-3119-48cd-9dba-e5c55f1b5e2b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'fd7c3fde-4a5f-4daa-8526-5a7ecfe88059', N'Logout')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3ca0db68-3174-45f2-8017-e5faaa1359ec', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'af018441-53b8-4a9b-8723-b2ebd9d4b4a5', N'cccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ac84eb1f-9a87-42cf-b60c-e62a98b4cad6', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'a6741a23-d492-47d7-960e-e6cb57c9515e', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'9677c08c-c471-4ebe-9c02-f9cda6b2b177', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f1ef31c0-3300-43cb-9fd0-e701ccd879d4', N'6146e65f-7984-4c0f-8503-f891700e552d', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'f8f0b145-5a6b-47a0-8722-e70a4cbe5259', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4bc1995c-fba3-4aca-9415-e75ef2981c81', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'82407299-1889-4c19-ba23-e7c895da437b', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'dba1461a-3d9b-4407-96e8-e7daaa75fb8a', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'59254406-fca8-48cd-9ede-08b064febf0a', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'35aecdf4-e37f-4511-a0bd-e7e201d2cc24', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e5ee8bdf-f56e-4752-a925-ea1efaa9150b', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'9a71170b-d7ee-41f4-ac26-eb81a76124a0', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'85261c6d-031f-4f60-bc75-ebf40398d1f6', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'efa0ee2c-6834-4ebe-a7fd-bef7c117bb28', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ef756a53-de35-4248-8d1d-ecbe8ec33404', N'6146e65f-7984-4c0f-8503-f891700e552d', N'58d3198f-b5d0-47d2-8da4-658aca3514cc', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'013fdcf5-d886-4aaa-8531-ed1a6e01a315', N'6146e65f-7984-4c0f-8503-f891700e552d', N'c0d50815-325d-4d22-9d64-d6e5b14f845c', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'86616ff9-9559-42d1-98a6-edc787baeb13', N'6146e65f-7984-4c0f-8503-f891700e552d', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ee7e6f98-41d3-447e-9fcc-edfd923a6df5', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0fe9c529-a5ff-456e-811c-ee29d2cbc774', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'Modify Language')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'33a9a578-d8f7-4e5f-955c-ee4a1aa7c15b', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'384f4e24-4cd3-4cf2-bbfe-c54cf2678c89', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ec7b9dcb-46a7-4694-8156-ef08d4d971db', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'ccc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c5534667-dc94-4aea-b047-ef82c99ea11f', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'5c5735e2-023d-438b-93a8-29c84e6297a3', N'dd')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3047ea14-cc78-4afb-9c2c-f05c4896aac4', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'34b1c9bb-db82-4908-857e-3a7a4f530523', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ef446e0e-3ad6-42ec-baca-f0f1133981ab', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd3457403-a7b6-4ead-91a0-f13c817f4214', N'6146e65f-7984-4c0f-8503-f891700e552d', N'339c85b1-5c87-456a-b254-6d5101949924', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'60a19558-cd98-4dd7-944b-f1d58490cc79', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'fd1b4ada-d94b-43c3-a0b7-409685a0303e', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b6378fbf-6e3c-48d0-92e2-f1fcd6f6645b', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'7cc57a03-62a1-4fc2-93d1-9a04cdbf91a9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'e7f5b8ae-04ad-460d-b339-f247f8576351', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'f3741989-6e50-40a7-958d-ec048ee1a14b', N'My Profile')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b42a4e34-16f0-4a1a-a5b5-f2e1b34320a9', N'60ab7ada-b479-4a73-880d-36db0f899af1', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N's')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'23d96322-3ee9-433b-9b7c-f3184a81272f', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'7e5080c5-b904-47ba-9bc7-9319af4b3621', N'Cambiar Rol')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8acd762c-11e4-46d4-b60a-f3c50a7c654b', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'5ab4894a-59ab-4a3f-9d48-08238be9e538', N'aaaa')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'033c8e91-6525-4fb2-a0a1-f3fde8d95157', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'87b1a66f-ffce-461d-937f-f4c3875a746c', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'6fa4e90d-990e-4eda-8ee4-6cbc7ac12a89', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd5e60a6a-0e6e-49aa-b311-f5005b172937', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'Configuracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'07715fb6-d8e1-4002-ae7c-f50fcb78fa58', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'339c85b1-5c87-456a-b254-6d5101949924', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'ce2381cb-b11e-4b05-97c9-f58dd7564c47', N'd92859d1-79fc-4595-aad6-5209011c3ec0', N'efc7bcbf-8e39-4230-a3eb-3471403a499a', N'a')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'd2162480-88f8-4ac7-8d8c-f5fe609e639b', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'22594147-d7b9-4a34-b8cc-eb884d10341d', N'General')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'c1f6badc-c79c-448a-8de6-f6dd758d41dd', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'Mi Perfil')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b2a57bd9-a2a3-4116-b875-f773868956fe', N'6146e65f-7984-4c0f-8503-f891700e552d', N'33ff5359-4af6-435d-bca8-7f8b23f18cc4', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'05c0304c-682b-4cf8-b7f6-f7c9fd4f546f', N'6146e65f-7984-4c0f-8503-f891700e552d', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'6a83ec22-e8d2-47a1-940a-f84af04fcbb1', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'e869eb99-f4aa-4576-811f-502be2bf66b0', N'Configuracion')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'88283eb4-e5fa-4562-9f11-f94e01501937', N'6146e65f-7984-4c0f-8503-f891700e552d', N'e8695003-0a52-4f77-aef7-b3c187f57e18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'7269c11e-67c8-41dd-811b-fa2927634d68', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'96b555d2-1293-4c74-8518-bd5a0e393c26', N'View inventory')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3db212ab-0b27-4e03-9651-fa56597f8e8f', N'6146e65f-7984-4c0f-8503-f891700e552d', N'e5e33aad-97f7-4c68-920d-0fc7753cd622', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'8fbea366-fbe4-4ab1-b351-fa8d704d4753', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'99fa60a6-4279-4e97-8b7d-e5b0c2fa868d', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'b29eac8f-06dd-4737-aa36-fb1397999dc0', N'6146e65f-7984-4c0f-8503-f891700e552d', N'e3e4d519-336d-46b8-bb73-fc707d7d142b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'be9bfd08-8444-4221-9cc0-fb2e27ddbac2', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'648f4ddd-7753-46ee-a08a-201e210945b9', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0b6894ba-518e-4c51-890d-fb5f661973fb', N'6146e65f-7984-4c0f-8503-f891700e552d', N'3b3f809d-cf6b-4f2d-8054-94e8ceb7f51b', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'917e6cd5-21c6-4fb1-9cd0-fc07a7336476', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'4867bda0-5924-4216-bc24-987c351fd47a', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'63f4b6d2-b1a8-4fab-8158-fc70b4a8cb38', N'1e2020b9-725b-46ca-b013-d5eb88a411a1', N'4fe59276-9a46-4eea-8e41-30d8258b9d34', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'09637be4-370b-4eb9-bcab-fd5dd6d3ecc4', N'6146e65f-7984-4c0f-8503-f891700e552d', N'9e8a95e2-4699-4e68-a266-a0f11d4ddc0f', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'0f0ec90f-4aee-4101-b259-fd5f2944b901', N'6146e65f-7984-4c0f-8503-f891700e552d', N'db1b776a-ff40-4a02-8bbb-c1d0a301dd18', N'')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'4942fd69-6b5d-4e07-9891-fd945489260e', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'4867bda0-5924-4216-bc24-987c351fd47a', N'cc')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'bab26cd2-c9f4-411b-a8f9-ff6a24de2b6e', N'4abb4abd-9fe9-4590-ba70-426026968d66', N'9014aaa6-32bc-4586-a805-f5bc2198ceae', N'bbbbb')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'28e885f8-aedf-481b-8496-ff765e9a4b14', N'37c99bde-5a59-48e2-96d3-971d578f4815', N'266477e2-f731-4d0f-be49-db30ab16da35', N'Tickets')
INSERT [dbo].[traducciones] ([traduccion_id], [idioma_id], [etiqueta_id], [texto]) VALUES (N'3e9ae133-b8a3-4555-8c35-ffaaed38a86b', N'342ffd45-f71d-468c-8eca-aec3247dcac8', N'3cc5762b-eac2-4313-aee6-cd0b4e5a4cac', N'')
GO
SET IDENTITY_INSERT [dbo].[ubicaciones] ON 

INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (1, N'Edificio Central', N'Calle 123, Zona Empresarial', N'Piso 3', N'Ciudad Central', N'País X', N'12345')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (2, N'Edificio Central', N'Calle 123, Zona Empresarial', N'Piso 2', N'Ciudad Central', N'País X', N'12345')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (3, N'Edificio Norte', N'Avenida Norte 456', N'Piso 1', N'Ciudad Norte', N'País X', N'67890')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (4, N'Edificio Este', N'Avenida Este 789', N'Piso 5', N'Ciudad Este', N'País X', N'23456')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (5, N'Planta Industrial', N'Zona Industrial, Área 4', NULL, N'Ciudad Industrial', N'País X', N'34567')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (6, N'Edificio Oeste', N'Avenida Oeste 1011', N'Piso 6', N'Ciudad Oeste', N'País X', N'45678')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (7, N'Edificio Sur', N'Calle Sur 1213', N'Laboratorio 1', N'Ciudad Sur', N'País X', N'56789')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (8, N'Edificio Norte', N'Avenida Norte 456', N'Piso 2', N'Ciudad Norte', N'País X', N'67890')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (9, N'Edificio Central', N'Calle 123, Zona Empresarial', N'Piso 1', N'Ciudad Central', N'País X', N'12345')
INSERT [dbo].[ubicaciones] ([ubicacion_id], [nombre], [direccion], [piso], [ciudad], [pais], [codigo_postal]) VALUES (10, N'Centro de Distribución', N'Zona Logística, Área 3', NULL, N'Ciudad Logística', N'País X', N'78901')
SET IDENTITY_INSERT [dbo].[ubicaciones] OFF
GO
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', N'javier.gomez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Javier', N'Gomez', N'jg_112', 1222, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-09-28T08:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'78')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'e4d68b97-50de-47fd-a129-153af2b205b9', N'ale.duran@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'ale', N'duran', N'ad_333', 333, CAST(N'2025-06-16T14:51:53.237' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'19')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'b9d228df-8d04-4d84-a662-2913efa491e1', N'mario.bross@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Mario', N'Bross', N'MB_33302', 33302, CAST(N'2025-06-03T21:26:38.563' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'92')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', N'seguridad@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Seguridad', N'Aprobador', N'SA_44', 44, CAST(N'2025-06-01T21:56:39.750' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'70')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'c62603c5-2d56-4dcf-bb30-35948eb2e202', N'diego.perez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Diego', N'Pérez', N'dp_108', 108, CAST(N'2024-01-02T00:00:00.000' AS DateTime), CAST(N'2024-09-28T09:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'10')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'62a7e2a0-1fd3-400e-8ad3-37e56118da67', N'isabel.torres@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Isabel', N'Torres', N'it_111', 111, CAST(N'2024-01-03T00:00:00.000' AS DateTime), CAST(N'2024-09-28T09:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'70')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'6af09799-054a-4b1a-b143-40c259570a12', N'fernando.romero@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Fernando', N'Romero', N'fr_109', 109, CAST(N'2024-01-04T00:00:00.000' AS DateTime), CAST(N'2024-09-28T10:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'16')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'da102f82-03b9-4092-a804-47741b42f4de', N'carla.ruiz@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Carla', N'Ruiz', N'cr_105', 105, CAST(N'2024-01-05T00:00:00.000' AS DateTime), CAST(N'2024-09-28T10:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'78')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'86f95524-adc2-4609-844c-4ac2f642867c', N'laura.sanchez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Laura', N'Sánchez', N'ls_114', 114, CAST(N'2024-01-06T00:00:00.000' AS DateTime), CAST(N'2024-09-28T11:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'83')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'd316d289-aaa4-47bc-a199-4b9122303973', N'hugo.ortiz@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Hugo', N'Ortiz', N'ho_110', 110, CAST(N'2024-01-07T00:00:00.000' AS DateTime), CAST(N'2024-09-28T11:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'25')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'f574033a-cd6a-426f-a35e-4dfdcc22568c', N'claudia.ramirez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Claudia', N'Ramírez', N'cr_107', 107, CAST(N'2024-01-08T00:00:00.000' AS DateTime), CAST(N'2024-09-28T12:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'68')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'78d32d5b-6476-4bfe-af21-53deecf5f633', N'carlos.garcia@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Carlos', N'García', N'cg_106', 106, CAST(N'2024-01-09T00:00:00.000' AS DateTime), CAST(N'2024-09-28T12:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'17')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'942561f1-7941-4d6e-a278-566f0e7bde38', N'ana.lopez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Ana', N'López', N'al_102', 102, CAST(N'2024-01-10T00:00:00.000' AS DateTime), CAST(N'2024-09-28T13:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'02')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', N'jorge.rodriguez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Jorge', N'Rodríguez', N'jr_113', 113, CAST(N'2024-01-11T00:00:00.000' AS DateTime), CAST(N'2024-09-28T13:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'77')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', N'prueba2.prueba2@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'prueba2', N'prueba2', N'pp_333', 333, CAST(N'2025-05-19T22:30:44.067' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'80')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'0bef0c2c-dee1-44c5-94a7-74e5b75af358', N'ligimat@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Ligimat', N'Dugarte', N'LD_444', 444, CAST(N'2025-06-01T23:23:45.373' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'09')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'30f87abb-be23-4dcd-9379-7a8266bf1199', N'pablo.fernandez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Pablo', N'Fernández', N'pf_117', 117, CAST(N'2024-01-12T00:00:00.000' AS DateTime), CAST(N'2024-09-28T14:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'35')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'e0934566-989e-4c9d-b568-7c57fccefb93', N'luis.demoya@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Luis', N'Demoya', N'LD_330', 330, CAST(N'2025-06-03T21:06:31.030' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'82')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', N'andres.diaz@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Andrés', N'Díaz', N'ad_103', 103, CAST(N'2024-01-13T00:00:00.000' AS DateTime), CAST(N'2024-09-28T14:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'49')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'b1d25d5b-e9be-4d81-b60c-88bde24c24b4', N'sofia.gonzalez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Sofía', N'González', N'sg_118', 118, CAST(N'2024-01-14T00:00:00.000' AS DateTime), CAST(N'2024-09-28T15:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'92')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', N'christian.chamulla@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'christian', N'chamulla', N'cc_23230', 23230, CAST(N'2025-06-16T14:23:38.010' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'88')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'75823e87-7292-4817-bef7-8d73f2137f1c', N'ligimat.dugarte@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Ligimat', N'Dugarte', N'LD_9', 9, CAST(N'2025-06-17T00:21:21.690' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'56')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'3361ff0a-ed4e-48f8-9134-9102e51da531', N'aprobador.gomez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Aprobador', N'Gomez', N'ag_104', 104, CAST(N'2024-01-15T00:00:00.000' AS DateTime), CAST(N'2024-09-28T15:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'33')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'06200641-6fc0-4e22-a1c5-9e9f82e23e53', N'martina.gata@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'martina', N'gata', N'mg_999', 999, CAST(N'2025-06-03T20:57:48.740' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'35')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'55901113-92ba-4142-a7e7-a01c95403a86', N'test.test123@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Pepito', N'ape', N'Pa_0', 0, CAST(N'2025-06-10T14:35:42.130' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'91')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', N'tecnicodeprueba@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'tecnico', N'prueba', N'tp_220', 220, CAST(N'2025-06-01T23:19:08.813' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'64')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'277c00c6-a926-41c9-a114-c6118cab788f', N'facundo.longo@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Facundo', N'Longo', N'FL_24', 24, CAST(N'2025-05-21T20:13:48.750' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'67')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', N'tecnico.deprueba1@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'tecnico', N'deprueba1', N'td_4444', 4444, CAST(N'2025-06-02T21:34:06.980' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'18')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'cce4cd43-763d-4c9c-871e-e6bec7c96157', N'maria.hernandez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'María', N'Hernández', N'mh_116', 116, CAST(N'2024-01-16T00:00:00.000' AS DateTime), CAST(N'2024-09-28T16:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'50')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'eae6a861-2362-41e8-b268-ee74e71ada22', N'luis.martinez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Luis', N'Martínez', N'lm_115', 115, CAST(N'2024-01-17T00:00:00.000' AS DateTime), CAST(N'2024-09-28T16:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'49')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', N'pruebadetecnico2@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'pruebadetecnico2', N'pruebadetecnico2', N'pp_2222', 2222, CAST(N'2025-06-01T23:46:22.453' AS DateTime), NULL, N'37c99bde-5a59-48e2-96d3-971d578f4815', N'64')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'19f49e74-e4c9-4adb-b135-f9d4ded64a24', N'usuario.gomez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Usuario', N'Gomez', N'ug_119', 119, CAST(N'2024-01-18T00:00:00.000' AS DateTime), CAST(N'2024-09-28T17:00:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'36')
INSERT [dbo].[usuario] ([usuario_id], [email], [password], [nombre], [apellido], [nombre_usuario], [legajo], [fecha_alta], [ultimo_inicio_sesion], [idioma_id], [digito_verificador_h]) VALUES (N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', N'administrador.gomez@crm.com', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'Administrador', N'Gomez', N'ag_101', 101, CAST(N'2024-01-19T00:00:00.000' AS DateTime), CAST(N'2024-09-28T17:30:00.000' AS DateTime), N'37c99bde-5a59-48e2-96d3-971d578f4815', N'43')
GO
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 65)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 81)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 82)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'e4d68b97-50de-47fd-a129-153af2b205b9', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'b9d228df-8d04-4d84-a662-2913efa491e1', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 84)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'c62603c5-2d56-4dcf-bb30-35948eb2e202', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'62a7e2a0-1fd3-400e-8ad3-37e56118da67', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'6af09799-054a-4b1a-b143-40c259570a12', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'da102f82-03b9-4092-a804-47741b42f4de', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'86f95524-adc2-4609-844c-4ac2f642867c', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'd316d289-aaa4-47bc-a199-4b9122303973', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'f574033a-cd6a-426f-a35e-4dfdcc22568c', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'78d32d5b-6476-4bfe-af21-53deecf5f633', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'942561f1-7941-4d6e-a278-566f0e7bde38', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 82)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'30f87abb-be23-4dcd-9379-7a8266bf1199', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'e0934566-989e-4c9d-b568-7c57fccefb93', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'b1d25d5b-e9be-4d81-b60c-88bde24c24b4', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'75823e87-7292-4817-bef7-8d73f2137f1c', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'06200641-6fc0-4e22-a1c5-9e9f82e23e53', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'277c00c6-a926-41c9-a114-c6118cab788f', 1)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'cce4cd43-763d-4c9c-871e-e6bec7c96157', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'cce4cd43-763d-4c9c-871e-e6bec7c96157', 3)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'eae6a861-2362-41e8-b268-ee74e71ada22', 2)
INSERT [dbo].[usuario_permisos] ([usuario_id], [permiso_id]) VALUES (N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', 3)
GO
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2e6461e5-ccc1-4d82-81b4-00f7deb4d0a6', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'e4d68b97-50de-47fd-a129-153af2b205b9', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'b9d228df-8d04-4d84-a662-2913efa491e1', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'4551b9cb-32b3-498b-9457-30aadf224def', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'c62603c5-2d56-4dcf-bb30-35948eb2e202', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'da102f82-03b9-4092-a804-47741b42f4de', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'f574033a-cd6a-426f-a35e-4dfdcc22568c', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'78d32d5b-6476-4bfe-af21-53deecf5f633', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'942561f1-7941-4d6e-a278-566f0e7bde38', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2b8bf3dc-516c-4006-a16e-592367eae274', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'2c5ca9b2-d1d1-4b8a-bd78-5f38392ecc0e', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'e0934566-989e-4c9d-b568-7c57fccefb93', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'4f926bcd-3858-4ac9-a310-8715fdd04858', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'b3371fa3-e171-4314-a3c8-8c44aa868ce3', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'75823e87-7292-4817-bef7-8d73f2137f1c', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'3361ff0a-ed4e-48f8-9134-9102e51da531', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'06200641-6fc0-4e22-a1c5-9e9f82e23e53', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'1345f85b-15ac-4057-a6c4-ae6df1f8aaf9', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'277c00c6-a926-41c9-a114-c6118cab788f', 1)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'6adc0ba7-deeb-4129-9bab-d7aa166edbda', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'cce4cd43-763d-4c9c-871e-e6bec7c96157', 2)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'cce4cd43-763d-4c9c-871e-e6bec7c96157', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'fed36346-aed4-48fb-b3aa-f5ead9f0b7e4', 3)
INSERT [dbo].[usuario_roles] ([usuario_id], [rol_id]) VALUES (N'd54f071e-4db5-4d4f-9f4b-ff2ac5bdf738', 1)
GO
/****** Object:  Index [IX_Administradores_UsuarioId]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Administradores_UsuarioId] ON [dbo].[administrador]
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_Fecha]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_Fecha] ON [dbo].[comentario]
(
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_Padre]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_Padre] ON [dbo].[comentario]
(
	[comentario_padre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_Ticket]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_Ticket] ON [dbo].[comentario]
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_TicketId]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_TicketId] ON [dbo].[comentario]
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_Usuario]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_Usuario] ON [dbo].[comentario]
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comentario_UsuarioId]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [IX_Comentario_UsuarioId] ON [dbo].[comentario]
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Tecnico__2ED7D2AECC5F35CA]    Script Date: 17/6/2025 09:08:45 ******/
ALTER TABLE [dbo].[tecnico] ADD UNIQUE NONCLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Traducci__AE5A3C812AB8EB95]    Script Date: 17/6/2025 09:08:45 ******/
ALTER TABLE [dbo].[traducciones] ADD UNIQUE NONCLUSTERED 
(
	[idioma_id] ASC,
	[etiqueta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_traduccion_etiqueta_id]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [idx_traduccion_etiqueta_id] ON [dbo].[traducciones]
(
	[etiqueta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_traduccion_idioma_id]    Script Date: 17/6/2025 09:08:45 ******/
CREATE NONCLUSTERED INDEX [idx_traduccion_idioma_id] ON [dbo].[traducciones]
(
	[idioma_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_usuarios_nombre_usuario]    Script Date: 17/6/2025 09:08:45 ******/
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [UQ_usuarios_nombre_usuario] UNIQUE NONCLUSTERED 
(
	[nombre_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[administrador] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[administrador] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[bandeja_tickets_detalle] ADD  DEFAULT (getdate()) FOR [fecha_asignacion]
GO
ALTER TABLE [dbo].[bandejas_tickets] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[categoria] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[categoria] ADD  DEFAULT ((0)) FOR [aprobador_requerido]
GO
ALTER TABLE [dbo].[categoria] ADD  CONSTRAINT [DF__categoria__activ__1BE81D6E]  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT ((0)) FOR [es_aprobador]
GO
ALTER TABLE [dbo].[comentario] ADD  CONSTRAINT [DF_Comentario_Fecha]  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[comentario] ADD  CONSTRAINT [DF_Comentario_Eliminado]  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[grupo_tecnico] ADD  CONSTRAINT [DF_grupo_tecnico_eliminado]  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[grupo_tecnico] ADD  CONSTRAINT [DF_grupo_tecnico_fecha_creacion]  DEFAULT (sysutcdatetime()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[idioma] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[sesion] ADD  DEFAULT (newid()) FOR [session_id]
GO
ALTER TABLE [dbo].[sesion] ADD  DEFAULT (getdate()) FOR [fecha_inicio]
GO
ALTER TABLE [dbo].[sesion] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[tecnico] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[tecnico] ADD  DEFAULT (getdate()) FOR [fecha_alta]
GO
ALTER TABLE [dbo].[ticket] ADD  CONSTRAINT [DF_ticket_eliminado]  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[ticket_historico] ADD  DEFAULT (getdate()) FOR [fecha_cambio]
GO
ALTER TABLE [dbo].[ticket_historico] ADD  CONSTRAINT [DF_TicketHistorico_TipoEvento]  DEFAULT ('') FOR [TipoEvento]
GO
ALTER TABLE [dbo].[administrador]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_Usuarios] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[administrador] CHECK CONSTRAINT [FK_Administradores_Usuarios]
GO
ALTER TABLE [dbo].[bandeja_tickets_detalle]  WITH CHECK ADD  CONSTRAINT [FK_bandeja] FOREIGN KEY([bandeja_id])
REFERENCES [dbo].[bandejas_tickets] ([bandeja_id])
GO
ALTER TABLE [dbo].[bandeja_tickets_detalle] CHECK CONSTRAINT [FK_bandeja]
GO
ALTER TABLE [dbo].[categoria]  WITH CHECK ADD  CONSTRAINT [FK_categoria_grupo_tecnico] FOREIGN KEY([group_id])
REFERENCES [dbo].[grupo_tecnico] ([grupo_id])
GO
ALTER TABLE [dbo].[categoria] CHECK CONSTRAINT [FK_categoria_grupo_tecnico]
GO
ALTER TABLE [dbo].[categoria]  WITH CHECK ADD  CONSTRAINT [FK_categorias_usuarios] FOREIGN KEY([creador_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[categoria] CHECK CONSTRAINT [FK_categorias_usuarios]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK__cliente__departa__24285DB4] FOREIGN KEY([departamento_id])
REFERENCES [dbo].[departamento] ([departamento_id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK__cliente__departa__24285DB4]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_clientes_departamento] FOREIGN KEY([departamento_id])
REFERENCES [dbo].[departamento] ([departamento_id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_clientes_departamento]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_clientes_usuarios] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_clientes_usuarios]
GO
ALTER TABLE [dbo].[cliente_tecnicos]  WITH CHECK ADD FOREIGN KEY([tecnico_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[cliente_tecnicos]  WITH CHECK ADD  CONSTRAINT [FK_cliente_tecnicos_cliente] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[cliente] ([cliente_id])
GO
ALTER TABLE [dbo].[cliente_tecnicos] CHECK CONSTRAINT [FK_cliente_tecnicos_cliente]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Padre] FOREIGN KEY([comentario_padre_id])
REFERENCES [dbo].[comentario] ([comentario_id])
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_Comentario_Padre]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Ticket] FOREIGN KEY([ticket_id])
REFERENCES [dbo].[ticket] ([ticket_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_Comentario_Ticket]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_Comentario_Usuario]
GO
ALTER TABLE [dbo].[grupo_tecnico]  WITH CHECK ADD  CONSTRAINT [FK_grupo_tecnico_tecnico_lider] FOREIGN KEY([tecnico_lider_id])
REFERENCES [dbo].[tecnico] ([tecnico_id])
GO
ALTER TABLE [dbo].[grupo_tecnico] CHECK CONSTRAINT [FK_grupo_tecnico_tecnico_lider]
GO
ALTER TABLE [dbo].[grupo_tecnico]  WITH CHECK ADD  CONSTRAINT [FK_GrupoTecnico_TecnicoLider] FOREIGN KEY([tecnico_lider_id])
REFERENCES [dbo].[tecnico] ([tecnico_id])
GO
ALTER TABLE [dbo].[grupo_tecnico] CHECK CONSTRAINT [FK_GrupoTecnico_TecnicoLider]
GO
ALTER TABLE [dbo].[grupo_tecnico_tecnico]  WITH CHECK ADD  CONSTRAINT [FK_gtt_grupo] FOREIGN KEY([grupo_id])
REFERENCES [dbo].[grupo_tecnico] ([grupo_id])
GO
ALTER TABLE [dbo].[grupo_tecnico_tecnico] CHECK CONSTRAINT [FK_gtt_grupo]
GO
ALTER TABLE [dbo].[grupo_tecnico_tecnico]  WITH CHECK ADD  CONSTRAINT [FK_gtt_tecnico] FOREIGN KEY([tecnico_id])
REFERENCES [dbo].[tecnico] ([tecnico_id])
GO
ALTER TABLE [dbo].[grupo_tecnico_tecnico] CHECK CONSTRAINT [FK_gtt_tecnico]
GO
ALTER TABLE [dbo].[permiso_permisos]  WITH CHECK ADD  CONSTRAINT [FK_permiso_permiso_permiso] FOREIGN KEY([permiso_padre_id])
REFERENCES [dbo].[permisos] ([permiso_id])
GO
ALTER TABLE [dbo].[permiso_permisos] CHECK CONSTRAINT [FK_permiso_permiso_permiso]
GO
ALTER TABLE [dbo].[permiso_permisos]  WITH CHECK ADD  CONSTRAINT [FK_permiso_permiso_permiso1] FOREIGN KEY([permiso_hijo_id])
REFERENCES [dbo].[permisos] ([permiso_id])
GO
ALTER TABLE [dbo].[permiso_permisos] CHECK CONSTRAINT [FK_permiso_permiso_permiso1]
GO
ALTER TABLE [dbo].[sesion]  WITH CHECK ADD FOREIGN KEY([ultimo_idioma])
REFERENCES [dbo].[idioma] ([idioma_id])
GO
ALTER TABLE [dbo].[sesion]  WITH CHECK ADD  CONSTRAINT [FK__sesion__ultimo_r__703EA55A] FOREIGN KEY([ultimo_rol_id])
REFERENCES [dbo].[rol] ([rol_id])
GO
ALTER TABLE [dbo].[sesion] CHECK CONSTRAINT [FK__sesion__ultimo_r__703EA55A]
GO
ALTER TABLE [dbo].[sesion]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[tecnico]  WITH CHECK ADD  CONSTRAINT [FK_Tecnico_Usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[tecnico] CHECK CONSTRAINT [FK_Tecnico_Usuario]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_categoria] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[categoria] ([categoria_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_categoria]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_cliente_creador] FOREIGN KEY([cliente_creador_id])
REFERENCES [dbo].[cliente] ([cliente_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_cliente_creador]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_estado] FOREIGN KEY([estado_id])
REFERENCES [dbo].[ticket_estados] ([ticket_estado_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_estado]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_grupo_tecnico] FOREIGN KEY([grupo_tecnico_id])
REFERENCES [dbo].[grupo_tecnico] ([grupo_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_grupo_tecnico]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_prioridad] FOREIGN KEY([prioridad_id])
REFERENCES [dbo].[prioridad] ([prioridad_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_prioridad]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_tecnico_asignado] FOREIGN KEY([tecnico_id])
REFERENCES [dbo].[tecnico] ([tecnico_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_tecnico_asignado]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_usuario_aprobador] FOREIGN KEY([usuario_aprobador_id])
REFERENCES [dbo].[cliente] ([cliente_id])
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_usuario_aprobador]
GO
ALTER TABLE [dbo].[ticket_historico]  WITH CHECK ADD  CONSTRAINT [FK_ticket_historico_ticket] FOREIGN KEY([ticket_id])
REFERENCES [dbo].[ticket] ([ticket_id])
GO
ALTER TABLE [dbo].[ticket_historico] CHECK CONSTRAINT [FK_ticket_historico_ticket]
GO
ALTER TABLE [dbo].[ticket_historico]  WITH CHECK ADD  CONSTRAINT [FK_ticket_historico_usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[ticket_historico] CHECK CONSTRAINT [FK_ticket_historico_usuario]
GO
ALTER TABLE [dbo].[traducciones]  WITH CHECK ADD FOREIGN KEY([etiqueta_id])
REFERENCES [dbo].[etiquetas] ([etiqueta_id])
GO
ALTER TABLE [dbo].[traducciones]  WITH CHECK ADD FOREIGN KEY([idioma_id])
REFERENCES [dbo].[idioma] ([idioma_id])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Idiomas] FOREIGN KEY([idioma_id])
REFERENCES [dbo].[idioma] ([idioma_id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_Usuarios_Idiomas]
GO
ALTER TABLE [dbo].[usuario_roles]  WITH CHECK ADD  CONSTRAINT [FK__usuario_r__rol_i__5E54FF49] FOREIGN KEY([rol_id])
REFERENCES [dbo].[rol] ([rol_id])
GO
ALTER TABLE [dbo].[usuario_roles] CHECK CONSTRAINT [FK__usuario_r__rol_i__5E54FF49]
GO
ALTER TABLE [dbo].[usuario_roles]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[categoria]  WITH CHECK ADD  CONSTRAINT [CK_Categoria_AprobadorRequerido] CHECK  (([aprobador_requerido]=(1) AND [cliente_aprobador_id] IS NOT NULL OR [aprobador_requerido]=(0) AND [cliente_aprobador_id] IS NULL))
GO
ALTER TABLE [dbo].[categoria] CHECK CONSTRAINT [CK_Categoria_AprobadorRequerido]
GO
/****** Object:  StoredProcedure [dbo].[borrar_permiso_permiso]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[borrar_permiso_permiso] @permiso_padre_id INT AS
BEGIN
    DELETE FROM permiso_permisos WHERE permiso_padre_id = @permiso_padre_id;
END
GO
/****** Object:  StoredProcedure [dbo].[familia_guardar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[familia_guardar] @permiso_padre_id INT, @permiso_hijo_id INT AS
BEGIN
    INSERT INTO permiso_permisos (permiso_padre_id, permiso_hijo_id) VALUES (@permiso_padre_id, @permiso_hijo_id);
END
GO
/****** Object:  StoredProcedure [dbo].[familias_listar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[familias_listar] AS
BEGIN
    SELECT * 
    FROM permisos p 
    WHERE p.descripcion IS NULL AND LEN(p.nombre) > 0;
END
GO
/****** Object:  StoredProcedure [dbo].[fillusercomponents]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fillusercomponents] @id UNIQUEIDENTIFIER AS
BEGIN
    SELECT p.* 
    FROM usuario_permisos up 
    INNER JOIN permisos p ON up.permiso_id = p.permiso_id 
    WHERE up.usuario_id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPermissions]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPermissions]
    @familia VARCHAR(100) = NULL  -- Parámetro opcional, por defecto NULL
AS
BEGIN
    -- Si @familia es NULL, obtiene todos los permisos, sino solo los de esa familia
    IF @familia IS NULL
    BEGIN
        SELECT p.permiso_id, p.nombre, p.descripcion
        FROM permisos p;
    END
    ELSE
    BEGIN
        WITH recursivo AS (
            SELECT sp2.permiso_padre_id, sp2.permiso_hijo_id
            FROM permiso_permisos sp2
            WHERE sp2.permiso_padre_id = @familia
            UNION ALL
            SELECT sp.permiso_padre_id, sp.permiso_hijo_id
            FROM permiso_permisos sp
            INNER JOIN recursivo r ON r.permiso_hijo_id = sp.permiso_padre_id
        )
        SELECT r.permiso_padre_id, r.permiso_hijo_id, p.permiso_id, p.nombre, p.descripcion
        FROM recursivo r
        INNER JOIN permisos p ON r.permiso_hijo_id = p.permiso_id;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[permiso_guardar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[permiso_guardar] @nombre VARCHAR(100), @descripcion VARCHAR(100) AS
BEGIN
    INSERT INTO permisos (nombre, descripcion) VALUES (@nombre, @descripcion);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActivarIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActivarIdioma]
    @idioma_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Idiomas
       SET activo = 1
     WHERE idioma_id = @idioma_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCategoria]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarCategoria]
    @Id INT,
    @Nombre NVARCHAR(255),
    @GroupId INT,
    @TipoId INT,
    @FechaCreacion DATETIME,
    @CreadorId UNIQUEIDENTIFIER,
    @Descripcion NVARCHAR(MAX),
    @AprobadorRequerido BIT,
    @ClienteAprobadorId INT,
    @DepartamentoId INT,
    @PrioridadId INT
AS
BEGIN
    UPDATE categoria
    SET 
        nombre = @Nombre, 
        group_id = @GroupId, 
        tipo_id = @TipoId, 
        fecha_creacion = @FechaCreacion, 
        creador_id = @CreadorId, 
        descripcion = @Descripcion, 
        aprobador_requerido = @AprobadorRequerido, 
        cliente_aprobador_id = @ClienteAprobadorId, 
        departamento_id = @DepartamentoId,
        prioridad_id = @PrioridadId
    WHERE categoria_id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarCliente]
    @ClienteID INT,
    @Telefono NVARCHAR(50),
    @Direccion NVARCHAR(255),
    @EmailContacto NVARCHAR(255),
    @PreferenciaContacto NVARCHAR(50)
AS
BEGIN
    UPDATE clientes
    SET telefono = @Telefono,
        direccion = @Direccion,
        email_contacto = @EmailContacto,
        preferencia_contacto = @PreferenciaContacto
    WHERE cliente_id = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDepartamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarDepartamento]
    @Id INT,
    @Nombre VARCHAR(100),
    @ClienteLiderId INT = NULL,
    @FechaCreacion DATETIME,
    @CodigoDepartamento VARCHAR(10),
    @Descripcion NVARCHAR(500) = NULL,
    @Ubicacion NVARCHAR(100) = NULL,
    @Estado BIT
AS
BEGIN
    UPDATE Departamento
    SET nombre = @Nombre,
        cliente_lider_id = @ClienteLiderId,
        fecha_creacion = @FechaCreacion,
        codigo_departamento = @CodigoDepartamento,
        descripcion = @Descripcion,
        ubicacion = @Ubicacion,
        estado = @Estado
    WHERE departamento_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDVH_Usuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarDVH_Usuario]
    @UsuarioId UNIQUEIDENTIFIER,
    @DigitoVerificadorH NVARCHAR(10)
AS
BEGIN
    UPDATE usuario
    SET digito_verificador_h = @DigitoVerificadorH
    WHERE usuario_id = @UsuarioId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDVHTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ActualizarDVHTicket]
    @ticket_id UNIQUEIDENTIFIER,
    @dvh NVARCHAR(100)
AS
BEGIN
    UPDATE Ticket
    SET digito_verificador_h = @dvh
    WHERE ticket_id = @ticket_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDVV]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarDVV]
    @Tabla NVARCHAR(100),
    @ValorDV NVARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DigitoVerificadorV WHERE tabla = @Tabla)
    BEGIN
        UPDATE DigitoVerificadorV
        SET valor_dv = @ValorDV
        WHERE tabla = @Tabla;
    END
    ELSE
    BEGIN
        INSERT INTO DigitoVerificadorV (tabla, valor_dv)
        VALUES (@Tabla, @ValorDV);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEsAprobador]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarEsAprobador]
    @ClienteId INT,
    @EsAprobador BIT
AS
BEGIN
    UPDATE cliente
    SET es_aprobador = @EsAprobador
    WHERE cliente_id = @ClienteId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarEtiqueta]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarEtiqueta]
@EtiquetaId UNIQUEIDENTIFIER,
@Nombre NVARCHAR(255)
AS
BEGIN
    UPDATE etiquetas
    SET nombre = @Nombre
    WHERE etiqueta_id = @EtiquetaId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarGrupoTecnico]
    @Id INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @TecnicoLiderId INT = NULL
AS
BEGIN
    UPDATE grupo_tecnico
    SET nombre = @Nombre,
        descripcion = @Descripcion,
        tecnico_lider_id = @TecnicoLiderId
    WHERE grupo_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ActualizarTecnico]
    @tecnico_id INT,
    @activo     BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Tecnico
    SET activo = @activo
    WHERE tecnico_id = @tecnico_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarTicket]
    @ticket_id              UNIQUEIDENTIFIER,
    @asunto                 NVARCHAR(50),
    @descripcion            NVARCHAR(150),
    @categoria_id           INT,
    @prioridad_id           INT,
    @estado_id              INT,
    @usuario_aprobador_id   INT     = NULL,
    @grupo_tecnico_id       INT     = NULL,
    @tecnico_id             INT     = NULL,
    @eliminado              BIT,                 -- nuevo
    @fecha_ultima_modif     DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Ticket
    SET
        asunto                 = @asunto,
        descripcion            = @descripcion,
        categoria_id           = @categoria_id,
        prioridad_id           = @prioridad_id,
        estado_id              = @estado_id,
        usuario_aprobador_id   = @usuario_aprobador_id,
        grupo_tecnico_id       = @grupo_tecnico_id,
        tecnico_id             = @tecnico_id,
        eliminado              = @eliminado,      -- incluirlo
        fecha_ultima_modif     = @fecha_ultima_modif
    WHERE ticket_id = @ticket_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarTraduccion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarTraduccion]
    @TraduccionId UNIQUEIDENTIFIER,
    @IdiomaId     UNIQUEIDENTIFIER,
    @EtiquetaId   UNIQUEIDENTIFIER,
    @Texto        NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE traducciones
       SET idioma_id   = @IdiomaId,
           etiqueta_id = @EtiquetaId,
           texto       = @Texto
     WHERE traduccion_id = @TraduccionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_agregar_permisos_usuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_agregar_permisos_usuario]
    @id_usuario UNIQUEIDENTIFIER,
    @id_permiso INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO usuario_permisos (usuario_id, permiso_id)
    VALUES (@id_usuario, @id_permiso);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_agregar_rol_usuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_agregar_rol_usuario]
    @id_usuario UNIQUEIDENTIFIER,
    @id_permiso INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO usuario_roles (usuario_id, rol_id)
    VALUES (@id_usuario, @id_permiso);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarCategoria]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarCategoria]
    @Nombre NVARCHAR(255),
    @GroupId INT,
    @TipoId INT,
    @Eliminado BIT,
    @FechaCreacion DATETIME,
    @CreadorId UNIQUEIDENTIFIER,
    @Descripcion NVARCHAR(MAX),
    @AprobadorRequerido BIT,
    @ClienteAprobador INT,
    @DepartamentoId INT,
    @PrioridadId INT
AS
BEGIN
    INSERT INTO categoria (
        nombre, group_id, tipo_id, eliminado, fecha_creacion, 
        creador_id, descripcion, aprobador_requerido, cliente_aprobador_id, departamento_id, prioridad_id
    )
    VALUES (
        @Nombre, @GroupId, @TipoId, @eliminado, @FechaCreacion, 
        @CreadorId, @Descripcion, @AprobadorRequerido, @ClienteAprobador, @DepartamentoId, @PrioridadId
    );

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarComentarioTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarComentarioTicket]
    @TicketId UNIQUEIDENTIFIER,
    @UsuarioId UNIQUEIDENTIFIER,
    @Comentario NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ticket_comentarios (ticket_id, usuario_id, comentario, fecha_comentario)
    VALUES (@TicketId, @UsuarioId, @Comentario, GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarDepartamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarDepartamento]
    @Nombre VARCHAR(100),
    @ClienteLiderId INT = NULL,
    @FechaCreacion DATETIME,
    @CodigoDepartamento VARCHAR(10),
    @Descripcion NVARCHAR(500) = NULL,
    @Ubicacion NVARCHAR(100) = NULL,
    @Estado BIT
AS
BEGIN
    INSERT INTO Departamento (nombre, cliente_lider_id, fecha_creacion, codigo_departamento, descripcion, ubicacion, estado)
    VALUES (@Nombre, @ClienteLiderId, @FechaCreacion, @CodigoDepartamento, @Descripcion, @Ubicacion, @Estado);

    SELECT SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AgregarGrupoTecnico]
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @TecnicoLiderId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO grupo_tecnico (nombre, descripcion, tecnico_lider_id, eliminado, fecha_creacion)
    VALUES (@Nombre, @Descripcion, @TecnicoLiderId, 0, GETUTCDATE());

    -- Devolver el ID recién insertado
    SELECT SCOPE_IDENTITY() AS grupo_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarIdioma]
    @idioma_id UNIQUEIDENTIFIER,
    @nombre NVARCHAR(100),
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Idiomas (idioma_id, nombre, activo)
    VALUES (@idioma_id, @nombre, @activo);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignarPermisoACliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AsignarPermisoACliente]
    @ClienteID INT,
    @PermisoID INT
AS
BEGIN
    INSERT INTO clientes_permisos (cliente_id, permiso_id)
    VALUES (@ClienteID, @PermisoID);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignarPermisos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_AsignarPermisos] @usuario_id UNIQUEIDENTIFIER, @permiso_id INT AS
BEGIN
    INSERT INTO usuario_permisos (usuario_id, permiso_id) VALUES (@usuario_id, @permiso_id);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AsignarTecnicoACliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AsignarTecnicoACliente]
    @ClienteID INT,
    @TecnicoID uniqueidentifier 
AS
BEGIN
    INSERT INTO cliente_tecnicos (cliente_id, tecnico_id)
    VALUES (@ClienteID, @TecnicoID);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_borrar_permiso_permiso]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_borrar_permiso_permiso] 
    @id INT
AS
BEGIN
    DELETE FROM permiso_permisos WHERE permiso_padre_id = @id 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarDepartamentoPorNombre]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BuscarDepartamentoPorNombre]
    @Nombre VARCHAR(100)
AS
BEGIN
    SELECT * FROM Departamento
    WHERE nombre LIKE '%' + @Nombre + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CambiarEstadoDeCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CambiarEstadoDeCliente]
    @ClienteID INT,
    @NuevoEstadoID INT
AS
BEGIN
    UPDATE clientes
    SET estado_cliente_id = @NuevoEstadoID
    WHERE cliente_id = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearCliente]
    @UsuarioID UNIQUEIDENTIFIER,
    @DepartamentoID INT,
    @FechaRegistro DATETIME = NULL,
    @Telefono NVARCHAR(20) = NULL,
    @Direccion NVARCHAR(255) = NULL,
    @EmailContacto NVARCHAR(255) = NULL,
    @FechaUltimaInteraccion DATETIME = NULL,
    @PreferenciaContacto NVARCHAR(50) = NULL,
    @Estado BIT = 1,
    @Observaciones NVARCHAR(500) = NULL,
    @EsAprobador BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación: el usuario debe existir
    IF NOT EXISTS (SELECT 1 FROM usuario WHERE usuario_id = @UsuarioID)
    BEGIN
        RAISERROR('El UsuarioID proporcionado no existe. Un cliente debe ser un usuario previamente registrado.', 16, 1);
        RETURN;
    END

    -- Insertar nuevo cliente
    INSERT INTO cliente (
        usuario_id,
        departamento_id,
        fecha_registro,
        telefono,
        direccion,
        email_contacto,
        fecha_ultima_interaccion,
        preferencia_contacto,
        estado,
        observaciones,
        es_aprobador
    )
    VALUES (
        @UsuarioID,
        @DepartamentoID,
        @FechaRegistro,
        @Telefono,
        @Direccion,
        @EmailContacto,
        @FechaUltimaInteraccion,
        @PreferenciaContacto,
        @Estado,
        @Observaciones,
        @EsAprobador
    );

    -- Devolver el ID generado
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS cliente_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DesactivarIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DesactivarIdioma]
    @idioma_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Idiomas
       SET activo = 0
     WHERE idioma_id = @idioma_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarCategoria]
    @Id INT
AS
BEGIN
    UPDATE categoria
    SET eliminado = 1
    WHERE categoria_id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarCliente]
    @ClienteID INT
AS
BEGIN
    DELETE FROM clientes
    WHERE cliente_id = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarComentarioRecursivo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarComentarioRecursivo]
  @comentario_id INT
AS
BEGIN
  SET NOCOUNT ON;

  ;WITH CTE AS (
    SELECT comentario_id
    FROM dbo.Comentario
    WHERE comentario_id = @comentario_id

    UNION ALL

    SELECT c.comentario_id
    FROM dbo.Comentario c
    INNER JOIN CTE      x ON c.comentario_padre_id = x.comentario_id
  )
  UPDATE dbo.Comentario
  SET eliminado = 1
  WHERE comentario_id IN (SELECT comentario_id FROM CTE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarDepartamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarDepartamento]
    @Id INT
AS
BEGIN
    DELETE FROM Departamento
    WHERE departamento_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarEtiqueta]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarEtiqueta]
@EtiquetaId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM etiquetas
    WHERE etiqueta_id = @EtiquetaId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarGrupoTecnico]
    @GrupoId INT
AS
BEGIN
    DELETE FROM GrupoTecnico WHERE grupo_id = @GrupoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarIdioma]
    @idioma_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Borramos todas las traducciones ligadas a este idioma
    DELETE FROM traducciones
    WHERE idioma_id = @idioma_id;



    -- 3) Finalmente, borramos el idioma
    DELETE FROM idiomas
    WHERE idioma_id = @idioma_id;
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPermisos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarPermisos] @usuario_id UNIQUEIDENTIFIER AS
BEGIN
    DELETE FROM usuario_permisos WHERE usuario_id = @usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarTecnicoDeGrupo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarTecnicoDeGrupo]
    @GrupoId INT,
    @TecnicoId INT
AS
BEGIN
    DELETE FROM grupo_tecnico_tecnico
    WHERE grupo_id = @GrupoId AND tecnico_id = @TecnicoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteNombreGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ExisteNombreGrupoTecnico]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT COUNT(1)
    FROM grupo_tecnico
    WHERE nombre = @Nombre;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteTecnicoEnGrupo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ExisteTecnicoEnGrupo]
    @GrupoId INT,
    @TecnicoId INT
AS
BEGIN
    SELECT COUNT(1)
    FROM grupo_tecnico_tecnico
    WHERE grupo_id = @GrupoId AND tecnico_id = @TecnicoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ExisteTraduccion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ExisteTraduccion]
    @TraduccionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Cant
    FROM traducciones
    WHERE traduccion_id = @TraduccionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ExisteUsuario]
    @usuario_id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT COUNT(*) FROM usuario WHERE usuario_id = @usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_familia_guardar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_familia_guardar]
    @id_permiso_padre INT, 
    @id_permiso_hijo INT
AS
BEGIN
    -- Validar si ya existe la relación entre la familia y el permiso
    IF EXISTS (
        SELECT 1 
        FROM permiso_permisos 
        WHERE permiso_padre_id = @id_permiso_padre 
          AND permiso_hijo_id = @id_permiso_hijo
    )
    BEGIN
        RAISERROR('La relación ya existe en la familia.', 16, 1);
        RETURN;
    END;

    -- Declaración de tabla temporal para almacenar el resultado del CTE (para detectar ciclos)
    DECLARE @CycleCheck TABLE (
        permiso_padre_id INT,
        permiso_hijo_id INT
    );

    -- CTE recursivo para recorrer la jerarquía a partir de @id_permiso_hijo
    WITH RecursiveCheck AS (
        SELECT permiso_padre_id, permiso_hijo_id
        FROM permiso_permisos
        WHERE permiso_padre_id = @id_permiso_hijo
        
        UNION ALL
        
        SELECT pp.permiso_padre_id, pp.permiso_hijo_id
        FROM permiso_permisos pp
        INNER JOIN RecursiveCheck rc ON pp.permiso_padre_id = rc.permiso_hijo_id
    )
    INSERT INTO @CycleCheck
    SELECT permiso_padre_id, permiso_hijo_id
    FROM RecursiveCheck;

    -- Validar ciclo: si se encuentra que el id del permiso padre aparece en la cadena de relaciones
    IF EXISTS (
        SELECT 1
        FROM @CycleCheck
        WHERE permiso_hijo_id = @id_permiso_padre
    )
    BEGIN
        RAISERROR('No se puede insertar esta relación porque generaría un ciclo.', 16, 1);
        RETURN;
    END;

    -- Si no se detecta la existencia de la relación ni un ciclo, insertar la nueva relación
    INSERT INTO permiso_permisos (permiso_padre_id, permiso_hijo_id)
    VALUES (@id_permiso_padre, @id_permiso_hijo);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_familias_listar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_familias_listar]
AS
BEGIN
     SELECT * FROM Permisos p WHERE p.descripcion is null  AND LEN(p.nombre) > 0


END
GO
/****** Object:  StoredProcedure [dbo].[sp_FinalizarSesion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_FinalizarSesion]
    @SessionID uniqueidentifier,
    @FechaFin datetime,
    @Estado bit,
    @UltimmoRolID int
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
            
        -- Actualizar la sesión con los datos de finalización
        UPDATE sesion
        SET 
            fecha_fin = @FechaFin,
            estado = @Estado,
            ultimo_rol_id = @UltimmoRolID
        WHERE 
            session_id = @SessionID;
            
        -- Verificar si se actualizó correctamente la sesión
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No se encontró la sesión con el ID especificado.', 16, 1);
        END
            
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- Propagar el error al cliente
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarTicket]
    @TicketId              UNIQUEIDENTIFIER,   -- Ticket.TicketId
    @FechaCreacion         DATETIME,           -- Ticket.FechaCreacion
    @FechaUltimaModif      DATETIME,           -- Ticket.FechaUltimaModif
    @FechaCierre           DATETIME     = NULL,-- Ticket.FechaCierre (nullable)
    @Eliminado             BIT,                -- Ticket.Eliminado
    @Asunto                NVARCHAR(50),       -- Ticket.Asunto (max 50)
    @Descripcion           NVARCHAR(100),      -- Ticket.Descripcion (max 150)
    @ClienteCreadorId      INT,                -- Ticket.ClienteCreadorId
    @CategoriaId           INT,                -- Ticket.CategoriaId
    @PrioridadId           INT,                -- Ticket.PrioridadId
    @EstadoId              INT,                -- Ticket.EstadoId
    @UsuarioAprobadorId    INT          = NULL,-- Ticket.UsuarioAprobadorId (nullable)
    @GrupoTecnicoId        INT          = NULL,-- Ticket.GrupoTecnicoId (nullable)
    @TecnicoId             INT          = NULL -- Ticket.TecnicoId (nullable)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ticket (
        ticket_id,
        fecha_creacion,
        fecha_ultima_modif,
        fecha_cierre,
        eliminado,
        asunto,
        descripcion,
        cliente_creador_id,
        categoria_id,
        prioridad_id,
        estado_id,
        usuario_aprobador_id,
        grupo_tecnico_id,
        tecnico_id
    )
    VALUES (
        @TicketId,
        @FechaCreacion,
        @FechaUltimaModif,
        @FechaCierre,
        @Eliminado,
        @Asunto,
        @Descripcion,
        @ClienteCreadorId,
        @CategoriaId,
        @PrioridadId,
        @EstadoId,
        @UsuarioAprobadorId,
        @GrupoTecnicoId,
        @TecnicoId
    );
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GuardarTraduccion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GuardarTraduccion]
@TraduccionId UNIQUEIDENTIFIER,
@IdiomaId UNIQUEIDENTIFIER,
@EtiquetaId UNIQUEIDENTIFIER,
@Texto NVARCHAR(MAX)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM traducciones WHERE traduccion_id = @TraduccionId)
    BEGIN
        UPDATE traducciones
        SET texto = @Texto
        WHERE traduccion_id = @TraduccionId;
    END
    ELSE
    BEGIN
        INSERT INTO traducciones (traduccion_id, idioma_id, etiqueta_id, texto)
        VALUES (@TraduccionId, @IdiomaId, @EtiquetaId, @Texto);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_familia]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_familia]
    @Nombre NVARCHAR(255), @Permiso NVARCHAR(255)
AS
BEGIN
    INSERT INTO Permisos (nombre, descripcion)
    VALUES (@Nombre, NULL); -- No se requiere un valor para el campo `permiso` en familias
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_patente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertar_patente]
    @Nombre NVARCHAR(255),
    @Permiso NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Si @Permiso es cadena vacía, se asigna NULL
    IF (@Permiso = '')
        SET @Permiso = NULL;

    INSERT INTO Permiso (nombre, permiso)
    VALUES (@Nombre, @Permiso);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarAdministrador]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarAdministrador]
    @administrador_id UNIQUEIDENTIFIER,
    @usuario_id       UNIQUEIDENTIFIER,
    @fecha_creacion   DATETIME,
    @estado           BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el usuario exista
    IF NOT EXISTS (SELECT 1 FROM usuario WHERE usuario_id = @usuario_id)
    BEGIN
        RAISERROR('El usuario especificado no existe.', 16, 1);
        RETURN;
    END

    -- Validar duplicado
    IF EXISTS (SELECT 1 FROM administrador WHERE usuario_id = @usuario_id)
    BEGIN
        RAISERROR('El usuario ya está registrado como administrador.', 16, 1);
        RETURN;
    END

    -- Insertar
    INSERT INTO administrador (administrador_id, usuario_id, fecha_creacion, estado)
    VALUES (@administrador_id, @usuario_id, @fecha_creacion, @estado);

    -- Retorno explícito
    SELECT 1 AS Resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarComentario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarComentario]
  @ticket_id           UNIQUEIDENTIFIER,
  @usuario_id          UNIQUEIDENTIFIER,
  @texto               NVARCHAR(1000),
  @comentario_padre_id INT = NULL
AS
BEGIN
  SET NOCOUNT ON;

  INSERT INTO dbo.Comentario (
    ticket_id,
    usuario_id,
    texto,
    fecha,               -- usa DEFAULT(GETDATE()) si prefieres
    eliminado,
    comentario_padre_id
  )
  VALUES (
    @ticket_id,
    @usuario_id,
    @texto,
    GETDATE(),
    0,
    @comentario_padre_id
  );

  SELECT CAST(SCOPE_IDENTITY() AS INT) AS NuevoComentarioId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarEtiqueta]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarEtiqueta]
@EtiquetaId UNIQUEIDENTIFIER,
@Nombre NVARCHAR(255)
AS
BEGIN
    INSERT INTO etiquetas (etiqueta_id, nombre)
    VALUES (@EtiquetaId, @Nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarIdioma]
    @IdiomaId UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(255)
AS
BEGIN
    INSERT INTO Idiomas (idioma_id, nombre)
    VALUES (@IdiomaId, @Nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_InsertarTecnico]
    @usuario_id UNIQUEIDENTIFIER,
    @activo     BIT,
    @fecha_alta DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Tecnico (usuario_id, activo, fecha_alta)
    VALUES (@usuario_id, @activo, @fecha_alta);

    -- Devolvemos el ID recién generado
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NuevoTecnicoId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarTecnicoEnGrupo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarTecnicoEnGrupo]
    @GrupoId INT,
    @TecnicoId INT
AS
BEGIN
    INSERT INTO grupo_tecnico_tecnico (grupo_id, tecnico_id)
    VALUES (@GrupoId, @TecnicoId);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarTicketHistorico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarTicketHistorico]
    @ticket_id          UNIQUEIDENTIFIER,
    @usuario_id         UNIQUEIDENTIFIER,
    @fecha_cambio       DATETIME,
    @TipoEvento         NVARCHAR(100),
    @ValorAnteriorId    INT = NULL,
    @ValorNuevoId       INT = NULL,
    @comentario         NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.ticket_historico
        (
          ticket_id,
          usuario_id,
          fecha_cambio,
          TipoEvento,
          ValorAnteriorId,
          ValorNuevoId,
          comentario
        )
    VALUES
        (
          @ticket_id,
          @usuario_id,
          @fecha_cambio,
          @TipoEvento,
          @ValorAnteriorId,
          @ValorNuevoId,
          @comentario
        );
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarTraduccion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarTraduccion]
    @TraduccionId UNIQUEIDENTIFIER,
    @IdiomaId UNIQUEIDENTIFIER,
    @EtiquetaId UNIQUEIDENTIFIER,
    @Texto NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO traducciones (traduccion_id, idioma_id, etiqueta_id, texto)
    VALUES (@TraduccionId, @IdiomaId, @EtiquetaId, @Texto);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarUsuario]
    @UsuarioId       UNIQUEIDENTIFIER,
    @Email           NVARCHAR(255),
    @Password        NVARCHAR(255),
    @Nombre          NVARCHAR(255),
    @Apellido        NVARCHAR(255),
    @Nombre_Usuario  NVARCHAR(100),
    @Legajo          INT,
    @Fecha_Alta      DATETIME           = NULL,
    @Idioma_Id       UNIQUEIDENTIFIER   = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Si no se recibió idioma, usar el default
    SET @Idioma_Id = ISNULL(
        @Idioma_Id,
        '37C99BDE-5A59-48E2-96D3-971D578F4815'
    );

    INSERT INTO dbo.Usuario (
        usuario_id,
        email,
        password,
        nombre,
        apellido,
        nombre_usuario,
        legajo,
        fecha_alta,
        idioma_id
    )
    VALUES (
        @UsuarioId,
        @Email,
        @Password,
        @Nombre,
        @Apellido,
        @Nombre_Usuario,
        @Legajo,
        @Fecha_Alta,
        @Idioma_Id
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_componentes]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_listar_componentes]
    @Familia NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    WITH recursivo AS (
        SELECT pp.permiso_padre_id, pp.permiso_hijo_id
        FROM permiso_permisos pp
        WHERE pp.permiso_padre_id = @Familia
        UNION ALL
        SELECT p2.permiso_padre_id, p2.permiso_hijo_id
        FROM permiso_permisos p2
        INNER JOIN recursivo r ON r.permiso_hijo_id = p2.permiso_padre_id
    )
    SELECT r.permiso_padre_id, r.permiso_hijo_id, p.permiso_id, p.nombre, p.descripcion,
           CASE WHEN p.descripcion IS NULL THEN 1 ELSE 0 END AS esFamilia
    FROM recursivo r
    INNER JOIN permisos p ON r.permiso_hijo_id = p.permiso_id;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_listar_componentes_directos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Crea el SP que lista solo los hijos directos de una familia
CREATE PROCEDURE [dbo].[sp_listar_componentes_directos]
    @FamiliaId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.permiso_id, 
        p.nombre, 
        p.descripcion
    FROM permiso_permisos pp
    INNER JOIN Permisos p 
        ON pp.permiso_hijo_id = p.permiso_id
    WHERE pp.permiso_padre_id = @FamiliaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_patentes]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_listar_patentes]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT permiso_id, nombre,  descripcion
    FROM Permisos
    WHERE descripcion IS NOT NULL;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarCategorias]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarCategorias]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.categoria_id, 
        c.nombre                  AS categoria_nombre, 
        c.descripcion, 
        c.eliminado,               -- ← reemplazo de estado
        c.tipo_id, 
        c.prioridad_id,            -- ← agregado
        pr.nombre                  AS prioridad_nombre,       -- ← agregado
        pr.descripcion             AS prioridad_descripcion,  -- ← agregado
        c.group_id, 
        gt.nombre                 AS grupo_nombre,            -- ← existente
        c.fecha_creacion, 
        c.creador_id, 
        c.aprobador_requerido, 
        c.cliente_aprobador_id, 
        c.departamento_id,

        -- Info del cliente aprobador (desde usuario)
        u.usuario_id, 
        u.email, 
        u.password, 
        u.nombre                  AS usuario_nombre, 
        u.apellido, 
        u.nombre_usuario, 
        u.legajo, 
        u.fecha_alta, 
        u.ultimo_inicio_sesion,

        -- Info del departamento
        d.nombre                  AS departamento_nombre

    FROM categoria c
    LEFT JOIN grupo_tecnico gt 
        ON c.group_id = gt.grupo_id
    LEFT JOIN cliente cli 
        ON c.cliente_aprobador_id = cli.cliente_id
    LEFT JOIN usuario u 
        ON cli.usuario_id = u.usuario_id
    INNER JOIN departamento d 
        ON d.departamento_id = c.departamento_id
    LEFT JOIN prioridad pr 
        ON c.prioridad_id = pr.prioridad_id;  -- ← join a Prioridad
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarClientes]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarClientes]
AS
BEGIN
    SELECT 
        c.cliente_id,
        c.usuario_id,
        u.nombre,
        u.apellido,
        c.departamento_id,
        c.fecha_registro,
        c.telefono,
        c.direccion,
        c.email_contacto,
        c.fecha_ultima_interaccion,
        c.preferencia_contacto,
        c.estado,
        c.observaciones,
        c.es_aprobador
    FROM cliente c
    INNER JOIN usuario u ON c.usuario_id = u.usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarClientesAprobadores]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarClientesAprobadores]
AS
BEGIN
    SELECT 
        cliente_id,
        usuario_id,
        departamento_id,
        fecha_registro,
        telefono,
        direccion,
        email_contacto,
        fecha_ultima_interaccion,
        preferencia_contacto,
        estado,
        observaciones,
        es_aprobador
    FROM cliente
    WHERE es_aprobador = 1 AND estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarClientesParaLider]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarClientesParaLider]
AS
BEGIN
    SELECT c.cliente_id, u.nombre, u.apellido, u.email
    FROM Cliente c
    INNER JOIN Usuario u ON u.usuario_id = c.usuario_id
    WHERE c.es_aprobador = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarComentariosPorTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarComentariosPorTicket]
  @ticket_id UNIQUEIDENTIFIER
AS
BEGIN
  SET NOCOUNT ON;

  SELECT
    c.comentario_id,
    c.ticket_id,
    c.usuario_id,
    u.nombre        AS usuario_nombre,
    u.apellido      AS usuario_apellido,
    c.texto,
    c.fecha,
    c.eliminado,
    c.comentario_padre_id
  FROM dbo.Comentario AS c
  INNER JOIN dbo.Usuario    AS u ON c.usuario_id = u.usuario_id
  WHERE c.ticket_id = @ticket_id
    AND c.eliminado = 0
  ORDER BY c.fecha;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarDepartamentos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarDepartamentos]
AS
BEGIN
    SELECT * FROM Departamento;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarDepartamentosPorEstado]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarDepartamentosPorEstado]
    @Estado BIT
AS
BEGIN
    SELECT * FROM Departamento
    WHERE estado = @Estado;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarEstadosCategorias]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarEstadosCategorias]
AS
BEGIN
    -- Selecciona todos los atributos de la tabla estados_categorias
    SELECT estado_categoria_id, nombre, descripcion
    FROM estados_categorias;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarEstadosTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarEstadosTicket]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ticket_estado_id AS EstadoId,
        nombre           AS Nombre,
        descripcion      AS Descripcion
    FROM dbo.ticket_estados
    ORDER BY nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarGruposPorTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarGruposPorTecnico]
    @TecnicoId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT g.*
    FROM grupo_tecnico g
    INNER JOIN grupo_tecnico_tecnico gt
        ON g.grupo_id = gt.grupo_id
    WHERE gt.tecnico_id = @TecnicoId
      AND g.eliminado = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarGruposTecnicos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarGruposTecnicos]
AS
BEGIN
    SELECT 
        grupo_id,
        nombre,
        descripcion,
        tecnico_lider_id,
        eliminado,
        fecha_creacion
    FROM grupo_tecnico;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPrioridades]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarPrioridades]
AS
BEGIN
    SELECT 
        prioridad_id, 
        nombre, 
        descripcion
    FROM 
        Prioridad;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTecnicosPorGrupo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarTecnicosPorGrupo]
    @GrupoId INT
AS
BEGIN
    SELECT t.tecnico_id
    FROM grupo_tecnico_tecnico gt
    INNER JOIN tecnico t ON gt.tecnico_id = t.tecnico_id
    WHERE gt.grupo_id = @GrupoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTicketHistoricoPorTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarTicketHistoricoPorTicket]
    @ticket_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ticket_historial_id,
        ticket_id,
        usuario_id,
        fecha_cambio,
        TipoEvento,
        ValorAnteriorId,
        ValorNuevoId,
        comentario
      FROM dbo.ticket_historico
     WHERE ticket_id = @ticket_id
     ORDER BY fecha_cambio ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTicketsDeCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarTicketsDeCliente]
    @cliente_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.ticket_id,
        t.fecha_creacion,
        t.fecha_ultima_modif,
        t.fecha_cierre,
        t.eliminado,
        t.asunto,
        t.descripcion,
        t.cliente_creador_id,
        t.categoria_id,
        t.prioridad_id,
        t.estado_id,
        t.usuario_aprobador_id,
        t.grupo_tecnico_id,
        t.tecnico_id,
        t.digito_verificador_h    -- ← Asegúrate de incluirlo
    FROM dbo.Ticket AS t
    WHERE t.cliente_creador_id = @cliente_id
      AND t.eliminado = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTicketsDelDepartamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarTicketsDelDepartamento]
    @departamento_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.ticket_id,
        t.fecha_creacion,
        t.fecha_ultima_modif,
        t.fecha_cierre,
        t.eliminado,
        t.asunto,
        t.descripcion,
        t.cliente_creador_id,
        t.categoria_id,
        t.prioridad_id,
        t.estado_id,
        t.usuario_aprobador_id,
        t.grupo_tecnico_id,
        t.tecnico_id
    FROM dbo.Ticket AS t
    INNER JOIN dbo.Cliente AS c
        ON t.cliente_creador_id = c.cliente_id
    WHERE c.departamento_id = @departamento_id
      AND t.eliminado = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTicketsParaAprobacion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListarTicketsParaAprobacion]
    @usuario_aprobador_id INT,
    @estado_id           INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        ticket_id,
        fecha_creacion,
        fecha_ultima_modif,
        fecha_cierre,
        eliminado,
        asunto,
        descripcion,
        cliente_creador_id,
        categoria_id,
        prioridad_id,
        estado_id,
        usuario_aprobador_id,
        grupo_tecnico_id,
        tecnico_id,
        digito_verificador_h
    FROM dbo.Ticket
    WHERE usuario_aprobador_id = @usuario_aprobador_id
      AND estado_id           = @estado_id
      AND eliminado            = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTicketsPorGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarTicketsPorGrupoTecnico]
    @grupo_tecnico_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM dbo.Ticket
    WHERE grupo_tecnico_id = @grupo_tecnico_id
      AND eliminado = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTiposCategorias]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_ListarTiposCategorias]
AS
BEGIN
    -- Selecciona todos los atributos de la tabla estados_categorias
    SELECT tipo_id, nombre, descripcion
    FROM tipo_categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTodosTickets]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarTodosTickets]
AS
BEGIN
    SELECT 
        ticket_id,
        fecha_creacion,
        fecha_ultima_modif,
        fecha_cierre,
        eliminado,
        asunto,
        descripcion,
        cliente_creador_id,
        categoria_id,
        prioridad_id,
        estado_id,
        usuario_aprobador_id,
        grupo_tecnico_id,
        tecnico_id,
        -- añadimos esta línea:
        digito_verificador_h
    FROM Ticket;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUsuarios]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_ListarUsuarios]
AS  
BEGIN
    SELECT 
        usuario_id,
        email,
        password,
        nombre,
        apellido,
        nombre_usuario,
        legajo,
        fecha_alta,
        ultimo_inicio_sesion,
        idioma_id
    FROM Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUsuariosConAtributos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarUsuariosConAtributos]
AS
BEGIN
    -- Seleccionar todos los atributos del usuario, incluyendo el idioma
    SELECT 
        u.usuario_id, 
        u.email, 
        u.password, 
        u.nombre, 
        u.apellido, 
        u.nombre_usuario, 
        u.legajo, 
        u.fecha_alta, 
        u.ultimo_inicio_sesion,
        u.idioma_id,
        i.nombre AS nombre_idioma -- Se selecciona el nombre del idioma
    FROM 
        usuario u
    LEFT JOIN 
        idioma i ON u.idioma_id = i.idioma_id; -- Unión para obtener el idioma
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUsuariosConDVH]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarUsuariosConDVH]
AS
BEGIN
    SELECT 
        usuario_id,
        email,
        password,
        nombre,
        apellido,
        nombre_usuario,
        legajo,
        fecha_alta,
        ultimo_inicio_sesion,
        idioma_id,
        digito_verificador_h
    FROM usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LoginUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_LoginUsuario]
    @Email NVARCHAR(255),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT u.usuario_id,u.email,u.password,u.nombre,u.apellido,u.nombre_usuario,u.legajo,u.fecha_alta,u.ultimo_inicio_sesion,u.idioma_id,i.nombre as nombre_idioma
    FROM usuario u
	inner join idioma i  on i.idioma_id=u.idioma_id
    WHERE email = @Email AND password = @Password;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_MarcarComoEliminadoGrupoTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_MarcarComoEliminadoGrupoTecnico]
    @Id INT
AS
BEGIN
    UPDATE grupo_tecnico
    SET eliminado = 1
    WHERE grupo_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerAtributosAdministrador]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerAtributosAdministrador]
    @usuario_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        estado,
        fecha_creacion
    FROM administrador
    WHERE usuario_id = @usuario_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerAtributosCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerAtributosCliente]
    @usuario_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cliente_id,
        departamento_id,
        direccion,
        email_contacto,
        fecha_registro,
        fecha_ultima_interaccion,
        preferencia_contacto,
        telefono,
        estado,
        observaciones,
        es_aprobador
    FROM cliente
    WHERE usuario_id = @usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerCategoriaPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_obtenerCategoriaPorId]
    @CategoriaId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.categoria_id,
        c.nombre                   AS categoria_nombre,
        c.descripcion,
        c.eliminado,
        c.fecha_creacion,
        c.creador_id,
        c.aprobador_requerido,
        c.departamento_id,
        d.nombre                   AS departamento_nombre,
        c.group_id,
        gt.nombre                  AS grupo_nombre,
        c.cliente_aprobador_id,
        c.tipo_id,
        c.prioridad_id,
        pr.nombre                   AS prioridad_nombre,
        pr.descripcion             AS prioridad_descripcion,
        apro.usuario_id,
        u.nombre                   AS usuario_nombre,
        u.apellido,
        u.email
    FROM dbo.Categoria AS c
    LEFT JOIN dbo.Departamento AS d
        ON c.departamento_id = d.departamento_id
    LEFT JOIN dbo.grupo_tecnico AS gt
        ON c.group_id = gt.grupo_id
    LEFT JOIN dbo.Cliente AS apro
        ON c.cliente_aprobador_id = apro.cliente_id
    LEFT JOIN dbo.Usuario AS u
        ON apro.usuario_id = u.usuario_id
    LEFT JOIN dbo.Prioridad AS pr
        ON c.prioridad_id = pr.prioridad_id
    WHERE c.categoria_id = @CategoriaId
      AND c.eliminado = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerClientePorID]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerClientePorID]
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        -- Campos de usuario
        c.usuario_id,
        u.email,
        u.password,
        u.nombre        AS nombre,
        u.apellido      AS apellido,
        u.nombre_usuario,
        u.legajo,
        u.fecha_alta    AS fecha_alta,
        u.ultimo_inicio_sesion,
        u.idioma_id,

        -- Campos de cliente
        c.departamento_id,
        c.fecha_registro,
        c.telefono,
        c.direccion,
        c.email_contacto,
        c.fecha_ultima_interaccion,
        c.preferencia_contacto,
        c.estado       AS estado,
        c.observaciones,
        c.es_aprobador,
        c.cliente_id

    FROM dbo.cliente AS c
    LEFT JOIN dbo.usuario AS u
        ON c.usuario_id = u.usuario_id
    WHERE c.cliente_id = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerClientePorIdUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerClientePorIdUsuario]
    @usuario_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.cliente_id,
        c.usuario_id,
        u.email,                    -- <- usuario.email
        u.password,                 -- <- usuario.password
        u.nombre,                   -- <- usuario.nombre
        u.apellido,                 -- <- usuario.apellido
        u.nombre_usuario,           -- <- usuario.nombre_usuario
        u.legajo,                   -- <- usuario.legajo
        u.fecha_alta,               -- <- usuario.fecha_alta
        u.ultimo_inicio_sesion,     -- <- usuario.ultimo_inicio_sesion
        c.departamento_id,
        c.fecha_registro,
        c.telefono,
        c.direccion,
        c.email_contacto,
        c.fecha_ultima_interaccion,
        c.preferencia_contacto,
        c.estado,
        c.observaciones,
        c.es_aprobador
    FROM Cliente AS c
    INNER JOIN Usuario AS u
        ON c.usuario_id = u.usuario_id
    WHERE c.usuario_id = @usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerClientesConTecnicos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerClientesConTecnicos]
AS
BEGIN
    SELECT c.*, ct.tecnico_id
    FROM clientes c
    JOIN cliente_tecnicos ct ON c.cliente_id = ct.cliente_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerClientesPorDepartamento]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerClientesPorDepartamento]
    @DepartamentoID INT
AS
BEGIN
    SELECT 
        c.*, 
        u.email,
        u.password,
        u.nombre,
        u.apellido,
        u.nombre_usuario,
        u.legajo,
        u.fecha_alta,
        u.ultimo_inicio_sesion,
        u.idioma_id
    FROM cliente c
    INNER JOIN usuario u ON c.usuario_id = u.usuario_id
    WHERE c.departamento_id = @DepartamentoID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerClientesPorTipo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerClientesPorTipo]
    @TipoClienteID INT
AS
BEGIN
    SELECT * 
    FROM clientes
    WHERE tipo_cliente_id = @TipoClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerComentario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerComentario]
  @comentario_id INT
AS
BEGIN
  SET NOCOUNT ON;

  SELECT
    c.comentario_id,
    c.ticket_id,
    c.usuario_id,
    u.nombre        AS usuario_nombre,
    u.apellido      AS usuario_apellido,
    c.texto,
    c.fecha,
    c.eliminado,
    c.comentario_padre_id
  FROM dbo.Comentario AS c
  INNER JOIN dbo.Usuario    AS u ON c.usuario_id = u.usuario_id
  WHERE c.comentario_id = @comentario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDepartamentoPorCodigo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerDepartamentoPorCodigo]
    @CodigoDepartamento VARCHAR(10)
AS
BEGIN
    SELECT * FROM Departamento
    WHERE codigo_departamento = @CodigoDepartamento;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDepartamentoPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerDepartamentoPorId]
    @Id INT
AS
BEGIN
    SELECT departamento_id, nombre, cliente_lider_id, fecha_creacion, codigo_departamento,
           descripcion, ubicacion, estado
    FROM Departamento
    WHERE departamento_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDVV]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerDVV]
    @Tabla NVARCHAR(100)
AS
BEGIN
    SELECT valor_dv
    FROM DigitoVerificadorV
    WHERE tabla = @Tabla;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEstadoTicket]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerEstadoTicket]
    @estado_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ticket_estado_id AS EstadoId,
        nombre           AS Nombre,
        descripcion      AS Descripcion
    FROM dbo.ticket_estados
    WHERE ticket_estado_id = @estado_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerEtiquetaPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerEtiquetaPorId]
@EtiquetaId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT etiqueta_id, nombre
    FROM etiquetas
    WHERE etiqueta_id = @EtiquetaId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerGrupoTecnicoPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerGrupoTecnicoPorId]
    @Id INT
AS
BEGIN
    SELECT 
        grupo_id,
        nombre,
        descripcion,
        tecnico_lider_id,
        eliminado,
        fecha_creacion
    FROM grupo_tecnico
    WHERE grupo_id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerIdiomaDeSesion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerIdiomaDeSesion]
    @UsuarioID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    WITH SesionIdioma AS (
        SELECT 
            i.idioma_id AS idioma_id,
            i.nombre AS idioma_nombre
        FROM 
            sesion s
            INNER JOIN idioma i ON s.ultimo_idioma = i.idioma_id
        WHERE 
            s.usuario_id = @UsuarioID
            AND s.estado = 1  -- Assuming 1 means active session
        ORDER BY 
            s.fecha_inicio DESC  -- Get the most recent session
        OFFSET 0 ROWS
        FETCH NEXT 1 ROW ONLY
    )

    SELECT idioma_id, idioma_nombre FROM SesionIdioma
    UNION ALL
    SELECT 
        i.idioma_id,
        i.nombre
    FROM idioma i
    WHERE i.idioma_id = '37C99BDE-5A59-48E2-96D3-971D578F4815'
    AND NOT EXISTS (SELECT 1 FROM SesionIdioma);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerIdiomas]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerIdiomas]
AS
BEGIN
    SELECT idioma_id, nombre
    FROM Idiomas
    ORDER BY idioma_id ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerIdiomasActivos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerIdiomasActivos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        idioma_id,
        nombre,
        activo
    FROM Idioma
    WHERE activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerIdiomasInactivos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerIdiomasInactivos]
AS
BEGIN
    SELECT 
        idioma_id,
        nombre,
        activo
    FROM Idiomas
    WHERE activo = 0;  -- Solo los inactivos
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerPermisosUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerPermisosUsuario]
    @id_usuario UNIQUEIDENTIFIER
AS
BEGIN
  	select p.permiso_id AS permiso_id,p.nombre as nombre,p.descripcion as descripcion from usuario_permisos u
	inner join permisos p on p.permiso_id = u.permiso_id
	where usuario_id = @id_usuario
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerPrioridad]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_ObtenerPrioridad]
    @CategoriaId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.prioridad_id,
        p.nombre,
        p.descripcion
    FROM categoria c
    INNER JOIN prioridad p ON c.prioridad_id = p.prioridad_id
    WHERE c.categoria_id = @CategoriaId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerPrioridadPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerPrioridadPorId]
    @PrioridadId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        prioridad_id,
        nombre,
        descripcion
    FROM Prioridad
    WHERE prioridad_id = @PrioridadId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerRolesUsuario]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerRolesUsuario]
    @UsuarioId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.rol_id,
        r.nombre AS rol_nombre, r.descripcion
    FROM 
        usuario_roles ur
    INNER JOIN 
        rol r ON ur.rol_id = r.rol_id
    WHERE 
        ur.usuario_id = @UsuarioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTecnicoPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ObtenerTecnicoPorId]
    @tecnico_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.tecnico_id,
        t.usuario_id,
        u.nombre,
        u.apellido,
        u.email,
        t.activo,
        t.fecha_alta
    FROM dbo.Tecnico AS t
    INNER JOIN dbo.Usuario AS u
        ON t.usuario_id = u.usuario_id
    WHERE t.tecnico_id = @tecnico_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTicketPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTicketPorId]
    @ticket_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ticket_id,
        fecha_creacion,
        fecha_ultima_modif,
        fecha_cierre,
        eliminado,
        asunto,
        descripcion,
        cliente_creador_id,
        categoria_id,
        prioridad_id,
        estado_id,
        usuario_aprobador_id,
        grupo_tecnico_id,
        tecnico_id,
        digito_verificador_h      -- ← Agregado
    FROM dbo.Ticket
    WHERE ticket_id = @ticket_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTodasLasEtiquetas]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTodasLasEtiquetas]
AS
BEGIN
    SELECT etiqueta_id, nombre
    FROM etiquetas;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTodosLosIdiomas]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTodosLosIdiomas]
AS
BEGIN
    SELECT 
        idioma_id,
        nombre,
        activo
    FROM Idiomas;  -- Sin WHERE, para traer todos (activos + inactivos)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodosTecnicos]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ObtenerTodosTecnicos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.tecnico_id,
        t.usuario_id,
        u.nombre,
        u.apellido,
        u.email,
        t.activo,
        t.fecha_alta
    FROM dbo.Tecnico AS t
    INNER JOIN dbo.Usuario AS u
        ON t.usuario_id = u.usuario_id
    ORDER BY t.tecnico_id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTraducciones]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTraducciones]
    @IdiomaId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        t.traduccion_id, 
        t.idioma_id, 
        t.etiqueta_id, 
        t.texto, 
        e.nombre AS etiqueta,
		e.form as formulario 
    FROM 
        traducciones t
    INNER JOIN 
        etiquetas e ON t.etiqueta_id = e.etiqueta_id
    WHERE 
        t.idioma_id = @IdiomaId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTraduccionesPorIdioma]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTraduccionesPorIdioma]
@idioma_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.etiqueta_id,
        e.nombre AS EtiquetaNombre,
        e.form   AS Formulario,
        e.texto  AS TextoOriginal,

        t.traduccion_id,
        t.texto       AS TextoTraduccion,
        t.idioma_id   AS IdiomaId

    FROM etiquetas e
    LEFT JOIN traducciones t 
        ON t.etiqueta_id = e.etiqueta_id
       AND t.idioma_id   = @idioma_id
    ORDER BY e.nombre;
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuarioDeSesion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuarioDeSesion]
    @UsuarioID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Consulta para obtener el último rol del usuario
    SELECT TOP 1 ultimo_rol_id
    FROM sesion
    WHERE usuario_id = @UsuarioID
    ORDER BY fecha_inicio DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuarioIdPorClienteId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuarioIdPorClienteId]
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        usuario_id
    FROM 
        Cliente
    WHERE 
        cliente_id = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuarioPorId]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuarioPorId]
    @usuario_id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        usuario_id,
        email,
        password,
        nombre,
        apellido,
        nombre_usuario,
        legajo,
        fecha_alta,
        ultimo_inicio_sesion,
        idioma_id,
        digito_verificador_h
    FROM dbo.usuario
    WHERE usuario_id = @usuario_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuarioPorLegajo]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuarioPorLegajo]
    @Legajo INT
AS
BEGIN
    SELECT 
        usuario_id,
        email,
        password,
        nombre,
        apellido,
        nombre_usuario,
        legajo,
        fecha_alta,
        ultimo_inicio_sesion,
        idioma_id,
        digito_verificador_h
    FROM usuario
    WHERE legajo = @Legajo;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuariosDisponiblesParaAdministrador]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ObtenerUsuariosDisponiblesParaAdministrador]
    @rol_Admin INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT u.usuario_id, u.nombre, u.apellido, u.email
    FROM Usuario u
    INNER JOIN usuario_roles ur ON u.usuario_id = ur.usuario_id
    LEFT JOIN Administrador a ON u.usuario_id = a.usuario_id
    WHERE ur.rol_id = @rol_Admin AND a.usuario_id IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuariosDisponiblesParaCliente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuariosDisponiblesParaCliente]
    @rol_cliente INT
AS
BEGIN
    SELECT u.usuario_id, u.nombre, u.apellido, u.email
    FROM Usuario u
    INNER JOIN usuario_roles ur ON u.usuario_id = ur.usuario_id
    WHERE ur.rol_id = @rol_cliente
      AND NOT EXISTS (
          SELECT 1
          FROM Cliente c
          WHERE c.usuario_id = u.usuario_id
      )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuariosDisponiblesParaTecnico]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerUsuariosDisponiblesParaTecnico]
    @rol_tecnico INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT u.usuario_id, u.nombre, u.apellido, u.email
    FROM Usuario u
    INNER JOIN usuario_roles ur ON u.usuario_id = ur.usuario_id
    LEFT JOIN Tecnico t ON u.usuario_id = t.usuario_id
    WHERE ur.rol_id = @rol_tecnico AND t.usuario_id IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_permiso_listar]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_permiso_listar]
AS
BEGIN
    SELECT nombre,permiso_id,descripcion FROM permisos WHERE  descripcion is null;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_permiso_listar_familias]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_permiso_listar_familias]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.permiso_id,
        p.nombre,
        p.descripcion
    FROM 
        permisos p
    WHERE 
        p.permiso_id NOT IN (
            SELECT permiso_hijo_id FROM permiso_permisos
        );
END
GO
/****** Object:  StoredProcedure [dbo].[sp_permiso_listar_patentes]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_permiso_listar_patentes]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT 
        p.permiso_id,
        p.nombre,
        p.descripcion
    FROM 
        permisos p
        INNER JOIN permiso_permisos pp ON p.permiso_id = pp.permiso_hijo_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarSesion]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarSesion]
    @SessionID uniqueidentifier,
    @UsuarioID uniqueidentifier,
    @FechaInicio datetime,
    @UltimoIdioma uniqueidentifier,
    @UltimoRolID int,
    @Estado bit
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Insert a new session record
    INSERT INTO sesion (
        session_id,
        usuario_id,
        fecha_inicio,
        ultimo_idioma,
        ultimo_rol_id,
        estado,
        fecha_fin
    )
    VALUES (
        @SessionID,
        @UsuarioID,
        @FechaInicio,
        @UltimoIdioma,
        @UltimoRolID,
        @Estado,
        NULL -- fecha_fin is NULL for a new session
    );
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ValidarEtiquetaExistente]    Script Date: 17/6/2025 09:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ValidarEtiquetaExistente]
    @Nombre NVARCHAR(255),
    @Form NVARCHAR(255),
    @Texto NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM etiquetas
        WHERE nombre = @Nombre
        AND form = @Form
        AND texto = @Texto
    )
    BEGIN
        SELECT 1 AS Existe; -- Existe la etiqueta
    END
    ELSE
    BEGIN
        SELECT 0 AS Existe; -- No existe la etiqueta
    END
END;
GO
USE [master]
GO
ALTER DATABASE [CRM] SET  READ_WRITE 
GO
