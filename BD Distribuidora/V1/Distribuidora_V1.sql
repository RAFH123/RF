use Distribuidora_v1

--|||||||||||||||||||||||||||||
--||CREACION DE TABLAS SIMPES||
--|||||||||||||||||||||||||||||

--Ciudades
CREATE TABLE Ciudades(
id_ciudad INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre VARCHAR(50) NOT NULL
)

--Barrios
CREATE TABLE Barrios(
id_barrio INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
ciudad INT CONSTRAINT FK_Ciudad FOREIGN KEY REFERENCES Ciudades (id_ciudad)
)

--Categorias
CREATE TABLE Categorias(
id_categoria INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR (50) NOT NULL,
)

--EstadoProveedor
CREATE TABLE EstadoProveedor(
id_estadoP INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50) NOT NULL,
)

--EstadoCliente
CREATE TABLE EstadoCliente(
id_estadoC INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR(50) NOT NULL
)

--EstadoProducto
CREATE TABLE EstadoProducto(
id_estadoPr INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR (50)
)

--TipoProveedor
CREATE TABLE TipoProveedor(
id_tipoP INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50) NOT NULL
)

--TipoCliente
CREATE TABLE TipoCliente(
id_tipoC INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50)NOT NULL
)

--TipoFactura
CREATE TABLE TipoFactura(
id_tipoFactura CHAR PRIMARY KEY NOT NULL,
descripcion VARCHAR (50),
)

--||||||||||||||||||||||||||||||||
--||CREACION DE TABLAS COMPLEJAS||
--||||||||||||||||||||||||||||||||

--Clientes
CREATE TABLE Clientes(
id_cliente INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre_local VARCHAR(50),
nombre_cliente VARCHAR(50) NOT NULL,
domicilio_calle VARCHAR(50)NOT NULL,
domicilio_numero INT NOT NULL,
telefono VARCHAR(50),
email VARCHAR (50),
fecha_registro date,
barrio INT CONSTRAINT FK_barrioC FOREIGN KEY REFERENCES Barrios (id_barrio),
tipo_cliente INT CONSTRAINT FK_tipo_cliente FOREIGN KEY REFERENCES TipoCliente (id_tipoC),
estado_cliente INT CONSTRAINT FK_estado_cliente FOREIGN KEY REFERENCES EstadoCliente (id_estadoC)
)

--Proveedores
CREATE TABLE Proveedores(
id_proveedor INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre_local VARCHAR (50),
nombre_dueño VARCHAR (50) NOT NULL,
domicilio_calle VARCHAR(50)NOT NULL,
domicilio_numero INT NOT NULL,
telefono VARCHAR(50),
email VARCHAR (50),
fecha_registro date,
barrio INT CONSTRAINT FK_barrioP FOREIGN KEY REFERENCES Barrios (id_barrio),
tipo_proveedor INT CONSTRAINT FK_tipo_proveedor FOREIGN KEY REFERENCES TipoProveedor (id_tipoP),
estado_proveedor INT CONSTRAINT FK_estado_proveedor FOREIGN KEY REFERENCES EstadoProveedor (id_estadoP)
)
 
--Productos
CREATE TABLE Productos(
id_producto INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
unidad VARCHAR (10),
fecha_registro date,
estado INT CONSTRAINT FK_estadoProducto FOREIGN KEY REFERENCES EstadoProducto (id_estadoPr),
categoria INT CONSTRAINT FK_categoria FOREIGN KEY REFERENCES Categorias (id_categoria),
proveedor INT CONSTRAINT FK_proveedor_productos FOREIGN KEY REFERENCES Proveedores (id_proveedor),
)

--|||||||||||||||||||||||||||||||||||||||
--||CREACION DE TABLAS DE TRANSACCIONES||
--|||||||||||||||||||||||||||||||||||||||

--Ventas
CREATE TABLE Ventas(
nro_factura INT not null IDENTITY (1,1000),
fecha date not null,
cliente INT CONSTRAINT FK_cliente_ventas FOREIGN KEY REFERENCES Clientes (id_cliente),
tipoFactura CHAR CONSTRAINT FK_tipoFactura_ventas FOREIGN KEY REFERENCES TipoFactura (id_tipoFactura),
PRIMARY KEY (nro_factura, tipoFactura) 
)

--DetVentas
CREATE TABLE DetVentas(
nro_factura INT ,
tipo_factura CHAR,
id_producto INT CONSTRAINT FK_producto_detVenta FOREIGN KEY REFERENCES Productos (id_producto),
PRIMARY KEY (nro_factura,tipo_factura,id_producto),
FOREIGN KEY (nro_factura,tipo_factura) REFERENCES Ventas (nro_factura, tipoFactura),
)

--Compras
CREATE TABLE Compras(
nro_compra INT not null IDENTITY (1,1000),
fecha date not null,
proveedor INT CONSTRAINT FK_proveedor_compras FOREIGN KEY REFERENCES Proveedores (id_proveedor),
tipoFactura CHAR CONSTRAINT FK_tipoFactura_compras FOREIGN KEY REFERENCES TipoFactura (id_tipoFactura),
PRIMARY KEY (nro_compra, tipoFactura) 
)

--DetCompras
CREATE TABLE DetCompras(
nro_compra INT,
tipo_factura CHAR,
id_producto INT CONSTRAINT FK_producto_detCompras FOREIGN KEY REFERENCES Productos (id_producto),
FOREIGN KEY (nro_compra,tipo_factura) REFERENCES Compras (nro_compra, tipoFactura),
PRIMARY KEY (nro_compra,tipo_factura,id_producto)
)

--|||||||||||||||||||||||||||||||
--||CREACION DE TABLAS DE LOGIN||
--|||||||||||||||||||||||||||||||

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

CREATE TABLE [dbo].[Perfiles](
	[id_Perfil] [int] NOT NULL,
	[descripcion] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Perfiles] ([id_Perfil], [descripcion]) VALUES (1, N'Admins    ')

 --INT CONSTRAINT FK_ FOREIGN KEY REFERENCES Tabla (campo)