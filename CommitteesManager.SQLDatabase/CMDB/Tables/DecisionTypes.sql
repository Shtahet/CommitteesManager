CREATE TABLE [CMDB].[DecisionTypes]
(
	DecisionTypeID			INT				NOT NULL IDENTITY(1, 1),
	DecisionType_name_UA	NVARCHAR(50)	NOT NULL,
	DecisionType_name_US	NVARCHAR(50)	NOT NULL,
	Is_available			BIT				NOT NULL
		CONSTRAINT DFT_DecisionTypes_IsAvaliable DEFAULT(1),
	CONSTRAINT PK_DecisionTypes_DecisionTypeID PRIMARY KEY CLUSTERED (DecisionTypeID)
)
