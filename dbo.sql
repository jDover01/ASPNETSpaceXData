CREATE TABLE [dbo].[PatientInfo] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]       VARCHAR (15) NOT NULL,
    [LastName]        VARCHAR (15) NOT NULL,
    [Chocolate]       BIT          NOT NULL,
    [PreferredColors] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

