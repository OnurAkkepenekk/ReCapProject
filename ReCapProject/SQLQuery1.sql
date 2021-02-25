
Create Table Users(
	Id int Not NULL IDENTITY(1, 1),
	FirstName varchar(32),
	LastName varchar(32),
	Email varchar(52),
	[Password] varchar(32)
	CONSTRAINT PK_Users PRIMARY KEY (Id) 
)
Create Table Customers(
	Id int Not Null IDENTITY(1, 1),
	UserId int Not NULL,
	CompanyName varchar(32)
	CONSTRAINT PK_Customers PRIMARY KEY (UserId) 
	CONSTRAINT FK_Customers_Users FOREIGN KEY (UserId) REFERENCES Users (Id) ON UPDATE CASCADE ON DELETE CASCADE,
)

Create Table Rentals(
	Id int Not NULL IDENTITY(1, 1),
	CarId int Not Null,
	CustomerId int not null,
	RentDate Date,
	ReturnDate Date DEFAULT NULL,	
	CONSTRAINT PK_Rentals PRIMARY KEY (Id) ,
	CONSTRAINT FK_Rentals_Cars FOREIGN KEY (CarId) REFERENCES Cars(CarId) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Rentals_Customers FOREIGN KEY (CustomerId) REFERENCES Customers (UserId) ON UPDATE CASCADE ON DELETE CASCADE,
)
