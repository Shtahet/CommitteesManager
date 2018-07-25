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
	(1, 1,	'Protocol status',	N'На розгляді',				'Under consideration'),
	(2, 1,	'Protocol status',	N'Погоджено',				'APPROVED'),
	(3, 1,	'Protocol status',	N'Відхилено',				'REJECTED'),
	(4, 1,	'Protocol status',	N'Перегляд',				'REVISION'),
	(5, 2,	'Deals status',		N'В роботі',				'In process'),
	(6, 2,	'Deals status',		N'Відхилено',				'Rejected'),
	(7, 2,	'Deals status',		N'Діючий',					'Active'),
	(8, 2,	'Deals status',		N'Частково виконано',		'Partly take place'),
	(9, 2,	'Deals status',		N'Не виконано',				'Didn''t take place'),
	(10, 2, 'Deals status',		N'Роботу припинено',		'Closed'),
	(11, 2, 'Deals status',		N'Зупинений',				'Stopped'),
	(12, 2, 'Deals status',		N'Виконано (перевірка)',	'Take place check'),
	(13, 2, 'Deals status',		N'Виконано',				'Take place'),
	(14, 3,	'Agendas status',	N'Погоджено',				'APPROVED'),
	(15, 3,	'Agendas status',	N'Відхилено',				'REJECTED')
)
AS Source (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
ON s.StatusID = Source.StatusID
WHEN MATCHED THEN
	UPDATE SET	Status_typeID = Source.Status_typeID,
				Status_type_name = Source.Status_type_name,
				Status_name_UA = Source.Status_name_UA,
				Status_name_US = Source.Status_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
VALUES (StatusID, Status_typeID, Status_type_name, Status_name_UA, Status_name_US)
;

SET IDENTITY_INSERT CMDB.Statuses OFF;
