-- Tabla de Productos
CREATE TABLE Productos (
    ProductoID INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre TEXT NOT NULL,
    Precio REAL NOT NULL,
    Stock INTEGER NOT NULL
);
