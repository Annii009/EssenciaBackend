-- TABLA PRINCIPAL DE CAFETERÍA
CREATE TABLE ProductosCafeteria (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(50) NOT NULL, -- Bebida o Comida
    ImagenRuta NVARCHAR(255),
    Descripcion NVARCHAR(500),
    PrecioEuros DECIMAL(10, 2) NOT NULL
);

-- TABLA PARA NORMALIZAR INGREDIENTES
CREATE TABLE IngredientesCafeteria (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT FOREIGN KEY REFERENCES ProductosCafeteria(ID) NOT NULL,
    Ingrediente NVARCHAR(100) NOT NULL
);

-- TABLA PARA NORMALIZAR ALÉRGENOS
CREATE TABLE AlergenosCafeteria (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT FOREIGN KEY REFERENCES ProductosCafeteria(ID) NOT NULL,
    Alergeno NVARCHAR(100) NOT NULL
);

-- TABLA PRINCIPAL DE FLORISTERÍA
CREATE TABLE ProductosFloristeria (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    ImagenRuta NVARCHAR(255),
    Detalle NVARCHAR(255),
    DescripcionCuidados NVARCHAR(MAX),
    PrecioEuros DECIMAL(10, 2) NOT NULL
);

------------------------------------------------
-- TABLA DE MESAS
------------------------------------------------
CREATE TABLE Mesas (
    ID INT PRIMARY KEY,
    NumeroMesa INT NOT NULL UNIQUE,
    Capacidad INT NOT NULL,
    Disponible BIT NOT NULL,
    Ubicacion NVARCHAR(50) 
);

------------------------------------------------
-- TABLA DE PEDIDOS
------------------------------------------------
CREATE TABLE Pedidos (
    ID INT IDENTITY(1000,1) PRIMARY KEY,
    MesaID INT FOREIGN KEY REFERENCES Mesas(ID) NOT NULL,
    FechaHoraPedido DATETIME2 NOT NULL,
    PedidoCompletado BIT NOT NULL DEFAULT 0, 
    Total DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    Notas NVARCHAR(500)
);

------------------------------------------------
-- TABLA DE DETALLE DE PEDIDO (Para enlazar productos con pedidos)
------------------------------------------------
CREATE TABLE DetallePedido (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    PedidoID INT FOREIGN KEY REFERENCES Pedidos(ID) NOT NULL,
    ProductoCafeteriaID INT FOREIGN KEY REFERENCES ProductosCafeteria(ID) NULL, -- Puede ser nulo si pides solo flores
    ProductoFloristeriaID INT FOREIGN KEY REFERENCES ProductosFloristeria(ID) NULL, -- Puede ser nulo si pides solo comida
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL
);