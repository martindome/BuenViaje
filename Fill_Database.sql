
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
(1, 'Bitacora-pdf-Title', 'Report of Logs'),
(1, 'Bitacora-pdf-Date', 'Date'),
(1, 'Bitacora-pdf-Requested', 'Requested By')
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

----Localidad Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'LocalidadPrincipal-Columna-Pais', 'Country'),
(1, 'LocalidadPrincipal-Columna-LocalidadID','ID'),
(1, 'LocalidadPrincipal-Columna-Nombre','Name'),
(1, 'LocalidadPrincipal-Columna-Provincia','Provincia'),
(1, 'UsuarioPrincipal-Localidades-AccesoDenegado', 'Users does not have enough access')

----ABM Localidad
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMLocalidades-Form', 'Locations'),
(1, 'ABMLocalidades-Validacion-Localidad','Location already existing'),
(1, 'ABMLocalidades-Confirmacion-Baja','Are you sure to delete the location?'),
(1, 'ABMLocalidades-Error-Aplicar','An error has ocurred while applying the changes')

----Buses Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'BusPrincipal-Columna-BusID', 'ID'),
(1, 'BusPrincipal-Columna-Patente','Number'),
(1, 'BusPrincipal-Columna-Marca','Brand'),
(1, 'BusPrincipal-Columna-Asientos','Seats'),
(1, 'UsuarioPrincipal-Buses-AccesoDenegado', 'User does not have enough permissions'),
(1, 'Buses-pdf-Title', 'Report of Buses'),
(1, 'Buses-pdf-Date', 'Date'),
(1, 'Buses-pdf-Requested', 'Requested By')

----ABM Buses
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMBuses-Form', 'Buses'),
(1, 'ABMBuses-Validacion-Bus','Bus already exists'),
(1, 'ABMBuses-ValidacionPatente-Bus','Plate can only contain numbers and letters'),
(1, 'ABMBuses-Confirmacion-Baja','Are you sure to delete the bus?'),
(1, 'ABMBuses-Error-Aplicar','An error has ocurred while applying the changes')

----Clientes Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ClientesPrincipal-Columna-ClienteID', 'ID'),
(1, 'ClientesPrincipal-Columna-Nombre','Name'),
(1, 'ClientesPrincipal-Columna-Apellido','Surname'),
(1, 'ClientesPrincipal-Columna-DNI','DNI'),
(1, 'ClientesPrincipal-Columna-Email', 'Email'),
(1, 'UsuarioPrincipal-Clientes-AccesoDenegado', 'User does not have enough privilages')

----Clientes ABM
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMClientes-Form', 'Clients'),
(1, 'ABMClientes-Validacion-Cliente','Cliente already exists'),
(1, 'ABMClientes-Confirmacion-Baja','Are you sure to delete the client'),
(1, 'ABMClientes-Error-Aplicar','An error occured while applying the changes')

----Rutas Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'RutaPrincpal-Columna-RutaID', 'ID'),
(1, 'RutaPrincpal-Columna-Nombre','Name'),
(1, 'RutaPrincpal-Columna-Origen','From'),
(1, 'RutaPrincpal-Columna-Destino','To'),
(1, 'RutaPrincpal-Columna-Duracion', 'Time(min)'),
(1, 'UsuarioPrincipal-Rutas-AccesoDenegado', 'User does not have enough privilages')

---
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMRutas-Form', 'Routes'),
(1, 'ABMRuta-Validacion-Misma','Route cannot have same oring and desteny'),
(1, 'ABMRuta-Validacion-Igual','There is already a route between those cities'),
(1, 'ABMRuta-Validacion-Nombre','There is already an existing route with that name'),
(1, 'ABMRuta-Confirmacion-Baja','Are you sure to delete the route?'),
(1, 'ABMRuta-Error-Aplicar','An error occured while applying the changes')

----Viajes Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ViajePrincpal-Columna-ViajeID', 'ID_Viaje'),
(1, 'ViajePrincpal-Columna-RutaID','ID_Ruta'),
(1, 'ViajePrincpal-Columna-BusID','ID_Bus'),
(1, 'ViajePrincpal-Columna-RutaNombre','Route'),
(1, 'ViajePrincpal-Columna-BusPatente', 'Bus'),
(1, 'ViajePrincpal-Columna-Fecha', 'Date'),
(1, 'ViajePrincpal-Columna-Cancelado', 'Canceled'),
(1, 'UsuarioPrincipal-Viajes-AccesoDenegado', 'User does not have enough permissions'),
(1, 'Cancelado', 'Yes'),
(1, 'No Cancelado', 'No')

