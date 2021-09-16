
--https://www.guru99.com/sql-server-create-user.html
--Idioma
INSERT INTO dbo.Idioma(ID_Idioma, Descripcion) VALUES
(1, 'English'),  
(2, 'Español')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Texto
----Inicio
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Inicio-Error-ConexionBaseDatos', 'Error while connection to data base'),
(1, 'Inicio-Error-IntegridadBaseDatos', 'Error on the Data Base integrity'),  
(1, 'Inicio-Info-CargaCorrecta', 'The application loaded successfully'), 
(1, 'Inicio-Error-CargaIncorrecta', 'An error happend while loading the application')
----Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Principal-Confirmar-CerrarSesion', 'Are you sure you want to close the session?'),
(1, 'Principal-Info-CerrarSesion', 'LogOut'),
(1, 'Principal-Permiso-Denegado', 'Higher access required to perform the operation')
----Idioma
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Idioma-Form', 'Change Languaje'),
(1, 'Idioma-Info-cambio', 'Languaje has been changed')
----Bitacora
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Bitacora-Form', 'Logs'),
(1, 'Bitacora-Columna-BitacoraID', 'ID'),
(1, 'Bitacora-Columna-BitacoraFecha', 'Date'),
(1, 'Bitacora-Columna-BitacoraUsuario', 'User'),
(1, 'Bitacora-Columna-BitacoraCriticidad', 'Level'),
(1, 'Bitacora-Columna-BitacoraMovimiento', 'Description'),
(1, 'Bitacora-pdf-Title', 'Logs')
----Cambiar Contrasenia
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'CambiarContrasenia-Form', 'Change Password'),
(1, 'CambiarContrasenia-Info-CambioCorrecto', 'Password changed successfully')
----Usuario principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'UsuarioPrincipal-Form', 'Users'),
(1, 'UsuarioPrincipal-Columna-UsuarioID','ID'),
(1, 'UsuarioPrincipal-Columna-Nombre','Name'),
(1, 'UsuarioPrincipal-Columna-Apellido','Surname'),
(1, 'UsuarioPrincipal-Columna-Usuario','Username'),
(1, 'UsuarioPrincipal-Columna-Logins','Login Attempts'),
(1, 'UsuarioPrincipal-Columna-Languaje','Language')

