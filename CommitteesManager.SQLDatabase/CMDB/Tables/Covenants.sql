CREATE TABLE [CMDB].[Covenants]
(
	CovenantID				INT				NOT NULL IDENTITY(1, 1),
	AgendaID				NUMERIC(18, 0)	NOT NULL,
	Covenant_object			NVARCHAR(50)	NULL,
	Covenant_condition		INT				NULL,
	Covenant_expire			NUMERIC(18, 2)	NULL,
	Covenant_expire_unit	NVARCHAR(50)	NULL,
	Covenant_result			NVARCHAR(255)	NULL,
	Covenant_result_value	NUMERIC(18, 2)	NULL,
	CONSTRAINT PK_Covenants_CovenantID PRIMARY KEY (CovenantID),
	CONSTRAINT FK_Covenants_Agendas FOREIGN KEY (AgendaID)
		REFERENCES CMDB.Agendas (AgendaID)
)
