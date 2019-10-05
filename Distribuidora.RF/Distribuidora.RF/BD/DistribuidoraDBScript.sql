--CREATE DATABASE Distribuidora_v2
use Distribuidora_v2

--|||||||||||||||||||||||||||||
--||CREACION DE TABLAS SIMPES||
--|||||||||||||||||||||||||||||

--Ciudades
CREATE TABLE Ciudades(
id_ciudad INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre VARCHAR(50) NOT NULL,
borrado BIT NOT NULL DEFAULT 0)

--Barrios
CREATE TABLE Barrios(
id_barrio INT PRIMARY KEY NOT NULL IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
ciudad INT CONSTRAINT FK_Ciudad FOREIGN KEY REFERENCES Ciudades (id_ciudad),
borrado BIT NOT NULL DEFAULT 0
)

--Categorias
CREATE TABLE Categorias(
id_categoria INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR (50) NOT NULL,
borrado BIT NOT NULL DEFAULT 0
)

--EstadoProveedor
CREATE TABLE EstadoProveedor(
id_estadoP INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50) NOT NULL,
borrado BIT NOT NULL DEFAULT 0
)

--EstadoCliente
CREATE TABLE EstadoCliente(
id_estadoC INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR(50) NOT NULL,
borrado BIT NOT NULL DEFAULT 0
)

--EstadoProducto
CREATE TABLE EstadoProducto(
id_estadoPr INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion VARCHAR (50),
borrado BIT NOT NULL DEFAULT 0
)

--TipoProveedor
CREATE TABLE TipoProveedor(
id_tipoP INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50) NOT NULL,
borrado BIT NOT NULL DEFAULT 0
)

--TipoCliente
CREATE TABLE TipoCliente(
id_tipoC INT PRIMARY KEY NOT NULL IDENTITY (1,1),
descripcion varchar (50)NOT NULL,
borrado BIT NOT NULL DEFAULT 0
)

--TipoFactura
CREATE TABLE TipoFactura(
id_tipoFactura CHAR PRIMARY KEY NOT NULL,
descripcion VARCHAR (50),
borrado BIT NOT NULL DEFAULT 0
)

--||||||||||||||||||||||||||||||||
--||CREACION DE TABLAS COMPLEJAS||
--||||||||||||||||||||||||||||||||

--Clientes
CREATE TABLE Clientes(
id_cliente INT PRIMARY KEY NOT NULL IDENTITY (1,1),
cuit VARCHAR(13),
nombre_local VARCHAR(50),
nombre_cliente VARCHAR(50) NOT NULL,
domicilio_calle VARCHAR(50)NOT NULL,
domicilio_numero INT NOT NULL,
telefono VARCHAR(50),
email VARCHAR (50),
fecha_registro date,
barrio INT CONSTRAINT FK_barrioC FOREIGN KEY REFERENCES Barrios (id_barrio),
tipo_cliente INT CONSTRAINT FK_tipo_cliente FOREIGN KEY REFERENCES TipoCliente (id_tipoC),
estado_cliente INT CONSTRAINT FK_estado_cliente FOREIGN KEY REFERENCES EstadoCliente (id_estadoC),
borrado BIT NOT NULL DEFAULT 0
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
estado_proveedor INT CONSTRAINT FK_estado_proveedor FOREIGN KEY REFERENCES EstadoProveedor (id_estadoP),
borrado BIT NOT NULL DEFAULT 0
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
precio DECIMAL(10,2) NOT NULL,
stock INT NOT NULL DEFAULT 0,
borrado BIT NOT NULL DEFAULT 0
)

--|||||||||||||||||||||||||||||||||||||||
--||CREACION DE TABLAS DE TRANSACCIONES||
--|||||||||||||||||||||||||||||||||||||||

--Ventas
CREATE TABLE Ventas(
tipoFactura CHAR NOT NULL CONSTRAINT FK_tipoFactura_ventas FOREIGN KEY REFERENCES TipoFactura (id_tipoFactura),
nro_factura DECIMAL(8,0) NOT NULL,
PRIMARY KEY (tipoFactura, nro_factura),
fecha date not null,
cliente INT CONSTRAINT FK_cliente_ventas FOREIGN KEY REFERENCES Clientes (id_cliente),
condiva VARCHAR(40),
condventa VARCHAR(20),
subtotal DECIMAL(10,2),
porc_descuento INT,
importe_neto DECIMAL(10,2),
importe_iva DECIMAL(10,2) DEFAULT 0,
importe_total DECIMAL(10,2),
borrado BIT NOT NULL DEFAULT 0
)

