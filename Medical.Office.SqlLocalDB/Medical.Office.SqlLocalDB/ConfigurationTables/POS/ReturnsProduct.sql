CREATE TABLE [dbo].[ReturnsProducts]
(
    ReturnId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the return | ES: Identificador único de la devolución
    SaleId INT NOT NULL, -- EN: Foreign key reference to the associated sale | ES: Referencia a la venta asociada
    ReturnDate DATETIME NOT NULL, -- EN: Date of the return | ES: Fecha de la devolución
    RefundedAmount DECIMAL(18,2) NOT NULL, -- EN: Amount refunded to the client | ES: Monto reembolsado al cliente
    [ReturnStatusName] NVARCHAR(50) NOT NULL, -- EN: Foreign key reference to the return status | ES: Referencia al estado de la devolución
    CONSTRAINT [FK_ReturnsProductss_ToSales] FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    CONSTRAINT [FK_ReturnsProducts_ToReturnStatuses] FOREIGN KEY ([ReturnStatusName]) REFERENCES ReturnStatuses(StatusName)
);