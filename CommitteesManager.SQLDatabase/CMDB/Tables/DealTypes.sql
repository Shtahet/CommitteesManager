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

CREATE TABLE [CMDB].[DealTypes]
(
	Deal_typeID						int identity(1, 1) NOT NULL,
	Deal_name_UA					nvarchar(200) NOT NULL,
	Deal_name_US					varchar(200) NULL,
	Question_type_UA				nvarchar(200) NOT NULL,
	Question_type_US				varchar(200) NOT NULL,
	Deal_type						varchar(50) NOT NULL,
	Is_available					bit NOT NULL DEFAULT(1),
	CONSTRAINT PK_Deal_type_TypeID PRIMARY KEY CLUSTERED (Deal_typeID)
)
