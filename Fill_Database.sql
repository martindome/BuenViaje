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
(1, 'Principal-Info-CerrarSesion', 'LogOut')
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
(1, 'CambiarContrasenia-Form', 'Change Password')

----Inicio
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Inicio-Error-ConexionBaseDatos', 'Error al conectar a la base de datos'),
(2, 'Inicio-Error-IntegridadBaseDatos', 'Error en la integridad de la base de datos'),
(2, 'Inicio-Info-CargaCorrecta', 'Carga de la aplicacion correcta'),
(2, 'Inicio-Error-CargaIncorrecta', 'Ocurrio un error en la carga de la aplicacion')
----Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Principal-Confirmar-CerrarSesion', 'Esta seguro de cerrar la sesion?'),
(2, 'Principal-Info-CerrarSesion', 'Cerrar Sesion')
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
(2, 'CambiarContrasenia-Form', 'Cambiar Contraseña')


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
(1,'gestionarUsuariosToolStripMenuItem', 'Manage Users'),
(1,'gestionarPermisosToolStripMenuItem', 'Manage Access'),
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
(2,'gestionarUsuariosToolStripMenuItem', 'Manejar Usuarios'),
(2,'gestionarPermisosToolStripMenuItem', 'Manejar Permisos'),
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

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Usuario
INSERT INTO dbo.Usuario(ID_Usuario, Nombre, Apellido, Nombre_Usuario, Contrasenia, DVH, Intentos_Login, ID_Idioma) VALUES
(1, 'Martin', 'Dome', 'bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==', 'CB1338CD67E63B81FC59F8107E76811C','196993', 0, 2) 

Insert INTO dbo.Digito_Verificador(ID_Digito_Verificador, Tabla, DVV) Values (1, 'Usuario', '196993')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------