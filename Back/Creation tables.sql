CREATE TABLE Customer
(
	Id int PRIMARY KEY identity(1,1),
	Nickname nvarchar(50),
	Pass nvarchar(50),
	IsAdmin bit,
)

CREATE TABLE Comic
(
	Id int primary key identity(1,1),
	Title nvarchar(50),
	Writer nvarchar(50),
	CatergoryId int,
	Synopsis text,
	Content text,
	ThumbnailLink nvarchar(max),
	CoverLink nvarchar(max)
)

CREATE TABLE Category
(
	Id int primary key identity(1,1),
	Title nvarchar(50)
)

CREATE TABLE Favorite
(
	Id int primary key identity(1,1),
	CustomerId int,
	ComicId int
)
	