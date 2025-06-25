-- Tabla de Productos
CREATE TABLE Productos (
    ProductoID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Precio REAL NOT NULL,
    Stock INTEGER NOT NULL
);
