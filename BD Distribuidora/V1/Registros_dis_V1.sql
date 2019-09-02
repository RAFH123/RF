use Distribuidora_v1
----------------------------------------------------
--Carga de Ciudades
----------------------------------------------------
INSERT INTO Ciudades VALUES('Córdoba')
INSERT INTO Ciudades VALUES('Jesús María')
INSERT INTO Ciudades VALUES('Carlos Paz')
INSERT INTO Ciudades VALUES('Cosquin')
INSERT INTO Ciudades VALUES('Arroyito')
INSERT INTO Ciudades VALUES('Río Cuarto')
INSERT INTO Ciudades VALUES('Río Tercero')
INSERT INTO Ciudades VALUES('Villa María')
INSERT INTO Ciudades VALUES('Alta Gracia')
INSERT INTO Ciudades VALUES('San Francisco')
INSERT INTO Ciudades VALUES('Bell-Ville')
INSERT INTO Ciudades VALUES('La Falda')
INSERT INTO Ciudades VALUES('La Calera')

----------------------------------------------------
--Carga de Barrios
----------------------------------------------------
INSERT INTO Barrios VALUES('Alberdi',1)
INSERT INTO Barrios VALUES('Nueva Cordoba',1)
INSERT INTO Barrios VALUES('Centro',1)
INSERT INTO Barrios VALUES('Junior',1)
INSERT INTO Barrios VALUES('Gral Paz',1)
INSERT INTO Barrios VALUES('Alta Córdoba',1)
INSERT INTO Barrios VALUES('Talleres Este',1)
INSERT INTO Barrios VALUES('Talleres Oeste',1)
INSERT INTO Barrios VALUES('Villa Esquiú',1)
INSERT INTO Barrios VALUES('Yofre Norte',1)
INSERT INTO Barrios VALUES('Centro',2)
INSERT INTO Barrios VALUES('Barrancas',2)
INSERT INTO Barrios VALUES('Pueblo Nuevo',2)
INSERT INTO Barrios VALUES('Centro',3)
INSERT INTO Barrios VALUES('La Cuesta',3)
INSERT INTO Barrios VALUES('Costa Azul Sur',3)
INSERT INTO Barrios VALUES('Altos de las Vertientes',3)
INSERT INTO Barrios VALUES('Villa del Lago',3)
INSERT INTO Barrios VALUES('Centro',4)
INSERT INTO Barrios VALUES('Cumbre Azul',4)
INSERT INTO Barrios VALUES('Pan de Azucar',4)
INSERT INTO Barrios VALUES('Alto Mieres',4)
INSERT INTO Barrios VALUES('Yacanto',5)
INSERT INTO Barrios VALUES('Centro',5)
INSERT INTO Barrios VALUES('Los Reartes',5)
INSERT INTO Barrios VALUES('San Javier',5)
INSERT INTO Barrios VALUES('Centro',6)
INSERT INTO Barrios VALUES('Banda Norte',6)
INSERT INTO Barrios VALUES('Abilene',6)
INSERT INTO Barrios VALUES('Centro',7)
INSERT INTO Barrios VALUES('Golf Club',7)
INSERT INTO Barrios VALUES('Las Quintas',7)
INSERT INTO Barrios VALUES('Centro',8)
INSERT INTO Barrios VALUES('Obrero',8)
INSERT INTO Barrios VALUES('Centro',9)
INSERT INTO Barrios VALUES('1° de Mayo',9)
INSERT INTO Barrios VALUES('Parque del Virrey',9)
INSERT INTO Barrios VALUES('Centro',10)
INSERT INTO Barrios VALUES('Las Rosas',10)
INSERT INTO Barrios VALUES('Maipú',10)
INSERT INTO Barrios VALUES('Centro',11)
INSERT INTO Barrios VALUES('El Prado',11)
INSERT INTO Barrios VALUES('Santa Rosa',12)
INSERT INTO Barrios VALUES('Valle Verde',12)
INSERT INTO Barrios VALUES('Centro',13)
INSERT INTO Barrios VALUES('Stoecklin',13)
INSERT INTO Barrios VALUES('Villa Los Paraísos',13)

----------------------------------------------------
--Carga de TipoFactura
----------------------------------------------------
INSERT INTO TipoFactura VALUES ('A','Factura del tipo A')
INSERT INTO TipoFactura VALUES ('B','Factura del tipo B')
INSERT INTO TipoFactura VALUES ('C','Factura del tipo C')

----------------------------------------------------
--Carga de TipoCliente
----------------------------------------------------
INSERT INTO TipoCliente VALUES ('Mayorista')
INSERT INTO TipoCliente VALUES ('Minorista')
INSERT INTO TipoCliente VALUES ('Consumidor')

----------------------------------------------------
--Carga de TipoProveedor
----------------------------------------------------
INSERT INTO TipoProveedor VALUES ('Mayorista')
INSERT INTO TipoProveedor VALUES ('Minorista')
INSERT INTO TipoProveedor VALUES ('Productor')

----------------------------------------------------
--Carga de EstadoCliente
----------------------------------------------------
INSERT INTO EstadoCliente VALUES ('En Alta')
INSERT INTO EstadoCliente VALUES ('De Baja')

----------------------------------------------------
--Carga de EstadoProveedor
----------------------------------------------------
INSERT INTO EstadoProveedor VALUES ('En Alta')
INSERT INTO EstadoProveedor VALUES ('De Baja')

----------------------------------------------------
--Carga de EstadoProducto
----------------------------------------------------
INSERT INTO EstadoProducto VALUES ('En produccion')
INSERT INTO EstadoProducto VALUES ('Fuera de produccion')

----------------------------------------------------
--Carga de Categoria
----------------------------------------------------
INSERT INTO Categorias VALUES ('Alimentos que aceleran el metabolismo')
INSERT INTO Categorias VALUES ('Alimentos saciantes')
INSERT INTO Categorias VALUES ('Alimentos digestivos')