
--https://www.guru99.com/sql-server-create-user.html
ALTER ROLE [db_owner] ADD MEMBER [buenviajedtblogin]
ALTER ROLE [db_datareader] ADD MEMBER [buenviajedtblogin]
ALTER ROLE [db_datawriter] ADD MEMBER [buenviajedtblogin]

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
----Login
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Login-Error-InicioSesion', 'Error while login in'),
(1, 'Login-Error-cambiarClave', 'Error while changing password') 
----Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Principal-Confirmar-CerrarSesion', 'Are you sure you want to close the session?'),
(1, 'Principal-Info-CerrarSesion', 'LogOut'),
(1, 'Principal-Permiso-Denegado', 'Higher access required to perform the operation')
----Idioma
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Idioma-Form', 'Change Languaje'),
(1, 'Idioma-Info-cambio', 'Languaje has been changed'),
(1, 'Idioma-Error-CambioIdioma', 'Error while changing lenguage')
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
(1, 'CambiarContrasenia-Info-CambioCorrecto', 'Password changed successfully'),
(1, 'CambiarContrasenia-Error-CambioClave', 'Error while changing password')
----Usuario principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'UsuarioPrincipal-Form', 'Users'),
(1, 'UsuarioPrincipal-Permiso-Usuario-Denegado', 'Not enough privilages ta manage users'),
(1, 'UsuarioPrincipal-Columna-UsuarioID','ID'),
(1, 'UsuarioPrincipal-Columna-Nombre','Name'),
(1, 'UsuarioPrincipal-Columna-Apellido','Surname'),
(1, 'UsuarioPrincipal-Columna-Usuario','Username'),
(1, 'UsuarioPrincipal-Columna-Logins','Login Attempts'),
(1, 'UsuarioPrincipal-Columna-Languaje','Language')
----ABM USUARIO
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMUsuarios-Form', 'Usuario'),
(1, 'ABMUSuarios-Columna-FamiliaID', 'ID'),
(1, 'ABMUSuarios-Columna-FamiliaNombre', 'Name'),
(1, 'ABMUSuarios-Columna-PatenteID', 'ID'),
(1, 'ABMUSuarios-Columna-PatenteNombre', 'Name'),
(1, 'ABMUsuarios-Validacion-Clave', 'Password must have 8+ chars, 1 number, 1 upper case, 1 lower case at least'),
(1, 'ABMUsuarios-Validacion-UsuarioUnico', 'Username already taken'),
(1, 'ABMUsuarios-Validacion-UsuarioMail', 'Username does not match an email address'),
(1, 'ABMUsuarios-Validacion-Nombre', 'Name and surname must be 50 characters or less'),
(1, 'ABMUsuarios-Confirmacion-Baja', 'Are you sure to delete the user?'),
(1, 'ABMUsuarios-Validacion-Resetear', 'Are you sure top reset the password?'),
(1, 'ABMUsuario-Error-Aplicar', 'Error while operating users')


----Permisos principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'PermisosPrincipal-Form', 'Accesses'),
(1, 'PermisosPrincipal-Permiso-Usuario-Denegado', 'Not enough privilages ta manage accesses'),
(1, 'PermisosPrincipal-Columna-FamiliaID','ID'),
(1, 'PermisosPrincipal-Columna-FamiliaNombre','Name'),
(1, 'PermisosPrincipal-Columna-FamiliaDescripcion','Description')

----ABM Permisos
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMPermisos-Form', 'Accesses'),
(1, 'ABMPermisos-Validacion-Nombre', 'Name and description should be 50 chars or less'),
(1, 'ABMPermisos-Confirmacion-Baja', 'Are you sure to delete the group?'),
(1, 'ABMPermiso-Error-Aplicar', 'Error while operating groups')


----Backup
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Backup-Form', 'Backup'),
(1, 'Backup-Confirmacion-Ejecucion', 'Create database backup?'),
(1, 'Backup-Validacion-Ruta', 'Path is not valid'),
(1, 'Backup-Confirmacion-Backup', 'The backup was created successfully'),
(1, 'Backup-Error-Aplicar', 'Error while creating backup')

----Restore
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Restore-Form', 'Restore'),
(1, 'Restore-Columna-Volumen', 'Files'),
(1, 'Restore-Confirmacion-Ejecucion', 'Execute restore?'),
(1, 'Restore-Confirmacion-Backup', 'The restauration was executed successfully'),
(1, 'Restore-Validacion-Rutas', 'File was not found'),
(1, 'Restore-Error-Aplicar', 'Error while restaurating backup')


