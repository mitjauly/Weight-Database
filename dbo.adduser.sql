CREATE PROCEDURE [dbo].[AddUser]
	@FIO char(50) ,
	@Height int
AS
BEGIN 
 INSERT INTO users (FIO,Height)
 VALUES (@FIO,@Height)
	END
RETURN 0