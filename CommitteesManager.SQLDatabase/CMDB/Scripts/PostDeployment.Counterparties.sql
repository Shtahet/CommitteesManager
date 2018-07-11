/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT CMDB.Counterparties ON;

MERGE INTO CMDB.Counterparties AS c
USING (VALUES
	(0,		N'Акредитована компанія',						N'Accredited company'),
	(1,		N'ПАТ "АБ "РАДАБАНК"',							N'Radabank PJSC'),
	(2,		N'ПАТ "Артем-банк"',							N'Artem-Bank PJSC'),
	(3,		N'ПАТ "ВЕКТОР БАНК"',							N'VECTOR-BANK PJSC'),
	(4,		N'ПАТ "Комерційний Банк "Хрещатик"',			N'Commercial Bank "Khreschatyk" PJSC'),
	(5,		N'ПАТ "Комерційний Індустріальний Банк"',		N'Commercial Industrial Bank PJSC'),
	(6,		N'ПАТ "Юніон Стандард Банк"',					N'Union Standard Bank PJSC'),
	(7,		N'Група "ПрімоКоллект"',						N'Primocollect'),
	(8,		N'ПАТ "Юнекс банк"',							N'Unex Bank PJSC'),
	(9,		N'ПАТ "Міжнародний інвестиційний банк"',		N'International investment Bank PJSC'),
	(10,	N'ПАТ "Комерційний Банк Фінансовий партнер"',	N'Commercial Bank Financial partner PJSC'),
	(11,	N'ТОВ Будівельна компанія Лантера',				N'LLC Building Company "Lantera"'),
	(12,	N'ТОВ Вердикт Финанс',							N'LLC Verdict Finance'),
	(13,	N'SV Finance',									N'SV Finance'),
	(14,	N'«ФК»Європейська агенція з повернення боргів',	N'EADR'),
	(15,	N'ТОВ Арма-Факторинг',							N'LLC ARMA-Factoring'),
	(16,	N'ПАТ "Комерційний банк "Фінансовий партнер"',	N'Commercial Bank Financial partner PJSC'),
	(17,	N'Фінансова компанія "Довіра і гарантія"',		N'Dovira&Garantia'),
	(18,	N'КА "Фактор"',									N'Factor'),
	(19,	N'Група "ПрімоКолект"',							N'Primocollect'),
	(20,	N'Українська факторингова компанія',			N'Ukrainian Factoring Company')
)
AS Source (Id, NameUA, NameUS)
ON c.CounterpartID = Source.Id
WHEN MATCHED THEN
	UPDATE SET	Counterpart_name_UA = NameUA,
				Counterpart_name_US = NameUS
WHEN NOT MATCHED BY TARGET THEN
INSERT (CounterpartID, Counterpart_name_UA, Counterpart_name_US)
VALUES (Id, NameUA, NameUS)
;

SET IDENTITY_INSERT CMDB.Counterparties OFF;