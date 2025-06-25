CREATE TABLE [dbo].[SalesPromotions] (
    SalePromotionId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the sale promotion record | ES: Identificador único del registro de la promoción de venta
    SaleId INT NOT NULL, -- EN: Foreign key reference to the sale | ES: Referencia a la venta
    PromotionId INT NOT NULL, -- EN: Foreign key reference to the promotion applied | ES: Referencia a la promoción aplicada
    DiscountApplied DECIMAL(18,2) NOT NULL, -- EN: Value of the discount applied to the sale | ES: Valor del descuento aplicado a la venta
     CONSTRAINT [FK_SalesPromotions_ToSales] FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
     CONSTRAINT [FK_SalesPromotions_ToPromotions] FOREIGN KEY (PromotionId) REFERENCES Promotions(PromotionId)
);