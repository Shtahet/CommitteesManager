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

CREATE TABLE [CMDB].[AppGroups]
(
	AppGroupID			INT				NOT NULL IDENTITY(1, 1),
	AppGroup_name_UA	NVARCHAR(100)	NOT NULL,
	AppGroup_name_US	NVARCHAR(100)	NULL,
	Is_available		BIT				NOT NULL 
		CONSTRAINT DFT_AppGroups_IsAvaliable DEFAULT(1),
	CONSTRAINT PK_AppGroups_AppGroupID PRIMARY KEY CLUSTERED (AppGroupID)
)
