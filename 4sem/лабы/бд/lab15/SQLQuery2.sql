use S_MyBase3

create table TR_AUDIT(
id int identity,
STMT varchar(20) check (STMT in ('INS','UPD','DEL')),
TRNAME varchar(50),
CC varchar(300))

go
create trigger TRIG_TEACHER_INS on TEACHER after INSERT
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from inserted);
declare @a2 varchar(50);set @a2 = (select TEACHER from inserted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_TEACHER_INS',@ret);
return;
go