--DetVentas
CREATE TABLE DetVentas(
tipo_factura CHAR,
nro_factura DECIMAL(8,0),
id_producto INT CONSTRAINT FK_producto_detVenta FOREIGN KEY REFERENCES Productos (id_producto),
PRIMARY KEY (tipo_factura,nro_factura,id_producto),
FOREIGN KEY (tipo_factura,nro_factura) REFERENCES Ventas (tipoFactura,nro_factura),
precio DECIMAL(10,2),
cantidad INT,
importe DECIMAL(10,2),
borrado BIT NOT NULL DEFAULT 0
)

--Compras
CREATE TABLE Compras(
nro_compra INT not null IDENTITY (1,1000),
fecha date not null,
proveedor INT CONSTRAINT FK_proveedor_compras FOREIGN KEY REFERENCES Proveedores (id_proveedor),
tipoFactura CHAR CONSTRAINT FK_tipoFactura_compras FOREIGN KEY REFERENCES TipoFactura (id_tipoFactura),
PRIMARY KEY (nro_compra, tipoFactura),
borrado BIT NOT NULL DEFAULT 0
)

--DetCompras
CREATE TABLE DetCompras(
nro_compra INT,
tipo_factura CHAR,
id_producto INT CONSTRAINT FK_producto_detCompras FOREIGN KEY REFERENCES Productos (id_producto),
FOREIGN KEY (nro_compra,tipo_factura) REFERENCES Compras (nro_compra, tipoFactura),
PRIMARY KEY (nro_compra,tipo_factura,id_producto),
borrado BIT NOT NULL DEFAULT 0
)

--|||||||||||||||||||||||||||||||
--||CREACION DE TABLAS DE LOGIN||
--|||||||||||||||||||||||||||||||

