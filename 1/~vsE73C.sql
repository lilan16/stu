exec sp_databases;
exec sp_tables; 
select * from sys.tables
show sp_databases status
show create procedure sp_databases

if (object_id('proc_getMovieRecord','p')is not null)
drop proc proc_getMovieRecord
go
create proc proc_getMovieRecord
as
select top 1 * from dbo.moviedbs

exec proc_getMovieRecord

if (object_id('proc_getMovieRecordArgs','p')is not null)
drop proc proc_getMovieRecordArgs
go
create proc proc_getMovieRecordArgs(@topCount int =1,@outAllCount int output)
as
select top @topCount * from dbo.moviedbs
select count
go

insert into dbo.moviedbs(id,title,director,date) values(5,'5','5','2016-07-11')


----------------------------------------------

 --master db
select * from dbo.msreplication_options
--select * from dbo.spt_fallback_usg
--select * from dbo.spt_fallback_db
--select * from dbo.spt_fallback_dev
select * from dbo.spt_monitor
select * from sys.trace_xe_action_map
select * from sys.trace_xe_event_map


----------------------------------


--trigger

if(OBJECT_ID('tgr_afterInsert_TitleAdmin','tr') is not null)
drop trigger tgr_afterInsert_TitleAdmin
go

create trigger tgr_afterInsert_TitleAdmin
on dbo.moviedbs
after insert
as

declare @id int,@title varchar(20),@director varchar(20),@time datetime 

select @id=id,@title=title,@director=director,@time = date  from inserted
if @title= 'admin'
begin
	raisError('title is "admin" can not insert',16,11);
	rollback tran;
	print 'have rollback'
end

update title ,ok
update dbo.moviedbs set title=@title+'_trigger' where id=@id
print 'have updated'

out info,ok
print 'add record:'
print @title
print @director 
print @time

if @title='ttt'
raiserror('title = ""',16,8)
rollback

begin

declare @title
select @title=title from inserted
if @title='ttt'
raiserror('title = ""',16,8)
rollback

end 
go


-- test

--select count(*) from dbo.MovieDBs

--select getdate() 

--select * from dbo.MovieDBs where title is not null

--insert into dbo.moviedbs(id,title,director,date) values(6,'6','5',GETDATE())

--show proc status
--exec sp_helptext Procedure_Name
--insert into dbo.moviedbs(id,title,director,date) values(10,'admin22','5',GETDATE())


------------------------------------------
--0721 update
--  ~vs af6e.sql

 select * from move
select * from sys.objects

select * from sysphfg
select * from dbo.EventNotificationErrorsQueue;
select * from sys.ServiceBrokerQueue;
select * from sys.messages;


select * from dbo.moviedbs

declare @id int,
declare @title varchar
set @id=3

select @title=title from dbo.moviedbs where id =@id
update dbo.moviedbs set title='55' ,director='5555'  where id = 5

insert into dbo.moviedbs(id,title,director,date) values(5,'5','5','2016-07-11')
insert into dbo.moviedbs(id,title,director,date) values(6,'6','5','2016-07-11')

delete dbo.moviedbs where id>=5
select * into moviedbs_backup
from moviedbs

create database myDB
select * from dbo.spt_monitor

exec getdate()

=============
sql query 1
select * from sys.triggers;

disable trigger afterInsert on dbo.moviedbs;
disable trigger tgr_afterInsert_updatetitle on dbo.moviedbs;
disable trigger tgr_afterInsert_titleadmin on dbo.moviedbs
--disable trigger tgr_moviedbs_InsteadUpdate on dbo.moviedbs

update dbo.moviedbs set title='adminABC_Trigger' where id =10
===================

sql query 2
if(OBJECT_ID('tgr_moviedbs_InsteadUpdate','tr') is not null)
drop trigger tgr_moviedbs_InsteadUpdate
go

create trigger tgr_moviedbs_InsteadUpdate
on dbo.moviedbs
instead of update
as

declare @id int,@title varchar(20),@director varchar(20),@time datetime 

select @id=id,@title=title,@director=director,@time = date  from inserted
raisError('tgr_moviedbs_InsteadUpdate 触发',16,10);
print 'instead of update'