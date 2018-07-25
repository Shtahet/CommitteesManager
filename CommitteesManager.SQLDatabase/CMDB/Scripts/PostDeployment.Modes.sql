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

SET IDENTITY_INSERT CMDB.Modes ON;

MERGE INTO CMDB.Modes AS m
USING (VALUES
	(2, N'в індивідуальному порядку',	'on a case-by-case basis'),
	(1, N'в запланованому порядку',		'as planned')
)
AS Source (ModeID, Mode_name_UA, Mode_name_US)
ON m.ModeID = Source.ModeID
WHEN MATCHED THEN
	UPDATE SET Mode_name_UA = Source.Mode_name_UA,
				Mode_name_US = Source.Mode_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (ModeID, Mode_name_UA, Mode_name_US)
VALUES (ModeID, Mode_name_UA, Mode_name_US)
;

SET IDENTITY_INSERT CMDB.Modes OFF;