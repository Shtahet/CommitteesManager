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

SET IDENTITY_INSERT CMDB.AppGroups ON;

MERGE INTO CMDB.AppGroups AS apg
USING (VALUES
	(1, 'Питання по судовій стадії', 'Court'),
	(2, 'Питання по виконавчій стадії', 'Execution'),
	(3, 'Кредити 61-90', '61-90'),
	(4, 'Кредити 31-60', '31-60'),
	(5, 'Кредити до 180', 'PI_Restr'),
	(6, 'Кредити ВТТ', 'BTT'),
	(7, 'Кредити МТТ', 'MTT'),
	(8, 'Кредити PreCourt', 'PreCourt'),
	(9, 'Кредити CourtRec', 'CourtRec'),
	(10, 'Реалізація застави', 'AS'),
	(11, 'Добровільне індивідуальне врегулювання', 'Vol_approach'),
	(12, 'Списання', 'WrOff'),
	(13, 'Інше', 'Other')
)
AS Source (ApID, ApNameUA, ApNameUS)
ON apg.AppGroupID = Source.ApID
WHEN NOT MATCHED BY TARGET THEN
INSERT (AppGroupID, AppGroup_name_UA, AppGroup_name_US)
VALUES (ApID, ApNameUA, ApNameUS)
;

SET IDENTITY_INSERT CMDB.AppGroups OFF;