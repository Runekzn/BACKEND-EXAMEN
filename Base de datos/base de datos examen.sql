/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     06/03/2023 12:13:25 p. m.                    */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ENCUESTADO') and o.name = 'FK_ENCUESTA_PERSO-ENC_ENCUESTA')
alter table ENCUESTADO
   drop constraint "FK_ENCUESTA_PERSO-ENC_ENCUESTA"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"SUCUR-ENCUES"') and o.name = 'FK_SUCUR-EN_SUCUR-ENC_ENCUESTA')
alter table "SUCUR-ENCUES"
   drop constraint "FK_SUCUR-EN_SUCUR-ENC_ENCUESTA"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"SUCUR-ENCUES"') and o.name = 'FK_SUCUR-EN_SUCUR-ENC_SUCURSAL')
alter table "SUCUR-ENCUES"
   drop constraint "FK_SUCUR-EN_SUCUR-ENC_SUCURSAL"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENCUESTA')
            and   type = 'U')
   drop table ENCUESTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ENCUESTADO')
            and   name  = 'PERSO-ENCUETA_FK'
            and   indid > 0
            and   indid < 255)
   drop index ENCUESTADO."PERSO-ENCUETA_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENCUESTADO')
            and   type = 'U')
   drop table ENCUESTADO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"SUCUR-ENCUES"')
            and   name  = 'SUCUR-ENCUES_FK'
            and   indid > 0
            and   indid < 255)
   drop index "SUCUR-ENCUES"."SUCUR-ENCUES_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"SUCUR-ENCUES"')
            and   name  = 'SUCUR-ENCUES2_FK'
            and   indid > 0
            and   indid < 255)
   drop index "SUCUR-ENCUES"."SUCUR-ENCUES2_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"SUCUR-ENCUES"')
            and   type = 'U')
   drop table "SUCUR-ENCUES"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUCURSALES')
            and   type = 'U')
   drop table SUCURSALES
go

/*==============================================================*/
/* Table: ENCUESTA                                              */
/*==============================================================*/
create table ENCUESTA (
   ID_ENCUESTA          int                  not null,
   PREGUNTA1            varchar(10)          not null,
   PREGUNTA2            varchar(10)          not null,
   PREGUNTA3            int                  not null,
   PREGUNTA4            int                  not null,
   PREGUNTA5            int                  not null,
   OBSERVACIONES        varchar(1000)        not null,
   sucursal             int                  not null,
   encuesta             varchar(10)          not null,
   constraint PK_ENCUESTA primary key (ID_ENCUESTA)
)
go

/*==============================================================*/
/* Table: ENCUESTADO                                            */
/*==============================================================*/
create table ENCUESTADO (
   CI_ENCUESTADO        varchar(10)          not null,
   ID_ENCUESTA          int                  null,
   NOMBRE_COMPLETO      varchar(1000)        not null,
   SEXO                 varchar(1)           not null,
   EDAD                 int                  not null,
   constraint PK_ENCUESTADO primary key (CI_ENCUESTADO)
)
go

/*==============================================================*/
/* Index: "PERSO-ENCUETA_FK"                                    */
/*==============================================================*/




create nonclustered index "PERSO-ENCUETA_FK" on ENCUESTADO (ID_ENCUESTA ASC)
go

/*==============================================================*/
/* Table: "SUCUR-ENCUES"                                        */
/*==============================================================*/
create table "SUCUR-ENCUES" (
   ID_ENCUESTA          int                  not null,
   ID_SUCURSALES        int                  not null,
   constraint "PK_SUCUR-ENCUES" primary key (ID_ENCUESTA, ID_SUCURSALES)
)
go

/*==============================================================*/
/* Index: "SUCUR-ENCUES2_FK"                                    */
/*==============================================================*/




create nonclustered index "SUCUR-ENCUES2_FK" on "SUCUR-ENCUES" (ID_SUCURSALES ASC)
go

/*==============================================================*/
/* Index: "SUCUR-ENCUES_FK"                                     */
/*==============================================================*/




create nonclustered index "SUCUR-ENCUES_FK" on "SUCUR-ENCUES" (ID_ENCUESTA ASC)
go

/*==============================================================*/
/* Table: SUCURSALES                                            */
/*==============================================================*/
create table SUCURSALES (
   ID_SUCURSALES        int                  not null,
   SUC_NOMBRE           varchar(100)         not null,
   SUC_CIUDAD           varchar(100)         not null,
   SUC_PROVINCIA        varchar(100)         not null,
   constraint PK_SUCURSALES primary key (ID_SUCURSALES)
)
go

alter table ENCUESTADO
   add constraint "FK_ENCUESTA_PERSO-ENC_ENCUESTA" foreign key (ID_ENCUESTA)
      references ENCUESTA (ID_ENCUESTA)
go

alter table "SUCUR-ENCUES"
   add constraint "FK_SUCUR-EN_SUCUR-ENC_ENCUESTA" foreign key (ID_ENCUESTA)
      references ENCUESTA (ID_ENCUESTA)
go

alter table "SUCUR-ENCUES"
   add constraint "FK_SUCUR-EN_SUCUR-ENC_SUCURSAL" foreign key (ID_SUCURSALES)
      references SUCURSALES (ID_SUCURSALES)
go

