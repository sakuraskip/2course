use S_MyBase3
declare @названиеоборудования nvarchar(50);

declare оборудованиеcursor cursor for 
select rtrim([название оборудования]) 
from оборудование;

open оборудованиеcursor;

fetch next from оборудованиеcursor into @названиеоборудования;

while @@fetch_status = 0
begin
    print @названиеоборудования;
    fetch next from оборудованиеcursor into @названиеоборудования;
end;

close оборудованиеcursor;
deallocate оборудованиеcursor;
go
declare @названиеоборудования nvarchar(50);

declare локальныйcursor cursor local for 
select [название оборудования] 
from оборудование;

declare глобальныйcursor cursor global for 
select [название оборудования] 
from оборудование;

open локальныйcursor;
fetch next from локальныйcursor into @названиеоборудования;
print 'локальный курсор: ' + @названиеоборудования;
close локальныйcursor;

open глобальныйcursor;
fetch next from глобальныйcursor into @названиеоборудования;
print 'глобальный курсор: ' + @названиеоборудования;
fetch next from глобальныйcursor into @названиеоборудования;
print 'глобальный курсор 2: ' + @названиеоборудования;
close глобальныйcursor;

deallocate локальныйcursor;
deallocate глобальныйcursor;
go

declare @названиеоборудования nvarchar(50);

declare статическийcursor cursor static for 
select [название оборудования] 
from оборудование;

declare динамическийcursor cursor dynamic for 
select [название оборудования] 
from оборудование;

open статическийcursor;
fetch next from статическийcursor into @названиеоборудования;
print 'статический курсор: ' + @названиеоборудования;
close статическийcursor;

open динамическийcursor;
fetch next from динамическийcursor into @названиеоборудования;
print 'динамический курсор: ' + @названиеоборудования;
close динамическийcursor;

deallocate статическийcursor;
deallocate динамическийcursor;
go
declare @названиеоборудования nvarchar(50);
declare оборудованиеcursor cursor scroll for 
select [название оборудования] 
from оборудование;

open оборудованиеcursor;

fetch first from оборудованиеcursor into @названиеоборудования;
print 'первая строка: ' + @названиеоборудования;

fetch last from оборудованиеcursor into @названиеоборудования;
print 'последняя строка: ' + @названиеоборудования;

fetch absolute -1 from оборудованиеcursor into @названиеоборудования;
print 'предпоследняя строка: ' + @названиеоборудования;

close оборудованиеcursor;
deallocate оборудованиеcursor;
go
declare @номерсписания int, @названиеоборудования nvarchar(50);

declare списанияcursor cursor for 
select [номер списания], [название оборудования] 
from списания;

open списанияcursor;

fetch next from списанияcursor into @номерсписания, @названиеоборудования;

while @@fetch_status = 0
begin
    if @номерсписания % 2 = 0
    begin
        update списания set [название оборудования] = [Название оборудования]+'(обновлено)' where current of списанияcursor;
    end
    else
    begin
        delete from списания where current of списанияcursor;
    end;

    fetch next from списанияcursor into @номерсписания, @названиеоборудования;
end;

close списанияcursor;
deallocate списанияcursor;
go