GO
USE [BuenViaje]
GO
--/****** Object:  Table [dbo].[Producto]    Script Date: 06/14/2018 21:53:25 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Producto](
--    [Producto_Id] [int] NOT NULL,
--    [Producto_Nombre] [varchar](50) NULL,
--    [Producto_Precio] [varchar](50) NULL
-- CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED CLUSTERED 
--(
--    [Producto_Id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO
--/****** Object:  Table [dbo].[Cliente]    Script Date: 06/14/2018 21:54:10 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Cliente](
--    [Cliente_Id] [int] NOT NULL,
--    [Cliente_Nombre] [varchar](50) NULL,
--    [Cliente_Direccion] [varchar](50) NULL,
--    [Cliente_Email] [varchar](50) NULL,
-- CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED CLUSTERED 
--(
--    [Cliente_Id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO
--/****** Object:  Table [dbo].[Pedido]    Script Date: 06/14/2018 21:54:10 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Pedido](
--    [Pedido_Id] [int] NOT NULL,
--    [Pedido_Fecha] [varchar](100) NOT NULL,
--    [Pedido_Entregado] [varchar](100) NOT NULL,
--    [Pedido_ClienteId] [int] NOT NULL,
-- CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED CLUSTERED 
--(
--    [Pedido_Id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO
--/****** Object:  ForeignKey [FK_Pedido_Cliente]    Script Date: 06/14/2018 21:54:10 ******/
--ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([Pedido_ClienteId])
--REFERENCES [dbo].[Cliente] ([Cliente_Id])
--GO
--ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
--GO
--/****** Object:  Table [dbo].[PackBebida]    Script Date: 06/14/2018 21:53:25 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[PackBebida](
--    [PackBebida_Id] [int] NOT NULL,
--    [PackBebida_ProductoId] [int] NOT NULL,
--    [PackBebida_PedidoId] [int],
--    [PackBebida_Cantidad] [varchar](50) NOT NULL,
--    [PackBebida_Retornable] [varchar](50) NULL,
-- CONSTRAINT [PK_PackBebida] PRIMARY KEY CLUSTERED CLUSTERED 
--(
--    [PackBebida_Id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO
--/****** Object:  ForeignKey [FK_PackBebida_Producto]    Script Date: 06/14/2018 21:53:25 ******/
--ALTER TABLE [dbo].[PackBebida]  WITH CHECK ADD  CONSTRAINT [FK_PackBebida_Producto] FOREIGN KEY([PackBebida_ProductoId])
--REFERENCES [dbo].[Producto] ([Producto_Id])
--GO
--ALTER TABLE [dbo].[PackBebida] CHECK CONSTRAINT [FK_PackBebida_Producto]
--GO
--SET ANSI_PADDING OFF
--GO
--/****** Object:  ForeignKey [FK_PackBebida_Pedido]    Script Date: 06/14/2018 21:53:25 ******/
--ALTER TABLE [dbo].[PackBebida]  WITH CHECK ADD  CONSTRAINT [FK_PackBebida_Pedido] FOREIGN KEY([PackBebida_PedidoId])
--REFERENCES [dbo].[Pedido] ([Pedido_Id])
--GO
--ALTER TABLE [dbo].[PackBebida] CHECK CONSTRAINT [FK_PackBebida_Pedido]
--GO


CREATE TABLE Nombre(
	ID_Producto bigint Not Null

)

CREATE TABLE PRODUCTO
       (
       ID_PRODUCTO BIGINT NOT NULL,                              
       NOMBRE CHAR(250) NOT NULL,                              
       STOCK BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_PRODUCTO)
       );


CREATE TABLE CLIENTE
       (
       ID_CLIENTE BIGINT NOT NULL,                              
       DIRECCION CHAR(250) NOT NULL,                              
       PROVINCIA CHAR(250) NOT NULL,                              
       EMAIL BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_CLIENTE)
       );


CREATE TABLE INSUMO
       (
       ID_INSUMO BIGINT NOT NULL,                              
       NOMBRE CHAR(250) NOT NULL,                              
       STOCK BIGINT NOT NULL,                              
       STOCKMINIMO BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_INSUMO)
       );


CREATE TABLE COMPRA
       (
       ID_COMPRA BIGINT NOT NULL,                              
       FECHA BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_COMPRA)
       );


CREATE TABLE PROVEDOR
       (
       ID_PROVEDOR BIGINT NOT NULL,                              
       NOMBRE BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_PROVEDOR)
       );

