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

MERGE INTO CMDB.AccessTypes AS act
USING (VALUES
	(0,		'Користувач',		'User'),
	(100,	'Керівник команди',	'Team leader'),
	(250,	'Секретар',			'Secretary'),
	(800,	'Аналітик',			'Analyst'),
	(999,	'Адмінистратор',	'Administrator')
)
AS Source (Type_level, Type_name_UA, Type_name_US)
ON act.Type_level = Source.Type_level
WHEN MATCHED THEN
	UPDATE SET	Type_name_UA = Source.Type_name_UA,
				Type_name_US = Source.Type_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (Type_level, Type_name_UA, Type_name_US)
VALUES (Type_level, Type_name_UA, Type_name_US)
;
