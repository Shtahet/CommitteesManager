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

CREATE TABLE [CMDB].[AccessTypes]
(
	Type_level		INT				NOT NULL,
	Type_name_UA	NVARCHAR(60)	NOT NULL,
	Type_name_US	NVARCHAR(60)	NULL,
	Is_available	BIT				NOT NULL
		CONSTRAINT DF_AccessTypes_avaliable DEFAULT(1),
	CONSTRAINT PK_AccessTypes_TypeLevel PRIMARY KEY CLUSTERED (Type_level)
)