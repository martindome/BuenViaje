USE [BuenViaje]
GO
ALTER TABLE [dbo].[Viaje] DROP CONSTRAINT [FK__Viaje__ID_Ruta__662B2B3B]
GO
ALTER TABLE [dbo].[Viaje] DROP CONSTRAINT [FK__Viaje__ID_Bus__671F4F74]
GO
ALTER TABLE [dbo].[Usuario_Permiso] DROP CONSTRAINT [FK__Usuario_P__ID_Us__540C7B00]
GO
ALTER TABLE [dbo].[Usuario_Permiso] DROP CONSTRAINT [FK__Usuario_P__ID_Pe__55009F39]
GO
ALTER TABLE [dbo].[Usuario_Familia] DROP CONSTRAINT [FK__Usuario_F__ID_Us__57DD0BE4]
GO
ALTER TABLE [dbo].[Usuario_Familia] DROP CONSTRAINT [FK__Usuario_F__ID_Fa__58D1301D]
GO
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK__Usuario__ID_Idio__4D5F7D71]
GO
ALTER TABLE [dbo].[Texto] DROP CONSTRAINT [FK__Texto__ID_Idioma__42E1EEFE]
GO
ALTER TABLE [dbo].[Telefono] DROP CONSTRAINT [FK__Telefono__ID_Cli__4A8310C6]
GO
ALTER TABLE [dbo].[Ruta] DROP CONSTRAINT [FK__Ruta__Origen__634EBE90]
GO
ALTER TABLE [dbo].[Ruta] DROP CONSTRAINT [FK__Ruta__Destino__625A9A57]
GO
ALTER TABLE [dbo].[Pasaje] DROP CONSTRAINT [FK__Pasaje__ID_Viaje__69FBBC1F]
GO
ALTER TABLE [dbo].[Pasaje] DROP CONSTRAINT [FK__Pasaje__ID_Usuar__6BE40491]
GO
ALTER TABLE [dbo].[Pasaje] DROP CONSTRAINT [FK__Pasaje__ID_Clien__6AEFE058]
GO
ALTER TABLE [dbo].[Controles] DROP CONSTRAINT [FK__Controles__ID_Id__45BE5BA9]
GO
ALTER TABLE [dbo].[Bitacora] DROP CONSTRAINT [FK__Bitacora__ID_Usu__5BAD9CC8]
GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Viaje]') AND type in (N'U'))
DROP TABLE [dbo].[Viaje]
GO
/****** Object:  Table [dbo].[Usuario_Permiso]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_Permiso]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario_Permiso]
GO
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_Familia]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario_Familia]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Texto]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Texto]') AND type in (N'U'))
DROP TABLE [dbo].[Texto]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Telefono]') AND type in (N'U'))
DROP TABLE [dbo].[Telefono]
GO
/****** Object:  Table [dbo].[Ruta]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ruta]') AND type in (N'U'))
DROP TABLE [dbo].[Ruta]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permiso]') AND type in (N'U'))
DROP TABLE [dbo].[Permiso]
GO
/****** Object:  Table [dbo].[Pasaje]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pasaje]') AND type in (N'U'))
DROP TABLE [dbo].[Pasaje]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Localidad]') AND type in (N'U'))
DROP TABLE [dbo].[Localidad]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Idioma]') AND type in (N'U'))
DROP TABLE [dbo].[Idioma]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Familia]') AND type in (N'U'))
DROP TABLE [dbo].[Familia]
GO
/****** Object:  Table [dbo].[Digito_Verificador]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Digito_Verificador]') AND type in (N'U'))
DROP TABLE [dbo].[Digito_Verificador]
GO
/****** Object:  Table [dbo].[Controles]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Controles]') AND type in (N'U'))
DROP TABLE [dbo].[Controles]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
/****** Object:  Table [dbo].[Bus]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bus]') AND type in (N'U'))
DROP TABLE [dbo].[Bus]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bitacora]') AND type in (N'U'))
DROP TABLE [dbo].[Bitacora]
GO
/****** Object:  Table [dbo].[Backups]    Script Date: 05/09/2021 16:33:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Backups]') AND type in (N'U'))
DROP TABLE [dbo].[Backups]
GO
