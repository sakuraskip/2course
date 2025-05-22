use S_MyBase3
go
drop function fObor;
go

create function fObor(@param varchar(50)) returns int as
begin
declare @result int =0;

set @result = (select count(*) from Оборудование о inner join Списания с 
on о.[Название оборудования] = с.[Название оборудования] where
о.[Название оборудования] like @param)
return @result;
end;
go
declare @pr int  = dbo.fObor('%станок%');
print @pr

go


drop function списаниябольше3;
go
create function списаниябольше3()
returns nvarchar(max)
as
begin
    declare @результат nvarchar(max) = '';
    declare @номер_списания int, @название nvarchar(50), @количество int, 
            @причина nvarchar(50), @дата date, @ответственный varchar(50);

    declare списания_курсор cursor local for
    select c.[Номер списания],c.[Название оборудования],
	c.[Количество списанного оборудования],c.[Причина списания],c.[Дата списания],o.[Тип оборудования] from оборудование o inner join списания c on
    o.[название оборудования] = c.[название оборудования]
    where [количество списанного оборудования] > 3;

    open списания_курсор;
    fetch next from списания_курсор into @номер_списания, @название, @количество, @причина, @дата, @ответственный;
    
    while @@fetch_status = 0
    begin
        set @результат = @результат + 
            cast(@номер_списания as varchar)+ ': ' +
            @название + ' '+ cast(@количество as varchar(50)) + ' шт.' +
            'причина: ' + @причина + 
           + ' тип оборудования: ' + 
            @ответственный;
        
        fetch next from списания_курсор into @номер_списания, @название, @количество, @причина, @дата, @ответственный;
    end;

    close списания_курсор;
    deallocate списания_курсор;
    
    return @результат;
end;
go

print dbo.списаниябольше3();
--task3
go
drop function task3
go
create function task3(@name varchar(50)) returns table
as
return(
select * from Оборудование where Оборудование.[Название оборудования] = isnull(@name,Оборудование.[Название оборудования]))
go
select * from dbo.task3('Кран-балка')
go

--task4
drop function task4
go
create function task4(@type varchar(50)) returns int as
begin
declare @res int =0;
set @res = (select count(*) from Оборудование where Оборудование.[Тип оборудования] like @type);
return @res;
end;
go
select dbo.task4('%токарное%')[кол-во токарного оборудования]
