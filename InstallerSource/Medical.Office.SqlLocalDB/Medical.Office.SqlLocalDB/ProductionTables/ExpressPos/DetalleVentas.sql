-- Tabla de DetalleVentas
CREATE TABLE DetalleVentas (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    VentaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    IDPatient BIGINT NULL,  -- ← agrega la coma aquí
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);
