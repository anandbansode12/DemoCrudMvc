create database CrudMvcDb
go
use CrudMvcDb
go
create table Players(
PlayerID int primary key identity,
PlayerName varchar(max),
PlayerAge int,
PlayerAddress varchar(max),
PlayerJoiningDate datetime2(7)
)
go
insert into Players values ('Rohit Sharma', 35, 'Mumbai','2007/06/30')
go
select * from Players
