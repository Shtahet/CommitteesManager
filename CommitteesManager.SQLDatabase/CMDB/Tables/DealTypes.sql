CREATE TABLE [CMDB].[DealTypes]
(
	Deal_typeID						int identity(1, 1) NOT NULL,
	Deal_name_UA					varchar(200) NOT NULL,
	Deal_name_US					varchar(200) NULL,
	Question_type_UA				varchar(200) NOT NULL,
	Question_type_US				varchar(200) NOT NULL,
	Deal_type						varchar(50) NOT NULL,
	Is_available					bit NOT NULL DEFAULT(1),
	CONSTRAINT PK_Deal_type_TypeID PRIMARY KEY CLUSTERED (Deal_typeID)
)
