CREATE TABLE [dbo].[Agent] (
    [shipID]       INT          NOT NULL,
    [shipname]     NVARCHAR (50)  NULL,
    [maxweight]    NVARCHAR (50)  NULL,
    [agentFN]      NVARCHAR (50)  NULL,
    [agentLN]      NVARCHAR (50)  NULL,
    [agentEmail]   NVARCHAR (MAX) NULL,
    [agentContact] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([shipID] ASC)
);

