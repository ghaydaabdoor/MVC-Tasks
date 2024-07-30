create table user29(
ID int primary key identity(1,1),
UserName varchar(30),
Email varchar(50),
PasswordNew varchar(30),
images varchar(200),
)
insert into user29 values
('Ghayda', 'ghaida.bdoor@gmail.com','12345','imgs\testimonials-1.jpg'),
('Ali', 'alikhaled@gmail.com','ali123','imgs\testimonials-2.jpg'),
('Ahmad','ahmad99@gmail.com','ahmad9912','imgs\testimonials-3'),
('Mohammad','mohammad12_00@yahoo.com','Moh1200','imgs\testimonials-4'),
('Abdulrahman','abd20@yahoo.com','abdalr20_4','imgs\testimonials-5');