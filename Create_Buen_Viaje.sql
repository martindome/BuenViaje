Use BuenViaje

Create Table Backups(
    ID_Backup BIGINT NOT NULL,
    Filepath VARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED(ID_Backup)
);

Create Table Idioma (
    ID_Idioma bigint not null,
    Descripcion varchar(max),
    PRIMARY KEY CLUSTERED (ID_Idioma)
);

Create Table Texto(
    ID_Texto varchar(50),
    ID_Idioma bigint not null,
    Mensaje varchar(max),
    FOREIGN KEY (ID_Idioma) REFERENCES Idioma (ID_Idioma) on delete cascade,
    PRIMARY KEY CLUSTERED (ID_Texto, ID_Idioma)
);

Create Table Controles(
    ID_Control varchar(50),
    ID_Idioma bigint not null,
    Mensaje varchar(max),
    FOREIGN KEY (ID_Idioma) REFERENCES Idioma (ID_Idioma) on delete cascade,
    PRIMARY KEY CLUSTERED (ID_Control, ID_Idioma)
);

Create Table Cliente(
    ID_Cliente BIGINT Not null,
    Nombre varchar (50),
    Apellido varchar (50),
    DNI varchar (50),
    Email varchar (50),
    PRIMARY KEY CLUSTERED (ID_Cliente)
);

Create Table Telefono (
    ID_Telefono Bigint Not null,
    Numero varchar(50),
    ID_Cliente bigint not null,
    PRIMARY KEY CLUSTERED (ID_Telefono),
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente (ID_Cliente) ON DELETE NO Action 
);

Create Table Usuario(
    ID_Usuario bigint not null,
    Nombre varchar (50) not null,
    Apellido varchar (50) not null,
    Nombre_Usuario varchar (50) not null,
    Contrasenia varchar (50) not null,
    DVH varchar (50) not null,
    Intentos_Login bigint not null,
    ID_Idioma bigint not null,
    FOREIGN KEY (ID_Idioma) references Idioma (ID_Idioma) on delete no action,
    PRIMARY KEY CLUSTERED (ID_Usuario)
);

Create Table Permiso(
    ID_Permiso bigint not null,
    Nombre varchar(50) not null,
    Descripcion varchar(max) not null,
    PRIMARY KEY CLUSTERED(ID_Permiso)
);

Create Table Familia (
    ID_Familia bigint not null,
    Nombre varchar(50) not null,
    Descripcion varchar(max) not null,
    PRIMARY KEY CLUSTERED (ID_Familia)
);

Create Table Usuario_Permiso(
    ID_Usuario bigint not null,
    ID_Permiso bigint not null,
    Descripcion varchar(max) not null,
    DVH varchar(50) not null,
    PRIMARY KEY CLUSTERED (ID_Usuario, ID_Permiso),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) on delete no action,
    FOREIGN KEY (ID_Permiso) REFERENCES Permiso (ID_Permiso) on delete no action 
);

Create Table Usuario_Familia(
    ID_Usuario bigint not null,
    ID_Familia bigint not null,
    Descripcion varchar(max) not null,
    DVH varchar(50) not null,
    PRIMARY KEY CLUSTERED (ID_Usuario, ID_Familia),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) on delete no action,
    FOREIGN KEY (ID_Familia) REFERENCES Familia (ID_Familia) on delete no action 
);

Create Table Bitacora(
    ID_Bitacora bigint not null,
    Fecha datetime not null,
    Tipo_Evento varchar (50),
    Descripcion varchar (MAX),
    DVH varchar (50),
    ID_Usuario bigint not null,
    PRIMARY KEY CLUSTERED (ID_Bitacora),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) ON DELETE No action
);

Create Table Bus(
    ID_Bus bigint not null,
    Patente varchar(50) not null,
    Marca varchar(50) not null,
    Asientos int not null,
    DVH varchar(50) not null,
    PRIMARY KEY CLUSTERED(ID_Bus)
);

Create Table Localidad (
    ID_Localidad bigint not null,
    Nombre varchar(50) not null,
    Provinica varchar(50) not null,
    Pais varchar(50) not null,
	Primary Key Clustered (ID_Localidad)
)

Create table Ruta(
    ID_Ruta bigint not null,
    Origen bigint not null,
    Destino bigint not null,
    Descripcion varchar(max) not null,
    Duracion int not null,
    DVH varchar(50) not null,
    Nombre varchar(100) not null,
    PRIMARY KEY CLUSTERED(ID_Ruta),
    FOREIGN KEY (Destino) REFERENCES Localidad (ID_Localidad) on delete no action,
    FOREIGN KEY (Origen) REFERENCES Localidad (ID_Localidad) on delete no action
);

Create Table Viaje(
    ID_Viaje bigint not null,
    ID_Ruta bigint not null,
    ID_Bus bigint not null,
    Fecha datetime not null,
    Cancelado bit not null,
    PRIMARY KEY CLUSTERED(ID_Viaje),
    FOREIGN KEY (ID_Ruta) REFERENCES Ruta (ID_Ruta) on delete no action,
    FOREIGN KEY (ID_Bus) REFERENCES Bus (ID_Bus) on delete no action
);

Create Table Pasaje(
    ID_Pasaje bigint not null,
    ID_Usuario bigint not null,
    DVH varchar(50) not null,
    Fecha datetime not null,
    Descripcion varchar(max) not null,
    Aclaraciones varchar(50) not null,
    Devuelto varchar (50) not null,
    ID_Viaje bigint not null,
    ID_Cliente bigint not null,
    PRIMARY KEY CLUSTERED (ID_Pasaje),
    FOREIGN KEY (ID_Viaje) REFERENCES Viaje (ID_Viaje) on delete no action,
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente (ID_Cliente) on delete no action,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) on delete no action
);

Create Table Digito_Verificador(
    ID_DVV bigint not null,
    Tabla varchar (50) not null,
    DVV bigint not null,
    Primary key clustered (ID_DVV)
);