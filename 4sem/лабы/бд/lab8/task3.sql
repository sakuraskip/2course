--task 3
create view [Аудитории] as
select aud.AUDITORIUM[код],aud.[AUDITORIUM_NAME] from AUDITORIUM aud
where aud.AUDITORIUM_TYPE like 'ЛК%';
with SCHEMABINDING
