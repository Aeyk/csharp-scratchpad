INSERT INTO User (Username) VALUES ('me');


INSERT INTO UserRole (UserID, RoleID) 
SELECT User.ID, Role.ID
FROM Role, User
WHERE Role.Name = @role
AND User.Username = 'me';

INSERT INTO UserRole (UserID, RoleID) 


SELECT * UserRole
WHERE Role.ID = (SELECT * FROM Role)