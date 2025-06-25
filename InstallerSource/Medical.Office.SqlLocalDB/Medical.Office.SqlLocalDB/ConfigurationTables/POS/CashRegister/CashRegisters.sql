CREATE TABLE [dbo].[CashRegisters] (
    CashRegisterId INT PRIMARY KEY IDENTITY(1,1), -- EN: Unique identifier for the cash register | ES: Identificador único de la caja registradora
    RegisterName NVARCHAR(100) NOT NULL, -- EN: Name or description of the cash register | ES: Nombre o descripción de la caja registradora
    RegisterStatus NVARCHAR(50) NOT NULL, -- EN: Status of the cash register (open, closed) | ES: Estado de la caja registradora (abierta, cerrada)
    OpeningDate DATETIME NOT NULL, -- EN: Date and time of opening the cash register | ES: Fecha y hora de apertura de la caja registradora
    ClosingDate DATETIME, -- EN: Date and time of closing the cash register (if applicable) | ES: Fecha y hora de cierre de la caja registradora (si aplica)
    InitialBalance DECIMAL(18,2) NOT NULL, -- EN: Initial balance of the cash register at the time of opening | ES: Saldo inicial de la caja registradora en el momento de la apertura
    FinalBalance DECIMAL(18,2) -- EN: Final balance of the cash register at the time of closing (calculated) | ES: Saldo final de la caja registradora en el momento de cierre (calculado)
);
