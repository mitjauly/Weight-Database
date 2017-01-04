CREATE PROCEDURE [dbo].[AddWeight]
	@User int ,
	@Weight float,
	@MassIndex float
AS
BEGIN 
 INSERT INTO measurement(UsrID,Weight,MassIndex)
 VALUES (@User,@Weight,@MassIndex)
	END
RETURN 0