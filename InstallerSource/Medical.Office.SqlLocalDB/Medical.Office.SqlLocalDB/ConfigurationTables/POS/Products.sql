CREATE TABLE [dbo].[Products] (
    ProductId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the product | ES: Identificador único para el producto
    ProductName NVARCHAR(100) NOT NULL, -- EN: Name of the product (e.g., Medication, Supplement) | ES: Nombre del producto (por ejemplo, Medicamento, Suplemento)
    Description NVARCHAR(255), -- EN: Description of the product | ES: Descripción del producto
    Price DECIMAL(18,2) NOT NULL, -- EN: Price of the product | ES: Precio del producto
    Stock INT NOT NULL, -- EN: Quantity available in inventory | ES: Cantidad disponible en inventario
    ProductCategoryName VARCHAR(100) NOT NULL, -- EN: Foreign key reference to the product category | ES: Referencia a la tabla de categorías de productos
    [IDORBarcode] NVARCHAR(50), -- EN: Barcode of the product (if applicable) | ES: Código de barras del producto (si aplica)
    CONSTRAINT [FK_Products_ToProductCategories] FOREIGN KEY (ProductCategoryName) REFERENCES ProductCategories(CategoryName)
     
);