----Inicio
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Inicio-Error-ConexionBaseDatos', 'Error al conectar a la base de datos'),
(2, 'Inicio-Error-IntegridadBaseDatos', 'Error en la integridad de la base de datos'),
(2, 'Inicio-Info-CargaCorrecta', 'Carga de la aplicacion correcta'),
(2, 'Inicio-Error-CargaIncorrecta', 'Ocurrio un error en la carga de la aplicacion')
----Login
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Login-Error-InicioSesion', 'Error al iniciar sesion'),
(2, 'Login-Error-cambiarClave', 'Error al cambiar la clave') 
----Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Principal-Confirmar-CerrarSesion', 'Esta seguro de cerrar la sesion?'),
(2, 'Principal-Info-CerrarSesion', 'Cerrar Sesion'),
(2, 'Principal-Permiso-Denegado', 'Mayores permisos son necesarios para realizar la accion')
----Idioma
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Idioma-Form', 'Cambiar Lenguaje'),
(2, 'Idioma-Info-cambio', 'El lenguaje ha sido cambiado'),
(2, 'Idioma-Error-CambioIdioma', 'Error al cambiar el lenguaje')
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
(2, 'CambiarContrasenia-Info-CambioCorrecto', 'Clave cambiada satisfactoriamente'),
(2, 'CambiarContrasenia-Error-CambioClave', 'Error al cambiar clave')
----Usuario principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'UsuarioPrincipal-Form', 'Usuarios'),
(2, 'UsuarioPrincipal-Permiso-Usuario-Denegado', 'Permisos insuficientes para manejo de usuarios'),
(2, 'UsuarioPrincipal-Columna-UsuarioID','ID'),
(2, 'UsuarioPrincipal-Columna-Nombre','Nombre'),
(2, 'UsuarioPrincipal-Columna-Apellido','Apellido'),
(2, 'UsuarioPrincipal-Columna-Usuario','Nombre Usuario'),
(2, 'UsuarioPrincipal-Columna-Logins','Intentos Login'),
(2, 'UsuarioPrincipal-Columna-Languaje','Idioma')
----ABM USUARIO
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMUsuarios-Form', 'Usuario'),
(2, 'ABMUSuarios-Columna-FamiliaID', 'ID'),
(2, 'ABMUSuarios-Columna-FamiliaNombre', 'Nombre'),
(2, 'ABMUSuarios-Columna-PatenteID', 'ID'),
(2, 'ABMUSuarios-Columna-PatenteNombre', 'Nombre'),
(2, 'ABMUsuarios-Validacion-Clave', 'La clave debe tener 8+ characteres, 1 numbero, 1 mayuscula, 1 minuscula por lo menos'),
(2, 'ABMUsuarios-Validacion-UsuarioUnico', 'Nombre de usuario ya esta en uso'),
(2, 'ABMUsuarios-Validacion-UsuarioMail', 'El nombre de usuario no es una casilla de mail'),
(2, 'ABMUsuarios-Validacion-Nombre', 'Nombre y apellido deben tener menos de 50 caracteres'),
(2, 'ABMUsuarios-Confirmacion-Baja', 'Esta seguro de borrar el usuario?'),
(2, 'ABMUsuarios-Validacion-Resetear', 'Esta seguro de resetear clave?'),
(2, 'ABMUsuario-Error-Aplicar', 'Error al operar con usuarios')

----Permisos principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'PermisosPrincipal-Form', 'Permisos'),
(2, 'PermisosPrincipal-Permiso-Usuario-Denegado', 'Permisos insuficientes para manejo de permisos'),
(2, 'PermisosPrincipal-Columna-FamiliaID','ID'),
(2, 'PermisosPrincipal-Columna-FamiliaNombre','Nombre'),
(2, 'PermisosPrincipal-Columna-FamiliaDescripcion','Descripcion')

----ABM Permisos
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMPermisos-Form', 'Permisos'),
(2, 'ABMPermisos-Validacion-Nombre', 'Nombre y descripcion deben tener menos de 50 caracteres'),
(2, 'ABMPermisos-Confirmacion-Baja', 'Esta seguro de borrar la familia?'),
(2, 'ABMPermiso-Error-Aplicar', 'Error al operar con las familias')



----Backup
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Backup-Form', 'Copia de seguridad'),
(2, 'Backup-Confirmacion-Ejecucion', 'Crear Copia de Seguridad?'),
(2, 'Backup-Validacion-Ruta', 'Ruta no valida'),
(2, 'Backup-Confirmacion-Backup', 'La copia de seguridad se creo exitosamente'),
(2, 'Backup-Error-Aplicar', 'Error al crear la copia de seguridad')

