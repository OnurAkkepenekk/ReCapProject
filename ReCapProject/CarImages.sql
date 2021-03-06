CREATE TABLE [dbo].[CarImages] (
    [Id]        INT           NOT NULL Identity(1,1),
    [CarId]     INT           NOT NULL,
    [ImagePath] VARCHAR (255) NULL,
    [Date]      DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]) ON DELETE CASCADE ON UPDATE CASCADE
);

