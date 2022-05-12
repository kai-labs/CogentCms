
create table [dbo].[AppUser]
(
	AppUserId int identity(1,1) not null,
	FullName nvarchar(100) not null,
	IdProvider nvarchar(250) not null,
	SubjectId nvarchar(250) not null

	constraint PK_AppUser primary key (AppUserId)	
)
go

create index UX_AppUser_IdProviderSubjectId on AppUser(IdProvider,SubjectId)
go


create table [dbo].[BlogPost]
(
	BlogPostId int identity(1,1) not null,
		
	Title nvarchar(500) not null,
	Body nvarchar(max) not null,
	Slug nvarchar(500) not null,
	AuthorAppUserId int not null,
	PublishDate datetime null

	constraint PK_BlogPost primary key (BlogPostId),
	constraint FK_BlogPost_AppUser foreign key (AuthorAppUserId) references AppUser(AppUserId)
)

go

