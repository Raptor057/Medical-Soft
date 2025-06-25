CREATE TABLE [dbo].[ReturnDetails] (
    ReturnDetailId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the return detail | ES: Identificador único del detalle de la devolución
    ReturnId INT NOT NULL, -- EN: Foreign key reference to the return | ES: Referencia a la devolución
    ProductId INT NOT NULL, -- EN: Foreign key reference to the returned product | ES: Referencia al producto devuelto
    Quantity INT NOT NULL, -- EN: Quantity returned | ES: Cantidad devuelta
    UnitPrice DECIMAL(18,2) NOT NULL, -- EN: Unit price of the returned product | ES: Precio unitario del producto devuelto
    Subtotal DECIMAL(18,2) NOT NULL, -- EN: Subtotal calculated as (Quantity * UnitPrice) | ES: Subtotal calculado (Cantidad * Precio unitario)
    CONSTRAINT [FK_ReturnDetails_ToReturnProducts] FOREIGN KEY (ReturnId) REFERENCES ReturnsProducts(ReturnId),
    CONSTRAINT [FK_ReturnDetails_ToProducts] FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);