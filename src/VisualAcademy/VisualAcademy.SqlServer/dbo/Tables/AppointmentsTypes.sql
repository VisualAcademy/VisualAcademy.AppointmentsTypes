﻿CREATE TABLE AppointmentsTypes (
  Id INT PRIMARY KEY IDENTITY(1,1),
  AppointmentTypeName NVARCHAR(50) NOT NULL,
  IsActive BIT NOT NULL DEFAULT 1,
  DateCreated DATETIME NOT NULL DEFAULT GETDATE()
)