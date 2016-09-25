--*************EstadoPago*****************
CREATE TABLE EstadoPago
(	IdEstadoPago INT NOT NULL,
	DescripEstadoPago VARCHAR(200) NOT NULL,
	CONSTRAINT [PK_EstadoPago] PRIMARY KEY(IdEstadoPago))



--**********PAGO********************
CREATE TABLE Pago
(	IdPago INT NOT NULL,
	IdPedido INT NOT NULL,
	FechaPago DATETIME NOT NULL,
	IdEstadoPago INT NOT NULL,
	IdFormaPago INT NOT NULL,
	MontoPago DECIMAL NOT NULL,
	NroComprobante INT NOT NULL,
	IdSucursal INT NOT NULL,
	CUIT INT NOT NULL, 
	CONSTRAINT [PK_Pago] PRIMARY KEY(IdPago))

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_Pedido] 
FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_EstadoPago] 
FOREIGN KEY (IdEstadoPago) REFERENCES EstadoPago(IdEstadoPago)

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_FormaPago] 
FOREIGN KEY (IdFormaPago) REFERENCES FormaPago(IdFormaPago)

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_Comprobante] 
FOREIGN KEY (NroComprobante) REFERENCES Comprobante(NroComprobante)

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_Sucursal] 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)

ALTER TABLE Pago ADD CONSTRAINT [FK_Pago_Empresa] 
FOREIGN KEY (CUIT) REFERENCES Empresa(CUIT)


--************EMPRESA********************
CREATE TABLE Empresa
(	CUIT INT NOT NULL,
	NombreEmpresa VARCHAR(200) NOT NULL,
	CONSTRAINT [PK_Empresa] PRIMARY KEY(CUIT))


--*************FormaPago********************
CREATE TABLE FormaPago
(	IdFormaPago INT NOT NULL,
	DescripFormaPago VARCHAR(200) NOT NULL,
	CONSTRAINT [PK_FormaPago] PRIMARY KEY(IdFormaPago))

--******************TipoComprobante**************
CREATE TABLE TipoComprobante
(	IdTipoComprobante INT NOT NULL,
	DescripTipoComprobante VARCHAR(200) NOT NULL,
	CONSTRAINT [PK_TipoComprobante] PRIMARY KEY(IdTipoComprobante))

--********************Comprobante******************
CREATE TABLE Comprobante
(	NroComprobante INT NOT NULL,
	IdSucursal INT NOT NULL,
	CUIT INT NOT NULL,
	IdTipoComprobante INT NOT NULL,
	IdComprobante INT NOT NULL,
	FechaComprobante DATETIME NOT NULL,
	IdPedido INT NOT NULL,
	CONSTRAINT [PK_Comprobante] PRIMARY KEY(NroComprobante, IdSucursal, IdTipoComprobante, CUIT))

ALTER TABLE Comprobante ADD CONSTRAINT [FK_Comprobante_Sucursal] 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)

ALTER TABLE Comprobante ADD CONSTRAINT [FK_Comprobante_Empresa] 
FOREIGN KEY (CUIT) REFERENCES Empresa(CUIT)

ALTER TABLE Comprobante ADD CONSTRAINT [FK_Comprobante_Pedido] 
FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)

ALTER TABLE Comprobante ADD CONSTRAINT [FK_Comprobante_TipoComprobante] 
FOREIGN KEY (IdTipoComprobante) REFERENCES TipoComprobante(IdTipoComprobante)

--****************ComprobanteDetalle**********************
CREATE TABLE ComprobanteDetalle
(	IdComprobanteDetalle INT NOT NULL,
	NroComprobante INT NOT NULL,
	IdSucursal INT NOT NULL,
	CUIT INT NOT NULL,
	IdProducto INT NOT NULL,
	CantidadProducto INT NOT NULL,
	PrecioUnitarioFact DECIMAL NOT NULL,
	CONSTRAINT [PK_ComprobanteDetalle] PRIMARY KEY(IdComprobanteDetalle, NroComprobante, IdSucursal, CUIT))

ALTER TABLE ComprobanteDetalle ADD CONSTRAINT [FK_ComprobanteDetalle_Comprobante] 
FOREIGN KEY (NroComprobante) REFERENCES Comprobante(NroComprobante)

ALTER TABLE ComprobanteDetalle ADD CONSTRAINT [FK_ComprobanteDetalle_Sucursal] 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)

ALTER TABLE ComprobanteDetalle ADD CONSTRAINT [FK_ComprobanteDetalle_Empresa] 
FOREIGN KEY (CUIT) REFERENCES Empresa(CUIT)

ALTER TABLE ComprobanteDetalle ADD CONSTRAINT [FK_ComprobanteDetalle_Producto] 
FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)

--*****************Sucursal***********************
CREATE TABLE Sucursal
(	IdSucursal INT NOT NULL,
	DescripSucursal VARCHAR(200) NOT NULL,
	DireccionSucursal INT NOT NULL,
	CUIT INT NOT NULL,
	CONSTRAINT [PK_Sucursal] PRIMARY KEY(IdSucursal))

ALTER TABLE Sucursal ADD CONSTRAINT [FK_Sucursal_Empresa] 
FOREIGN KEY (CUIT) REFERENCES Empresa(CUIT)

ALTER TABLE Sucursal ADD CONSTRAINT [FK_Sucursal_Direccion] 
FOREIGN KEY (DireccionSucursal) REFERENCES Direccion(IdDireccion)



--***************Producto_Categoria****************
CREATE TABLE ProdCategoria
(	IdProducto INT NOT NULL,
	IdCategoria INT NOT NULL,
	CONSTRAINT [PK_ProdCategoria] PRIMARY KEY(IdProducto, IdCategoria))

ALTER TABLE ProdCategoria ADD CONSTRAINT [FK_ProductoCateg_Producto] 
FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)

ALTER TABLE ProdCategoria ADD CONSTRAINT [FK_ProductoCateg_Categoria] 
FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)

--******************Categoria***********************
CREATE TABLE Categoria
(	IdCategoria INT NOT NULL,
	DescripCategoria VARCHAR (200) NOT NULL,
	CONSTRAINT [PK_Categoria] PRIMARY KEY(IdCategoria))


--*******************IvaProducto**************************
CREATE TABLE IvaProducto
(	IdIvaProducto INT NOT NULL,
	PorcentajeIvaProd INT NOT NULL,
	CONSTRAINT [PK_IvaProducto] PRIMARY KEY(IdIvaProducto))

















