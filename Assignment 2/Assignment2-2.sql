--14. List all Products that has been sold at least once in last 25 years.
SELECT p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(year, -25, GETDATE())
GROUP BY p.ProductName

--15. List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 ShipPostalCode, COUNT(*) AS TotalSales
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY ShipPostalCode
ORDER BY TotalSales DESC

--16. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 ShipPostalCode, COUNT(*) AS TotalSales
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.OrderDate >= DATEADD(year, -25, GETDATE())
GROUP BY ShipPostalCode
ORDER BY TotalSales DESC

--17. List all city names and number of customers in that city.
SELECT c.City, COUNT(*) AS TotalCustomers
FROM Customers c
GROUP BY c.City

--18. List city names which have more than 2 customers, and number of customers in that city.
SELECT c.City, COUNT(*) AS TotalCustomers
FROM Customers c
GROUP BY c.City
HAVING COUNT(*) > 2

--19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

--20. List the names of all customers with most recent order dates.
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrder
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

--21. Display the names of all customers along with the count of products they bought.
SELECT c.ContactName, COUNT(*) AS TotalProductsBought
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName

--22. Display the customer ids who bought more than 100 Products with count of products.
SELECT o.CustomerID, COUNT(*) AS TotalProductsBought
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
HAVING COUNT(*) > 100

--23.List all of the possible ways that suppliers can ship their products. Display the results as below:
SELECT s.CompanyName AS 'Supplier Company Name', sh.CompanyName AS 'Shipping Company Name'
FROM Suppliers s
JOIN Shippers sh ON s.SupplierID = sh.ShipperID

--24. Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate

--25.Display pairs of employees who have the same job title.
SELECT e1.LastName AS Employee1_LastName, e1.FirstName AS Employee1_FirstName, e1.Title AS Employee1_Title, 
       e2.LastName AS Employee2_LastName, e2.FirstName AS Employee2_FirstName, e2.Title AS Employee2_Title
FROM Employees e1 
INNER JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID <> e2.EmployeeID 
ORDER BY e1.Title, e1.LastName, e1.FirstName, e2.LastName, e2.FirstName

--26. Display all the Managers who have more than 2 employees reporting to them:
SELECT e1.LastName, e1.FirstName, COUNT(*) AS EmployeesNumbers
FROM Employees AS e1
INNER JOIN Employees AS e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.EmployeeID, e1.LastName, e1.FirstName
HAVING COUNT(*) > 2

--27. Display the customers and suppliers by city. The results should have the following columns:
SELECT c.City, c.CompanyName AS Name, c.ContactName, 'Customer' AS Type
FROM Customers c
UNION ALL
SELECT s.City, s.CompanyName AS Name, s.ContactName, 'Supplier' AS Type
FROM Suppliers s
ORDER BY City, Name