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
	(0,		'декілька питань',										'Декілька питань',			'several deals',							'Several deals',		'Several',			0), 
	(1,		'2 аукціон',											'Примусова реалізація',		'2nd Auction',								'Forced asset sale',	'Settlement',		1),
	(2,		'2 торги',												'Примусова реалізація',		'2nd Trade',								'Forced asset sale',	'Settlement',		1),
	(3,		'3 аукціон',											'Примусова реалізація',		'3rd Auction',								'Forced asset sale',	'Settlement',		1),
	(4,		'взяття на баланс майна (рекомендація Правлінню)',		'Взяття на баланс',			'take to balance',							'Take to balance',		'Settlement',		0),
	(5,		'виведення з роботи',									'Стратегія',				'finish of work',							'Strategy',				'Strategy',			1),
	(6,		'виконання розпорядження',								'Стратегія',				'execution of the order',					'Strategy',				'Strategy',			1),
	(7,		'відклик виконавчого провадження',						'Стратегія',				'revocation of enforcement proceedings',	'Strategy',				'Strategy',			1),
	(8,		'відкликання судового провадження',						'Стратегія',				'withdrawal of litigation',					'Strategy',				'Strategy',			1),
	(9,		'відступлення права вимоги',							'Відступлення прав вимоги',	'debt sale',								'Debt sale',			'Settlement',		0),
	(10,	'реалізація активів',									'Добровільна реалізація',	'assets sale',								'Voluntary asset sale',	'Settlement',		1),
	(11,	'дозвіл на неподання апел.скарги',						'Стратегія',				'permission not to submit an appeal',		'Strategy',				'Strategy',			1),
	(12,	'заміна поручителя',									'Поручитель',				'guarantor change',							'Guarantor',			'Strategy',			0),
	(13,	'зарахування коштів в рамках процедури банкрутство',	'Банкрутство',				'credited funds of bankruptcy',				'Bankruptcy',			'Settlement',		1),
	(14,	'зміни в складі забезпечення',							'Стратегія',				'changes in the collateral',				'Strategy',				'Strategy',			1),
	(15,	'зміни до протоколу',									'Стратегія',				'changes to the protocol',					'Strategy',				'Strategy',			1),
	(16,	'зняття обтяжень',										'Поручитель',				'removal of encumbrances',					'Guarantor',			'Settlement',		1),
	(17,	'залишення позову без розгляду',						'Стратегія',				'leave the claim without consideration',	'Strategy',				'Settlement',		1),
	(18,	'пролонгація строку договору',							'Пролонгація',				'prolongation of the contract term',		'Prolongation',			'Restructuring',	1),
	(19,	'оформлення документів',								'Стратегія',				'paperwork',								'Strategy',				'Strategy',			1),
	(20,	'передача ВЛ до ДВС',									'Стратегія',				'transfer of the writ',						'Strategy',				'Strategy',			1),
	(21,	'погодження непередачі ВЛ',								'Стратегія',				'agreement not to transfer the writ',		'Strategy',				'Strategy',			1),
	(22,	'погодження нотаріуса',									'Нотаріус',					'agreement of the notary',					'Notary',				'Strategy',			1),
	(23,	'поновлення протоколу',									'Стратегія',				'protocol update',							'Strategy',				'Strategy',			1),
	(24,	'примусова реалізація',									'Примусова реалізація',		'forced asset sale',						'Forced asset sale',	'Settlement',		1),
	(25,	'припинення примусового стягнення',						'Стратегія',				'termination of enforcement',				'Strategy',				'Strategy',			1),
	(26,	'припинення стягнення',									'Стратегія',				'stop charging',							'Strategy',				'Strategy',			0),
	(27,	'продаж з балансу',										'Продаж з балансу',			'balance sale',								'Sale on balance',		'Strategy',			1),
	(28,	'продовження дії протоколу',							'Стратегія',				'prolongation of the protocol',				'Strategy',				'Strategy',			1),
	(29,	'процедура банкрутство',								'Банкрутство',				'bankruptcy',								'Bankruptcy',			'Strategy',			1),
	(30,	'реалізація згідно рішення суду',						'Примусова реалізація',		'realization according to court decision',	'Forced asset sale',	'Settlement',		1),
	(31,	'стратегія - внесення змін до положення',				'Стратегія',				'strategy - making changes to principle',	'Strategy','Strategy',	'Strategy',			1),
	(32,	'стратегія - на комітет великий',						'Стратегія',				'strategy - to big committee',				'Strategy','Strategy',	'Strategy',			1),
	(33,	'відміна дії протоколу',								'Стратегія',				'cancel protocol action',					'Strategy','Strategy',	'Strategy',			1),
	(34,	'1 аукціон',											'Примусова реалізація',		'1st Auction',								'Forced asset sale',	'Cash',				1)
)
AS Source (Deal_typeID, Deal_name_UA,								Question_type_UA,			Deal_name_US,								Question_type_US,		Deal_type,			Is_available)
ON d.Deal_typeID = Source.Deal_typeID
WHEN MATCHED THEN
	UPDATE SET	Deal_name_UA = Source.Deal_name_UA,
				Question_type_UA = Source.Question_type_UA,
				Deal_name_US = Source.Deal_name_US,
				Question_type_US = Source.Question_type_US,
				Deal_type = Source.Deal_type,
				Is_available = Source.Is_available
WHEN NOT MATCHED BY TARGET THEN
INSERT (Deal_name_UA, Question_type_UA, Deal_name_US, Question_type_US, Deal_type, Is_available)
VALUES (Deal_name_UA, Question_type_UA, Deal_name_US, Question_type_US, Deal_type, Is_available)
;

SET IDENTITY_INSERT CMDB.DealTypes OFF;