CREATE TABLE VENTA
       (
       ID_VENTA BIGINT NOT NULL,                              
       ID_CLIENTE BIGINT NOT NULL,                              
       FECHA DATETIME NOT NULL,                              
       FORMADEPAGO CHAR(250) NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_VENTA),
       FOREIGN KEY(ID_CLIENTE)
          REFERENCES CLIENTE(ID_CLIENTE)
	   ON DELETE NO ACTION
       );


CREATE TABLE COTIZACION
       (
       ID_COTIZACION BIGINT NOT NULL,                              
       ID_PROVEDOR BIGINT NOT NULL,                              
       ID_COMPRA BIGINT,                              
       PLAZOENTREGA DATETIME NOT NULL,                              
       FECHA DATETIME NOT NULL,                              
       FECHAVENCIMIENTO DATETIME NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_COTIZACION),
       FOREIGN KEY(ID_PROVEDOR)
          REFERENCES PROVEDOR (ID_PROVEDOR)
  	   ON DELETE NO ACTION,
       FOREIGN KEY(ID_COMPRA)
          REFERENCES COMPRA(ID_COMPRA)
	    ON DELETE SET NULL
       );

CREATE TABLE TRASLADO
       (
       ID_TRASLADO BIGINT NOT NULL,                              
       ID_PRODUCTO BIGINT NOT NULL,                              
       FECHATRASLADO BIGINT NOT NULL,                              
       CANTIDAD BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_TRASLADO, ID_PRODUCTO),
       FOREIGN KEY(ID_PRODUCTO)
          REFERENCES PRODUCTO (ID_PRODUCTO)
	    ON DELETE CASCADE
       );


CREATE TABLE TELEFONO
       (
       ID_TELEFONO BIGINT NOT NULL,                              
       ID_CLIENTE BIGINT NOT NULL,                              
       NUMERO CHAR(250) NOT NULL,                              
       COMPANIA BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_TELEFONO, ID_CLIENTE),
       FOREIGN KEY (ID_CLIENTE)
          REFERENCES CLIENTE(ID_CLIENTE)
	    ON DELETE CASCADE
       );

CREATE TABLE RECEPCION
       (
       ID_RECEPCION BIGINT NOT NULL,                              
       ID_INSUMO BIGINT NOT NULL,                              
       ID_COMPRA BIGINT NOT NULL,                              
       CANTIDAD BIGINT NOT NULL,                              
       FECHA DATETIME NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_RECEPCION, ID_INSUMO),
       FOREIGN KEY (ID_INSUMO)
          REFERENCES INSUMO(ID_INSUMO)
    ON DELETE CASCADE,
       FOREIGN KEY(ID_COMPRA)
          REFERENCES COMPRA (ID_COMPRA)
	    ON DELETE NO ACTION	
       );


CREATE TABLE COTIZACIONINSUMO
       (
       ID_COTIZACION BIGINT NOT NULL,                              
       ID_INSUMO BIGINT NOT NULL,                              
       PRECIO BIGINT NOT NULL,                              
       CANTIDAD BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED(ID_COTIZACION, ID_INSUMO),
       FOREIGN KEY (ID_COTIZACION)
          REFERENCES COTIZACION(ID_COTIZACION)
    ON DELETE NO ACTION,
       FOREIGN KEY (ID_INSUMO)
          REFERENCES INSUMO (ID_INSUMO)
	    ON DELETE CASCADE
       );

CREATE TABLE PRODUCTOINSUMO
       (
       ID_INSUMO BIGINT NOT NULL,                              
       ID_PRODUCTO BIGINT NOT NULL,                              
       MEDIDA BIGINT NOT NULL,                              
       CANTIDAD BIGINT NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_INSUMO, ID_PRODUCTO),
       FOREIGN KEY (ID_INSUMO)
          REFERENCES INSUMO (ID_INSUMO)
    ON DELETE CASCADE,
       FOREIGN KEY (ID_PRODUCTO)
          REFERENCES PRODUCTO(ID_PRODUCTO)
	    ON DELETE CASCADE
       );

CREATE TABLE VENTAPRODUCTO
       (
       ID_PRODUCTO BIGINT NOT NULL,                              
       ID_VENTA BIGINT NOT NULL,                              
       CANTIDAD BIGINT NOT NULL,                              
       PRECIO BIGINT NOT NULL,                              
       LUGARENTREGA BIGINT NOT NULL,                              
       PLAZOENTREGA DATETIME NOT NULL,                              
       PRIMARY KEY CLUSTERED (ID_PRODUCTO, ID_VENTA),
       FOREIGN KEY (ID_PRODUCTO)
          REFERENCES PRODUCTO (ID_PRODUCTO)
    ON DELETE CASCADE,
       FOREIGN KEY (ID_VENTA)
          REFERENCES VENTA (ID_VENTA)
	    ON DELETE CASCADE
       );