----Restore
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Restore-Form', 'Restauracion'),
(2, 'Restore-Columna-Volumen', 'Volumenes'),
(2, 'Restore-Confirmacion-Ejecucion', 'Realizar restauracion de la base de datos?'),
(2, 'Restore-Confirmacion-Backup', 'La restauracion se realizo exitosamente'),
(2, 'Restore-Validacion-Rutas', 'Volumen no encontrado'),
(2, 'Restore-Error-Aplicar', 'Error al restaurar copia de seguridad')

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Control
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----Inicio
(1, 'LoginLabel1', 'User'),  
(1, 'LoginLabel2', 'Pass'), 
(1, 'LoginLabel3', 'Lenguage'), 
(1, 'LoginBotton1', 'Login'), 
(1, 'LoginBotton2', 'Exit'),
(1, 'LoginButton3', 'Change Password')
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'CambiarPasswordLabel1', 'Username'),
(1, 'CambiarPasswordButton1', 'Reset Password')
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
--- ABMUsuarios
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ABMUsuariosLabel1', 'Name'),
(1, 'ABMUsuariosLabel2', 'Surname'),
(1, 'ABMUsuariosLabel3', 'Usuer'),
(1, 'ABMUsuariosLabel4', 'Password'),
(1, 'ABMUsuariosLabel5', 'Language'),
(1, 'ABMUsuariosLabel6', 'Available'),
(1, 'ABMUsuariosLabel7', 'Assigned'),
(1, 'ABMUsuariosLabel8', 'Available'),
(1, 'ABMUsuariosLabel9', 'Assigned'),
(1, 'ABMUsuarioGroupboxUsuario', 'User'),
(1, 'ABMUsuarioGroupboxPermisos', 'Accesses'),
(1, 'ABMUsuarioGroupboxFamilia', 'Groups'),
(1, 'ABMUsuarioGroupboxPatentes', 'Permitions'),
(1, 'ABMUsuariosBotton1', 'Apply'),
(1, 'ABMUsuariosBotton2', 'Cancel')

--- Permisos Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'PermisosPrincipalBotton1', 'Read'),
(1, 'PermisosPrincipalBotton2', 'Create'),
(1, 'PermisosPrincipalBotton3', 'Modify'),
(1, 'PermisosPrincipalBotton4', 'Delete'),
(1, 'PermisosPrincipalBotton5', 'Apply'),
(1, 'PermisosPrincipalBotton6', 'Clean'),
(1, 'PermisosPrincipalLabel1', 'Name'),
(1, 'PermisosPrincipalLabel2', 'Description'),
(1, 'PermisosPrincipalGroupBox', 'Filters')

INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----
(2, 'LoginLabel1', 'Usuario'), 
(2, 'LoginLabel2', 'Clave'), 
(2, 'LoginLabel3', 'Idioma'), 
(2, 'LoginButton1', 'Iniciar Sesion'), 
(2, 'LoginBotton2', 'Salir'),
(2, 'LoginButton3', 'Cambiar Clave')
----ResetPasswrd
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'CambiarPasswordLabel1', 'Nombre de usuario'),
(2, 'CambiarPasswordButton1', 'Cambiar Clave')
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

--- ABMUsuarios
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ABMUsuariosLabel1', 'Nombre'),
(2, 'ABMUsuariosLabel2', 'Apellido'),
(2, 'ABMUsuariosLabel3', 'Usuario'),
(2, 'ABMUsuariosLabel4', 'Clave'),
(2, 'ABMUsuariosLabel5', 'Idioma'),
(2, 'ABMUsuariosLabel6', 'Disponibles'),
(2, 'ABMUsuariosLabel7', 'Actuales'),
(2, 'ABMUsuariosLabel8', 'Disponibles'),
(2, 'ABMUsuariosLabel9', 'Actuales'),
(2, 'ABMUsuarioGroupboxUsuario', 'Usuarios'),
(2, 'ABMUsuarioGroupboxPermisos', 'Permisos'),
(2, 'ABMUsuarioGroupboxFamilia', 'Familias'),
(2, 'ABMUsuarioGroupboxPatentes', 'Patentes'),
(2, 'ABMUsuariosBotton1', 'Aplicar'),
(2, 'ABMUsuariosBotton2', 'Cancelar')


