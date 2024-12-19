-- Create Customers table
CREATE TABLE Customers
(
    Id          SERIAL PRIMARY KEY,
    Name        TEXT NOT NULL,
    PhoneNumber TEXT NOT NULL
);

-- Create Tables table
CREATE TABLE Tables
(
    Id          SERIAL PRIMARY KEY,
    TableNumber INT     NOT NULL,
    IsOccupied  BOOLEAN NOT NULL DEFAULT FALSE
);

-- Create MenuItems table
CREATE TABLE MenuItems
(
    Id       SERIAL PRIMARY KEY,
    Name     TEXT           NOT NULL,
    Price    DECIMAL(10, 2) NOT NULL,
    Category TEXT           NOT NULL
);

-- Create Orders table
CREATE TABLE Orders
(
    Id         SERIAL PRIMARY KEY,
    CustomerId INT REFERENCES Customers (Id),
    TableId    INT REFERENCES Tables (Id),
    Status     TEXT CHECK (Status IN ('В ожидании', 'Готовится', 'Подан', 'Завершен')) NOT NULL
);

-- Create OrderItems table
CREATE TABLE OrderItems
(
    Id         SERIAL PRIMARY KEY,
    OrderId    INT REFERENCES Orders (Id),
    MenuItemId INT REFERENCES MenuItems (Id)
);

-- Populate Customers table
INSERT INTO Customers (Name, PhoneNumber)
VALUES ('Иван Иванов', '+79001112233'),
       ('Мария Петрова', '+79002223344'),
       ('Дмитрий Смирнов', '+79003334455');

-- Populate Tables table
INSERT INTO Tables (TableNumber, IsOccupied)
VALUES (1, FALSE),
       (2, FALSE),
       (3, TRUE),
       (4, TRUE);

-- Populate MenuItems table
INSERT INTO MenuItems (Name, Price, Category)
VALUES ('Борщ', 250.00, 'Супы'),
       ('Цезарь', 300.00, 'Салаты'),
       ('Стейк', 700.00, 'Горячее'),
       ('Тирамису', 400.00, 'Десерты'),
       ('Чай', 100.00, 'Напитки');

-- Populate Orders table
INSERT INTO Orders (CustomerId, TableId, Status)
VALUES (1, 3, 'Готовится'),
       (2, 4, 'Подан');

-- Populate OrderItems table
INSERT INTO OrderItems (OrderId, MenuItemId)
VALUES (1, 1),
       (1, 3),
       (2, 2),
       (2, 4);
