use S_MyBase3

create table TR_AUDIT(
id int identity,
STMT varchar(20) check (STMT in ('INS','UPD','DEL')),
TRNAME varchar(50),
CC varchar(300))

go
create trigger TRIG_Списания_INS on Списания after INSERT
as
declare @a1 varchar(50); set @a1 = (select [Название оборудования] from inserted);
declare @a2 varchar(50);set @a2 = (select [Причина списания] from inserted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_Списания_INS',@ret);
return;
go

create trigger TRIG_Списания_DEL on Списания after Delete
as
declare @a1 varchar(50); set @a1 = (select [Название оборудования] from deleted);
declare @a2 varchar(50);set @a2 = (select [Причина списания] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_Списания_DEL',@ret);
return;
GO

create trigger TRIG_Списания_DEL1 on Списания after Delete
as
declare @a1 varchar(50); set @a1 = (select [Название оборудования] from deleted);
declare @a2 varchar(50);set @a2 = (select [Причина списания] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_Списания_DEL1',@ret);
return;
GO

create trigger TRIG_Списания_FULL on Списания after delete,update 
as
declare @ins int = (select count(*) from inserted),
 @del int = (select count(*) from deleted);
 if @ins > 0 and @del>0 begin
declare @a1 varchar(50); set @a1 = (select [Название оборудования] from deleted);
declare @a2 varchar(50);set @a2 = (select [Причина списания] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
set @a1 = (select [Название оборудования] from inserted);
set @a2 = (select [Причина списания] from inserted);
set @ret = @a1+ ' '+@a2 + ' '+@ret;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_Списания_full',@ret);
end;
return;
go
exec sp_settriggerorder @triggername = 'TRIG_Списания_DEL',@order = 'First',@stmttype = 'DELETE';
exec sp_settriggerorder @triggername = 'TRIG_Списания_DEL1',@order = 'Last',@stmttype = 'DELETE';
select t.name, e.type_desc
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'Списания' and 
	                                                                        e.type_desc = 'DELETE' ;  

--
go
drop trigger TRIG_Списания_before
go
create trigger TRIG_Списания_before on Списания instead of delete
as
declare @l1 varchar(100) = '';
set @l1 = @l1 +' нельзя удалить из списания'
raiserror(@l1,10,1);
return;
go
delete from Списания where [Название оборудования] like '%б%'
