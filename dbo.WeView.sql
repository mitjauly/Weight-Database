CREATE VIEW [dbo].[WeView]
	As SELECT measurement.Id,users.FIO, Weight,users.Height, MassIndex
	FROM measurement INNER JOIN
users ON users.id=UsrID