--- Viajes ABM
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ABMViajes-Form', 'Trips'),
(1, 'ABMViajes-Mensual', 'Monthly'),
(1, 'ABMViajes-Semanal', 'Weekly'),
(1, 'ABMViajes-Diario', 'Daily'),
(1, 'ABMViajes-Especial', 'Especial'),
(1, 'ABMViaje-Validacion-Fecha','Date is incorrect'),
(1, 'ABMViaje-Validacion-Bus','Bus is busy in another trip'),
(1, 'ABMViajes-Confirmacion-Baja','Are you sure to cancel the trip?'),
(1, 'ABMViajes-Error-Aplicar','An error occured while applying the changes')

--Pasaje principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'PasajePrincipal-Columna-ViajeID', 'IDViaje'),
(1, 'PasajePrincipal-Columna-RutaID','IDRuta'),
(1, 'PasajePrincipal-Columna-BusID','IDBus'),
(1, 'PasajePrincipal-Columna-Origen','From'),
(1, 'PasajePrincipal-Columna-Destino', 'To'),
(1, 'PasajePrincipal-Columna-Fecha', 'Date'),
(1, 'PasajePrincipal-Columna-Disponibles', 'Available'),
(1, 'PasajePrincipal-Error-CantidadPasaje', 'Wrong amount of seats required'),
(1, 'PasajePrincipal-Error-VentaPasaje', 'An error ocurred while trying to sell a ticket')

---Devolucion
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Devolucion-Form', 'Tickets'),
(1, 'PasajePrincipal-Columna-PasajeID', 'IDPasaje'),
(1, 'Devolucion-Info-Correcta', 'Ticket returned correctly'),
(1, 'Devolucion-Error-Exception', 'An error occured while returning the ticket')

---------- ESPANIOL

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
(2, 'Bitacora-pdf-Title', 'Reporte de Bitacora'),
(2, 'Bitacora-pdf-Date', 'Fecha'),
(2, 'Bitacora-pdf-Requested', 'Pedido por')
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


----Localidad Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'LocalidadPrincipal-Columna-Pais', 'Pais'),
(2, 'LocalidadPrincipal-Columna-LocalidadID','ID'),
(2, 'LocalidadPrincipal-Columna-Nombre','Nombre'),
(2, 'LocalidadPrincipal-Columna-Provincia','Provincia'),
(2, 'UsuarioPrincipal-Localidades-AccesoDenegado', 'Usuario no tiene permisos necesarios')

----ABM Localidad
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMLocalidades-Form', 'Localidades'),
(2, 'ABMLocalidades-Validacion-Localidad','Localidad ya existente'),
(2, 'ABMLocalidades-Confirmacion-Baja','Esta seguro de borrar la localidad?'),
(2, 'ABMLocalidades-Error-Aplicar','Un error ocurrio al intentar operar con localidades')

----Buses Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'BusPrincipal-Columna-BusID', 'ID'),
(2, 'BusPrincipal-Columna-Patente','Patente'),
(2, 'BusPrincipal-Columna-Marca','Marca'),
(2, 'BusPrincipal-Columna-Asientos','Asientos'),
(2, 'UsuarioPrincipal-Buses-AccesoDenegado', 'El usuario no tiene los permisos suficientes'),
(2, 'Buses-pdf-Title', 'Reporte de buses'),
(2, 'Buses-pdf-Date', 'Fecha'),
(2, 'Buses-pdf-Requested', 'Pedido por')

----ABM Localidad
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMBuses-Form', 'Buses'),
(2, 'ABMBuses-Validacion-Bus','Bus ya existente'),
(2, 'ABMBuses-ValidacionPatente-Bus','Patente solo contiene numeros y letras'),
(2, 'ABMBuses-Confirmacion-Baja','Esta seguro de elimianr el bus?'),

(2, 'ABMBuses-Error-Aplicar','Un error ocurrio al aplicar los cambios')

----Clientes Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ClientesPrincipal-Columna-ClienteID', 'ID'),
(2, 'ClientesPrincipal-Columna-Nombre','Nombre'),
(2, 'ClientesPrincipal-Columna-Apellido','Apellido'),
(2, 'ClientesPrincipal-Columna-DNI','DNI'),
(2, 'ClientesPrincipal-Columna-Email', 'Email'),
(2, 'UsuarioPrincipal-Clientes-AccesoDenegado', 'El usuario no tiene los permisos suficientes')

----Clientes Localidad
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMClientes-Form', 'Clientes'),
(2, 'ABMClientes-Validacion-Cliente','Cliente ya existente'),
(2, 'ABMClientes-Confirmacion-Baja','Esta seguro de elimianar el cliente?'),
(2, 'ABMClientes-Error-Aplicar','Un error ocurrio al aplicar los cambios')

----Rutas Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'RutaPrincpal-Columna-RutaID', 'ID'),
(2, 'RutaPrincpal-Columna-Nombre','Nombre'),
(2, 'RutaPrincpal-Columna-Origen','Origen'),
(2, 'RutaPrincpal-Columna-Destino','Destino'),
(2, 'RutaPrincpal-Columna-Duracion', 'Duracion(min)'),
(2, 'UsuarioPrincipal-Rutas-AccesoDenegado', 'El usuario no tiene los permisos suficientes')

