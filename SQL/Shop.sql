-- TABELE
    CREATE TABLE Addresses (Id int(10) NOT NULL AUTO_INCREMENT, City varchar(60) NOT NULL, Street varchar(60) NOT NULL, Building varchar(10) NOT NULL, Apartment varchar(10), PostCode varchar(10) NOT NULL, PRIMARY KEY (Id));
    CREATE TABLE Baskets (ProductId int(10) NOT NULL, CustomerId int(10) NOT NULL, AmountInBasket int(5) DEFAULT 1 NOT NULL, PRIMARY KEY (ProductId, CustomerId));
    CREATE TABLE Categories (Id int(10) NOT NULL AUTO_INCREMENT, Name varchar(60) NOT NULL, FieldName1 varchar(50), FieldName2 varchar(50), FieldName3 varchar(50), FieldName4 varchar(50), FieldName5 varchar(50), FieldName6 varchar(50), FieldName7 varchar(50), FieldName8 varchar(50), PRIMARY KEY (Id), INDEX (Name));
    CREATE TABLE Customers (Id int(10) NOT NULL AUTO_INCREMENT, FirstName varchar(30) NOT NULL, LastName varchar(30) NOT NULL, Email varchar(60) NOT NULL, BirthDate date NOT NULL, PhoneNumber varchar(20) NOT NULL, BasketValue decimal(8, 2) DEFAULT 0 NOT NULL, AddressId int(10) NOT NULL, Password varchar(60) NOT NULL, Login varchar(60) NOT NULL, PRIMARY KEY (Id), INDEX (FirstName), INDEX (LastName), UNIQUE INDEX (Login));
    CREATE TABLE Discounts (Id int(10) NOT NULL AUTO_INCREMENT, Name varchar(60) NOT NULL, EmployeeId int(10) NOT NULL, BeginDate date NOT NULL, EndDate date NOT NULL, Percentage int(2) NOT NULL, PRIMARY KEY (Id), INDEX (EndDate));
    CREATE TABLE Employees (Id int(10) NOT NULL AUTO_INCREMENT, FirstName varchar(30) NOT NULL, LastName varchar(30) NOT NULL, PhoneNumber varchar(20) NOT NULL, Salary int(5) NOT NULL, Email varchar(50) NOT NULL, HireDate date NOT NULL, AddressId int(10) NOT NULL, Password varchar(15) NOT NULL, Login varchar(15) NOT NULL UNIQUE, PRIMARY KEY (Id));
    CREATE TABLE Invoices (Id int(10) NOT NULL AUTO_INCREMENT, InvoiceDate date NOT NULL, SaleDate date NOT NULL, ValueBrutto decimal(8, 2) NOT NULL, TaxRate int(2) NOT NULL, NIP int(10) NOT NULL, CustomerId int(10) NOT NULL, PRIMARY KEY (Id), INDEX (NIP));
    CREATE TABLE OrderedProducts (OrderId int(10) NOT NULL, ProductId int(10) NOT NULL, AmountInOrder int(5) DEFAULT 1 NOT NULL, PRIMARY KEY (OrderId, ProductId));
    CREATE TABLE Orders (Id int(10) NOT NULL AUTO_INCREMENT, SaleDate date NOT NULL, Value int(1) DEFAULT 0 NOT NULL, Status varchar(30) NOT NULL, CustomerId int(10) NOT NULL, InvoiceId int(10), AddressId int(10), PRIMARY KEY (Id), INDEX (SaleDate), INDEX (Status), INDEX (CustomerId));
    CREATE TABLE Products (Id int(10) NOT NULL AUTO_INCREMENT, Price decimal(8, 2) NOT NULL, Name varchar(60) NOT NULL, Description varchar(10000), CategoryId int(10) NOT NULL, DiscountId int(10), FieldValue1 int(4), FieldValue2 int(4), FieldValue3 int(4), FieldValue4 int(4), FieldValue5 varchar(100), FieldValue6 varchar(100), FieldValue7 varchar(100), FieldValue8 varchar(100), AmountInStore int(10) DEFAULT 0 NOT NULL, ProducerName varchar(100), PRIMARY KEY (Id), INDEX (Price), INDEX (Name), INDEX (CategoryId));
    CREATE TABLE ProductsInStore (Id int(10) NOT NULL AUTO_INCREMENT, ProductId int(10) NOT NULL, Status varchar(30) NOT NULL, Rack int(3) NOT NULL, Shelf int(1) NOT NULL, Price decimal(8, 2) DEFAULT 0 NOT NULL, OrderId int(10), SerialNumber varchar(20) NOT NULL, PRIMARY KEY (Id), INDEX (ProductId), INDEX (Status));
    ALTER TABLE Baskets ADD CONSTRAINT `Basket contains products` FOREIGN KEY (ProductId) REFERENCES Products (Id);
    ALTER TABLE Customers ADD CONSTRAINT `Customer has address` FOREIGN KEY (AddressId) REFERENCES Addresses (Id);
    ALTER TABLE Orders ADD CONSTRAINT `Customer has orders` FOREIGN KEY (CustomerId) REFERENCES Customers (Id);
    ALTER TABLE Invoices ADD CONSTRAINT `Customer may have invoices` FOREIGN KEY (CustomerId) REFERENCES Customers (Id);
    ALTER TABLE Employees ADD CONSTRAINT `Employee has address` FOREIGN KEY (AddressId) REFERENCES Addresses (Id);
    ALTER TABLE Discounts ADD CONSTRAINT `Employee may give a discount` FOREIGN KEY (EmployeeId) REFERENCES Employees (Id);
    ALTER TABLE Baskets ADD CONSTRAINT `Having basket` FOREIGN KEY (CustomerId) REFERENCES Customers (Id);
    ALTER TABLE OrderedProducts ADD CONSTRAINT `Order includes ordered products` FOREIGN KEY (OrderId) REFERENCES Orders (Id);
    ALTER TABLE Orders ADD CONSTRAINT `Order may have address where to send` FOREIGN KEY (AddressId) REFERENCES Addresses (Id);
    ALTER TABLE Orders ADD CONSTRAINT `Order may have invoice` FOREIGN KEY (InvoiceId) REFERENCES Invoices (Id);
    ALTER TABLE ProductsInStore ADD CONSTRAINT `Particular product is assigned to a specified order` FOREIGN KEY (OrderId) REFERENCES OrderedProducts (OrderId);
    ALTER TABLE Products ADD CONSTRAINT `Product belongs to a category` FOREIGN KEY (CategoryId) REFERENCES Categories (Id);
    ALTER TABLE ProductsInStore ADD CONSTRAINT `Product describes existing item` FOREIGN KEY (ProductId) REFERENCES Products (Id);
    ALTER TABLE Products ADD CONSTRAINT `Product may be on a discount` FOREIGN KEY (DiscountId) REFERENCES Discounts (Id);
    ALTER TABLE OrderedProducts ADD CONSTRAINT `Set of products assigned to a specified order` FOREIGN KEY (ProductId) REFERENCES Products (Id);



