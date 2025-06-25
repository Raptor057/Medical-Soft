CREATE TABLE [dbo].[InventoryMovements] (
    MovementId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the inventory movement | ES: Identificador único del movimiento de inventario
    ProductId INT NOT NULL, -- EN: Foreign key reference to the product | ES: Referencia al producto
    MovementType NVARCHAR(50) NOT NULL, -- EN: Type of movement (inbound, outbound, adjustment) | ES: Tipo de movimiento (entrada, salida, ajuste)
    Quantity INT NOT NULL, -- EN: Quantity of products affected by the movement | ES: Cantidad de productos afectados por el movimiento
    MovementDate DATETIME NOT NULL DEFAULT GETDATE(), -- EN: Date of the movement | ES: Fecha del movimiento
    Description NVARCHAR(255), -- EN: Description or reason for the movement (e.g., Sale, Inventory Adjustment) | ES: Descripción o motivo del movimiento (por ejemplo, Venta, Ajuste de inventario)
    CONSTRAINT [FK_InventoryMovements_ToProducts] FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);