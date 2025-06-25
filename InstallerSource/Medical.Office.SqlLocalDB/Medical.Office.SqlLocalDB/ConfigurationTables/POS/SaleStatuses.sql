CREATE TABLE [dbo].[SaleStatuses] (
    SaleStatusId INT  IDENTITY(1,1), -- EN: Unique identifier for the sale status | ES: Identificador único del estado de la venta
    StatusName VARCHAR(50) NOT NULL -- EN: Name of the sale status (e.g., Completed, Canceled) | ES: Estado de la venta (por ejemplo, Completada, Cancelada)
, 
    PRIMARY KEY ([StatusName]));
