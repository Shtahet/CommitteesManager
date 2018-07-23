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

CREATE TABLE [CMDB].[Modes]
(
	ModeID			INT				NOT NULL IDENTITY(1, 1),
	Mode_name_UA	VARCHAR(100)	NOT NULL,
	Mode_name_US	VARCHAR(100)	NULL,
	Is_available	BIT				NOT NULL
		CONSTRAINT DF_Mode_avaliable DEFAULT(1),
	CONSTRAINT PK_Modes_ModeID PRIMARY KEY CLUSTERED (ModeID)
)
