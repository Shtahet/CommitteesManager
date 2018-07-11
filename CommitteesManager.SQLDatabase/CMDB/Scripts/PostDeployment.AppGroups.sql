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
SET IDENTITY_INSERT CMDB.AppGroups ON;

MERGE INTO CMDB.AppGroups AS apg
USING (VALUES
	(1, 'Питання по судовій стадії', 'Court'),
	(2, 'Питання по виконавчій стадії', 'Execution'),
	(3, 'Кредити 61-90', '61-90'),
	(4, 'Кредити 31-60', '31-60'),
	(5, 'Кредити до 180', 'PI_Restr'),
	(6, 'Кредити ВТТ', 'BTT'),
	(7, 'Кредити МТТ', 'MTT'),
	(8, 'Кредити PreCourt', 'PreCourt'),
	(9, 'Кредити CourtRec', 'CourtRec'),
	(10, 'Реалізація застави', 'AS'),
	(11, 'Добровільне індивідуальне врегулювання', 'Vol_approach'),
	(12, 'Списання', 'WrOff'),
	(13, 'Інше', 'Other')
)
AS Source (ApID, ApNameUA, ApNameUS)
ON apg.AppGroupID = Source.ApID
WHEN NOT MATCHED BY TARGET THEN
INSERT (AppGroupID, AppGroup_name_UA, AppGroup_name_US)
VALUES (ApID, ApNameUA, ApNameUS)
;

SET IDENTITY_INSERT CMDB.AppGroups OFF;