-- WIDOKI
--> widok przechowujący najpopularniejsze produkty:
    CREATE VIEW Top_products AS 
        SELECT Products.Id, Products.Name, Products.ProducerName, Products.AmountInStore AS In_store, SUM(OrderedProducts.AmountInOrder) AS Sold 
            FROM Products 
            JOIN OrderedProducts ON Products.Id = OrderedProducts.ProductId 
        GROUP BY OrderedProducts.ProductId 
        ORDER BY SUM(OrderedProducts.AmountInOrder) DESC;

--> widok przechowujący wszystkich pracowników i ich zniżki:
    CREATE VIEW Employee_discount AS
        SELECT Employees.Id, Employees.LastName
            FROM Employees
            JOIN Discounts ON Employees.Id = Discounts.EmployeeId
        ORDER BY Employees.LastName;

--> widok przechowujący informacje o wszystkich zamówieniach w trakcie realizacji: 
    CREATE VIEW Orders_in_progress AS
        SELECT Id, Value, CustomerId, InvoiceId, AddressId, SaleDate
            FROM Orders
        WHERE Status = 'Realizowane';

--> widok przechowujący informacje których produktów brak na magazynie:
    CREATE VIEW Products_sell_out AS
        SELECT Products.Id, Products.Name, Categories.Name as Categories, Products.ProducerName
            FROM Products
            JOIN Categories ON Products.CategoryId = Categories.Id
        WHERE Products.AmountInStore = 0
        ORDER BY Categories.Name;

