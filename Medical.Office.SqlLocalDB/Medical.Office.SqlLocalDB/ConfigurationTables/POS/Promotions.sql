CREATE TABLE [dbo].[Promotions] (
    PromotionId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the promotion | ES: Identificador único de la promoción
    PromotionName NVARCHAR(100) NOT NULL, -- EN: Name of the promotion (e.g., Volume Discount, Buy One Get One Free) | ES: Nombre de la promoción (por ejemplo, Descuento por volumen, 2x1)
    Description NVARCHAR(255), -- EN: Description of the promotion | ES: Descripción de la promoción
    StartDate DATETIME NOT NULL, -- EN: Start date of the promotion | ES: Fecha de inicio de la promoción
    EndDate DATETIME NOT NULL, -- EN: End date of the promotion | ES: Fecha de fin de la promoción
    PromotionType NVARCHAR(50) NOT NULL, -- EN: Type of promotion (percentage, fixed amount, free product, etc.) | ES: Tipo de promoción (porcentaje, cantidad fija, producto gratis, etc.)
    Value DECIMAL(18,2) NOT NULL -- EN: Value of the discount or promotion (percentage, fixed amount) | ES: Valor del descuento o promoción (porcentaje, cantidad fija)
);
