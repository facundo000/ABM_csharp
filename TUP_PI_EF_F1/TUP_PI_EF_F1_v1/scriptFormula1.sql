USE [Formula1]
GO
/****** Object:  Table [dbo].[Circuitos]    Script Date: 4/7/2023 02:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Circuitos](
	[idCircuito] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[longitud] [float] NOT NULL,
	[sentido] [int] NOT NULL,
	[pais] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competidores]    Script Date: 4/7/2023 02:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competidores](
	[numero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[pais] [int] NOT NULL,
	[escuderia] [int] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Competidores] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuderias]    Script Date: 4/7/2023 02:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuderias](
	[idEscuderia] [int] IDENTITY(1,1) NOT NULL,
	[nombreEscuderia] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 4/7/2023 02:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombrePais] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Circuitos] ON 

INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (1, N'Monza', 5500, 1, 1)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (2, N'Mónaco', 3750, 2, 6)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (3, N'Suzuka', 6150, 1, 2)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (4, N'Montmeló', 4800, 2, 3)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (5, N'Villeneuve', 5700, 2, 8)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (6, N'Nurburgring', 6350, 1, 4)
INSERT [dbo].[Circuitos] ([idCircuito], [nombre], [longitud], [sentido], [pais]) VALUES (8, N'Interlagos', 4500, 1, 10)
SET IDENTITY_INSERT [dbo].[Circuitos] OFF
GO
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (1, N'Verstappen', 9, 3, CAST(N'1995-03-12' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (4, N'Norris', 5, 4, CAST(N'2002-08-08' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (11, N'Perez', 7, 3, CAST(N'1998-11-23' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (14, N'Alonso', 3, 5, CAST(N'1988-09-21' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (16, N'Leclerc', 6, 1, CAST(N'2001-07-15' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (44, N'Hamilton', 5, 2, CAST(N'1990-06-10' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (55, N'Sainz', 3, 1, CAST(N'2000-05-07' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [pais], [escuderia], [fechaNacimiento]) VALUES (77, N'Bottas', 11, 8, CAST(N'1993-12-12' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Escuderias] ON 

INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (1, N'Ferrari')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (2, N'Mercedes')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (3, N'Red Bull')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (4, N'McLaren')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (5, N'Aston Martin')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (6, N'Alpine')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (7, N'Haas')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (8, N'Alpha Romeo')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (9, N'Williams')
INSERT [dbo].[Escuderias] ([idEscuderia], [nombreEscuderia]) VALUES (10, N'Alpha Tauri')
SET IDENTITY_INSERT [dbo].[Escuderias] OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (1, N'Italia')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (2, N'Japón')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (3, N'España')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (4, N'Alemania')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (5, N'Inglaterra')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (6, N'Mónaco')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (7, N'México')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (8, N'Canada')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (9, N'Holanda')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (10, N'Brasil')
INSERT [dbo].[Paises] ([idPais], [nombrePais]) VALUES (11, N'Finlandia')
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
