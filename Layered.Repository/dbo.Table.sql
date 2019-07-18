CREATE TABLE [dbo].[People] (
    [Id]        INT           NOT NULL,
    [FirstName] VARCHAR (250) NULL,
    [LastName]  VARCHAR (250) NULL,
    [Email]     VARCHAR (250) NULL,
    [Age]       INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

