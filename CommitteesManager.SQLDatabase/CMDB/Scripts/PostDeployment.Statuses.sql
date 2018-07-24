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

SET IDENTITY_INSERT CMDB.Statuses ON;

MERGE INTO CMDB.Statuses AS s
USING (VALUES
	(1, 1,	'Protocol status',	'На розгляді',			'Under consideration'),
	(2, 1,	'Protocol status',	'Погоджено',			'APPROVED'),
	(3, 1,	'Protocol status',	'Відхилено',			'REJECTED'),
	(4, 1,	'Protocol status',	'Перегляд',				'REVISION'),
	(5, 2,	'Deals status',		'В роботі',				'In process'),
	(6, 2,	'Deals status',		'Відхилено',			'Rejected'),
	(7, 2,	'Deals status',		'Діючий',				'Active'),
	(8, 2,	'Deals status',		'Частково виконано',	'Partly take place'),
	(9, 2,	'Deals status',		'Не виконано',			'Didn''t take place'),
	(10, 2, 'Deals status',		'Роботу припинено',		'Closed'),
	(11, 2, 'Deals status',		'Зупинений',			'Stopped'),
	(12, 2, 'Deals status',		'Виконано (перевірка)',	'Take place check'),
	(13, 2, 'Deals status',		'Виконано',				'Take place'),
	(14, 3,	'Agendas status',	'Погоджено',			'APPROVED'),
	(15, 3,	'Agendas status',	'Відхилено',			'REJECTED')
)
AS Source (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
ON s.StatusID = Source.StatusID
WHEN MATCHED THEN
	UPDATE SET	Status_typeID = Status_typeID,
				Status_type_name = Status_type_name,
				Status_name_UA = Status_name_UA,
				Status_name_US = Status_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
VALUES (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
;

SET IDENTITY_INSERT CMDB.Statuses OFF;
