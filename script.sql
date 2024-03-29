USE [master]
GO
/****** Object:  Database [ComercioLUG]    Script Date: 13/11/2023 15:49:45 ******/
CREATE DATABASE [ComercioLUG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComercioLUG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ComercioLUG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ComercioLUG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ComercioLUG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ComercioLUG] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComercioLUG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComercioLUG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComercioLUG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComercioLUG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComercioLUG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComercioLUG] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComercioLUG] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ComercioLUG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComercioLUG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComercioLUG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComercioLUG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComercioLUG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComercioLUG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComercioLUG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComercioLUG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComercioLUG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ComercioLUG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComercioLUG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComercioLUG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComercioLUG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComercioLUG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComercioLUG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComercioLUG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComercioLUG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComercioLUG] SET  MULTI_USER 
GO
ALTER DATABASE [ComercioLUG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComercioLUG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComercioLUG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComercioLUG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ComercioLUG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ComercioLUG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ComercioLUG] SET QUERY_STORE = OFF
GO
USE [ComercioLUG]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdCompra] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[NumeroFactura] [int] IDENTITY(1,1) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[IdCompra] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[TipoTarjeta] [varchar](255) NULL,
	[NroTarjeta] [int] NULL,
	[IdCompra] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
/****** Object:  StoredProcedure [dbo].[CrearCredencial]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCredencial]
    @NombreUsuario NVARCHAR(50),
    @Contraseña NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Usuarios (NombreUsuario, Contraseña)
    VALUES (@NombreUsuario, @Contraseña);
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCliente]
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Cliente
    WHERE IdCliente = @IdCliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarCliente]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarCliente]
    @IdCliente INT,
    @Nombre NVARCHAR(50),
    @Direccion NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @IdCliente = 0
    BEGIN
        -- Inserción
        INSERT INTO Cliente (Nombre, Direccion)
        VALUES (@Nombre, @Direccion);
    END
    ELSE
    BEGIN
        -- Actualización
        UPDATE Cliente
        SET Nombre = @Nombre, Direccion = @Direccion
        WHERE IdCliente = @IdCliente;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarCompra]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarCompra]
    @FechaCompra DATETIME,
    @Total DECIMAL(18, 2),
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Compra (FechaCompra, Total, IdCliente)
    VALUES (@FechaCompra, @Total, @IdCliente);
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarDetalleCompra]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarDetalleCompra]
    @Cantidad INT,
    @IdProducto INT,
    @IdCompra INT
    
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO DetalleCompra (Cantidad, IdProducto, IdCompra)
    VALUES (@Cantidad, @IdProducto, @IdCompra);
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarProducto]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarProducto]
    @IdProducto INT,
    @Nombre NVARCHAR(50),
    @Precio DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    IF @IdProducto = 0
    BEGIN
        -- Inserción
        INSERT INTO Producto (Nombre, Precio)
        VALUES (@Nombre, @Precio);
    END
    ELSE
    BEGIN
        -- Actualización
        UPDATE Producto
        SET Nombre = @Nombre, Precio = @Precio
        WHERE IdProducto = @IdProducto;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCliente]
    
    @Nombre NVARCHAR(50),
    @Direccion NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Cliente ( Nombre, Direccion)
    VALUES (@Nombre, @Direccion);
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerClientes]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerClientes]
AS
BEGIN
    SELECT IdCliente, Nombre, Direccion FROM Cliente;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductosEnCarrito]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProductosEnCarrito]
    @IdCompra INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT P.Nombre AS Producto, DC.Cantidad, P.Precio
    FROM DetalleCompra DC
    JOIN Producto P ON DC.IdProducto = P.IdProducto
    WHERE DC.IdCompra = @IdCompra;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerificarCredenciales]    Script Date: 13/11/2023 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarCredenciales]
    @NombreUsuario NVARCHAR(50),
    @Contraseña NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Count INT;
    
    SELECT @Count = COUNT(*)
    FROM Usuarios
    WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña;

    SELECT @Count AS 'Count';
END;
GO
USE [master]
GO
ALTER DATABASE [ComercioLUG] SET  READ_WRITE 
GO
