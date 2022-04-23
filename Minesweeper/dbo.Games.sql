CREATE TABLE [dbo].[Games] (
    [GameID]      INT IDENTITY(1,1),
    [Time]        INT NOT NULL,
    [Bombs]       INT NOT NULL,
    [Closed]      INT NOT NULL,
    [FieldHeight] INT NOT NULL,
    [FieldWidth]  INT NOT NULL,
    [IsFinished]  BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([GameID] ASC)
);

