drop table articles
drop table chapters
drop table users

create table users(
	nikname nvarchar(255) primary key,
	name nvarchar(max),
	password nvarchar(max)
);

create table chapters(
	tag nvarchar(255) primary key,
	name nvarchar(max)
);

create table articles(
	id int primary key identity,
	tag nvarchar(255),
	title nvarchar(max),
	task nvarchar(max),
	author nvarchar(255),
	creationDate DateTime,
	solutionlink nvarchar(max),
	codelink nvarchar(max),
	fileslink nvarchar(max),
	foreign key(tag) references chapters (tag) on delete cascade,
	foreign key(author) references users (nikname) on delete cascade
);

insert into chapters values ('csh','C#')
insert into chapters values ('python','Python')
insert into chapters values ('linux','Linux/Unix')
insert into chapters values ('cpp','C++')
insert into chapters values ('net','Networks')
insert into chapters values ('sp','System Programing')
insert into chapters values ('etc','Etc')

select * from users