---
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMRutas-Form', 'Rutas'),
(2, 'ABMRuta-Validacion-Misma','Ruta no puede tener mismo origen y destino'),
(2, 'ABMRuta-Validacion-Igual','Ya existe una ruta entre esas ciudades'),
(2, 'ABMRuta-Validacion-Nombre','Ya existe una ruta con ese nombre'),
(2, 'ABMRuta-Confirmacion-Baja','Esta seguro de que quiere borrar la ruta?'),
(2, 'ABMRuta-Error-Aplicar','Un error ocurrio al aplicar los cambios')

--Viajes Principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ViajePrincpal-Columna-ViajeID', 'ID_Viaje'),
(2, 'ViajePrincpal-Columna-RutaID','ID_Ruta'),
(2, 'ViajePrincpal-Columna-BusID','ID_Bus'),
(2, 'ViajePrincpal-Columna-RutaNombre','Ruta'),
(2, 'ViajePrincpal-Columna-BusPatente', 'Bus'),
(2, 'ViajePrincpal-Columna-Fecha', 'Fecha'),
(2, 'ViajePrincpal-Columna-Cancelado', 'Cancelado'),
(2, 'UsuarioPrincipal-Viajes-AccesoDenegado', 'El usuario no tiene los permisos suficientes'),
(2, 'Cancelado', 'Si'),
(2, 'No Cancelado', 'No')

--- Viajes ABM
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ABMViajes-Form', 'Viajes'),
(2, 'ABMViajes-Mensual', 'Mensual'),
(2, 'ABMViajes-Semanal', 'Semanal'),
(2, 'ABMViajes-Diario', 'Diario'),
(2, 'ABMViajes-Especial', 'Especial'),
(2, 'ABMViaje-Validacion-Fecha','Fecha es incorrecta'),
(2, 'ABMViaje-Validacion-Bus','Bus en uso para otro viaje'),
(2, 'ABMViajes-Confirmacion-Baja','Esta seguro de que quiere cancelar el viaje?'),
(2, 'ABMViajes-Error-Aplicar','Un error ocurrio al aplicar los cambios')

--Pasaje principal
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'PasajePrincipal-Columna-ViajeID', 'IDViaje'),
(2, 'PasajePrincipal-Columna-RutaID','IDRuta'),
(2, 'PasajePrincipal-Columna-BusID','IDBus'),
(2, 'PasajePrincipal-Columna-Origen','Desde'),
(2, 'PasajePrincipal-Columna-Destino', 'Hasta'),
(2, 'PasajePrincipal-Columna-Fecha', 'Fecha'),
(2, 'PasajePrincipal-Columna-Disponibles', 'Disponibles'),
(2, 'PasajePrincipal-Error-CantidadPasaje', 'Cantidad de asientos incorrecta'),
(2, 'PasajePrincipal-Error-VentaPasaje', 'Un error ocurrio al intenter vender el pasaje')

---Devolucion
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Devolucion-Form', 'Pasajes'),
(2, 'PasajePrincipal-Columna-PasajeID', 'IDPasaje'),
(2, 'Devolucion-Info-Correcta', 'Ticket devuelto correctamente'),
(2, 'Devolucion-Error-Exception', 'Un error ocurrio al intentar devolver un pasaje')


---TOOL TIPS___________________
------------------- Login
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'txtUser', 'Email of the user'),
(1, 'txtPass', 'Password of the user'),
(1, 'LoginButton1', 'Login suing username and password'),
(1, 'LoginBotton2', 'Exit the aplication'),
(1, 'LoginComboBox1', 'Change the languaje of the login screen'),
(1, 'LoginButton3', 'Reset a password for a system user')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'txtUser', 'Email del usuario'),
(2, 'txtPass', 'Contraseña del usuario'),
(2, 'LoginButton1', 'Entrar al sistema usando nombre de usaurio y contraseña'),
(2, 'LoginBotton2', 'Salir de la aplicacion'),
(2, 'LoginComboBox1', 'Cambiar el lenguaje de la pantalla de login'),
(2, 'LoginButton3', 'Cambiar la contraseña de un usuario del sistema')


