use master;
CREATE DATABASE S_MyBase3
on primary 
(name = N'S_MyBase3_mdf',filename = N'C:\Users\леха\Desktop\2 курс\4sem\лабы\бд\lab3\S_MyBase3_mdf.mdf',
size = 10240Kb, maxsize = unlimited, filegrowth = 1024Kb)
log on 
(name = N'S_MyBase3_log', filename = N'C:\Users\леха\Desktop\2 курс\4sem\лабы\бд\lab3\S_MyBase3_log.ldf',
size = 10240Kb, maxsize = 2048GB, filegrowth = 10%),

filegroup FG1
(name = N'')