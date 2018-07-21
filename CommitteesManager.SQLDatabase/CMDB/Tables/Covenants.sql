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