------------------- Principal Pasajes
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'pasajesPrincipalTextBox1', 'Name of the client'),
(1, 'pasajesPrincipalTextBox2', 'Surname of the client'),
(1, 'pasajesPrincipalTextBox3', 'ID of the client'),
(1, 'pasajesPrincipalTextBox4', 'Origin city'),
(1, 'pasajesPrincipalTextBox5', 'Destintaion city'),
(1, 'pasajeDateTimePicker1', 'Earliest date to search tickets'),
(1, 'pasajeDateTimePicker2', 'Latest date to search tickets'),
(1, 'pasajesPrincipalTextBox6', 'Amount of tickets to sell'),
(1, 'pasajesPrincipalButton1', 'Filter the clients with teh dates indicated'),
(1, 'pasajesPrincipalButton2', 'Filter the trip on the dates indicated'),
(1, 'pasajesPrincipalButton3', 'Create a new Client'),
(1, 'pasajesPrincipalButton5', 'Return tickets to the selected client'),
(1, 'pasajesPrincipalButton4', 'Sell selected ticket to the selected client the amount indicated')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'pasajesPrincipalTextBox1', 'Nombre del client'),
(2, 'pasajesPrincipalTextBox2', 'Apellido del cliente'),
(2, 'pasajesPrincipalTextBox3', 'Documento de identidad del client'),
(2, 'pasajesPrincipalTextBox4', 'Ciudad de origen'),
(2, 'pasajesPrincipalTextBox5', 'Ciudad de destino'),
(2, 'pasajeDateTimePicker1', 'Fecha mas temprano par buscar tickets'),
(2, 'pasajeDateTimePicker2', 'Fecha mas tarde para buscar tickets'),
(2, 'pasajesPrincipalTextBox6', 'Cantidad de tickets para vender'),
(2, 'pasajesPrincipalButton1', 'Buscar clientes con la informacion indicada'),
(2, 'pasajesPrincipalButton2', 'Buscar viajes con la informacion indicada'),
(2, 'pasajesPrincipalButton3', 'Ingresar un nuevo cliente'),
(2, 'pasajesPrincipalButton5', 'Devolver tickets a el cliente seleccionado'),
(2, 'pasajesPrincipalButton4', 'Vender tickets al cleinte seleccionado para el viaje seleccionado')


------------------- Principal Clientes
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ClientesTextBox1', 'Name of the client'),
(1, 'ClientesTextBox2', 'Surname of the client'),
(1, 'ClientesTextBox3', 'ID of the client'),
(1, 'ClientesTextBox4', 'Email of the client'),
(1, 'ClientesBotton5', 'Filter the clients'),
(1, 'ClientesBotton6', 'Clean the filters'),
(1, 'ClientesBotton1', 'Read the client'),
(1, 'ClientesBotton2', 'Create a new client'),
(1, 'ClientesBotton3', 'Modify the selected client'),
(1, 'ClientesBotton4', 'Delete the selected client')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ClientesTextBox1', 'Nombre del cliente'),
(2, 'ClientesTextBox2', 'Apellido del cliente'),
(2, 'ClientesTextBox3', 'Documento de identidad del client'),
(2, 'ClientesTextBox4', 'Email del cliente'),
(2, 'ClientesBotton5', 'Filtrar clientes'),
(2, 'ClientesBotton6', 'Limpiar los filtros'),
(2, 'ClientesBotton1', 'Ver cliente'),
(2, 'ClientesBotton2', 'Ingresar un nuevo cliente'),
(2, 'ClientesBotton3', 'Modificar el cliente seleccionado'),
(2, 'ClientesBotton4', 'Eliminar el cliente seleccionado')

------------------- Principal Viajes
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'ViajesPrincipalText1', 'Bus Identifiaction'),
(1, 'ViajesPrincipalText2', 'Route name'),
(1, 'ViajesPrincipalCheckBox', 'Check to search for canceled trips'),
(1, 'ViajeDatePickerDesde', 'First date to filter trips'),
(1, 'ViajeDatePickerHasta', 'Last date to filter trips'),
(1, 'ViajesPrincipalButton6', 'Clean the filters'),
(1, 'ViajesPrincipalButton5', 'Apply the filters'),
(1, 'ViajesPrincipalButton1', 'Read the trip'),
(1, 'ViajesPrincipalButton2', 'Create a new trip'),
(1, 'ViajesPrincipalButton3', 'Modify an existing trip'),
(1, 'ViajesPrincipalButton4', 'Cancel the selected trip')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'ViajesPrincipalText1', 'Patente del bus'),
(2, 'ViajesPrincipalText2', 'Nombre de la ruta'),
(2, 'ViajesPrincipalCheckBox', 'Prender para buscar viajes cancelados'),
(2, 'ViajeDatePickerDesde', 'Primer fecha para filtrar viajes'),
(2, 'ViajeDatePickerHasta', 'Ultima fecha para filtrar viajes'),
(2, 'ViajesPrincipalButton6', 'Limpiar los filtros'),
(2, 'ViajesPrincipalButton5', 'Aplicar los filtros'),
(2, 'ViajesPrincipalButton1', 'Ver el viaje'),
(2, 'ViajesPrincipalButton2', 'Ingresar nuevos viajes'),
(2, 'ViajesPrincipalButton3', 'Modificar un viaje existente seleccionado'),
(2, 'ViajesPrincipalButton4', 'Cancelar el viaje seleccionado')


