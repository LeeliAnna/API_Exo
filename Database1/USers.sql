﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Email VARCHAR(250) NOT NULL,
	Password VARCHAR(MAX) NOT NULL,
	Pseudo VARCHAR(50)
)
