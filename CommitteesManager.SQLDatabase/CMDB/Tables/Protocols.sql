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

CREATE TABLE [CMDB].[Protocols]
(
	ProtocolID				INT				NOT NULL IDENTITY(1, 1),
	ResponsibleID			VARCHAR(20)		NOT NULL,
	ReporterID				VARCHAR(20)		NULL,
	Decision_text			NVARCHAR(MAX)	NULL,
	Protocol_mode			INT				NOT NULL,
	Protocol_longation		INT				NULL,
	ProtocolID_longation	INT				NULL,
	Protocol_number			NVARCHAR(50)	NULL,
	Protocol_date			DATE			NOT NULL,
	CommitteeID				INT				NOT NULL,
	StatusID				INT				NULL,
	Add_date				DATETIME		NOT NULL
		CONSTRAINT DFT_Protocols_Add_date DEFAULT GetDate(),
	EXPIRIOD_DATE_DECISION	DATE			NULL,
	CONSTRAINT PK_Protocols_ProtocolID PRIMARY KEY (ProtocolID),
	CONSTRAINT FK_Protocols_ResponsibleID_Users FOREIGN KEY (ResponsibleID)
		REFERENCES CMDB.Users (UserID),
	CONSTRAINT FK_Protocols_ReporterID_Users FOREIGN KEY (ReporterID)
		REFERENCES CMDB.Users (UserID),
	CONSTRAINT FK_Protocols_Modes FOREIGN KEY (Protocol_mode)
		REFERENCES CMDB.Modes (ModeID),
	CONSTRAINT FK_Protocols_Protocols FOREIGN KEY (ProtocolID_longation)
		REFERENCES CMDB.Protocols (ProtocolID),
	CONSTRAINT FK_Protocols_Committees FOREIGN KEY (CommitteeID)
		REFERENCES CMDB.Committees (CommitteeID),
	CONSTRAINT FK_Protocols_Statuses FOREIGN KEY (StatusID)
		REFERENCES CMDB.Statuses (StatusID)
)
