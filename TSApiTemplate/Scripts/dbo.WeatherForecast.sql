USE [WeatherForecastDb]
GO

/****** Object: Table [dbo].[WeatherForecast] Script Date: 08.05.2022 02:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WeatherForecasts] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Date]         DATETIMEOFFSET (7) NULL,
    [TemperatureC] INT                NOT NULL,
    [Summary]      NCHAR (10)         NULL,
    [CreatedDate]  DATETIMEOFFSET (7) NULL,
    [UpdatedDate]  DATETIMEOFFSET (7) NULL
);


