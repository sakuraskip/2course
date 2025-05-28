drop table TR_AUDIT
go
create table TR_AUDIT(
id int identity,
STMT varchar(20) check (STMT in ('INS','UPD','DEL')),
TRNAME varchar(50),
CC varchar(300))
go
drop trigger TRIG_TEACHER_INS
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
delete from TEACHER where TEACHER = 'брддрб';
insert into TEACHER(TEACHER,TEACHER_NAME) values ('брддрб','Баринов Дмитрий Дробович')

--task2
go
drop trigger TR_TEACHER_DEL
go
create trigger TR_TEACHER_DEL on TEACHER after DELETE
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from deleted);
declare @a2 varchar(50);set @a2 = (select TEACHER from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TRIG_TEACHER_DEL',@ret);
return;
go
delete from TEACHER where TEACHER = 'брддрб';
insert into TEACHER(TEACHER,TEACHER_NAME) values ('брддрб','Баринов Дмитрий Дробович')

--task3
go
drop trigger TR_TEACHER_UPD
go
create trigger TR_TEACHER_UPD on TEACHER after UPDATE
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from inserted);
declare @a2 varchar(50);set @a2 = (select TEACHER from inserted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('UPD','TRIG_TEACHER_UPD',@ret);
return;
go
update TEACHER set TEACHER_NAME = 'арррр' where TEACHER = 'брддрб';

--task4
go
drop trigger TR_TEACHER
go
create trigger TR_TEACHER on TEACHER after INSERT,DELETE,update
as
declare @a1 varchar(50);
declare @a2 varchar(50);
declare @ret varchar(500);
declare @ins int = (select count(*) from inserted),
 @del int = (select count(*) from deleted);

if @ins >0 and @del =0
begin
set @a1 = (select TEACHER_NAME from inserted);
set @a2 = (select TEACHER from inserted);
set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_TEACHER',@ret);
end;
else if @ins = 0 and @del>0
begin
set @a1 = (select TEACHER_NAME from deleted);
set @a2 = (select TEACHER from deleted);
set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TRIG_TEACHER',@ret);
end;
else begin
set @a1 = (select TEACHER_NAME from inserted);
set @a2 = (select TEACHER from inserted);
set @ret = @a1 + ' '+@a2;
set @a1 = (select TEACHER_NAME from deleted);
set @a2 = (select TEACHER from deleted);
set @ret = @a1 + ' '+@a2 + @ret;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('UPD','TRIG_TEACHER',@ret);
end;
return;
go
delete from TEACHER where TEACHER = 'брддрб';
insert into TEACHER(TEACHER,TEACHER_NAME) values ('брддрб','Баринов Дмитрий Дробович')
update TEACHER set TEACHER_NAME = 'арррр' where TEACHER = 'брддрб';
select * from TR_AUDIT

--task5
go
insert into TEACHER(TEACHER,GENDER) values ('ррбр','щ')
select * from TR_AUDIT
--task6

go
drop trigger TR_TEACHER_DEL1
go
create trigger TR_TEACHER_DEL1 on TEACHER after DELETE
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from deleted);
declare @a2 varchar(50);set @a2 = (select TEACHER from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TRIG_TEACHER_DEL1',@ret);
return;
go

drop trigger TR_TEACHER_DEL2
go
create trigger TR_TEACHER_DEL2 on TEACHER after DELETE
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from deleted);
declare @a2 varchar(50);set @a2 = (select TEACHER from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TRIG_TEACHER_DEL2',@ret);
return;


drop trigger TR_TEACHER_DEL3
go
create trigger TR_TEACHER_DEL3 on TEACHER after DELETE
as
declare @a1 varchar(50); set @a1 = (select TEACHER_NAME from deleted);
declare @a2 varchar(50);set @a2 = (select TEACHER from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TRIG_TEACHER_DEL3',@ret);
return;
go
delete from TEACHER where TEACHER = 'брддрб';
insert into TEACHER(TEACHER,TEACHER_NAME) values ('брддрб','Баринов Дмитрий Дробович')

exec sp_settriggerorder @triggername = 'TR_TEACHER_DEL3',@order = 'First',@stmttype = 'DELETE';
exec sp_settriggerorder @triggername = 'TR_TEACHER_DEL1',@order = 'Last',@stmttype = 'DELETE';
select t.name, e.type_desc
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'TEACHER' and 
	                                                                        e.type_desc = 'DELETE' ;  

--task 7
go
drop trigger tran_trig
go
create trigger tran_trig on AUDITORIUM after insert,delete,update
as
if(select AUDITORIUM_CAPACITY from inserted)>200 or (select AUDITORIUM_CAPACITY from deleted) > 200
begin
raiserror('вместимость аудитории не больше 200',10,1);
rollback;
end;
return;
go
insert into AUDITORIUM(AUDITORIUM,AUDITORIUM_CAPACITY,AUDITORIUM_NAME,AUDITORIUM_TYPE)
values('520-1',300,'727auditname','ЛК')

--task8	
go
drop trigger univer_instead
go
create trigger univer_instead on FACULTY instead of delete
as 
raiserror('удалять факультеты нельзя',10,1);
return;
go
delete from FACULTY where FACULTY.FACULTY_NAME like '%а%';

--task9
go
drop trigger block_univer on database
go
create trigger block_univer on database for DDL_DATABASE_LEVEL_EVENTS as
declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
  declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
  declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 

  if @t1 = 'TEACHER'
  begin
       print 'Тип события: '+@t;
       print 'Имя объекта: '+@t1;
       print 'Тип объекта: '+@t2;
       raiserror( N'операции с таблицей UNIVER запрещены', 16, 1);  
       rollback;    
	   end;
	   go

	   alter table TEACHER add  gender12 varchar(50)
	   alter table teacher drop column gender12
