
CREATE DATABASE POS_System;

USE POS_System;

CREATE TABLE Persons 
(
	PersonID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	FirstName NVARCHAR(30) NOT NULL ,
	LastName NVARCHAR(30) NOT NULL ,
	BirthDate DATETIME NOT NULL,
	PersonAddress NVARCHAR(30) NOT NULL 
)

CREATE TABLE Phones 
(
	PhoneID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	PhoneNumber NVARCHAR(30) NOT NULL ,
	PersonID INT NOT NULL,
	FOREIGN KEY(PersonID) REFERENCES Persons(PersonID)
)

CREATE TABLE Roles 
(
	RoleID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	RoleName NVARCHAR(30) NOT NULL
)  

CREATE TABLE Users 
(
	UserID INT IDENTITY(1,1) PRIMARY KEY NOT NULL , 
	PersonID INT NOT NULL ,
	RoleID INT NOT NULL ,
	IsActive BIT NOT NULL , 
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL ,
	FOREIGN KEY(PersonID) REFERENCES Persons(PersonID),
	FOREIGN KEY(RoleID) REFERENCES Roles(RoleID)
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PersonID INT NOT NULL ,
	IsActive BIT NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL ,
	FOREIGN KEY(PersonID) REFERENCES Persons(PersonID)
)

CREATE TABLE Suppliers
(
	SupplierID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PersonID INT NOT NULL ,
	IsActive BIT NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL ,
	FOREIGN KEY(PersonID) REFERENCES Persons(PersonID)
)

CREATE TABLE Categories
(
	CategoryID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CategotyName NVARCHAR(30) NOT NULL , 
	IsActive BIT NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL 
)

CREATE TABLE Products
(
	ProductID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	ProductName NVARCHAR(30) NOT NULL,
	BarCode NVARCHAR(50) NOT NULL,
	UNIQUE(BarCode),
	SellingPrice DECIMAL(6,2) NOT NULL,
	BuyingPrice DECIMAL(6,2) NOT NULL,
	StockQuantity INT NOT NULL , 
	IsActive BIT NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL ,
	CategoryID INT NOT NULL ,
	CreatedByUserID INT NOT NULL ,
	CHECK(BuyingPrice > 0),
	CHECK(SellingPrice > 0),
	CHECK(StockQuantity >= 0),
	FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID),
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID)
)

CREATE TABLE Purchases
(
	PurchaseID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	PurchaseDate DATETIME NOT NULL , 
	CreatedByUserID INT NOT NULL ,
	SupplierID INT NOT NULL ,
	IsDeleted BIT NOT NULL ,
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID),
	FOREIGN KEY(SupplierID) REFERENCES Suppliers(SupplierID),
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL 
)

CREATE TABLE PurchaseItems
(
	PurchaseItemID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	Quantity INT NOT NULL CHECK (Quantity > 0),
	UnitBuyingPrice DECIMAL(6,2) NOT NULL,
	ProductID INT NOT NULL ,
	PurchaseID INT NOT NULL ,
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	FOREIGN KEY(PurchaseID) REFERENCES Purchases(PurchaseID),
	CreatedAt DATETIME NOT NULL ,                                                            
	UpdatedAt DATETIME NOT NULL 
)

CREATE TABLE Sales 
(
	SaleID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	SaleDate DATETIME NOT NULL ,
	CreatedByUserID INT NOT NULL ,
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID),
	IsDeleted BIT NOT NULL ,
	Amount DECIMAL(10,2) NOT NULL CHECK (Amount > 0) ,
	DiscountAmount DECIMAL(6,2) NULL CHECK (DiscountAmount is null or DiscountAmount >= 0) , 
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL 
)

CREATE TABLE SaleItems 
(
	SaleItemID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	Quantity INT NOT NULL CHECK (Quantity > 0) , 
	ProductID INT NOT NULL ,
	SaleID INT NOT NULL ,
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	FOREIGN KEY(SaleID) REFERENCES Sales(SaleID),
	UnitSalePrice DECIMAL(6,2) NOT NULL,
	DiscountAmount DECIMAL(6,2) NULL CHECK (DiscountAmount is null or DiscountAmount >= 0) , 
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL 
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	CreatedByUserID INT NOT NULL ,
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID),
	Amount DECIMAL(10,2) NOT NULL CHECK (Amount > 0) ,
	ReferenceType TINYINT NOT NULL ,  --( 1 = sale , 2 = purchase)
	SaleID INT NULL ,
	PurchaseID INT NULL ,
	FOREIGN KEY(SaleID) REFERENCES Sales(SaleID),
	FOREIGN KEY(PurchaseID) REFERENCES Purchases(PurchaseID),
	IsDeleted BIT NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	UpdatedAt DATETIME NOT NULL ,
	CHECK 
	(
	(SaleID IS NOT NULL AND PurchaseID IS NULL) OR (SaleID IS NULL AND PurchaseID IS NOT NULL)
	)
)

CREATE TABLE StockAdjustment 
(
	AdjustmentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	CreatedByUserID INT NOT NULL ,
	AdjustmentDate DATETIME NOT NULL ,
	Reason NVARCHAR(100) NOT NULL ,
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID),
	CreatedAt DATETIME NOT NULL 
)

CREATE TABLE StockAdjustmentItem 
(
	AdjustmentItemID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	Quantity INT NOT NULL CHECK (Quantity > 0),
	ProductID INT NOT NULL ,
	AdjustmentID INT NOT NULL,
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	FOREIGN KEY(AdjustmentID) REFERENCES StockAdjustment(AdjustmentID)
)

CREATE TABLE StockMovements
(
	StockMovementID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	CreatedByUserID INT NOT NULL ,
	ProductID INT NOT NULL ,
	FOREIGN KEY(CreatedByUserID) REFERENCES Users(UserID),
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	Quantity INT NOT NULL ,  --( can be - or +)
	MovementType TINYINT NOT NULL , -- ( 1 = sale , 2 = purchase , 3 = adjustment)
	AdjustmentID INT NULL ,
	SaleID INT NULL ,
	PurchaseID INT NULL ,
	FOREIGN KEY(AdjustmentID) REFERENCES StockAdjustment(AdjustmentID),
	FOREIGN KEY(SaleID) REFERENCES Sales(SaleID),
	FOREIGN KEY(PurchaseID) REFERENCES Purchases(PurchaseID),
	CreatedAt DATETIME NOT NULL 
)

CREATE TABLE Settings 
(
	SettingID INT PRIMARY KEY NOT NULL CHECK (SettingID = 1) ,
	CompanyName NVARCHAR(50) NOT NULL ,
	CompanyLogo NVARCHAR(50) NULL ,
	Vat DECIMAL(5,2) NOT NULL DEFAULT 0 
)