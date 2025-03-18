use master;
CREATE DATABASE S_MyBase3
on primary 
(name = N'S_MyBase3_mdf',filename = N'C:\sqltest\S_MyBase3_mdf.mdf',
size = 10240Kb, maxsize = unlimited, filegrowth = 1024Kb),

filegroup FG1
(name = N'S_MyBase3 fg1 1',filename = N'C:\sqltest\S_MyBase3 fgq-1.ndf',
size = 10240kb, maxsize = 1Gb, filegrowth = 25%),
(name = N'S_MyBase3 fg1 2',filename = N'C:\sqltest\S_MyBase3 fgq-2.ndf',
size = 10240kb, maxsize = 1Gb, filegrowth = 25%)
log on
(name = N'S_MyBase3 log',filename = N'C:\sqltest\S_MyBase3 log.ldf',
size = 10240kb, maxsize = 2048Gb, filegrowth = 10%)

--задание 1 и 6



