CREATE TABLE [dbo].[CashMovements] (
    CashMovementId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the cash movement | ES: Identificador único del movimiento de efectivo
    CashRegisterId INT NOT NULL, -- EN: Foreign key reference to the associated cash register | ES: Referencia a la caja registradora asociada
    MovementDate DATETIME NOT NULL DEFAULT GETDATE(), -- EN: Date of the movement | ES: Fecha del movimiento
    MovementType NVARCHAR(50) NOT NULL, -- EN: Type of movement (income, expense) | ES: Tipo de movimiento (ingreso, gasto)
    Amount DECIMAL(18,2) NOT NULL, -- EN: Amount of the movement | ES: Monto del movimiento
    Description NVARCHAR(255), -- EN: Description of the movement (e.g., Sale, Cash Adjustment) | ES: Descripción del movimiento (por ejemplo, Venta, Ajuste de caja)
    CONSTRAINT [FK_CashMovements_ToCashRegisters] FOREIGN KEY (CashRegisterId) REFERENCES CashRegisters(CashRegisterId)
);