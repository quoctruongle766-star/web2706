IF DB_ID(N'BookStoreDB') IS NULL
    CREATE DATABASE BookStoreDB;
GO
USE BookStoreDB;
GO

CREATE TABLE Publisher
(
    PublisherId int IDENTITY PRIMARY KEY,
    PublisherName nvarchar(200),
    Phone varchar(30),
    Address nvarchar(200)
);
GO

CREATE TABLE Category
(
    CategoryId int IDENTITY PRIMARY KEY,
    CategoryName nvarchar(100)
);
GO

CREATE TABLE Book
(
    BookId varchar(10) PRIMARY KEY,
    Title nvarchar(200) NOT NULL,
    Author nvarchar(100),
    Release int,
    Price float,
    Description ntext,
    Picture nvarchar(100),
    PublisherId int FOREIGN KEY REFERENCES Publisher(PublisherId),
    CategoryId int FOREIGN KEY REFERENCES Category(CategoryId)
);
GO

CREATE TABLE Account
(
    AccountId varchar(36) PRIMARY KEY,
    Username varchar(64) NOT NULL,
    Password varchar(256),
    FullName nvarchar(100),
    Picture varchar(512),
    Email varchar(64),
    Address nvarchar(512),
    Phone varchar(64),
    IsAdmin bit,
    Active bit
);
GO

CREATE TABLE OrderBook
(
    OrderId varchar(16) PRIMARY KEY,
    OrderDate datetime,
    AccountId varchar(36) FOREIGN KEY REFERENCES Account(AccountId),
    ReceiveAddress nvarchar(512),
    ReceivePhone varchar(64),
    OrderReceive datetime,
    Note nvarchar(512),
    Status varchar(16)
);
GO

CREATE TABLE OrderDetail
(
    OrderDetailId int IDENTITY PRIMARY KEY,
    OrderId varchar(16) FOREIGN KEY REFERENCES OrderBook(OrderId),
    BookId varchar(10) FOREIGN KEY REFERENCES Book(BookId),
    Quantity int,
    Price int,
    TotalMoney AS Quantity * Price
);
GO

INSERT INTO Publisher VALUES
(N'Nhà xuất bản trẻ','098746533',N'Hà Nội'),
(N'Nhà xuất bản kim đồng','096833435',N'Hà Nội'),
(N'Nhà xuất bản tri thức','097987653',N'Hà Nội'),
(N'Nhà xuất bản giáo dục','091956464',N'Hà Nội'),
(N'Nhà xuất bản lao động','091956464',N'Hà Nội');

INSERT INTO Category VALUES
(N'Sách kinh tế'),(N'Sách tin học'),(N'Sách thiếu nhi'),
(N'Sách nấu ăn'),(N'Sách văn học');

INSERT INTO Book VALUES
('P67934',N'Đường Đến Thành Công Của Jack Ma',N'Brad Schepp, Debra Schepp',2015,250000,N'chưa có mô tả','images/books/P67934.jpg',5,1),
('P68050',N'Đừng Bao Giờ Đi Ăn Một Mình',N'Tahl Raz, Keith Ferrazzi',2016,95000,N'chưa có mô tả','images/books/P68050.jpg',1,1),
('P68066',N'Vô Thường',N'Nguyễn Bảo Trung',2016,75000,N'chưa có mô tả','images/books/P68066.jpg',5,5),
('P68009',N'Siêu Mèo Capoo',N'Á Lạp',2016,5800,N'chưa có mô tả','images/books/P68009.jpg',2,3),
('P67842',N'Shin - Cậu Bé Bút Chì',N'Yoshito Usui ',2016,18000,N'chưa có mô tả','images/books/P67842.jpg',2,3),
('P67848',N'Chie - Cô Bé Hạt Tiêu',N'Etsumi Haruki',2016,28000,N'chưa có mô tả','images/books/P67848.jpg',2,3),
('P63952',N'Kung Fu Panda',N'Ngọc Linh',2016,28500,N'chưa có mô tả','images/books/P63952.jpg',2,3),
('P68102',N'Dạy Con Làm Giàu - Tập 9: Những Bí Mật Về Tiền Bạc Mà Bạn Không Học Ở Nhà Trường!',N'Robert T. Kiyosaki',2015,32000,N'chưa có mô tả','images/books/P68102.jpg',1,1),
('P68101',N'Dạy Con Làm Giàu - Tập 8: Để Có Những Đồng Tiền Tích Cực',N'Robert T. Kiyosaki',2015,32000,N'chưa có mô tả','images/books/P68101.jpg',1,1),
('P67957',N'36 Kế Trong Kinh Doanh Hiện Đại',N'Lan Bercu',2016,95000,N'chưa có mô tả','images/books/P67957.jpg',1,1),
('P67821',N'Mật Mã Champa - Phát Hành Dự Kiến',N'Giản Tư Hải',2016,113000,N'chưa có mô tả','images/books/P67821.jpg',1,5),
('P67687',N'Vui buồn trong hộp',N'Đoàn Bảo Châu',2015,250000,N'chưa có mô tả','images/books/P67687.jpg',1,5);

-- Dùng AccountId cố định để khóa ngoại của đơn hàng mẫu khớp chính xác.
INSERT INTO Account VALUES
('56EDA78A-FBBD-4D29-8115-8D5DC366503F','admin',LOWER(CONVERT(VARCHAR(32), HashBytes('md5', 'admin123456'), 2)),N'Quốc Trưởng',NULL,'quoctruong@example.com','Hà Nam','0968018161',1,1),
('2B3E44B0-7F51-4B8B-9A21-02D4D6D9B102','member01',LOWER(CONVERT(VARCHAR(32), HashBytes('md5', 'member01123456'), 2)),N'Nguyễn Thị Hòa','images/members/hoant.jpg','baohoa@gmail.com','Hà Nam','0968018162',0,1);

INSERT INTO OrderBook VALUES
('20200526102704','2020-05-26','56EDA78A-FBBD-4D29-8115-8D5DC366503F',N'Hà Nam','0968018162',GETDATE(),N'Giao hàng giờ hành chính','New');

INSERT INTO OrderDetail(OrderId,BookId,Quantity,Price) VALUES
('20200526102704','P68050',2,95000),
('20200526102704','P67934',2,250000),
('20200526102704','P68102',1,32000);
GO