------------------- Principal Rutas
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'RutasPrincipalText2', 'City of origin'),
(1, 'RutasPrincipalText3', 'City of destination'),
(1, 'RutasButton6', 'Clean the filters'),
(1, 'RutasButton5', 'Apply the filters'),
(1, 'RutasButton1', 'Read the route'),
(1, 'RutasButton2', 'Create a new route'),
(1, 'RutasButton3', 'Modify an existing route'),
(1, 'RutasButton4', 'Cancel the selected route')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'RutasPrincipalText2', 'Ciudad de origin'),
(2, 'RutasPrincipalText3', 'Ciudad de destino'),
(2, 'RutasButton6', 'Limpiar los filtros'),
(2, 'RutasButton5', 'Aplicar los filtros'),
(2, 'RutasButton1', 'Ver la ruta'),
(2, 'RutasButton2', 'Crear una nueva ruta'),
(2, 'RutasButton3', 'Modificar la ruta seleccionada'),
(2, 'RutasButton4', 'Eliminar la ruta seleccionada')

------------------- Principal Localidades
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'LocalidadPrincipalText1', 'Name of the city'),
(1, 'LocalidadPrincipalText2', 'Name of the province'),
(1, 'LocalidadPrincipalText3', 'Name of the country'),
(1, 'LocalidadBotton6', 'Clean the filters'),
(1, 'LocalidadBotton5', 'Apply the filters'),
(1, 'LocalidadBotton1', 'Read the city'),
(1, 'LocalidadBotton2', 'Ingress a new city'),
(1, 'LocalidadBotton3', 'Modify an existing city'),
(1, 'LocalidadBotton4', 'Cancel the selected city')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'LocalidadPrincipalText1', 'Nombre de la ciudad'),
(2, 'LocalidadPrincipalText2', 'Nombre de la provincia'),
(2, 'LocalidadPrincipalText3', 'nombre de la ciudad'),
(2, 'LocalidadBotton6', 'Limpiar los filtros'),
(2, 'LocalidadBotton5', 'Aplicar los filtros'),
(2, 'LocalidadBotton1', 'Ver la ciudad'),
(2, 'LocalidadBotton2', 'Ingresar una nueva ciudad'),
(2, 'LocalidadBotton3', 'Modificar la ciudad seleccionada'),
(2, 'LocalidadBotton4', 'Eliminar la ciudad seleccionada')

------------------- Principal Buses
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'busesText1', 'Identification of the bus'),
(1, 'busesText2', 'Brand of the bus'),
(1, 'busesText3', 'Seats of the bus'),
(1, 'busesButton6', 'Clean the filters'),
(1, 'busesButton5', 'Apply the filters'),
(1, 'busesButton7', 'Generate a report with teh filters applied'),
(1, 'busesButton1', 'Read the selected bus'),
(1, 'busesButton2', 'Ingress a new bus'),
(1, 'busesButton3', 'Modify an existing bus'),
(1, 'busesButton4', 'Eliminate the selected bus')

INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'busesText1', 'Patente del bus'),
(2, 'busesText2', 'Marca del bus'),
(2, 'busesText3', 'Asientos del bus'),
(2, 'busesButton6', 'Limpiar los filtros'),
(2, 'busesButton5', 'Aplicar los filtros'),
(2, 'busesButton7', 'Crear un reporte de los buses con los filtros aplicados'),
(2, 'busesButton1', 'Ver el bus seleccionado'),
(2, 'busesButton2', 'Ingresar un nuevo bus'),
(2, 'busesButton3', 'Modificar el bus seleccionado'),
(2, 'busesButton4', 'Eliminar el bus seleccionado')

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Control
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----Inicio
(1, 'LoginLabel1', 'User'),  
(1, 'LoginLabel2', 'Pass'), 
(1, 'LoginLabel3', 'Lenguage'), 
(1, 'LoginButton1', 'Login'), 
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
(1,'rutasToolStripMenuItem', 'Routes'),
(1, 'tabPageInicio', 'Main'),
(1, 'tabPagePasajes','Tickets'),
(1, 'tabPageClientes','Clients'),
(1, 'tabPageViajes','Trips'),
(1, 'tabPageRutas','Routes'),
(1, 'tabPageLocalidades','Locations'),
(1, 'tabPageBuses', 'Buses')
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


--- Backup
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'BackupLabel1', 'Destination'),
(1, 'BackupLabel2', 'Parts'),
(1, 'BackupButton1', 'Search'),
(1, 'BackupButton2', 'Create')

---Restore
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----
(1, 'RestoreButton1', 'Search'), 
(1, 'RestoreButton2', 'Restore')


