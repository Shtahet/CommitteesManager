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

SET IDENTITY_INSERT CMDB.DecisionTypes ON;

MERGE INTO CMDB.DecisionTypes AS dt
USING (VALUES
	(1, 'Погоджено', 'APPROVED'),
	(0, 'Відхилено', 'REJECTED'),
	(2, 'Перегляд', 'REVISION')
)
AS Source (TypeId, TypeNameUA, TypeNameUS)
ON dt.DecisionTypeID = Source.TypeId
WHEN MATCHED THEN
	UPDATE SET DecisionType_name_UA = TypeNameUA,
				DecisionType_name_US = TypeNameUS
WHEN NOT MATCHED BY TARGET THEN
INSERT (DecisionTypeID, DecisionType_name_UA, DecisionType_name_US)
VALUES (TypeId, TypeNameUA, TypeNameUS)
;

SET IDENTITY_INSERT CMDB.DecisionTypes OFF;