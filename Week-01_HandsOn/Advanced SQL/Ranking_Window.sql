CREATE DATABASE OnlineRetailStore;
GO

USE OnlineRetailStore;
GO

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Brand NVARCHAR(50) NOT NULL,
    StockQuantity INT DEFAULT 0,
    CreatedDate DATETIME2 DEFAULT GETDATE()
);
GO

INSERT INTO Products (ProductName, Category, Price, Brand, StockQuantity) VALUES
-- Electronics Category
('iPhone 15 Pro', 'Electronics', 1199.99, 'Apple', 50),
('Samsung Galaxy S24', 'Electronics', 999.99, 'Samsung', 75),
('MacBook Pro 16"', 'Electronics', 2499.99, 'Apple', 25),
('Dell XPS 13', 'Electronics', 1299.99, 'Dell', 30),

-- Clothing Category
('Nike Air Max', 'Clothing', 129.99, 'Nike', 100),
('Levi''s 501 Jeans', 'Clothing', 89.99, 'Levis', 150),
('Adidas Ultraboost', 'Clothing', 180.00, 'Adidas', 80),
('North Face Jacket', 'Clothing', 249.99, 'North Face', 45),

-- Home & Garden Category
('Dyson V15 Vacuum', 'Home & Garden', 749.99, 'Dyson', 35),
('KitchenAid Mixer', 'Home & Garden', 399.99, 'KitchenAid', 25),
('Instant Pot Pro', 'Home & Garden', 149.99, 'Instant Pot', 60),
('Roomba i7+', 'Home & Garden', 599.99, 'iRobot', 15),

-- Sports Category
('Peloton Bike', 'Sports', 1445.00, 'Peloton', 10),
('Bowflex Dumbbells', 'Sports', 349.99, 'Bowflex', 25),
('Yoga Mat Premium', 'Sports', 79.99, 'Manduka', 150),
('Resistance Bands Set', 'Sports', 29.99, 'Fit Simplify', 200);
GO

SELECT 'Database and table created successfully!' AS Status;

SELECT 
    'Total Products: ' + CAST(COUNT(*) AS VARCHAR(10)) AS Summary
FROM Products;

SELECT 
    Category,
    COUNT(*) AS ProductCount,
    MIN(Price) AS MinPrice,
    MAX(Price) AS MaxPrice
FROM Products
GROUP BY Category
ORDER BY Category;

//Query:

USE OnlineRetailStore;
GO

SELECT 'ROW_NUMBER() - Assigns unique sequential ranks' AS RankingType;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products
ORDER BY Category, Price DESC;
GO

SELECT 'RANK() - Leaves gaps after tied ranks' AS RankingType;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products
ORDER BY Category, Price DESC;
GO

SELECT 'DENSE_RANK() - No gaps after tied ranks' AS RankingType;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products
ORDER BY Category, Price DESC;
GO

SELECT 'COMPARISON: All Three Ranking Functions' AS ComparisonType;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products
ORDER BY Category, Price DESC;
GO

SELECT 'TOP 3 Products per Category using ROW_NUMBER()' AS ResultType;

WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        Brand,
        StockQuantity,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    StockQuantity,
    RowNum
FROM RankedProducts
WHERE RowNum <= 3
ORDER BY Category, RowNum;
GO

SELECT 'TOP 3 Products per Category using RANK()' AS ResultType;

WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        Brand,
        StockQuantity,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    StockQuantity,
    RankNum
FROM RankedProducts
WHERE RankNum <= 3
ORDER BY Category, RankNum;
GO

SELECT 'TOP 3 Products per Category using DENSE_RANK()' AS ResultType;

WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        Brand,
        StockQuantity,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    Brand,
    StockQuantity,
    DenseRankNum
FROM RankedProducts
WHERE DenseRankNum <= 3
ORDER BY Category, DenseRankNum;
GO
