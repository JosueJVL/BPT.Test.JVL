create database BTPJVL;
go

use BTPJVL;
go


create table estudiantes(
idEstudiante int identity(1,1) not null primary key,
nombre varchar(60),
fechaNacimiento dateTime not null
)

create table asignaciones(
idAsignacion int identity(1,1) not null primary key,
nombre varchar(60) not null
)

create table asignacionesEstudiantes(
id int identity(1,1) not null primary key,
idAsignacion int not null references asignaciones(idAsignacion),
idEstudiante int not null references estudiantes(idEstudiante), 
)