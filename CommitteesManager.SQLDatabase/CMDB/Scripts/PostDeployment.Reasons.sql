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

SET IDENTITY_INSERT CMDB.Reasons ON;

MERGE INTO CMDB.Reasons AS r
USING (VALUES
	(1, 'Потрібна додаткова інформація'),
	(2, 'Зміна сутті питання'),
	(3, 'Вимоги клієнта не припустимі'),
	(4, 'Погодження умов комітета з клієнтом'),
	(5, 'Уточнення умов питання'),
	(6, 'Технічна помилка')
)
AS Source (ReasonID, Reason_name_UA)
ON r.ReasonID = Source.ReasonID
WHEN MATCHED THEN
	UPDATE SET	Reason_name_UA = Reason_name_UA
WHEN NOT MATCHED BY TARGET THEN
INSERT (ReasonID, Reason_name_UA)
VALUES (ReasonID, Reason_name_UA)
;

SET IDENTITY_INSERT CMDB.Reasons OFF;
