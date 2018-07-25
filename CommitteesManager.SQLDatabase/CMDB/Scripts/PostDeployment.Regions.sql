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

MERGE INTO CMDB.Regions AS r
USING (VALUES
	(11, N'Вінницька ОД', 'Vinnitsa'),
	(6, N'Волиньська ОД', 'Volyn'),
	(3, N'Дніпропетровська ОД', 'Dnepropetrovsk'),
	(4, N'Донецька ОД', 'Donetsk'),
	(5, N'Житомирська ОД', 'Zhytomir'),
	(9, N'Закарпатська ОД', 'Zakarpatye'),
	(7, N'Запорізька ОД', 'Zaporozhye'),
	(8, N'Івано-Франківська ОД', 'Ivano-Frankovsk'),
	(29, N'Київська РД', 'Kiev'),
	(10, N'Кіровоградська ОД', 'Kirovograd'),
	(1, N'Кримська РД', 'Crym'),
	(12, N'Луганська ОД', 'Lugansk'),
	(13, N'Львівська ОД', 'Lvov'),
	(14, N'Миколаївська ОД', 'Nikolaev'),
	(15, N'Одеська ОД', 'Odessa'),
	(16, N'Полтавська ОД', 'Poltava'),
	(17, N'Рівненська ОД', 'Rovno'),
	(18, N'Сумська ОД', 'Sumy'),
	(19, N'Тернопільська ОД', 'Ternopol'),
	(20, N'Харківська ОД', 'Kharkov'),
	(21, N'Херсонська ОД', 'Kherson'),
	(22, N'Хмельницька ОД', 'Khmelnitsk'),
	(23, N'Черкаська ОД', 'Cherkassy'),
	(25, N'Чернівецька ОД', 'Chernovtsy'),
	(24, N'Чернігівська ОД', 'Chernigov')
)
AS Source (RegionID, Region_name_UA, Region_name_US)
ON r.RegionID = Source.RegionID
WHEN MATCHED THEN
	UPDATE SET	Region_name_UA = Source.Region_name_UA,
				Region_name_US = Source.Region_name_US
WHEN NOT MATCHED BY TARGET THEN
INSERT (RegionID, Region_name_UA,Region_name_US)
VALUES (RegionID, Region_name_UA, Region_name_US)
WHEN NOT MATCHED BY SOURCE THEN
DELETE
;