CREATE TABLE [dbo].[Usuarios](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[n_Usuario] [varchar](30) NOT NULL,
	[password] [varchar](20) NULL,
	[email] [varchar](40) NULL,
	[id_Perfil] [int] NULL,
	[estado] [char] DEFAULT 'S',
	[borrado] [bit] NOT NULL DEFAULT 0
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([id_Usuario], [n_Usuario], [password], [email], [id_Perfil]) VALUES (1, N'Admin', N'123', N'admin@rf.com', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Perfiles]    Script Date: 08/19/2019 10:05:58 ******/

CREATE TABLE [dbo].[Perfiles](
	[id_Perfil] [int] NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[borrado] [bit] NOT NULL DEFAULT 0	
) ON [PRIMARY]
GO
--INSERT [dbo].[Perfiles] ([id_Perfil], [descripcion]) VALUES (1, N'Admins')
INSERT [dbo].[Perfiles] ([id_perfil], [descripcion], [borrado]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Perfiles] ([id_perfil], [descripcion], [borrado]) VALUES (2, N'Tester', 0)
INSERT [dbo].[Perfiles] ([id_perfil], [descripcion], [borrado]) VALUES (3, N'Desarrollador', 0)
INSERT [dbo].[Perfiles] ([id_perfil], [descripcion], [borrado]) VALUES (4, N'Responsable de Reportes', 0)

 --INT CONSTRAINT FK_ FOREIGN KEY REFERENCES Tabla (campo)
 
 
 
 use Distribuidora_v2
----------------------------------------------------
--Carga de Ciudades
----------------------------------------------------
INSERT INTO Ciudades (nombre) VALUES('Córdoba')
INSERT INTO Ciudades (nombre) VALUES('Jesús María')
INSERT INTO Ciudades (nombre) VALUES('Carlos Paz')
INSERT INTO Ciudades (nombre) VALUES('Cosquin')
INSERT INTO Ciudades (nombre) VALUES('Arroyito')
INSERT INTO Ciudades (nombre) VALUES('Río Cuarto')
INSERT INTO Ciudades (nombre) VALUES('Río Tercero')
INSERT INTO Ciudades (nombre) VALUES('Villa María')
INSERT INTO Ciudades (nombre) VALUES('Alta Gracia')
INSERT INTO Ciudades (nombre) VALUES('San Francisco')
INSERT INTO Ciudades (nombre) VALUES('Bell-Ville')
INSERT INTO Ciudades (nombre) VALUES('La Falda')
INSERT INTO Ciudades (nombre) VALUES('La Calera')

----------------------------------------------------
--Carga de Barrios
----------------------------------------------------
INSERT INTO Barrios VALUES('Alberdi',1,0)
INSERT INTO Barrios VALUES('Nueva Cordoba',1,0)
INSERT INTO Barrios VALUES('Centro',1,0)
INSERT INTO Barrios VALUES('Junior',1,0)
INSERT INTO Barrios VALUES('Gral Paz',1,0)
INSERT INTO Barrios VALUES('Alta Córdoba',1,0)
INSERT INTO Barrios VALUES('Talleres Este',1,0)
INSERT INTO Barrios VALUES('Talleres Oeste',1,0)
INSERT INTO Barrios VALUES('Villa Esquiú',1,0)
INSERT INTO Barrios VALUES('Yofre Norte',1,0)
INSERT INTO Barrios VALUES('Centro',2,0)
INSERT INTO Barrios VALUES('Barrancas',2,0)
INSERT INTO Barrios VALUES('Pueblo Nuevo',2,0)
INSERT INTO Barrios VALUES('Centro',3,0)
INSERT INTO Barrios VALUES('La Cuesta',3,0)
INSERT INTO Barrios VALUES('Costa Azul Sur',3,0)
INSERT INTO Barrios VALUES('Altos de las Vertientes',3,0)
INSERT INTO Barrios VALUES('Villa del Lago',3,0)
INSERT INTO Barrios VALUES('Centro',4,0)
INSERT INTO Barrios VALUES('Cumbre Azul',4,0)
INSERT INTO Barrios VALUES('Pan de Azucar',4,0)
INSERT INTO Barrios VALUES('Alto Mieres',4,0)
INSERT INTO Barrios VALUES('Yacanto',5,0)
INSERT INTO Barrios VALUES('Centro',5,0)
INSERT INTO Barrios VALUES('Los Reartes',5,0)
INSERT INTO Barrios VALUES('San Javier',5,0)
INSERT INTO Barrios VALUES('Centro',6,0)
INSERT INTO Barrios VALUES('Banda Norte',6,0)
INSERT INTO Barrios VALUES('Abilene',6,0)
INSERT INTO Barrios VALUES('Centro',7,0)
INSERT INTO Barrios VALUES('Golf Club',7,0)
INSERT INTO Barrios VALUES('Las Quintas',7,0)
INSERT INTO Barrios VALUES('Centro',8,0)
INSERT INTO Barrios VALUES('Obrero',8,0)
INSERT INTO Barrios VALUES('Centro',9,0)
INSERT INTO Barrios VALUES('1° de Mayo',9,0)
INSERT INTO Barrios VALUES('Parque del Virrey',9,0)
INSERT INTO Barrios VALUES('Centro',10,0)
INSERT INTO Barrios VALUES('Las Rosas',10,0)
INSERT INTO Barrios VALUES('Maipú',10,0)
INSERT INTO Barrios VALUES('Centro',11,0)
INSERT INTO Barrios VALUES('El Prado',11,0)
INSERT INTO Barrios VALUES('Santa Rosa',12,0)
INSERT INTO Barrios VALUES('Valle Verde',12,0)
INSERT INTO Barrios VALUES('Centro',13,0)
INSERT INTO Barrios VALUES('Stoecklin',13,0)
INSERT INTO Barrios VALUES('Villa Los Paraísos',13,0)

----------------------------------------------------
--Carga de TipoFactura
----------------------------------------------------
INSERT INTO TipoFactura VALUES ('A','Factura del tipo A',0)
INSERT INTO TipoFactura VALUES ('B','Factura del tipo B',0)
INSERT INTO TipoFactura VALUES ('C','Factura del tipo C',0)

----------------------------------------------------
--Carga de TipoCliente
----------------------------------------------------
INSERT INTO TipoCliente VALUES ('Mayorista',0)
INSERT INTO TipoCliente VALUES ('Minorista',0)
INSERT INTO TipoCliente VALUES ('Consumidor',0)

----------------------------------------------------
--Carga de TipoProveedor
----------------------------------------------------
INSERT INTO TipoProveedor VALUES ('Mayorista',0)
INSERT INTO TipoProveedor VALUES ('Minorista',0)
INSERT INTO TipoProveedor VALUES ('Productor',0)

----------------------------------------------------
--Carga de EstadoCliente
----------------------------------------------------
INSERT INTO EstadoCliente VALUES ('En Alta',0)
INSERT INTO EstadoCliente VALUES ('De Baja',0)

----------------------------------------------------
--Carga de EstadoProveedor
----------------------------------------------------
INSERT INTO EstadoProveedor VALUES ('En Alta',0)
INSERT INTO EstadoProveedor VALUES ('De Baja',0)

----------------------------------------------------
--Carga de EstadoProducto
----------------------------------------------------
INSERT INTO EstadoProducto VALUES ('En produccion',0)
INSERT INTO EstadoProducto VALUES ('Fuera de produccion',0)

----------------------------------------------------
--Carga de Categoria
----------------------------------------------------
INSERT INTO Categorias VALUES ('Alimentos que aceleran el metabolismo',0)
INSERT INTO Categorias VALUES ('Alimentos saciantes',0)
INSERT INTO Categorias VALUES ('Alimentos digestivos',0)







use Distribuidora_v2
INSERT INTO Clientes VALUES('30-50108624-6', 'Pato Azul', 'Arturo Viñas', 'San Martín', 788, '0351-4514753','patoazul@gmail.com','2019-09-03',1,1,1,0)
INSERT INTO Clientes VALUES('30-66916066-2', 'Vida Sana', 'Maria Vegas', 'Oncativo', 1454, '0351-4518013','vidasanaproductos@gmail.com','2019-01-01',2,1,1,0)
INSERT INTO Clientes VALUES('30-67867622-1', 'Amanecer', 'Esmeralda Di Pietro', 'Santa Fé', 5120, '0351-159913445','dipietroventa@gmail.com','2017-08-13',3,3,1,0)
INSERT INTO Clientes VALUES('30-71070556-5', 'Dietetica Anahi', 'Anahi Sosa', 'Perón', 1157, '0351-450598','psosaadietetica@gmail.com','2018-05-07',5,1,1,0)
INSERT INTO Clientes VALUES('30-70908678-9', 'Holy Seed', 'Rosa Zabala', 'San Lorenzo', 510, '0351-4587009','holyseedmoon@gmail.com','2018-11-28',4,2,1,0)
INSERT INTO Clientes VALUES('30-68537634-9', 'Salud Hoy', 'Dario Brites', 'Av. Pueyrredón', 985, '0351-15145805','vidasaanainsumos@gmail.com','2018-11-28',21,2,1,0)
INSERT INTO Clientes VALUES(NULL, 'Dietetica San Lorenzo', 'Sofía Meinas', 'Perú', 320, '0351-4519772','dieteticasanlorenzo@gmail.com','2019-03-08',25,2,1,0)
INSERT INTO Clientes VALUES(NULL, 'Mundo Salud', 'Josefina Ariza', 'Independiente', 1828, '0351-15360028','mundosalud_josef@gmail.com','2019-03-28',4,1,1,0)
INSERT INTO Clientes VALUES(NULL, 'Comunidad Crecer', 'Thom Yorke', 'Obispo Trejo', 570, '0351-4588755','saludcomunidad_crecer@gmail.com','2018-03-12',10,3,1,0)
INSERT INTO Clientes VALUES(NULL, 'Patagonia', 'Camila Maldonado', 'Entre Rios', 386, '0351-4598800','patagonia_dietetica@gmail.com','2018-01-01',7,1,1,0)








use Distribuidora_v2
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Peperina', NULL, NULL, NULL, NULL, NULL, 643.54, 150, 0)
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Poleo', NULL, NULL, NULL, NULL, NULL, 339.93, 250, 0)
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Palo Amarillo', NULL, NULL, NULL, NULL, NULL, 189.50, 45, 0)
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Jarilla', NULL, NULL, NULL, NULL, NULL, 175.90, 95, 0)
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Incayuyo', NULL, NULL, NULL, NULL, NULL, 542.57, 120, 0)
INSERT INTO Productos (nombre, unidad, fecha_registro, estado, categoria, proveedor, precio, stock, borrado) 
		VALUES('Té de Burro', NULL, NULL, NULL, NULL, NULL, 242.56, 145, 0)






