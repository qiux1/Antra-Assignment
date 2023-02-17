--1. List all cities that have both Employees and Customers.
SELECT City FROM Employees 
WHERE City IN (SELECT City FROM Customers)
GROUP BY City;

--2a. List all cities that have Customers but no Employee (using sub-query).
SELECT City FROM Customers
WHERE City NOT IN (SELECT City FROM Employees)
GROUP BY City;

--2b. List all cities that have Customers but no Employee (without using sub-query).
SELECT DISTINCT c.City FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;

--3. List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalQuantity 
FROM Products p 
JOIN [Order Details] od ON p.ProductID = od.ProductID 
GROUP BY p.ProductName;

--4. List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS TotalQuantity
FROM Customers c 
JOIN Orders o ON c.CustomerID = o.CustomerID 
JOIN [Order Details] od ON o.OrderID = od.OrderID 
GROUP BY c.City;

--5a. List all Customer Cities that have at least two customers (using union).
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2
UNION
SELECT ShipCity AS City
FROM Orders
WHERE ShipCity NOT IN (
    SELECT City
    FROM Customers
)
GROUP BY ShipCity
HAVING COUNT(DISTINCT CustomerID) >= 2;

--5b. List all Customer Cities that have at least two customers (without using union).
SELECT DISTINCT City
FROM Customers
WHERE City IN (
    SELECT City
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >= 2
);

--6. List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City 
FROM Customers c 
JOIN Orders o ON c.CustomerID = o.CustomerID 
JOIN [Order Details] od ON o.OrderID = od.OrderID 
GROUP BY c.City, od.ProductID 
HAVING COUNT(DISTINCT od.ProductID) >= 2;

--7. List all Customers who have ordered products, but have the ¡®ship city¡¯ on the order different from their own customer cities.
SELECT c.CustomerID, c.CompanyName 
FROM Customers c 
JOIN Orders o ON c.CustomerID = o.CustomerID 
WHERE c.City <> o.ShipCity;

--8. List 5 most popular products, their average price, and the customer city that ordered the most quantity of it.
SELECT TOP 5 p.ProductName, AVG(od.UnitPrice) AS AvgPrice, c.City 
FROM Products p 
JOIN [Order Details] od ON p.ProductID = od.ProductID 
JOIN Orders o ON od.OrderID = o.OrderID 
JOIN Customers c ON o.CustomerID = c.CustomerID 
WHERE od.Quantity >= ALL(SELECT Quantity FROM [Order Details] WHERE ProductID = p.ProductID) 
GROUP BY p.ProductName, c.City 
ORDER BY SUM(od.Quantity) DESC;

--9a. List all cities that have never ordered something but we have employees there (using sub-query).
SELECT City FROM Employees 
WHERE City NOT IN (SELECT City FROM Customers) 
AND City NOT IN (SELECT DISTINCT ShipCity FROM Orders);

--9b.List all cities that have never ordered something but we have employees there (without using sub-query).
SELECT DISTINCT e.City FROM Employees e 
LEFT JOIN Customers c ON e.City = c.City 
LEFT JOIN Orders o ON e.City = o.ShipCity 
WHERE c.City IS NULL AND o.ShipCity IS NULL;

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT TOP 1 
    Orders.ShipCity, 
    SUM([Order Details].Quantity) AS TotalQuantity 
FROM 
    Orders 
    INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID 
    INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID 
    INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID 
GROUP BY 
    Orders.ShipCity 
ORDER BY 
    COUNT(Orders.OrderID) DESC, TotalQuantity DESC;


--11. How do you remove the duplicates record of a table?
--To remove duplicate records from a table, you can use the DISTINCT keyword with a SELECT statement to return only 
--the unique values. Alternatively, you can use the GROUP BY clause to group the results by one or more columns and use 
--aggregate functions like COUNT, SUM, MIN, MAX, or AVG to return a single row for each group.