----Inicio
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Inicio-Error-ConexionBaseDatos', 'Error al conectar a la base de datos'),
(2, 'Inicio-Error-IntegridadBaseDatos', 'Error en la integridad de la base de datos'),
(2, 'Inicio-Info-CargaCorrecta', 'Carga de la aplicacion correcta'),
(2, 'Inicio-Error-CargaIncorrecta', 'Ocurrio un error en la carga de la aplicacion')
----Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Principal-Confirmar-CerrarSesion', 'Esta seguro de cerrar la sesion?'),
(2, 'Principal-Info-CerrarSesion', 'Cerrar Sesion'),
(2, 'Principal-Permiso-Denegado', 'Mayores permisos son necesarios para realizar la accion')
----Idioma
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Idioma-Form', 'Cambiar Lenguaje'),
(2, 'Idioma-Info-cambio', 'El lenguaje ha sido cambiado')
----Bitacora
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Bitacora-Form', 'Bitacora'),
(2, 'Bitacora-Columna-BitacoraID', 'ID'),
(2, 'Bitacora-Columna-BitacoraFecha', 'Fecha'),
(2, 'Bitacora-Columna-BitacoraUsuario', 'Usuario'),
(2, 'Bitacora-Columna-BitacoraCriticidad', 'Nivel'),
(2, 'Bitacora-Columna-BitacoraMovimiento', 'Descripcion'),
(2, 'Bitacora-pdf-Title', 'Bitacora')
----Cambiar Contrasenia
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'CambiarContrasenia-Form', 'Cambiar Contraseña'),
(2, 'CambiarContrasenia-Info-CambioCorrecto', 'Clave cambiada satisfactoriamente')
----Usuario principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'UsuarioPrincipal-Form', 'Usuarios'),
(2, 'UsuarioPrincipal-Columna-UsuarioID','ID'),
(2, 'UsuarioPrincipal-Columna-Nombre','Nombre'),
(2, 'UsuarioPrincipal-Columna-Apellido','Apellido'),
(2, 'UsuarioPrincipal-Columna-Usuario','Nombre Usuario'),
(2, 'UsuarioPrincipal-Columna-Logins','Intentos Login'),
(2, 'UsuarioPrincipal-Columna-Languaje','Idioma')
----ABM USUARIO
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMUsuarios-Form', 'Usuario'),
(2, 'ABMUsuariosLabel1', 'Nombre'),
(2, 'ABMUsuariosLabel2', 'Apellido'),
(2, 'ABMUsuariosLabel3', 'Usuario'),
(2, 'ABMUsuariosLabel4', 'Clave'),
(2, 'ABMUsuariosLabel5', 'Idioma'),
(2, 'ABMUsuariosLabel6', 'Familia'),
(2, 'ABMUsuariosLabel7', 'Patente'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuarios'),
(2, 'ABMUsuarioGroupboxPermisos', 'Permisos'),
(2, 'ABMUsuarioGroupboxFamilia', 'Familias'),
(2, 'ABMUsuarioGroupboxPatentes', 'Patentes'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuario'),



---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Control
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----Inicio
(1, 'LoginLabel1', 'User'),  
(1, 'LoginLabel2', 'Pass'), 
(1, 'LoginBotton1', 'Login'), 
(1, 'LoginBotton2', 'Exit')
----Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'sesionToolStripMenuItem', 'Session'),
(1,'cambiarContraseñaToolStripMenuItem','Change Password'),
(1,'cerrarSesionToolStripMenuItem', 'Logout'),
(1,'cambiarIdiomaToolStripMenuItem', 'Change Languaje'),
(1,'administracionToolStripMenuItem', 'Security'),
(1,'bitacoraToolStripMenuItem', 'Logs'),
(1,'gestionarUsuariosToolStripMenuItem', 'Users'),
(1,'gestionarPermisosToolStripMenuItem', 'Access'),
(1,'copiaDeSeguridadToolStripMenuItem', 'Backup'),
(1,'restauracionToolStripMenuItem', 'Restore'),
(1,'pasajesStripMenuItem', 'Tickets'),
(1,'rutasToolStripMenuItem', 'Routes')
----Idioma
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'IdiomaLabel1', 'Choose languaje'),
(1, 'IdiomaBotton1', 'Accept')
----Bitacora
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
-- (1, 'BitacoraDatePickerDesde', 'Since'),
-- (1, 'BitacoraDatePickerHasta', 'To'),
(1, 'BitacoraLabelDesde', 'Since'),
(1, 'BitacoraLabelHasta', 'Until'),
(1, 'BitacoraLabelUsuario', 'User'),
(1, 'BitacoraComboUsuario', 'User'),
(1, 'BitacoraLabelCriticidad', 'Level'),
(1, 'BitacoraComboCriticidad', 'Level'),
(1, 'BitacoraBotonConsultar', 'Search'),
(1, 'BitacoraBottonExportToPDF', 'Export'),
(1, 'BitacoraDataGrid1', 'Data')
----Cmabiar Contrasnia
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'CambiarContraseniaLabel1', 'Current Password: '),
(1, 'CambiarContraseniaLabel2', 'New Password: '),
(1, 'CambiarContraseniaLabel3', 'Repeat Password: '),
(1, 'CambiarContraseniaLabel4', 'Passwords are not the same'),
(1, 'CambiarContraseniaLabel5', 'Passwords does not meet requirements'),
(1, 'CambiarContraseniaLabel6', 'Password must have 8+ chars, 1 number, 1 upper case, 1 lower case at least'),
(1, 'CambiarContraseniaLabel7', 'Passwords does not meet requirements'),
(1, 'CambiarContraseniaButton1', 'Accept'),
(1, 'CambiarContraseniaButton2', 'Cancel')
----UsuarioPrincipal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'UsuarioPrincipalBotton1', 'Read'),
(1, 'UsuarioPrincipalBotton2', 'Create'),
(1, 'UsuarioPrincipalBotton3', 'Update'),
(1, 'UsuarioPrincipalBotton4', 'Delete'),
(1, 'UsuarioPrincipalBotton5', 'Apply'),
(1, 'UsuarioPrincipalBotton6', 'Clean'),
(1, 'UsuarioPrincipalBotton7', 'Reset Password'),
(1, 'UsuarioPrincipalLabel1', 'Name'),
(1, 'UsuarioPrincipalLabel2', 'Surname'),
(1, 'UsuarioPrincipalLabel3', 'Username'),
(1, 'UsuarioPrincipalLabel4', 'Failed login attempts'),
(1, 'UsuarioPrincipalLabel5', 'Lenguaje'),
(1, 'UsuarioPrincipalGroupBox', 'Filters')


INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----Inicio
(2, 'LoginLabel1', 'Usuario'), 
(2, 'LoginLabel2', 'Clave'), 
(2, 'LoginBotton1', 'Login'), 
(2, 'LoginBotton2', 'Salir')
----Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'sesionToolStripMenuItem', 'Sesion'),
(2,'cambiarContraseñaToolStripMenuItem','Cambiar contraseña'),
(2,'cerrarSesionToolStripMenuItem', 'Cerrar Sesion'),
(2,'cambiarIdiomaToolStripMenuItem', 'Cambiar Idioma'),
(2,'administracionToolStripMenuItem', 'Admnistracion'),
(2,'bitacoraToolStripMenuItem', 'Bitacora'),
(2,'gestionarUsuariosToolStripMenuItem', 'Usuarios'),
(2,'gestionarPermisosToolStripMenuItem', 'Permisos'),
(2,'copiaDeSeguridadToolStripMenuItem', 'Copia de Seguridad'),
(2,'restauracionToolStripMenuItem', 'Restauracion'),
(2,'pasajesStripMenuItem', 'Pasajes'),
(2,'rutasToolStripMenuItem', 'Rutas')
----Idioma
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'IdiomaLabel1', 'Elegir idioma'),
(2, 'IdiomaBotton1', 'Aceptar')
----Bitacora
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
-- (2, 'BitacoraDatePickerDesde', 'Desde'),
-- (2, 'BitacoraDatePickerHasta', 'Hasta'),
(2, 'BitacoraLabelDesde', 'Desde'),
(2, 'BitacoraLabelHasta', 'Hasta'),
(2, 'BitacoraLabelUsuario', 'Usuario'),
(2, 'BitacoraComboUsuario', 'Usuario'),
(2, 'BitacoraLabelCriticidad', 'Nivel'),
(2, 'BitacoraComboCriticidad', 'Nivel'),
(2, 'BitacoraBotonConsultar', 'Buscar'),
(2, 'BitacoraBottonExportToPDF', 'Exportar'),
(2, 'BitacoraDataGrid1', 'Datos')
----Cmabiar Contrasnia
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'CambiarContraseniaLabel1', 'Contraseña Actual: '),
(2, 'CambiarContraseniaLabel2', 'Nueva Contraseña: '),
(2, 'CambiarContraseniaLabel3', 'Confirmar Contraseña: '),
(2, 'CambiarContraseniaLabel4', 'Las claves no coinciden'),
(2, 'CambiarContraseniaLabel5', 'Clave no cumple los requisitos'),
(2, 'CambiarContraseniaLabel6', 'Clave debe tener 8+ caracteres, 1 numero, 1 mayuscula, 1 minuscula'),
(2, 'CambiarContraseniaLabel7', 'Clave no cumple los requisitos'),
(2, 'CambiarContraseniaButton1', 'Aceptar'),
(2, 'CambiarContraseniaButton2', 'Cancelar')
--- Usuario Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'UsuarioPrincipalBotton1', 'Ver'),
(2, 'UsuarioPrincipalBotton2', 'Crear'),
(2, 'UsuarioPrincipalBotton3', 'Modificar'),
(2, 'UsuarioPrincipalBotton4', 'Borrar'),
(2, 'UsuarioPrincipalBotton5', 'Aplicar'),
(2, 'UsuarioPrincipalBotton6', 'Limpiar'),
(2, 'UsuarioPrincipalBotton7', 'Resetear Clave'),
(2, 'UsuarioPrincipalLabel1', 'Nombre'),
(2, 'UsuarioPrincipalLabel2', 'Apellido'),
(2, 'UsuarioPrincipalLabel3', 'Usuario'),
(2, 'UsuarioPrincipalLabel4', 'Logings Fallidos'),
(2, 'UsuarioPrincipalLabel5', 'Idioma'),
(2, 'UsuarioPrincipalGroupBox', 'Filtros')

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Usuario
INSERT INTO dbo.Usuario(ID_Usuario, Nombre, Apellido, Nombre_Usuario, Contrasenia, DVH, Intentos_Login, ID_Idioma) VALUES
(1, 'Martin', 'Dome', 'bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==', 'CB1338CD67E63B81FC59F8107E76811C','196993', 0, 2) 