---Localidades Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'LocalidadBotton1', 'Read'),
(1, 'LocalidadBotton2', 'New'),
(1, 'LocalidadBotton3', 'Modify'),
(1, 'LocalidadBotton4', 'Delete'),
(1, 'LocalidadBotton5', 'Apply'),
(1, 'LocalidadBotton6', 'Clean'),
(1, 'LocalidadLabel1', 'Name'),
(1, 'LocalidadLabel2', 'Province'),
(1, 'LocalidadLabel3', 'Country'),
(1, 'LocalidadGroupBox', 'Filters')

---ABM Localidades
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ABMLocalidadesLabel1', 'Name'),
(1, 'ABMLocalidadesLabel2', 'Province'),
(1, 'ABMLocalidadesLabel3', 'Country'),
(1, 'ABMLocalidadesBotton1', 'Apply'),
(1, 'ABMLocalidadesBotton2', 'Cancel')

---Buses Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'busesButton1', 'Read'),
(1, 'busesButton2', 'New'),
(1, 'busesButton3', 'Modify'),
(1, 'busesButton4', 'Delete'),
(1, 'busesButton5', 'Apply'),
(1, 'busesButton6', 'Clean'),
(1, 'busesButton7', 'Export pdf'),
(1, 'busesButton8', 'Print'),
(1, 'busesLabel1', 'Number'),
(1, 'busesLabel2', 'Brand'),
(1, 'busesLabel3', 'Seats'),
(1, 'busesGroupBox1', 'Filters')

---ABM Buses
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ABMBusesLabel1', 'Number'),
(1, 'ABMBusesLabel2', 'Brand'),
(1, 'ABMBusesLabel3', 'Seats'),
(1, 'ABMBusesBotton1', 'Apply'),
(1, 'ABMBusesBotton2', 'Cancel')

---Clientes Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ClientesBotton1', 'Read'),
(1, 'ClientesBotton2', 'New'),
(1, 'ClientesBotton3', 'Modify'),
(1, 'ClientesBotton4', 'Delete'),
(1, 'ClientesBotton5', 'Apply'),
(1, 'ClientesBotton6', 'Cleam'),
(1, 'ClientesLabel1', 'Name'),
(1, 'ClientesLabel2', 'Surname'),
(1, 'ClientesLabel3', 'DNI'),
(1, 'ClientesLabel4', 'Email'),
(1, 'ClientesGroupBox1', 'Filters')

---ABM Clientes
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ABMClientesLabel1', 'Name'),
(1, 'ABMClientesLabel2', 'Surname'),
(1, 'ABMClientesLabel3', 'DNI'),
(1, 'ABMClientesLabel4', 'Email'),
(1, 'ABMClientesBotton1', 'Apply'),
(1, 'ABMClientesBotton2', 'Cancel')

---Rutas Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'RutasButton1', 'Read'),
(1, 'RutasButton2', 'New'),
(1, 'RutasButton3', 'Modify'),
(1, 'RutasButton4', 'Delete'),
(1, 'RutasButton5', 'Apply'),
(1, 'RutasButton6', 'Clear'),
(1, 'RutaLabel1', 'From'),
(1, 'RutaLabel2', 'To'),
(1, 'RutasGroupBox', 'Filters')

---ABM Rutas
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'RutasLabel1', 'From'),
(1, 'RutasLabel2', 'To'),
(1, 'RutasLabel3', 'Duration'),
(1, 'ABMRutasButton1', 'Apply'),
(1, 'ABMRutasButton2', 'Cancel')

---Viajes Principa;
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ViajesPrincipalButton1', 'Read'),
(1, 'ViajesPrincipalButton2', 'New'),
(1, 'ViajesPrincipalButton3', 'Modify'),
(1, 'ViajesPrincipalButton4', 'Delete'),
(1, 'ViajesPrincipalButton5', 'Apply'),
(1, 'ViajesPrincipalButton6', 'Clear'),
(1, 'ViajePrincipalLabel1', 'Bus'),
(1, 'ViajePrincipalLabel2', 'Route'),
(1, 'ViajePrincipalLabel3', 'Date From'),
(1, 'ViajePrincipalLabel4', 'Date To'),
(1, 'ToViajesPrincipalCheckBox', 'Canceled'),
(1, 'ViajePrincipalGroupBox1', 'Filters')

---ABM Rutas
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'ViajeABMLabel1', 'Route'),
(1, 'ViajeABMLabel2', 'Bus'),
(1, 'ViajeABMLabel3', 'Type'),
(1, 'ViajeABMLabel4', 'Date From'),
(1, 'ViajeABMLabel5', 'Date to'),
(1, 'ViajeABMCheckBox1', 'Cancel'),
(1, 'ViajeABMButton1', 'Apply'),
(1, 'ViajeABMButton2', 'Cancel')

