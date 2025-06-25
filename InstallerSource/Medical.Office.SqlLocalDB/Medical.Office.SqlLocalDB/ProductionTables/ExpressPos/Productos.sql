-- Tabla de Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);