--Permisos
INSERT INTO Permiso(ID_Permiso, Nombre, Descripcion, Tipo_Permiso) VALUES 
(1, 'Administrador de Usuarios', 'Permite administrar usuarios', 'AdminUsuarios'),
(2, 'Administrador de Permisos', 'Permite administrar permisos de usuario', 'AdminPermisos'),
(3, 'Consultar Bitacora', 'Permite consultar la bitacora', 'ReadBitacora'),
(4, 'Administrador de Copias de seguridad', 'Permite administrar Copias de seguridad', 'AdminBackup'),
(5, 'Administrador de Restore', 'Permite administrar la restauracion del sistema', 'AdminRestore'),
(6, 'Vender Pasajes', 'Permite manejar la venta de pasajes', 'VendedorPasajes'),
(7, 'Administrador Rutas', 'Permite administrar la creacion de nuevas rutas', 'AdminRutas'),
(8, 'Administrador Localidad', 'Permite administrar las localidades', 'AdminLocalidades'),
(9, 'Administrador Cliente', 'Permite administrar el manejo de clientes', 'AdminClientes'),
(10, 'Consultar Usuarios', 'Permite consultar usuarios', 'ReadUsuarios'),
(11, 'Consultar Permisos', 'Permite consultar permisos', 'ReadPermisos'),
(12, 'Consultar Pasajes', 'Permite consultar los pasajes vendidos', 'ReadVentas'),
(13, 'Consultar Rutas', 'Permite consultar las rutas', 'ReadRutas'),
(14, 'Consultar Localidades', 'Permite consultar las localidades', 'ReadLocalidades'),
(15, 'Consultar Clientes', 'Permite consultar las localidades', 'ReadClientes')

--Familias
INSERT INTO Familia(ID_Familia, Nombre, Descripcion) VALUES
(1, 'Administrador Sistema', 'Permite administrar la seguridad del sistema'),
(2, 'Administrador Usuarios', 'Permite manejar los usuarios del sistema'),
(3, 'Auditor Sistema', 'Permite acceder a los logs del sistema')

--Usuario_Familia
INSERT INTO Usuario_Familia(ID_Usuario, ID_Familia, DVH) VALUES
(1,1,49)

--Permiso_Familia
INSERT INTO Permiso_Familia(ID_Permiso, ID_Familia, DVH) VALUES
(1,1,49),
(2,1,49),
(3,1,49)


Insert INTO dbo.Digito_Verificador(ID_Digito_Verificador, Tabla, DVV) Values 
(1, 'Usuario', '196993'),
(2, 'Permiso_Familia', '147'),
(3, 'Usuario_Familia', '49')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------