--Idioma
INSERT INTO dbo.Idioma(ID_Idioma, Descripcion) VALUES
(1, 'Ingles'),  
(2, 'Español')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Texto
INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(1, 'Inicio-Error-ConexionBaseDatos', 'Error while connection to data base'),
(1, 'Inicio-Error-IntegridadBaseDatos', 'Error on the Data Base integrity'),  
(1, 'Inicio-Info-CargaCorrecta', 'The application loaded successfully'), 
(1, 'Inicio-Error-CargaIncorrecta', 'An error happend while loading the application')


INSERT INTO dbo.Texto(ID_Idioma, ID_Texto, Mensaje) VALUES
(2, 'Inicio-Error-ConexionBaseDatos', 'Error al conectar a la base de datos'),
(2, 'Inicio-Error-IntegridadBaseDatos', 'Error en la integridad de la base de datos'),
(2, 'Inicio-Info-CargaCorrecta', 'Carga de la aplicacion correcta'),
(2, 'Inicio-Error-CargaIncorrecta', 'Ocurrio un error en la carga de la aplicacion')
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Control
INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(1, 'LoginLabel1', 'User'),  
(1, 'LoginLabel2', 'Pass'), 
(1, 'LoginBotton1', 'Login'), 
(1, 'LoginBotton2', 'Exit')

INSERT INTO dbo.Controles(ID_Idioma, ID_Control, Mensaje) VALUES
(2, 'LoginLabel1', 'Usuario'), 
(2, 'LoginLabel2', 'Clave'), 
(1, 'LoginBotton1', 'Login'), 
(1, 'LoginBotton2', 'Salir')

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------