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

SET IDENTITY_INSERT CMDB.DealTypes ON;

MERGE INTO CMDB.DealTypes AS d
USING (VALUES
	(0,		N'декілька питань',										N'Декілька питань',				'several deals',							'Several deals',		'Several',			0), 
	(1,		N'2 аукціон',											N'Примусова реалізація',		'2nd Auction',								'Forced asset sale',	'Settlement',		1),
	(2,		N'2 торги',												N'Примусова реалізація',		'2nd Trade',								'Forced asset sale',	'Settlement',		1),
	(3,		N'3 аукціон',											N'Примусова реалізація',		'3rd Auction',								'Forced asset sale',	'Settlement',		1),
	(4,		N'взяття на баланс майна (рекомендація Правлінню)',		N'Взяття на баланс',			'take to balance',							'Take to balance',		'Settlement',		0),
	(5,		N'виведення з роботи',									N'Стратегія',					'finish of work',							'Strategy',				'Strategy',			1),
	(6,		N'виконання розпорядження',								N'Стратегія',					'execution of the order',					'Strategy',				'Strategy',			1),
	(7,		N'відклик виконавчого провадження',						N'Стратегія',					'revocation of enforcement proceedings',	'Strategy',				'Strategy',			1),
	(8,		N'відкликання судового провадження',					N'Стратегія',					'withdrawal of litigation',					'Strategy',				'Strategy',			1),
	(9,		N'відступлення права вимоги',							N'Відступлення прав вимоги',	'debt sale',								'Debt sale',			'Settlement',		0),
	(10,	N'реалізація активів',									N'Добровільна реалізація',		'assets sale',								'Voluntary asset sale',	'Settlement',		1),
	(11,	N'дозвіл на неподання апел.скарги',						N'Стратегія',					'permission not to submit an appeal',		'Strategy',				'Strategy',			1),
	(12,	N'заміна поручителя',									N'Поручитель',					'guarantor change',							'Guarantor',			'Strategy',			0),
	(13,	N'зарахування коштів в рамках процедури банкрутство',	N'Банкрутство',					'credited funds of bankruptcy',				'Bankruptcy',			'Settlement',		1),
	(14,	N'зміни в складі забезпечення',							N'Стратегія',					'changes in the collateral',				'Strategy',				'Strategy',			1),
	(15,	N'зміни до протоколу',									N'Стратегія',					'changes to the protocol',					'Strategy',				'Strategy',			1),
	(16,	N'зняття обтяжень',										N'Поручитель',					'removal of encumbrances',					'Guarantor',			'Settlement',		1),
	(17,	N'залишення позову без розгляду',						N'Стратегія',					'leave the claim without consideration',	'Strategy',				'Settlement',		1),
	(18,	N'пролонгація строку договору',							N'Пролонгація',					'prolongation of the contract term',		'Prolongation',			'Restructuring',	1),
	(19,	N'оформлення документів',								N'Стратегія',					'paperwork',								'Strategy',				'Strategy',			1),
	(20,	N'передача ВЛ до ДВС',									N'Стратегія',					'transfer of the writ',						'Strategy',				'Strategy',			1),
	(21,	N'погодження непередачі ВЛ',							N'Стратегія',					'agreement not to transfer the writ',		'Strategy',				'Strategy',			1),
	(22,	N'погодження нотаріуса',								N'Нотаріус',					'agreement of the notary',					'Notary',				'Strategy',			1),
	(23,	N'поновлення протоколу',								N'Стратегія',					'protocol update',							'Strategy',				'Strategy',			1),
	(24,	N'примусова реалізація',								N'Примусова реалізація',		'forced asset sale',						'Forced asset sale',	'Settlement',		1),
	(25,	N'припинення примусового стягнення',					N'Стратегія',					'termination of enforcement',				'Strategy',				'Strategy',			1),
	(26,	N'припинення стягнення',								N'Стратегія',					'stop charging',							'Strategy',				'Strategy',			0),
	(27,	N'продаж з балансу',									N'Продаж з балансу',			'balance sale',								'Sale on balance',		'Strategy',			1),
	(28,	N'продовження дії протоколу',							N'Стратегія',					'prolongation of the protocol',				'Strategy',				'Strategy',			1),
	(29,	N'процедура банкрутство',								N'Банкрутство',					'bankruptcy',								'Bankruptcy',			'Strategy',			1),
	(30,	N'реалізація згідно рішення суду',						N'Примусова реалізація',		'realization according to court decision',	'Forced asset sale',	'Settlement',		1),
	(31,	N'стратегія - внесення змін до положення',				N'Стратегія',					'strategy - making changes to principle',	'Strategy',				'Strategy',			1),
	(32,	N'стратегія - на комітет великий',						N'Стратегія',					'strategy - to big committee',				'Strategy',				'Strategy',			1),
	(33,	N'відміна дії протоколу',								N'Стратегія',					'cancel protocol action',					'Strategy',				'Strategy',			1),
	(34,	N'1 аукціон',											N'Примусова реалізація',		'1st Auction',								'Forced asset sale',	'Cash',				1)
)
AS Source (Deal_typeID, Deal_name_UA,								Question_type_UA,				Deal_name_US,								Question_type_US,		Deal_type,			Is_available)
ON d.Deal_typeID = Source.Deal_typeID
WHEN MATCHED THEN
	UPDATE SET	Deal_name_UA = Source.Deal_name_UA,
				Question_type_UA = Source.Question_type_UA,
				Deal_name_US = Source.Deal_name_US,
				Question_type_US = Source.Question_type_US,
				Deal_type = Source.Deal_type,
				Is_available = Source.Is_available
WHEN NOT MATCHED BY TARGET THEN
INSERT (Deal_typeID, Deal_name_UA, Question_type_UA, Deal_name_US, Question_type_US, Deal_type, Is_available)
VALUES (Deal_typeID, Deal_name_UA, Question_type_UA, Deal_name_US, Question_type_US, Deal_type, Is_available)
;

SET IDENTITY_INSERT CMDB.DealTypes OFF;