---Pasajes Principa;
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'pasajesPrincipalButton1', 'Search'),
(1, 'pasajesPrincipalButton2', 'Search'),
(1, 'pasajesPrincipalButton3', 'New Client'),
(1, 'pasajesPrincipalButton4', 'Sell ticket'),
(1, 'pasajesPrincipalButton5', 'Returns'),
(1, 'pasajesPrincipalLabel1', 'Name'),
(1, 'pasajesPrincipalLabel2', 'Surname'),
(1, 'pasajesPrincipalLabel3', 'ID'),
(1, 'pasajesPrincipalLabel4', 'From'),
(1, 'pasajesPrincipalLabel5', 'To'),
(1, 'pasajesPrincipalLabel7', 'Since'),
(1, 'pasajesPrincipalLabel6', 'Until'),
(1, 'pasajesPrincipalLabel8', 'Amount'),
(1, 'pasajesPrincipalGroupBox1', 'Clients'),
(1, 'pasajesPrincipalGroupBox2', 'Trips')

---Devoluciones
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'DevolucionText1', 'Return'),
(1, 'DevolucionText2', 'Exit')

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
(2,'rutasToolStripMenuItem', 'Rutas'),
(2, 'tabPageInicio', 'Inicio'),
(2, 'tabPagePasajes','Pasajes'),
(2, 'tabPageClientes','Clientes'),
(2, 'tabPageViajes','Viajes'),
(2, 'tabPageRutas','Rutas'),
(2, 'tabPageLocalidades','Localidades'),
(2, 'tabPageBuses', 'Buses')
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

---Restore
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'BackupLabel1', 'Destination'),
(2, 'BackupLabel2', 'Parts'),
(2, 'BackupButton1', 'Search'),
(2, 'BackupButton2', 'Create')

INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
----
(2, 'RestoreButton1', 'Search'), 
(2, 'RestoreButton2', 'Restore')

---Localidades Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'LocalidadBotton1', 'Ver'),
(2, 'LocalidadBotton2', 'Crear'),
(2, 'LocalidadBotton3', 'Modificar'),
(2, 'LocalidadBotton4', 'Borrar'),
(2, 'LocalidadBotton5', 'Aplicar'),
(2, 'LocalidadBotton6', 'Limpiar'),
(2, 'LocalidadLabel1', 'Nombre'),
(2, 'LocalidadLabel2', 'Provincia'),
(2, 'LocalidadLabel3', 'Pais'),
(2, 'LocalidadGroupBox', 'Filtros')

---ABM Localidades
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ABMLocalidadesLabel1', 'Nombre'),
(2, 'ABMLocalidadesLabel2', 'Provincia'),
(2, 'ABMLocalidadesLabel3', 'Pais'),
(2, 'ABMLocalidadesBotton1', 'Aplicar'),
(2, 'ABMLocalidadesBotton2', 'Cancelar')

---Buses Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'busesButton1', 'Ver'),
(2, 'busesButton2', 'Alta'),
(2, 'busesButton3', 'Modificar'),
(2, 'busesButton4', 'Borrar'),
(2, 'busesButton5', 'Aplicar'),
(2, 'busesButton6', 'Limpiar'),
(2, 'busesButton7', 'Exportar pdf'),
(2, 'busesButton8', 'Impirmir'),
(2, 'busesLabel1', 'Patente'),
(2, 'busesLabel2', 'Marca'),
(2, 'busesLabel3', 'Asientos'),
(2, 'busesGroupBox1', 'Filtros')


---ABM Buses
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ABMBusesLabel1', 'Patente'),
(2, 'ABMBusesLabel2', 'Marca'),
(2, 'ABMBusesLabel3', 'Asientos'),
(2, 'ABMBusesBotton1', 'Aplicar'),
(2, 'ABMBusesBotton2', 'Cancelar')


---Clientes Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ClientesBotton1', 'Ver'),
(2, 'ClientesBotton2', 'Alta'),
(2, 'ClientesBotton3', 'Modificar'),
(2, 'ClientesBotton4', 'Borrar'),
(2, 'ClientesBotton5', 'Aplicar'),
(2, 'ClientesBotton6', 'Limpiar'),
(2, 'ClientesLabel1', 'Nombre'),
(2, 'ClientesLabel2', 'Apellido'),
(2, 'ClientesLabel3', 'DNI'),
(2, 'ClientesLabel4', 'Email'),
(2, 'ClientesGroupBox1', 'Filtros')


---ABM Clientes
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ABMClientesLabel1', 'Nombre'),
(2, 'ABMClientesLabel2', 'Apellido'),
(2, 'ABMClientesLabel3', 'DNI'),
(2, 'ABMClientesLabel4', 'Email'),
(2, 'ABMClientesBotton1', 'Aplicar'),
(2, 'ABMClientesBotton2', 'Cancelar')

