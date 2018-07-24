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

CREATE TABLE [CMDB].[RegisterOfApproved]
(
	RegisterID		INT				NOT NULL IDENTITY(1, 1),
	ProtocolID		INT				NOT NULL,
	RegisterYears	INT				NOT NULL,
	Register_number	INT				NOT NULL,
	Protocol_number	VARCHAR(50)		NOT NULL,
	Decision_date	DATE			NOT NULL,
	CONSTRAINT PK_RegisterOfApproved_RegisterID	PRIMARY KEY (RegisterID),
	CONSTRAINT FK_RegisterOfApp_Protocols FOREIGN KEY (ProtocolID)
		REFERENCES CMDB.Protocols (ProtocolID),
	CONSTRAINT UNQ_RegisterOfApp_YearRegNumber UNIQUE (RegisterYears, Register_number)
)
