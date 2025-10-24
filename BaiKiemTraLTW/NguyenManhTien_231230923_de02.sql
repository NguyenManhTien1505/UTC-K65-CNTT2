create database NguyenManhTien_231230923_de02
go
use NguyenManhTien_231230923_de02
go
CREATE TABLE NmtCatalog (
    nmtId INT IDENTITY(1,1) PRIMARY KEY,
    nmtCateName NVARCHAR(100),
    nmtCatePrice DECIMAL(18,2),
    nmtCateQty INT,
    nmtPicture NVARCHAR(255),
    nmtCateActive BIT
);
GO
INSERT INTO NmtCatalog (nmtCateName, nmtCatePrice, nmtCateQty, nmtPicture, nmtCateActive)
VALUES 
(N'Áo thun nam', 150000, 50, N'ao_nam.jpg', 1),
(N'Sách Cơ sở dữ liệu - Nguyen Manh Tien', 120000, 10, N'sach_csdl.jpg', 1),
(N'Balo laptop', 300000, 25, N'balo.jpg', 0);
GO

