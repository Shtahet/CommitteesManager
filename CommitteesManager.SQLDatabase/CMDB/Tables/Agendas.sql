--Copyright © 2018
--Alexandr Gergalo aka Shtahet <derien001@gmail.com>
--
--This file is part of CommitteesManger.
--
--CommitteesManger is free software: you can redistribute it and/or modify
--it under the terms of the GNU General Public License as published by
--the Free Software Foundation, either version 3 of the License, or
--(at your option) any later version.
--
--CommitteesManger is distributed in the hope that it will be useful,
--but WITHOUT ANY WARRANTY; without even the implied warranty of
--MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
--GNU General Public License for more details.
--
--You should have received a copy of the GNU General Public License
--along with Foobar.  If not, see <https://www.gnu.org/licenses/>.

CREATE TABLE [CMDB].[Agendas]
(
	AgendaID					NUMERIC(18, 0)	NOT NULL,
	ProtocolID					INT				NOT NULL,
	RegionID					INT				NULL,
	Contractor_Name				NVARCHAR(255)	NULL,
	Contract_number				NVARCHAR(255)	NULL,
	Contract_date				DATE			NULL,
	Deal_amount					NUMERIC(18, 2)	NULL,
	Tax_code					NVARCHAR(20)	NULL,
	Potential_amount_UAH		NUMERIC(18, 2)	NULL,
	Potential_amount_CCY		NUMERIC(18, 2)	NULL,
	Currency					NVARCHAR(5)		NULL,
	Fraud						NVARCHAR(50)	NULL,
	Comments					NVARCHAR(300)	NULL,
	Contact_info				NVARCHAR(50)	NULL,
	Contract_id					NUMERIC(8, 0)	NOT NULL,
	Covenant_Y_N				INT				NULL,
	Add_date					DATETIME		NOT NULL
		CONSTRAINT DFT_Agendas_Add_date DEFAULT GetDate(),
	CounterpartID				INT				NULL,
	Ban_departure				INT				NOT NULL
		CONSTRAINT DFT_Agendas_BanDeparture DEFAULT (0),
	CONSTRAINT PK_Agendas_AgendaID_ProtocolID PRIMARY KEY (AgendaID),
	CONSTRAINT FK_Agendas_Protocols FOREIGN KEY (ProtocolID)
		REFERENCES CMDB.Protocols (ProtocolID),
	CONSTRAINT FK_Agendas_Regions FOREIGN KEY (RegionID)
		REFERENCES CMDB.Regions (RegionID),
	CONSTRAINT FK_AgendasBuyerID_Buyers FOREIGN KEY (CounterpartID)
		REFERENCES CMDB.Counterparties (CounterpartID)
)
