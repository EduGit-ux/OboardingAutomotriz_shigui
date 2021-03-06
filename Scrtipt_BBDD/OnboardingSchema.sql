USE [BBDDOnboarding]
GO
/****** Object:  Table [dbo].[asignacion_cliente]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion_cliente](
	[as_id] [int] IDENTITY(1,1) NOT NULL,
	[as_id_cliente] [int] NOT NULL,
	[as_id_patio] [int] NOT NULL,
	[as_fecha_asignacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Asignacion_cliente] PRIMARY KEY CLUSTERED 
(
	[as_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cl_id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cl_identificacion] [varchar](10) NOT NULL,
	[cl_nombres] [varchar](50) NOT NULL,
	[cl_apellidos] [varchar](50) NOT NULL,
	[cl_edad] [varchar](10) NOT NULL,
	[cl_fecha_nacimiento] [date] NOT NULL,
	[cl_direccion] [varchar](50) NOT NULL,
	[cl_telefono] [varchar](10) NOT NULL,
	[cl_estado_civil] [varchar](10) NOT NULL,
	[cl_identificacion_conyuge] [varchar](10) NULL,
	[cl_nombre_conyuge] [varchar](50) NULL,
	[cl_sujeto_credito] [bit] NOT NULL,
 CONSTRAINT [PK_cl_cliente] PRIMARY KEY CLUSTERED 
(
	[cl_id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ejecutivo]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ejecutivo](
	[ej_id] [int] IDENTITY(1,1) NOT NULL,
	[ej_id_patio] [int] NOT NULL,
	[ej_identificacion] [varchar](10) NOT NULL,
	[ej_nombre] [varchar](50) NOT NULL,
	[ej_apellido] [varchar](50) NOT NULL,
	[ej_direccion] [varchar](50) NOT NULL,
	[ej_telefono] [varchar](10) NOT NULL,
	[ej_celular] [varchar](10) NOT NULL,
	[ej_edad] [varchar](10) NOT NULL,
 CONSTRAINT [PK_dt_ejecutivo] PRIMARY KEY CLUSTERED 
(
	[ej_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[ma_id_marca] [int] IDENTITY(1,1) NOT NULL,
	[ma_marca_auto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_au_marca] PRIMARY KEY CLUSTERED 
(
	[ma_id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patio]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patio](
	[pa_id] [int] IDENTITY(1,1) NOT NULL,
	[pa_nombre] [varchar](50) NOT NULL,
	[pa_direccion] [varchar](50) NOT NULL,
	[pa_telefono] [varchar](10) NOT NULL,
 CONSTRAINT [PK_patio] PRIMARY KEY CLUSTERED 
(
	[pa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solicitud_credito]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solicitud_credito](
	[sc_id] [int] IDENTITY(1,1) NOT NULL,
	[sc_id_cliente] [int] NOT NULL,
	[sc_id_patio] [int] NOT NULL,
	[sc_id_vehiculo] [int] NOT NULL,
	[sc_meses_plazo] [int] NOT NULL,
	[sc_cuotas] [int] NOT NULL,
	[sc_entrada] [money] NOT NULL,
	[sc_id_ejecutivo] [int] NOT NULL,
	[sc_observacion] [varchar](100) NULL,
	[sc_estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_solicitud_credito] PRIMARY KEY CLUSTERED 
(
	[sc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 27/6/2022 10:23:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[ve_id] [int] IDENTITY(1,1) NOT NULL,
	[ve_placa] [varchar](10) NOT NULL,
	[ve_modelo] [varchar](50) NOT NULL,
	[ve_marca_id] [int] NOT NULL,
	[ve_tipo] [varchar](50) NOT NULL,
	[ve_cilindraje] [varchar](50) NOT NULL,
	[ve_avaluo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_vehiculo] PRIMARY KEY CLUSTERED 
(
	[ve_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[asignacion_cliente] ON 

INSERT [dbo].[asignacion_cliente] ([as_id], [as_id_cliente], [as_id_patio], [as_fecha_asignacion]) VALUES (1, 10, 1, N'2022-12-22')
INSERT [dbo].[asignacion_cliente] ([as_id], [as_id_cliente], [as_id_patio], [as_fecha_asignacion]) VALUES (2, 15, 3, N'2022-06-22')
INSERT [dbo].[asignacion_cliente] ([as_id], [as_id_cliente], [as_id_patio], [as_fecha_asignacion]) VALUES (1002, 7, 3, N'23-06-2022')
INSERT [dbo].[asignacion_cliente] ([as_id], [as_id_cliente], [as_id_patio], [as_fecha_asignacion]) VALUES (1003, 5, 3, N'23-06-2022')
INSERT [dbo].[asignacion_cliente] ([as_id], [as_id_cliente], [as_id_patio], [as_fecha_asignacion]) VALUES (1004, 8, 2, N'23-06-2022')
SET IDENTITY_INSERT [dbo].[asignacion_cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (1, N'0503698545', N'Eduardo', N'Pruz', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584523', N'Sotero', N'', N'', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (2, N'0503698562', N'Lucas', N'Romero', N'85', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584540', N'Casado', N'705698575', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (3, N'0503698561', N'Jennifer', N'Alvarez', N'29', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584539', N'Casado', N'705698574', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (4, N'0503698560', N'Edison', N'Mu?oz', N'26', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584538', N'Casado', N'705698573', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (5, N'0503698559', N'Edwin', N'Diaz', N'25', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584537', N'Casado', N'705698572', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (6, N'0503698558', N'Xavier', N'Ruiz', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584536', N'Casado', N'705698571', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (7, N'0503698557', N'Ana', N'Moreno', N'23', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584535', N'Sotero', N'', N'', 0)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (8, N'0503698556', N'Petrona', N'Hernandez', N'24', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584534', N'Sotero', N'', N'', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (9, N'0503698555', N'Alexandra', N'Martin', N'55', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584533', N'Sotero', N'', N'', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (10, N'0503698554', N'Karla', N'Gomez', N'65', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584532', N'Casado', N'705698570', N'Nombre Conyuge', 0)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (11, N'0503698553', N'Andrea', N'Perez', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584531', N'Casado', N'705698569', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (12, N'0503698552', N'Felipe', N'Sanchez', N'20', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584530', N'Casado', N'705698568', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (13, N'0503698551', N'Andres', N'Martinez', N'45', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584529', N'Casado', N'705698567', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (14, N'0503698550', N'Veronica', N'Lopez', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584528', N'Casado', N'705698566', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (15, N'0503698549', N'Mario', N'Fernandez', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584527', N'Casado', N'705698565', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (16, N'0503698548', N'Luis', N'Gonzalez', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584526', N'Casado', N'705698564', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (17, N'0503698547', N'Carlos', N'Rodriguez', N'10', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584525', N'Casado', N'705698563', N'Nombre Conyuge', 0)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (18, N'0503698546', N'Jose', N'Garcia', N'32', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584524', N'Casado', N'705698562', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (19, N'0503698563', N'Juan', N'Alonso', N'20', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584541', N'Casado', N'705698576', N'Nombre Conyuge', 1)
INSERT [dbo].[cliente] ([cl_id_cliente], [cl_identificacion], [cl_nombres], [cl_apellidos], [cl_edad], [cl_fecha_nacimiento], [cl_direccion], [cl_telefono], [cl_estado_civil], [cl_identificacion_conyuge], [cl_nombre_conyuge], [cl_sujeto_credito]) VALUES (20, N'0503698564', N'Gabriel', N'Moreno', N'30', CAST(N'1991-07-07' AS Date), N'La Napo', N'986584542', N'Sotero', N'', N'', 1)
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[ejecutivo] ON 

INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (3, 1, N'0503658965', N'Juan?', N'Zambrano', N'La Carolina', N'226351', N'987456235', N'30')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (4, 1, N'0503658982', N'Martha', N'Bravo', N'Marian Jesus', N'226368', N'987456252', N'24')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (5, 2, N'0503658981', N'V?ctor', N'Salazar', N'La bota', N'226367', N'987456251', N'45')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (6, 1, N'0503658980', N'Carmen', N'Gomez', N'Pasteurizadora', N'226366', N'987456250', N'12')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (7, 1, N'0503658979', N'Ana', N'Romero', N'6 Dicimente', N'226365', N'987456249', N'30')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (8, 1, N'0503658978', N'Segundo', N'Delgado', N'Shyris', N'226364', N'987456248', N'21')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (9, 1, N'0503658977', N'Laura?', N'Macias', N'Mariscal Sucre', N'226363', N'987456247', N'65')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (10, 2, N'0503658976', N'Julio?', N'Flores', N'La Marinb', N'226362', N'987456246', N'21')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (11, 1, N'0503658975', N'Antonio', N'Mendoza', N'Trebol', N'226361', N'987456245', N'54')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (12, 2, N'0503658974', N'Marco?', N'Castro', N'Luluncoto', N'226360', N'987456244', N'25')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (13, 1, N'0503658973', N'Carlos?', N'Gonz?lez', N'Recre', N'226359', N'987456243', N'21')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (14, 2, N'0503658972', N'Alberto', N'Torres', N'La colmena', N'226358', N'987456242', N'50')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (15, 1, N'0503658971', N'Hugo', N'Cede?o', N'Carapungo', N'226357', N'987456241', N'32')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (16, 2, N'0503658970', N'V?ctor?', N'L?pez', N'Norte Quito', N'226356', N'987456240', N'31')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (17, 1, N'0503658969', N'Angel', N'Vera', N'Chubuleo', N'226355', N'987456239', N'54')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (18, 2, N'0503658968', N'Miguel?', N'Garc?a', N'Villaflorea', N'226354', N'987456238', N'52')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (19, 1, N'0503658967', N'Luis?', N'Rodr?guez', N'Sur Quito', N'226353', N'987456237', N'56')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (20, 2, N'0503658966', N'Jos?', N'S?nchez', N'La Napo', N'226352', N'987456236', N'30')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (21, 2, N'0503658983', N'Blanca', N'Reyes', N'La colmena', N'226369', N'987456253', N'65')
INSERT [dbo].[ejecutivo] ([ej_id], [ej_id_patio], [ej_identificacion], [ej_nombre], [ej_apellido], [ej_direccion], [ej_telefono], [ej_celular], [ej_edad]) VALUES (22, 2, N'0503658984', N'Pedro', N'Ruiz', N'Floresta', N'226370', N'987456254', N'45')
SET IDENTITY_INSERT [dbo].[ejecutivo] OFF
GO
SET IDENTITY_INSERT [dbo].[marca] ON 

INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (1, N'Chevrolet')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (2, N'KIA')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (3, N'Hyundai')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (4, N'Toyota')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (5, N'Great Wall')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (6, N'JAC')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (7, N'Chery')
INSERT [dbo].[marca] ([ma_id_marca], [ma_marca_auto]) VALUES (8, N'Renault')
SET IDENTITY_INSERT [dbo].[marca] OFF
GO
SET IDENTITY_INSERT [dbo].[patio] ON 

INSERT [dbo].[patio] ([pa_id], [pa_nombre], [pa_direccion], [pa_telefono]) VALUES (1, N'GranadosTork', N'La granados', N'0986536524')
INSERT [dbo].[patio] ([pa_id], [pa_nombre], [pa_direccion], [pa_telefono]) VALUES (2, N'El Valle', N'El valle y triangulo', N'0987569852')
INSERT [dbo].[patio] ([pa_id], [pa_nombre], [pa_direccion], [pa_telefono]) VALUES (3, N'Centro Quito', N'La Marin central', N'0986598562')
SET IDENTITY_INSERT [dbo].[patio] OFF
GO
SET IDENTITY_INSERT [dbo].[solicitud_credito] ON 

INSERT [dbo].[solicitud_credito] ([sc_id], [sc_id_cliente], [sc_id_patio], [sc_id_vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_id_ejecutivo], [sc_observacion], [sc_estado]) VALUES (1, 7, 2, 2, 36, 20, 5000.0000, 16, N'Validar observaciones', N'R')
INSERT [dbo].[solicitud_credito] ([sc_id], [sc_id_cliente], [sc_id_patio], [sc_id_vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_id_ejecutivo], [sc_observacion], [sc_estado]) VALUES (4, 7, 2, 2, 36, 20, 5000.0000, 16, N'Validar observaciones', N'A')
INSERT [dbo].[solicitud_credito] ([sc_id], [sc_id_cliente], [sc_id_patio], [sc_id_vehiculo], [sc_meses_plazo], [sc_cuotas], [sc_entrada], [sc_id_ejecutivo], [sc_observacion], [sc_estado]) VALUES (5, 8, 2, 3, 36, 20, 8000.0000, 16, N'Validar observaciones', N'A')
SET IDENTITY_INSERT [dbo].[solicitud_credito] OFF
GO
SET IDENTITY_INSERT [dbo].[vehiculo] ON 

INSERT [dbo].[vehiculo] ([ve_id], [ve_placa], [ve_modelo], [ve_marca_id], [ve_tipo], [ve_cilindraje], [ve_avaluo]) VALUES (1, N'PCY-2365', N'Sedan', 2, N'Automovil', N'5000', N'30000')
INSERT [dbo].[vehiculo] ([ve_id], [ve_placa], [ve_modelo], [ve_marca_id], [ve_tipo], [ve_cilindraje], [ve_avaluo]) VALUES (2, N'PCY-12365', N'Sedan', 1, N'Camioneta', N'5000', N'30000')
INSERT [dbo].[vehiculo] ([ve_id], [ve_placa], [ve_modelo], [ve_marca_id], [ve_tipo], [ve_cilindraje], [ve_avaluo]) VALUES (3, N'PCY-1259', N'Sedan', 2, N'Sub', N'5000', N'30000')
SET IDENTITY_INSERT [dbo].[vehiculo] OFF
GO
ALTER TABLE [dbo].[asignacion_cliente]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_cliente_cliente] FOREIGN KEY([as_id_cliente])
REFERENCES [dbo].[cliente] ([cl_id_cliente])
GO
ALTER TABLE [dbo].[asignacion_cliente] CHECK CONSTRAINT [FK_asignacion_cliente_cliente]
GO
ALTER TABLE [dbo].[asignacion_cliente]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_cliente_patio] FOREIGN KEY([as_id_patio])
REFERENCES [dbo].[patio] ([pa_id])
GO
ALTER TABLE [dbo].[asignacion_cliente] CHECK CONSTRAINT [FK_asignacion_cliente_patio]
GO
ALTER TABLE [dbo].[ejecutivo]  WITH CHECK ADD  CONSTRAINT [FK_ejecutivo_patio] FOREIGN KEY([ej_id_patio])
REFERENCES [dbo].[patio] ([pa_id])
GO
ALTER TABLE [dbo].[ejecutivo] CHECK CONSTRAINT [FK_ejecutivo_patio]
GO
ALTER TABLE [dbo].[solicitud_credito]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_credito_cliente] FOREIGN KEY([sc_id_cliente])
REFERENCES [dbo].[cliente] ([cl_id_cliente])
GO
ALTER TABLE [dbo].[solicitud_credito] CHECK CONSTRAINT [FK_solicitud_credito_cliente]
GO
ALTER TABLE [dbo].[solicitud_credito]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_credito_ejecutivo] FOREIGN KEY([sc_id_ejecutivo])
REFERENCES [dbo].[ejecutivo] ([ej_id])
GO
ALTER TABLE [dbo].[solicitud_credito] CHECK CONSTRAINT [FK_solicitud_credito_ejecutivo]
GO
ALTER TABLE [dbo].[solicitud_credito]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_credito_patio] FOREIGN KEY([sc_id_patio])
REFERENCES [dbo].[patio] ([pa_id])
GO
ALTER TABLE [dbo].[solicitud_credito] CHECK CONSTRAINT [FK_solicitud_credito_patio]
GO
ALTER TABLE [dbo].[solicitud_credito]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_credito_vehiculo] FOREIGN KEY([sc_id_vehiculo])
REFERENCES [dbo].[vehiculo] ([ve_id])
GO
ALTER TABLE [dbo].[solicitud_credito] CHECK CONSTRAINT [FK_solicitud_credito_vehiculo]
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_vehiculo_marca] FOREIGN KEY([ve_marca_id])
REFERENCES [dbo].[marca] ([ma_id_marca])
GO
ALTER TABLE [dbo].[vehiculo] CHECK CONSTRAINT [FK_vehiculo_marca]
GO
