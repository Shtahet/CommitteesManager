CREATE TABLE [CMDB].[Committees]
(
	CommitteeID			INT				NOT NULL IDENTITY(1, 1),
	Committee_name_UA	NVARCHAR(50)	NOT NULL,
	Committee_name_US	NVARCHAR(50)	NOT NULL,
	Is_available		BIT				NOT NULL 
		CONSTRAINT DFT_Committees_IsAvaliable DEFAULT(1),
	CONSTRAINT PK_Committees_CommitteeID PRIMARY KEY CLUSTERED (CommitteeID)
)
