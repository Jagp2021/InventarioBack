GO
/****** Object:  Table [dbo].[cliente]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_documento] [varchar](4) NOT NULL,
	[numero_documento] [varchar](50) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_factura]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[valor_unitario] [numeric](18, 0) NOT NULL,
	[valor_total] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_detalle_factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_garantia]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_garantia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_garantia] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[estado_producto_garantia] [varchar](4) NOT NULL,
	[id_proveedor] [int] NULL,
	[valor_producto] [numeric](18, 0) NULL,
 CONSTRAINT [PK_detalle_garantia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_ingreso] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[valor] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dominio]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dominio](
	[dominio] [varchar](50) NOT NULL,
	[sigla] [varchar](4) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_dominio] PRIMARY KEY CLUSTERED 
(
	[dominio] ASC,
	[sigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero_factura] [varchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cliente] [int] NOT NULL,
	[usuario_registro] [int] NOT NULL,
	[tipo_pago] [varchar](4) NOT NULL,
	[total] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[garantia]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[garantia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_factura] [int] NULL,
	[fecha] [datetime] NOT NULL,
	[estado_garantia] [varchar](4) NOT NULL,
	[id_ingreso] [int] NULL,
	[tipo_garantia] [varchar](4) NULL,
 CONSTRAINT [PK_garantia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingresos]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingresos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_proveedor] [int] NOT NULL,
 CONSTRAINT [PK_ingresos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs_excepcion]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs_excepcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_logs_excepcion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[icono] [varchar](30) NULL,
	[url] [varchar](200) NULL,
	[id_menu_padre] [int] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[perfil]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[perfil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permisos_perfil]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permisos_perfil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_perfil] [int] NULL,
	[id_menu] [int] NULL,
 CONSTRAINT [PK_permisos_perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[estado] [bit] NOT NULL,
	[cantidad_disponible] [int] NOT NULL,
	[tipo_producto] [varchar](4) NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[tipo_documento] [varchar](4) NOT NULL,
	[numero_documento] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 14/05/2024 20:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[tipo_documento] [varchar](4) NULL,
	[numero_documento] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](200) NULL,
	[id_perfil] [int] NOT NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id], [tipo_documento], [numero_documento], [nombre], [telefono], [email]) VALUES (1, N'CC', N'1234567', N'Miguel Martinez', N'43324324', N'mmartinez@gmail.com')
INSERT [dbo].[cliente] ([id], [tipo_documento], [numero_documento], [nombre], [telefono], [email]) VALUES (2, N'CC', N'324324324', N'Laura Rodriguez', N'3243432', N'lrodriguez@gmail.com')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[detalle_factura] ON 

INSERT [dbo].[detalle_factura] ([id], [id_factura], [id_producto], [cantidad], [valor_unitario], [valor_total]) VALUES (21, 15, 1, 1, CAST(20000 AS Numeric(18, 0)), CAST(20000 AS Numeric(18, 0)))
INSERT [dbo].[detalle_factura] ([id], [id_factura], [id_producto], [cantidad], [valor_unitario], [valor_total]) VALUES (22, 16, 1, 1, CAST(20000 AS Numeric(18, 0)), CAST(20000 AS Numeric(18, 0)))
INSERT [dbo].[detalle_factura] ([id], [id_factura], [id_producto], [cantidad], [valor_unitario], [valor_total]) VALUES (23, 17, 4, 1, CAST(50000 AS Numeric(18, 0)), CAST(50000 AS Numeric(18, 0)))
INSERT [dbo].[detalle_factura] ([id], [id_factura], [id_producto], [cantidad], [valor_unitario], [valor_total]) VALUES (24, 18, 4, 1, CAST(50000 AS Numeric(18, 0)), CAST(50000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[detalle_factura] OFF
GO
SET IDENTITY_INSERT [dbo].[detalle_garantia] ON 

INSERT [dbo].[detalle_garantia] ([id], [id_garantia], [id_producto], [cantidad], [estado_producto_garantia], [id_proveedor], [valor_producto]) VALUES (12, 12, 1, 1, N'REGI', NULL, NULL)
INSERT [dbo].[detalle_garantia] ([id], [id_garantia], [id_producto], [cantidad], [estado_producto_garantia], [id_proveedor], [valor_producto]) VALUES (13, 13, 1, 1, N'REGI', NULL, NULL)
SET IDENTITY_INSERT [dbo].[detalle_garantia] OFF
GO
SET IDENTITY_INSERT [dbo].[detalle_ingreso] ON 

INSERT [dbo].[detalle_ingreso] ([id], [id_ingreso], [id_producto], [cantidad], [valor]) VALUES (11, 10, 1, 2, CAST(20000 AS Numeric(18, 0)))
INSERT [dbo].[detalle_ingreso] ([id], [id_ingreso], [id_producto], [cantidad], [valor]) VALUES (12, 10, 4, 2, CAST(50000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[detalle_ingreso] OFF
GO
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'ESTADOGARANTIA', N'CERR', N'Cerrada', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'ESTADOGARANTIA', N'GEST', N'Gestionada', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'ESTADOGARANTIA', N'REGI', N'Registrada', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPODOCUMENTO', N'CC', N'Cédula de Ciudadania', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPODOCUMENTO', N'CE', N'Cédula de Extrnajeria', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPODOCUMENTO', N'NIT', N'Número de Identificación Tributaria', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPOGARANTIA', N'INGR', N'Ingreso', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPOGARANTIA', N'VENT', N'Venta', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPOPAGO', N'EFEC', N'Efectivo', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPOPAGO', N'TREL', N'Transferencia Electrónica', 1)
INSERT [dbo].[dominio] ([dominio], [sigla], [descripcion], [activo]) VALUES (N'TIPOPRODUCTO', N'GEN', N'Genérico', 1)
GO
SET IDENTITY_INSERT [dbo].[factura] ON 

INSERT [dbo].[factura] ([id], [numero_factura], [fecha], [cliente], [usuario_registro], [tipo_pago], [total]) VALUES (15, N'2024-0001', CAST(N'2024-05-14T00:00:00.000' AS DateTime), 1, 0, N'EFEC', CAST(20000 AS Numeric(18, 0)))
INSERT [dbo].[factura] ([id], [numero_factura], [fecha], [cliente], [usuario_registro], [tipo_pago], [total]) VALUES (16, N'2024-0002', CAST(N'2024-05-14T00:00:00.000' AS DateTime), 1, 0, N'EFEC', CAST(20000 AS Numeric(18, 0)))
INSERT [dbo].[factura] ([id], [numero_factura], [fecha], [cliente], [usuario_registro], [tipo_pago], [total]) VALUES (17, N'2024-0003', CAST(N'2024-05-14T00:00:00.000' AS DateTime), 1, 0, N'EFEC', CAST(50000 AS Numeric(18, 0)))
INSERT [dbo].[factura] ([id], [numero_factura], [fecha], [cliente], [usuario_registro], [tipo_pago], [total]) VALUES (18, N'2024-0004', CAST(N'2024-05-14T00:00:00.000' AS DateTime), 2, 2, N'EFEC', CAST(50000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[factura] OFF
GO
SET IDENTITY_INSERT [dbo].[garantia] ON 

INSERT [dbo].[garantia] ([id], [id_factura], [fecha], [estado_garantia], [id_ingreso], [tipo_garantia]) VALUES (12, 15, CAST(N'2024-05-14T05:00:00.000' AS DateTime), N'GEST', NULL, N'VENT')
INSERT [dbo].[garantia] ([id], [id_factura], [fecha], [estado_garantia], [id_ingreso], [tipo_garantia]) VALUES (13, 16, CAST(N'2024-05-14T05:00:00.000' AS DateTime), N'CERR', NULL, N'VENT')
SET IDENTITY_INSERT [dbo].[garantia] OFF
GO
SET IDENTITY_INSERT [dbo].[ingresos] ON 

INSERT [dbo].[ingresos] ([id], [fecha], [id_proveedor]) VALUES (10, CAST(N'2024-04-06T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ingresos] OFF

GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (1, N'Home', NULL, NULL, NULL)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (2, N'Home', N'pi pi-fw pi-home', N'/home', 1)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (3, N'Parametrización', NULL, NULL, NULL)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (4, N'Usuarios', N'pi pi-fw pi-id-card', N'/parametrizacion/usuario', 3)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (5, N'Proveedores', N'pi pi-fw pi-book', N'/parametrizacion/proveedor', 3)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (6, N'Productos', N'pi pi-bookmark', N'/parametrizacion/producto', 3)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (7, N'Clientes', N'pi pi-fw pi-id-card', N'/parametrizacion/cliente', 3)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (8, N'Proceso', NULL, NULL, NULL)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (9, N'Ventas', N'pi pi-fw pi-id-card', N'/procesos/venta', 8)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (10, N'Ingresos', N'pi pi-fw pi-book', N'/procesos/ingreso', 8)
INSERT [dbo].[menu] ([id], [nombre], [icono], [url], [id_menu_padre]) VALUES (11, N'Garantias', N'pi pi-bookmark', N'/procesos/garantia', 8)
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[perfil] ON 

INSERT [dbo].[perfil] ([id], [nombre], [activo]) VALUES (1, N'Administrador', 1)
INSERT [dbo].[perfil] ([id], [nombre], [activo]) VALUES (3, N'Consulta', 1)
INSERT [dbo].[perfil] ([id], [nombre], [activo]) VALUES (4, N'Operación', 1)
SET IDENTITY_INSERT [dbo].[perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[permisos_perfil] ON 

INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (1, 1, 1)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (2, 1, 2)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (3, 1, 3)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (4, 1, 4)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (5, 1, 5)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (6, 1, 6)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (7, 1, 7)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (8, 1, 8)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (9, 1, 9)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (10, 1, 10)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (11, 1, 11)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (12, 3, 1)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (13, 3, 2)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (14, 3, 8)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (15, 3, 9)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (16, 3, 10)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (17, 3, 11)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (18, 3, 1)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (19, 3, 2)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (20, 3, 8)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (21, 3, 9)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (22, 3, 10)
INSERT [dbo].[permisos_perfil] ([id], [id_perfil], [id_menu]) VALUES (23, 3, 11)
SET IDENTITY_INSERT [dbo].[permisos_perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (1, N'PACH', N'Pacha', N'Pacha', 1, 1, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (4, N'PANTALLA', N'Pantalla', N'Pantalla', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (5, N'BATE', N'Bateria', N'Bateria', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (6, N'VIDR', N'Vidrio', N'Vidrio', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (7, N'PARL', N'Parlante', N'Parlante', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (8, N'PROC', N'Procesador', N'Procesador', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (9, N'MEMO', N'Memoria', N'Memoria', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (10, N'AUDI', N'Audifonos', N'Audifonos', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (11, N'CARC', N'Carcasa', N'Carcasa', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (12, N'POWE', N'PowerBank', N'PowerBank', 1, 0, N'GEN')
INSERT [dbo].[producto] ([id], [codigo], [nombre], [descripcion], [estado], [cantidad_disponible], [tipo_producto]) VALUES (13, N'CARG', N'Cargador', N'Cargador', 1, 0, N'GEN')
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([id], [nombre], [tipo_documento], [numero_documento], [telefono], [email]) VALUES (1, N'Repuestos LTDA', N'NIT', N'324324324', N'324324324', N'dsfdsf@gmail.com')
INSERT [dbo].[proveedor] ([id], [nombre], [tipo_documento], [numero_documento], [telefono], [email]) VALUES (4, N'Celulares y Accesorios SA', N'NIT', N'432432434', N'324324324324', N'dasds@gmail.com')
INSERT [dbo].[proveedor] ([id], [nombre], [tipo_documento], [numero_documento], [telefono], [email]) VALUES (5, N'Juan Perez', N'CC', N'123231', N'2132132', N'sdadasd@gmail.com')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id], [username], [nombre], [tipo_documento], [numero_documento], [telefono], [email], [id_perfil], [password]) VALUES (2, N'jgonzalez', N'Javier Gonzalez', N'CC', N'1030554882', N'31223223', N'sadasd@gmail.com', 1, N'12345')
INSERT [dbo].[usuario] ([id], [username], [nombre], [tipo_documento], [numero_documento], [telefono], [email], [id_perfil], [password]) VALUES (3, N'jperez', N'Juan Perez', N'CC', N'5423213213', N'23213213', N'dsadsd@gmail.com', 3, N'Juan12345')
INSERT [dbo].[usuario] ([id], [username], [nombre], [tipo_documento], [numero_documento], [telefono], [email], [id_perfil], [password]) VALUES (4, N'yarango', N'Yesid Arango', N'CC', N'324234324', N'4324324324', N'sadsad@gmail.com', 1, N'12345')
INSERT [dbo].[usuario] ([id], [username], [nombre], [tipo_documento], [numero_documento], [telefono], [email], [id_perfil], [password]) VALUES (5, N'mjota', N'Marcela Jota', N'CC', N'1023883072', N'3118424791', N'marcela.jotaf@gmail.com', 3, N'Marcela12345')
INSERT [dbo].[usuario] ([id], [username], [nombre], [tipo_documento], [numero_documento], [telefono], [email], [id_perfil], [password]) VALUES (6, N'cperez', N'Carlos Perez', N'CC', N'32432434', N'454355435', N'sadsad@gmail.com', 3, N'12345')
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[producto] ADD  DEFAULT ((0)) FOR [cantidad_disponible]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[factura] ([id])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_factura]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_producto]
GO
ALTER TABLE [dbo].[detalle_garantia]  WITH CHECK ADD  CONSTRAINT [FK_detalle_garantia_garantia] FOREIGN KEY([id_garantia])
REFERENCES [dbo].[garantia] ([id])
GO
ALTER TABLE [dbo].[detalle_garantia] CHECK CONSTRAINT [FK_detalle_garantia_garantia]
GO
ALTER TABLE [dbo].[detalle_garantia]  WITH CHECK ADD  CONSTRAINT [FK_detalle_garantia_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[detalle_garantia] CHECK CONSTRAINT [FK_detalle_garantia_producto]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingresos] FOREIGN KEY([id_ingreso])
REFERENCES [dbo].[ingresos] ([id])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingresos]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_producto]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_cliente] FOREIGN KEY([cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_factura_cliente]
GO
ALTER TABLE [dbo].[garantia]  WITH CHECK ADD  CONSTRAINT [FK_garantia_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[factura] ([id])
GO
ALTER TABLE [dbo].[garantia] CHECK CONSTRAINT [FK_garantia_factura]
GO
ALTER TABLE [dbo].[garantia]  WITH CHECK ADD  CONSTRAINT [FK_garantia_ingreso] FOREIGN KEY([id_ingreso])
REFERENCES [dbo].[ingresos] ([id])
GO
ALTER TABLE [dbo].[garantia] CHECK CONSTRAINT [FK_garantia_ingreso]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_proveedor] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id])
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_proveedor]
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD  CONSTRAINT [FK_menu_menu] FOREIGN KEY([id_menu_padre])
REFERENCES [dbo].[menu] ([id])
GO
ALTER TABLE [dbo].[menu] CHECK CONSTRAINT [FK_menu_menu]
GO
ALTER TABLE [dbo].[permisos_perfil]  WITH CHECK ADD  CONSTRAINT [FK_permisos_perfil_menu] FOREIGN KEY([id_menu])
REFERENCES [dbo].[menu] ([id])
GO
ALTER TABLE [dbo].[permisos_perfil] CHECK CONSTRAINT [FK_permisos_perfil_menu]
GO
ALTER TABLE [dbo].[permisos_perfil]  WITH CHECK ADD  CONSTRAINT [FK_permisos_perfil_perfil] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[perfil] ([id])
GO
ALTER TABLE [dbo].[permisos_perfil] CHECK CONSTRAINT [FK_permisos_perfil_perfil]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_perfil] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[perfil] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_perfil]
GO
