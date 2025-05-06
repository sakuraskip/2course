INSERT INTO UserModel (Role, Login, Username, Password, ProfilePicture) VALUES
('Admin', 'admin1', 'Admin User 1', 'password1', NULL),
('User', 'user1', 'Regular User 1', 'password2', NULL),
('User', 'user2', 'Regular User 2', 'password3', NULL),
('User', 'user3', 'Regular User 3', 'password4', NULL),
('User', 'user4', 'Regular User 4', 'password5', NULL);
INSERT INTO Rental (ShipId, UserId, StartDate, EndDate, Status, Cost) VALUES
(1, 1, CONVERT(DATETIME, '2023-05-01', 120), CONVERT(DATETIME, '2023-05-10', 120), 'Completed', 500),
(2, 2, CONVERT(DATETIME, '2023-06-01', 120), CONVERT(DATETIME, '2023-06-05', 120), 'Pending', 300),
(3, 3, CONVERT(DATETIME, '2023-07-15', 120), CONVERT(DATETIME, '2023-07-20', 120), 'Cancelled', 400),
(1, 4, CONVERT(DATETIME, '2023-08-01', 120), CONVERT(DATETIME, '2023-08-10', 120), 'Completed', 600),
(2, 5, CONVERT(DATETIME, '2023-09-05', 120), CONVERT(DATETIME, '2023-09-15', 120), 'Pending', 350);