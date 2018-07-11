CREATE TABLE [CMDB].[Counterparties]
(
	CounterpartID			INT				NOT NULL IDENTITY(1, 1),
	Counterpart_name_UA		NVARCHAR(200)	NOT NULL,
	Counterpart_name_US		NVARCHAR(200)	NOT NULL,
	Is_available			BIT				NOT NULL 
		CONSTRAINT DFT_Counterparties_IsAvaliable DEFAULT(1),
	CONSTRAINT PK_Counterparties_CounterpartID PRIMARY KEY CLUSTERED (CounterpartID)
)
