create table Products(
ProductID int primary key identity(1,1),
ProductName varchar(50),
ProDescription varchar(500),
Category varchar(50),
Price_JOD varchar(50),
DateAdded date,
);

insert into Products values
('Wireless Mouse','Ergonomic wireless mouse with USB receiver','Electronics','25.99','2024-07-25'),
('Bluetooth Speaker', 'Portable Bluetooth speaker with high-quality sound', 'Electronics', '49.99', '2024-06-10'),
('Running Shoes', 'Lightweight running shoes for men', 'Sportswear', '75.00', '2024-05-15'),
('LED Desk Lamp', 'Adjustable LED desk lamp with touch control', 'Home & Office', '32.50', '2024-04-20'),
('Yoga Mat', 'Eco-friendly yoga mat with non-slip surface', 'Sportswear', '20.99', '2024-03-30'),
('Smartphone', 'Latest model smartphone with 128GB storage', 'Electronics', '699.00', '2024-02-25'),
('Coffee Maker', 'Automatic coffee maker with programmable settings', 'Home & Kitchen', '89.99', '2024-01-12'),
('Water Bottle', 'Stainless steel water bottle, 1L', 'Outdoor & Travel', '15.00', '2024-03-10'),
('Gaming Keyboard', 'Mechanical gaming keyboard with RGB lighting', 'Electronics', '85.00', '2024-04-05'),
('Electric Kettle', '1.7L electric kettle with automatic shut-off', 'Home & Kitchen', '27.50', '2024-02-20');


