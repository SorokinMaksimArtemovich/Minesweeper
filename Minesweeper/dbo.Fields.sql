CREATE TABLE [dbo].[Fields] (
    [SquereID]      INT      IDENTITY(1,1),
    [GameID]        INT      NOT NULL,
    [PositionX]     TINYINT  NOT NULL,
    [PositionY]     TINYINT  NOT NULL,
    [StartValue]    SMALLINT NOT NULL,
    [CurrentValue]  SMALLINT NOT NULL,
    [IsOpened]      BIT      NOT NULL,
    [IsMarked]      BIT      NOT NULL,
    [IsHighlighted] BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([SquereID] ASC)
);