---Rutas Principal
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'RutasButton1', 'Ver'),
(2, 'RutasButton2', 'Nuevo'),
(2, 'RutasButton3', 'Modificar'),
(2, 'RutasButton4', 'Borrar'),
(2, 'RutasButton5', 'Aplicar'),
(2, 'RutasButton6', 'limpiar'),
(2, 'RutaLabel1', 'Origen'),
(2, 'RutaLabel2', 'Destino'),
(2, 'RutasGroupBox', 'Filtros')

---ABM Rutas
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'RutasLabel1', 'Origen'),
(2, 'RutasLabel2', 'Destino'),
(2, 'RutasLabel3', 'Duracion'),
(2, 'ABMRutasButton1', 'Aplicar'),
(2, 'ABMRutasButton2', 'Cancelar')

---Viajes Principal;
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ViajesPrincipalButton1', 'Ver'),
(2, 'ViajesPrincipalButton2', 'Alta'),
(2, 'ViajesPrincipalButton3', 'Modificar'),
(2, 'ViajesPrincipalButton4', 'Borrar'),
(2, 'ViajesPrincipalButton5', 'Aplicar'),
(2, 'ViajesPrincipalButton6', 'Limpiar'),
(2, 'ViajePrincipalLabel1', 'Bus'),
(2, 'ViajePrincipalLabel2', 'Ruta'),
(2, 'ViajePrincipalLabel3', 'Desde'),
(2, 'ViajePrincipalLabel4', 'Hasta'),
(2, 'ToViajesPrincipalCheckBox', 'Cancelado'),
(2, 'ViajePrincipalGroupBox1', 'Filtros')


---ABM Rutas
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'ViajeABMLabel1', 'Ruta'),
(2, 'ViajeABMLabel2', 'Bus'),
(2, 'ViajeABMLabel3', 'Tipo'),
(2, 'ViajeABMLabel4', 'Fecha'),
(2, 'ViajeABMLabel5', 'Fecha Hasta'),
(2, 'ViajeABMCheckBox1', 'Cancelar'),
(2, 'ViajeABMButton1', 'Aplicar'),
(2, 'ViajeABMButton2', 'Cancelar')

---Pasajes Principa;
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'pasajesPrincipalButton1', 'Buscar'),
(2, 'pasajesPrincipalButton2', 'Buscar'),
(2, 'pasajesPrincipalButton3', 'Nuevo Cliente'),
(2, 'pasajesPrincipalButton4', 'Vender Pasaje'),
(2, 'pasajesPrincipalButton5', 'Devoluciones'),
(2, 'pasajesPrincipalLabel1', 'Nombre'),
(2, 'pasajesPrincipalLabel2', 'Apellido'),
(2, 'pasajesPrincipalLabel3', 'ID'),
(2, 'pasajesPrincipalLabel4', 'Desde'),
(2, 'pasajesPrincipalLabel5', 'Hsta'),
(2, 'pasajesPrincipalLabel7', 'Desde'),
(2, 'pasajesPrincipalLabel6', 'Hasta'),
(2, 'pasajesPrincipalLabel8', 'Cantidad'),
(2, 'pasajesPrincipalGroupBox1', 'Clientes'),
(2, 'pasajesPrincipalGroupBox2', 'Viajes')

---Devoluciones
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'DevolucionText1', 'Devolver'),
(2, 'DevolucionText2', 'Salir')


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
(17, 'Q29uc3VsdGFyIFZpYWplcw==', 'Permite consultar los viajes', 'ReadViajes'),
(18, 'QWRtaW5pc3RyYWRvciBkZSBCdXNlcw==','Permite administrar los buses','AdminBuses'),
(19, 'Q29uc3VsdGFyIEJ1c2Vz','Permite consultar los buses','ReadBuses')

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
(7, 'QWRtaW5pc3RyYXRpdm9z', 'Permite administrar rutas, viajes y localidades'),
(8, 'QWRtaW5zdHJhZG9yIEJ1c2Vz', 'Permite administrar Buses')

--Usuario_Familia
INSERT INTO Usuario_Familia(ID_Usuario, ID_Familia, DVH) VALUES
(1,1,49),
(1,2,50),
(1,3,51),
(1,4,52),
(1,5,53),
(1,6,54),
(1,7,55),
(1,8,56)

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
(17,7,165), --admin clientes
-- Familia Buses
(18,8,168), --admin buses
(19,8,169) --read buses

Insert INTO dbo.Digito_Verificador(ID_Digito_Verificador, Tabla, DVV) Values 
(1, 'Usuario', '196993'),
(2, 'Permiso_Familia', '3671'),
(3, 'Usuario_Familia', '420')

-- Insert INTO Localidad(ID_Localidad, Nombre, Provincia, Pais) VALUES
-- (1,'El Chalten', 'Santa Cruz', 'Argentina'),
-- (2,'El Calafate', 'Santa Cruz', 'Argentina'),
-- (3,'Rio Gallegos', 'Santa Cruz', 'Argentina')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------