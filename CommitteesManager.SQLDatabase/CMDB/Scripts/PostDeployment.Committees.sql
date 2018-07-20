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
MERGE INTO CMDB.Committees AS c
USING (VALUES
	('Регіональний комітет',	'Regional_Committee', 1),
	('Великий комітет',			'BigBoss_Committee', 1),
	('Постанова правління',		'BR', 0)
)
AS Source (Committee_name_UA, Committee_name_US, Is_available)
ON c.committee_name_US = Source.Committee_name_US
WHEN MATCHED THEN
	UPDATE SET	Committee_name_UA = Committee_name_UA
WHEN NOT MATCHED BY TARGET THEN
INSERT (Committee_name_UA, Committee_name_US, Is_available)
VALUES (Committee_name_UA, Committee_name_US, Is_available)
;

