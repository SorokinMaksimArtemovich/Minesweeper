CREATE TABLE [dbo].[GameLevels] (
    [LevelID]         INT           IDENTITY(1,1),
    [UserID]          INT           NOT NULL,
    [DifficultyLevel] NVARCHAR (20) NOT NULL,
    [GameID]          INT           DEFAULT ((-1)) NOT NULL,
    [BestTime]        INT           NOT NULL,
    [WinsCount]       INT           NOT NULL,
    [GamesCount]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([LevelID] ASC)
);

