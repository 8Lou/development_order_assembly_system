CREATE TABLE Nomenclature (
    NomenclatureID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Type NVARCHAR(50),
    IsKit BIT
);

CREATE TABLE AssemblySites (
    AssemblySiteID INT PRIMARY KEY,
    Name NVARCHAR(100),
    NomenclatureID INT,
    AssemblyTime INT, 
    FOREIGN KEY (NomenclatureID) REFERENCES Nomenclature(NomenclatureID)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderNumber NVARCHAR(50),
    OrderDate DATE
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    NomenclatureID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (NomenclatureID) REFERENCES Nomenclature(NomenclatureID)
);

CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY,
    AssemblySiteID INT,
    NomenclatureID INT,
    Quantity INT,
    Type NVARCHAR(50),
    FOREIGN KEY (AssemblySiteID) REFERENCES AssemblySites(AssemblySiteID),
    FOREIGN KEY (NomenclatureID) REFERENCES Nomenclature(NomenclatureID)
);

-- Создаем таблицу KitComponents для хранения компонентов комплектов
CREATE TABLE KitComponents (
    KitID INT,
    ComponentID INT,
    PRIMARY KEY (KitID, ComponentID),
    FOREIGN KEY (KitID) REFERENCES Nomenclature(NomenclatureID),
    FOREIGN KEY (ComponentID) REFERENCES Nomenclature(NomenclatureID)
);

-- Добавляем столбец KitID в таблицу AssemblySites
ALTER TABLE AssemblySites
ADD KitID INT,
ScheduledAssemblies INT,
FOREIGN KEY (KitID) REFERENCES Nomenclature(NomenclatureID);

-- Создаем таблицу OrderCancellation для отмененных заказов
CREATE TABLE OrderCancellation (
    OrderID INT,
    CancellationDate DATE,
    AssemblySiteID INT,
    NomenclatureID INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (AssemblySiteID) REFERENCES AssemblySites(AssemblySiteID),
    FOREIGN KEY (NomenclatureID) REFERENCES Nomenclature(NomenclatureID)
);

-- Создаем таблицу InventoryFreeItems для свободных остатков на сборочных площадках
CREATE TABLE InventoryFreeItems (
    AssemblySiteID INT,
    NomenclatureID INT,
    Quantity INT,
    FOREIGN KEY (AssemblySiteID) REFERENCES AssemblySites(AssemblySiteID),
    FOREIGN KEY (NomenclatureID) REFERENCES Nomenclature(NomenclatureID)
);
Go
-- Хранимая процедура для добавления заказа с учетом отмененных заказов
CREATE PROCEDURE AddOrderWithCancellation
    @OrderNumber NVARCHAR(50),
    @OrderDate DATE,
    @OrderItems XML,
    @CancelledOrders XML
AS
BEGIN
    DECLARE @OrderID INT;

    INSERT INTO Orders (OrderNumber, OrderDate)
    VALUES (@OrderNumber, @OrderDate);

    SELECT @OrderID = SCOPE_IDENTITY();

    -- Добавление позиций заказа
    INSERT INTO OrderItems (OrderID, NomenclatureID, Quantity)
    SELECT @OrderID AS OrderID, 
           Item.value('(NomenclatureID/text())[1]', 'INT') AS NomenclatureID,
           Item.value('(Quantity/text())[1]', 'INT') AS Quantity
    FROM @OrderItems.nodes('/OrderItems/Item') AS OrderItems(Item);

    -- Обработка отмененных заказов
    INSERT INTO OrderCancellation (OrderID, CancellationDate, AssemblySiteID, NomenclatureID)
    SELECT 
           CancelledOrder.value('(OrderID/text())[1]', 'INT') AS OrderID,
           GETDATE() AS CancellationDate,
           CancelledOrder.value('(AssemblySiteID/text())[1]', 'INT') AS AssemblySiteID,
           CancelledOrder.value('(NomenclatureID/text())[1]', 'INT') AS NomenclatureID
    FROM @CancelledOrders.nodes('/CancelledOrders/Cancel') AS CancelledOrder;
END;

GO

-- Добавляем столбец IsKit для обозначения типа номенклатуры в таблице Nomenclature
ALTER TABLE Nomenclature
ADD IsKit BIT;
 Go
-- Хранимая процедура для расчета общего времени сборки на сборочных площадках
CREATE PROCEDURE CalculateAssemblyTime
    @AssemblySiteID INT
AS
BEGIN
    DECLARE @TotalAssemblyTime INT;

    SELECT @TotalAssemblyTime = SUM(AssemblyTime) AS TotalAssemblyTime
    FROM AssemblySites
    WHERE AssemblySiteID = @AssemblySiteID;

    SELECT @TotalAssemblyTime AS TotalAssemblyTime;
END;
GO
-- Хранимая процедура для добавления заказа
CREATE PROCEDURE AddOrder
    @OrderNumber NVARCHAR(50),
    @OrderDate DATE,
    @OrderItems XML
AS
BEGIN
    DECLARE @OrderID INT;

    INSERT INTO Orders (OrderNumber, OrderDate)
    VALUES (@OrderNumber, @OrderDate);

    SELECT @OrderID = SCOPE_IDENTITY();

    INSERT INTO OrderItems (OrderID, NomenclatureID, Quantity)
    SELECT @OrderID, 
           Item.value('(NomenclatureID/text())[1]', 'INT'),
           Item.value('(Quantity/text())[1]', 'INT')
    FROM @OrderItems.nodes('/OrderItems/Item') AS OrderItems(Item);
END;
GO