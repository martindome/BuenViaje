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
    ID_Texto varchar(100),
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
    Nombre varchar (100),
    Apellido varchar (100),
    DNI varchar (50),
    Email varchar (100),
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
    Nombre varchar (100) not null,
    Apellido varchar (100) not null,
    Nombre_Usuario varchar (100) not null,
    Contrasenia varchar (MAX) not null,
    DVH varchar (MAX) not null,
    Intentos_Login bigint not null,
    ID_Idioma bigint not null,
    FOREIGN KEY (ID_Idioma) references Idioma (ID_Idioma) on delete no action,
    PRIMARY KEY CLUSTERED (ID_Usuario)
);

Create Table Permiso(
    ID_Permiso bigint not null,
    Nombre varchar(50) not null,
    Descripcion varchar(max) not null,
    Tipo_Permiso varchar(200) not null,
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
    --Descripcion varchar(max) not null,
    DVH varchar(MAX) not null,
    PRIMARY KEY CLUSTERED (ID_Usuario, ID_Permiso),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) on delete cascade,
    FOREIGN KEY (ID_Permiso) REFERENCES Permiso (ID_Permiso) on delete CASCADE 
);

Create Table Usuario_Familia(
    ID_Usuario bigint not null,
    ID_Familia bigint not null,
    --Descripcion varchar(max) not null,
    DVH varchar(MAX) not null,
    PRIMARY KEY CLUSTERED (ID_Usuario, ID_Familia),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) on delete CASCADE,
    FOREIGN KEY (ID_Familia) REFERENCES Familia (ID_Familia) on delete CASCADE 
);

Create Table Permiso_Familia(
    ID_Permiso bigint not null,
    ID_Familia bigint not null,
    --Descripcion varchar(max) not null,
    DVH varchar(MAX) not null,
    PRIMARY KEY CLUSTERED (ID_Permiso, ID_Familia),
    FOREIGN KEY (ID_Permiso) REFERENCES Permiso (ID_Permiso) on delete CASCADE,
    FOREIGN KEY (ID_Familia) REFERENCES Familia (ID_Familia) on delete CASCADE 
);

Create Table Bitacora(
    ID_Bitacora bigint not null,
    Fecha Datetime not null,
    Tipo_Evento varchar (50),
    Descripcion varchar (MAX),
    DVH varchar (MAX),
    Nombre_Usuario varchar (100) not null,
    PRIMARY KEY CLUSTERED (ID_Bitacora)
    ---FOREIGN KEY (ID_Usuario) REFERENCES Usuario (ID_Usuario) ON DELETE No action
);

Create Table Bus(
    ID_Bus bigint not null,
    Patente varchar(50) not null,
    Marca varchar(50) not null,
    Asientos int not null,
    DVH varchar (MAX) not null,
    PRIMARY KEY CLUSTERED(ID_Bus)
);

Create Table Localidad (
    ID_Localidad bigint not null,
    Nombre varchar(100) not null,
    Provincia varchar(100) not null,
    Pais varchar(100) not null,
	Primary Key Clustered (ID_Localidad)
)

Create table Ruta(
    ID_Ruta bigint not null,
    Nombre varchar (MAX),
    Origen bigint,
    Destino bigint,
    Duracion int not null,
    DVH varchar (MAX) not null,
    PRIMARY KEY CLUSTERED(ID_Ruta)
    -- FOREIGN KEY (Destino) REFERENCES Localidad (ID_Localidad) on delete cascade,
    -- FOREIGN KEY (Origen) REFERENCES Localidad (ID_Localidad) on delete cascade
);

Create Table Viaje(
    ID_Viaje bigint not null,
    ID_Ruta bigint,
    ID_Bus bigint,
    Fecha Datetime not null,
    Cancelado bit not null,
    DVH varchar (MAX) not null,
    PRIMARY KEY CLUSTERED(ID_Viaje),
    FOREIGN KEY (ID_Ruta) REFERENCES Ruta (ID_Ruta) on delete cascade,
    FOREIGN KEY (ID_Bus) REFERENCES Bus (ID_Bus) on delete cascade
);

Create Table Pasaje(
    ID_Pasaje bigint not null,
    ID_Viaje bigint not null,
    ID_Cliente bigint, 
    Fecha datetime not null,
    Devuelto bit not null,
    DVH varchar (MAX) not null,
    PRIMARY KEY CLUSTERED (ID_Pasaje),
    FOREIGN KEY (ID_Viaje) REFERENCES Viaje (ID_Viaje) on delete no action,
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente (ID_Cliente) on delete no action
);

Create Table Digito_Verificador(
    ID_Digito_Verificador bigint not null,
    Tabla varchar (50) not null,
    DVV bigint not null,
    Primary key clustered (ID_Digito_Verificador)
);