--- Permisos Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'PermisosPrincipalBotton1', 'Ver'),
(2, 'PermisosPrincipalBotton2', 'Crear'),
(2, 'PermisosPrincipalBotton3', 'Modificar'),
(2, 'PermisosPrincipalBotton4', 'Borrar'),
(2, 'PermisosPrincipalBotton5', 'Aplicar'),
(2, 'PermisosPrincipalBotton6', 'Limpiar'),
(2, 'PermisosPrincipalLabel1', 'Nombre'),
(2, 'PermisosPrincipalLabel2', 'Descripcion'),
(2, 'PermisosPrincipalGroupBox', 'Filtros')

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Usuario
INSERT INTO dbo.Usuario(ID_Usuario, Nombre, Apellido, Nombre_Usuario, Contrasenia, DVH, Intentos_Login, ID_Idioma) VALUES
(1, 'Martin', 'Dome', 'bWFydGluZG9tZTk2QGdtYWlsLmNvbQ==', 'CB1338CD67E63B81FC59F8107E76811C','196993', 0, 2) 

-- --Permisos
-- INSERT INTO Permiso(ID_Permiso, Nombre, Descripcion, Tipo_Permiso) VALUES 
-- (1, 'Administrador de Usuarios', 'Permite administrar usuarios', 'AdminUsuarios'),
-- (2, 'Administrador de Permisos', 'Permite administrar permisos de usuario', 'AdminPermisos'),
-- (3, 'Consultar Bitacora', 'Permite consultar la bitacora', 'ReadBitacora'),
-- (4, 'Administrador de Copias de seguridad', 'Permite administrar Copias de seguridad', 'AdminBackup'),
-- (5, 'Administrador de Restore', 'Permite administrar la restauracion del sistema', 'AdminRestore'),
-- (6, 'Vender Pasajes', 'Permite manejar la venta de pasajes', 'VendedorPasajes'),
-- (7, 'Administrador Rutas', 'Permite administrar la creacion de nuevas rutas', 'AdminRutas'),
-- (8, 'Administrador Localidad', 'Permite administrar las localidades', 'AdminLocalidades'),
-- (9, 'Administrador Cliente', 'Permite administrar el manejo de clientes', 'AdminClientes'),
-- (10, 'Consultar Usuarios', 'Permite consultar usuarios', 'ReadUsuarios'),
-- (11, 'Consultar Permisos', 'Permite consultar permisos', 'ReadPermisos'),
-- (12, 'Consultar Pasajes', 'Permite consultar los pasajes vendidos', 'ReadVentas'),
-- (13, 'Consultar Rutas', 'Permite consultar las rutas', 'ReadRutas'),
-- (14, 'Consultar Localidades', 'Permite consultar las localidades', 'ReadLocalidades'),
-- (15, 'Consultar Clientes', 'Permite consultar las localidades', 'ReadClientes'),
-- (16, 'Administrador Viajes', 'Permite crear y administrar los viajes', 'AdminViajes'),
-- (17, 'Consultar Viajes', 'Permite consultar los viajes', 'ReadViajes')

--Permisos
INSERT INTO Permiso(ID_Permiso, Nombre, Descripcion, Tipo_Permiso) VALUES 
(1, 'QWRtaW5pc3RyYWRvciBkZSBVc3Vhcmlvcw==', 'Permite administrar usuarios', 'AdminUsuarios'),
(2, 'QWRtaW5pc3RyYWRvciBkZSBQZXJtaXNvcw==', 'Permite administrar permisos de usuario', 'AdminPermisos'),
(3, 'Q29uc3VsdGFyIEJpdGFjb3Jh', 'Permite consultar la bitacora', 'ReadBitacora'),
(4, 'QWRtaW5pc3RyYWRvciBkZSBDb3BpYXMgZGUgc2VndXJpZGFk', 'Permite administrar Copias de seguridad', 'AdminBackup'),
(5, 'QWRtaW5pc3RyYWRvciBkZSBSZXN0b3Jl', 'Permite administrar la restauracion del sistema', 'AdminRestore'),
(6, 'VmVuZGVyIFBhc2FqZXM=', 'Permite manejar la venta de pasajes', 'VendedorPasajes'),
(7, 'QWRtaW5pc3RyYWRvciBSdXRhcw==', 'Permite administrar la creacion de nuevas rutas', 'AdminRutas'),
(8, 'QWRtaW5pc3RyYWRvciBMb2NhbGlkYWQ=', 'Permite administrar las localidades', 'AdminLocalidades'),
(9, 'QWRtaW5pc3RyYWRvciBDbGllbnRl', 'Permite administrar el manejo de clientes', 'AdminClientes'),
(10, 'Q29uc3VsdGFyIFVzdWFyaW9z', 'Permite consultar usuarios', 'ReadUsuarios'),
(11, 'Q29uc3VsdGFyIFBlcm1pc29z', 'Permite consultar permisos', 'ReadPermisos'),
(12, 'Q29uc3VsdGFyIFBhc2FqZXM=', 'Permite consultar los pasajes vendidos', 'ReadVentas'),
(13, 'Q29uc3VsdGFyIFJ1dGFz', 'Permite consultar las rutas', 'ReadRutas'),
(14, 'Q29uc3VsdGFyIExvY2FsaWRhZGVz', 'Permite consultar las localidades', 'ReadLocalidades'),
(15, 'Q29uc3VsdGFyIENsaWVudGVz', 'Permite consultar las localidades', 'ReadClientes'),
(16, 'QWRtaW5pc3RyYWRvciBWaWFqZXM=', 'Permite crear y administrar los viajes', 'AdminViajes'),
(17, 'Q29uc3VsdGFyIFZpYWplcw==', 'Permite consultar los viajes', 'ReadViajes')


