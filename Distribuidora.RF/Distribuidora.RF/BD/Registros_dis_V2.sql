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