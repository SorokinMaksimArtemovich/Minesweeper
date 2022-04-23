CREATE TABLE [dbo].[Users] (
    [UserID]         INT            IDENTITY(1,1),
    [Name]           NVARCHAR (MAX) NOT NULL,
    [AlwaysSaveGame] BIT            DEFAULT ((0)) NOT NULL,
    [AlwaysLoadGame] BIT            DEFAULT ((0)) NOT NULL,
    [LastGameLevel]  NVARCHAR (20)  CONSTRAINT [DF_Users_LastGameLevel] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

