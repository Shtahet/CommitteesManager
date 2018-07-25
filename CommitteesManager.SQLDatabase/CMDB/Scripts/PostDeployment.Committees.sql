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

MERGE INTO CMDB.Committees AS c
USING (VALUES
	(N'Регіональний комітет',		'Regional_Committee', 1),
	(N'Великий комітет',			'BigBoss_Committee', 1),
	(N'Постанова правління',		'BR', 0)
)
AS Source (Committee_name_UA, Committee_name_US, Is_available)
ON c.committee_name_US = Source.Committee_name_US
WHEN MATCHED THEN
	UPDATE SET	Committee_name_UA = Source.Committee_name_UA
WHEN NOT MATCHED BY TARGET THEN
INSERT (Committee_name_UA, Committee_name_US, Is_available)
VALUES (Committee_name_UA, Committee_name_US, Is_available)
;

