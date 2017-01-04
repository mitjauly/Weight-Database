CREATE TABLE [dbo].[users] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [FIO]    VARCHAR (50) NOT NULL,
    [Height] FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

