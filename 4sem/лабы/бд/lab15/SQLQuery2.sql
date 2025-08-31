use S_MyBase3

create table TR_AUDIT(
id int identity,
STMT varchar(20) check (STMT in ('INS','UPD','DEL')),
TRNAME varchar(50),
CC varchar(300))

go
create trigger TRIG_��������_INS on �������� after INSERT
as
declare @a1 varchar(50); set @a1 = (select [�������� ������������] from inserted);
declare @a2 varchar(50);set @a2 = (select [������� ��������] from inserted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_��������_INS',@ret);
return;
go

create trigger TRIG_��������_DEL on �������� after Delete
as
declare @a1 varchar(50); set @a1 = (select [�������� ������������] from deleted);
declare @a2 varchar(50);set @a2 = (select [������� ��������] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_��������_DEL',@ret);
return;
GO

create trigger TRIG_��������_DEL1 on �������� after Delete
as
declare @a1 varchar(50); set @a1 = (select [�������� ������������] from deleted);
declare @a2 varchar(50);set @a2 = (select [������� ��������] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
print @ret
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_��������_DEL1',@ret);
return;
GO

create trigger TRIG_��������_FULL on �������� after delete,update 
as
declare @ins int = (select count(*) from inserted),
 @del int = (select count(*) from deleted);
 if @ins > 0 and @del>0 begin
declare @a1 varchar(50); set @a1 = (select [�������� ������������] from deleted);
declare @a2 varchar(50);set @a2 = (select [������� ��������] from deleted);
declare @ret varchar(500); set @ret = @a1 + ' '+@a2;
set @a1 = (select [�������� ������������] from inserted);
set @a2 = (select [������� ��������] from inserted);
set @ret = @a1+ ' '+@a2 + ' '+@ret;
insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TRIG_��������_full',@ret);
end;
return;
go
exec sp_settriggerorder @triggername = 'TRIG_��������_DEL',@order = 'First',@stmttype = 'DELETE';
exec sp_settriggerorder @triggername = 'TRIG_��������_DEL1',@order = 'Last',@stmttype = 'DELETE';
select t.name, e.type_desc
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = '��������' and 
	                                                                        e.type_desc = 'DELETE' ;  

--
go
drop trigger TRIG_��������_before
go
create trigger TRIG_��������_before on �������� instead of delete
as
declare @l1 varchar(100) = '';
set @l1 = @l1 +' ������ ������� �� ��������'
raiserror(@l1,10,1);
return;
go
delete from �������� where [�������� ������������] like '%�%'
