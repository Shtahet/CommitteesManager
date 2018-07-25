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

MERGE INTO CMDB.Users AS u
USING (VALUES
	('ADU07ROG',	999,	N'Смірнов В.Л.',	'Smirnov Vladislav',	N'Директор департаменту',	'vsmirnov@mycompany.org',		'4401',	NULL,		999),
	('ADU12PFK',	999,	N'Громова А.В.',	'Gromova Alexandra',	N'Начальник управління',	'agromova@mycompany.org',		'4458',	'ADU07ROG', 999),
	('Derien',		999,	N'Гергало А.В.',	'Gergalo Alex',			N'Спеціаліст',				'agergalo@mycompany.org',		'6380',	'ADU12PFK',	999),
	('ADU25SRN',	999,	N'Беспалова Я.Р.',	'Bespalova Yana',		N'Головний економіст',		'yabespalova@mycompany.org',	'4418', 'ADU07ROG',	2),
	('ADU75TGW',	999,	N'Воронцов Д.Д.',	'Vorontsov Danylo',		N'Економіст',				'dvorotsov@mycompany.org',		'4436', 'ADU25SRN',	3),
	('ADU44FAJ',	999,	N'Белова Н.Т.',		'Belova Nina',			N'Молодший економіст',		'nbelova@mycompany.org',		'4467', 'ADU25SRN',	1)
)
AS Source (UserID, Access_typeID, User_name_UA, User_name_US, Job_title, Email, Phone_number, HeadID, User_order)
ON u.UserID = Source.UserID
WHEN MATCHED THEN
	UPDATE SET	Access_typeID = Source.Access_typeID,
				User_name_UA = Source.User_name_UA,
				User_name_US = Source.User_name_US,
				Job_title = Source.Job_title,
				Email = Source.Email,
				Phone_number = Source.Phone_number,
				HeadID = Source.HeadID, 
				User_order = Source.User_order
WHEN NOT MATCHED BY TARGET THEN
INSERT (UserID, Access_typeID, User_name_UA, User_name_US, Job_title, Email, Phone_number, HeadID, User_order)
VALUES (UserID, Access_typeID, User_name_UA, User_name_US, Job_title, Email, Phone_number, HeadID, User_order)
;
