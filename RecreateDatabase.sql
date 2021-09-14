USE BuenViaje
IF EXISTS(select * from sys.databases where name='BuenViaje')
DROP DATABASE BuenViaje

CREATE DATABASE BuenViaje