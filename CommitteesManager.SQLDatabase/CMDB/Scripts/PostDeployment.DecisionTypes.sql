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
SET IDENTITY_INSERT CMDB.DecisionTypes ON;

MERGE INTO CMDB.DecisionTypes AS dt
USING (VALUES
	(1, 'Погоджено', 'APPROVED'),
	(0, 'Відхилено', 'REJECTED'),
	(2, 'Перегляд', 'REVISION')
)
AS Source (TypeId, TypeNameUA, TypeNameUS)
ON dt.DecisionTypeID = Source.TypeId
WHEN MATCHED THEN
	UPDATE SET DecisionType_name_UA = TypeNameUA,
				DecisionType_name_US = TypeNameUS
WHEN NOT MATCHED BY TARGET THEN
INSERT (DecisionTypeID, DecisionType_name_UA, DecisionType_name_US)
VALUES (TypeId, TypeNameUA, TypeNameUS)
;

SET IDENTITY_INSERT CMDB.DecisionTypes OFF;