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

SET IDENTITY_INSERT CMDB.Regions ON;

MERGE INTO CMDB.Regions AS r
USING (VALUES
	(11, 'Вінницька ОД', 'Vinnitsa'),
	(6, 'Волиньська ОД', 'Volyn'),
	(3, 'Дніпропетровська ОД', 'Dnepropetrovsk'),
	(4, 'Донецька ОД', 'Donetsk'),
	(5, 'Житомирська ОД', 'Zhytomir'),
	(9, 'Закарпатська ОД', 'Zakarpatye'),
	(7, 'Запорізька ОД', 'Zaporozhye'),
	(8, 'Івано-Франківська ОД', 'Ivano-Frankovsk'),
	(29, 'Київська РД', 'Kiev'),
	(10, 'Кіровоградська ОД', 'Kirovograd'),
	(1, 'Кримська РД', 'Crym'),
	(12, 'Луганська ОД', 'Lugansk'),
	(13, 'Львівська ОД', 'Lvov'),
	(14, 'Миколаївська ОД', 'Nikolaev'),
	(15, 'Одеська ОД', 'Odessa'),
	(16, 'Полтавська ОД', 'Poltava'),
	(17, 'Рівненська ОД', 'Rovno'),
	(18, 'Сумська ОД', 'Sumy'),
	(19, 'Тернопільська ОД', 'Ternopol'),
	(20, 'Харківська ОД', 'Kharkov'),
	(21, 'Херсонська ОД', 'Kherson'),
	(22, 'Хмельницька ОД', 'Khmelnitsk'),
	(23, 'Черкаська ОД', 'Cherkassy'),
	(25, 'Чернівецька ОД', 'Chernovtsy'),
	(24,' Чернігівська ОД', 'Chernigov')
)
AS Source (RegionID, Region_name_UA, Region_name_US)
ON r.RegionID = Source.RegionID
WHEN MATCHED THEN
	UPDATE SET	Region_name_UA = Region_name_UA,
				Region_name_US = Region_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (RegionID, Region_name_UA,Region_name_US)
VALUES (ReasonID, Region_name_UA, Region_name_US)
WHEN NOT MATCHED BY SOURCE THEN
DELETE
;

SET IDENTITY_INSERT CMDB.Regions OFF;