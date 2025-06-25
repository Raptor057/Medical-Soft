CREATE TABLE [dbo].[SaleDetails] (
    SaleDetailId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the sale detail | ES: Identificador único del detalle de la venta
    SaleId INT NOT NULL, -- EN: Foreign key reference to the sale | ES: Referencia a la venta
    ProductId INT NOT NULL, -- EN: Foreign key reference to the product sold | ES: Referencia al producto vendido
    Quantity INT NOT NULL, -- EN: Quantity of products sold | ES: Cantidad de productos vendidos
    UnitPrice DECIMAL(18,2) NOT NULL, -- EN: Unit price of the product at the time of sale | ES: Precio unitario del producto en el momento de la venta
    Subtotal DECIMAL(18,2) NOT NULL, -- EN: Subtotal calculated as (Quantity * UnitPrice) | ES: Subtotal calculado (Cantidad * Precio unitario)
    FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);