--> widok przechowujący informacje o zwróconych produktach: 
   CREATE VIEW Returned_products AS
        SELECT Id, ProductId, Rack, Shelf, Price, SerialNumber
            FROM ProductsInStore
        WHERE Status = 'Zwrocony';

--------------------------------------------------------------------------------------------------------------------------------------------------
--PROCEDURY SKŁADOWE
--> procedura przeceniająca produkty
   CREATE PROCEDURE Make_discount
        (IN discountID int(10))
        UPDATE Products
            SET Price = Price*(1 - (SELECT Percentage FROM Discounts WHERE Id = discountID))
        WHERE Products.DiscountId = discountID;
   
--> procedura przenosząca produkty z koszyka do zamówienia
   delimiter //
   CREATE PROCEDURE Basket_to_order
        (IN customerID int(10), IN orderID int(10))
        BEGIN
            INSERT INTO OrderedProducts(OrderId, ProductId,AmountInOrder) 
                SELECT orderID, Baskets.ProductId, Baskets.AmountInBasket 
                    FROM Baskets 
                WHERE Baskets.CustomerId = customerID;
            DELETE FROM Baskets WHERE Baskets.CustomerId = customerID;
        END//
    delimiter ;

------------------------------------------------------------------------------------

--WYZWALACZE
--> powieksza wartosc koszyka w chwili dodania nowego produktu
   delimiter //
   CREATE TRIGGER Add_to_basket AFTER INSERT ON Baskets
   FOR EACH ROW BEGIN
       UPDATE Customers SET Customers.BasketValue = Customers.BasketValue + NEW.AmountInBasket*(
           SELECT Products.Price 
                FROM Products 
            WHERE Products.Id = NEW.ProductId)
       WHERE Customers.Id = NEW.CustomerId; 
   END//
   delimiter ;

--> zmniejszajacy wartosc po usunieciu calego rekordu
   delimiter //
   CREATE TRIGGER Remove_from_basket AFTER DELETE ON Baskets
   FOR EACH ROW BEGIN
       UPDATE Customers SET Customers.BasketValue = Customers.BasketValue - OLD.AmountInBasket*(SELECT Products.Price FROM Products WHERE Products.Id = OLD.ProductId)
       WHERE Customers.Id = OLD.CustomerId; 
   END//
   delimiter ;

--> modyfikacja wartosci koszyka po modyfikacji ilosci zamowienia
   delimiter //
   CREATE TRIGGER Update_basket AFTER UPDATE ON Baskets
   FOR EACH ROW BEGIN
       UPDATE Customers SET Customers.BasketValue = Customers.BasketValue + (NEW.AmountInBasket-OLD.AmountInBasket)*(SELECT Products.Price FROM Products WHERE Products.Id = OLD.ProductId)
       WHERE Customers.Id = OLD.CustomerId; 
   END//
   delimiter ;

--> powieksza wartosc zamowienia w chwili dodania nowego produktu
   delimiter //
   CREATE TRIGGER Add_to_order AFTER INSERT ON OrderedProducts
   FOR EACH ROW BEGIN
       UPDATE Orders SET Value = Value + NEW.AmountInOrder*(SELECT Price FROM Products WHERE Products.Id = NEW.ProductId)
       WHERE Orders.Id = NEW.OrderId;
   END//
   delimiter ;

--> zmniejszajacy wartosc zamowienia po usunieciu calego rekordu
    delimiter //
    CREATE TRIGGER Remove_from_order AFTER DELETE ON OrderedProducts
    FOR EACH ROW BEGIN
        UPDATE Orders SET Value = Value - OLD.AmountInOrder*(SELECT Price FROM Products WHERE Products.Id = OLD.ProductId)
        WHERE Orders.Id = OLD.OrderId;
   END//
   delimiter ;

--> modyfikujacy wartosc zamowienia po modyfikacji ilosci produktow w zamowieniau//zsprawdzic ten !!!!
   delimiter //
   CREATE TRIGGER Update_order AFTER UPDATE ON OrderedProducts
   FOR EACH ROW BEGIN
       UPDATE Orders SET Value = Value + (NEW.AmountInOrder-OLD.AmountInOrder)*(SELECT Products.Price FROM Products WHERE Products.Id = OLD.ProductId)
       WHERE Orders.Id = NEW.OrderId;
   END//
   delimiter ;