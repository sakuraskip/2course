--task 3
create view [���������] as
select aud.AUDITORIUM[���],aud.[AUDITORIUM_NAME] from AUDITORIUM aud
where aud.AUDITORIUM_TYPE like '��%';
with SCHEMABINDING
