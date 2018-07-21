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

--Set UI agent version for check update
MERGE INTO CMDB.Environment AS env
USING (VALUES
  ('Version', '1')
)
AS Source (EnvName, EnvValue)
ON env.EnvName = Source.EnvName
-- UPDATE matched ROWS
--WHEN MATCHED THEN
--UPDATE SET Name = Source.Name
-- INSERT new ROWS
WHEN NOT MATCHED BY TARGET THEN
INSERT (EnvName, EnvValue)
VALUES (EnvName, EnvValue)
-- DELETE rows that ARE IN the TARGET but NOT the SOURCE
--WHEN NOT MATCHED BY SOURCE THEN
--DELETE
;

--Set fields for committe date
MERGE INTO CMDB.Environment AS env
USING (VALUES
	('ScheduledCommitteeDate', '31.08.2017'),
	('StatusCommitteeDate', 'Activate'),
	('LastCommitteeDate', '31.08.2017')
)
AS SOURCE (EnvName, EnvValue)
ON env.EnvName = Source.EnvName
WHEN NOT MATCHED BY TARGET THEN
INSERT (EnvName, EnvValue)
VALUES (EnvName, EnvValue)
;