CREATE TABLE [dbo].[ReturnStatuses] (
    ReturnStatusId INT  IDENTITY(1,1), -- EN: Unique identifier for the return status | ES: Identificador único del estado de la devolución
    StatusName NVARCHAR(50) NOT NULL -- EN: Name of the return status (e.g., Processed, Rejected) | ES: Estado de la devolución (por ejemplo, Procesada, Rechazada)
, 
    PRIMARY KEY ([StatusName]));