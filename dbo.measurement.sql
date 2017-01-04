CREATE TABLE [dbo].[measurement] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [UsrID]     INT        NOT NULL,
    [Weight]    FLOAT (53) NOT NULL,
    [MassIndex] FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_measurement_ToUser] FOREIGN KEY ([UsrID]) REFERENCES [dbo].[users] ([Id])
);