-- --Familias
-- INSERT INTO Familia(ID_Familia, Nombre, Descripcion) VALUES
-- (1, 'Administradores Sistema', 'Permite administrar la seguridad del sistema'),
-- (2, 'Administradores Usuarios', 'Permite manejar los usuarios del sistema'),
-- (3, 'Administradores Permisos', 'Permite manejar los usuarios del sistema'),
-- (4, 'Auditores Seguridad', 'Permite acceder a los logs del sistema'),
-- (5, 'Vendedores', 'Permite realizar ventas de pasajes y dar alta clientes'),
-- (6, 'Auditor ventas', 'Permite acceder a las registros de ventas y clientes'),
-- (7, 'Administrativos', 'Permite administrar rutas, viajes y localidades')

--Familias
INSERT INTO Familia(ID_Familia, Nombre, Descripcion) VALUES
(1, 'QWRtaW5pc3RyYWRvcmVzIFNpc3RlbWE=', 'Permite administrar la seguridad del sistema'),
(2, 'QWRtaW5pc3RyYWRvcmVzIFVzdWFyaW9z', 'Permite manejar los usuarios del sistema'),
(3, 'QWRtaW5pc3RyYWRvcmVzIFBlcm1pc29z', 'Permite manejar los usuarios del sistema'),
(4, 'QXVkaXRvcmVzIFNlZ3VyaWRhZA==', 'Permite acceder a los logs del sistema'),
(5, 'VmVuZGVkb3Jlcw==', 'Permite realizar ventas de pasajes y dar alta clientes'),
(6, 'QXVkaXRvciB2ZW50YXM=', 'Permite acceder a las registros de ventas y clientes'),
(7, 'QWRtaW5pc3RyYXRpdm9z', 'Permite administrar rutas, viajes y localidades')

--Usuario_Familia
INSERT INTO Usuario_Familia(ID_Usuario, ID_Familia, DVH) VALUES
(1,1,49),
(1,2,50),
(1,3,51),
(1,4,52),
(1,5,53),
(1,6,54),
(1,7,55)

--Permiso_Familia
INSERT INTO Permiso_Familia(ID_Permiso, ID_Familia, DVH) VALUES
--FAMILIA SISTEMA ADMIN
(3,1,49),
(4,1,49),
(5,1,49),
--FAMILIA ADMIN USUARIOS
(1,2,50), --usuarios admin
(10,2,148), --usuarios read
--FAMILIA ADMIN PERMISOS
(2,3,51), --permisos admin
(11,3,151), --permisos read
--FAMILIA Auditores Seguridad
(3,4,52),
--FAMILIA VENDEDORES
(6,5,53), --Vender pasajes
(9,5,53), --Administar clientes
(15,5,159), --Consultar clientes
(17,5,161), --Consultar Viajes
(13,5,157), --Consultar Rutas
(12,5,156), --Consultar pasajes
--FAMILIA AUDITOR VENTAS
(12,6,158), --Consultar pasajess
(13,6,159), --Consultar Rutas
(14,6,160), --Consultar Localidades
(15,6,161), --Consultar Clientes
(17,6,163), --Consultar Viajes
--Familia Administrativo
(6,7,55), --admin pasajes
(7,7,55), --admin rutas
(8,7,55), -- admin localidad
(9,7,55), -- admin cliente
(12,7,160), --read pasajes
(13,7,161), --read rutas
(14,7,162), --read localidad
(15,7,163), --read clientes
(16,7,164), --admin viajes
(17,7,165) --admin clientes

Insert INTO dbo.Digito_Verificador(ID_Digito_Verificador, Tabla, DVV) Values 
(1, 'Usuario', '196993'),
(2, 'Permiso_Familia', '3334'),
(3, 'Usuario_Familia', '364')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------