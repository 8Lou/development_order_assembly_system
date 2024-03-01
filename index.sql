CREATE TABLE Nomenclature (
    NomenclatureID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Type NVARCHAR(50)
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
GO
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

CREATE PROCEDURE CalculateAssemblyTime
    @AssemblySiteID INT
AS
BEGIN
    DECLARE @TotalAssemblyTime INT;

    SELECT @TotalAssemblyTime = SUM(AssemblyTime)
    FROM AssemblySites
    WHERE AssemblySiteID = @AssemblySiteID;

    SELECT @TotalAssemblyTime;
END;

GO