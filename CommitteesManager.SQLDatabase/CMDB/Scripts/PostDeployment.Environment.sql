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
--Set UI agent version for check update
MERGE INTO CMDB.Environment AS env
USING (VALUES
  ('Version', '1')
)
AS Source (EnvName, EnvValue)
ON env.EnvName = Source.EnvName
-- UPDATE matched ROWS
--WHEN MATCHED THEN
--UPDATE SET Name = Source.Name
-- INSERT new ROWS
WHEN NOT MATCHED BY TARGET THEN
INSERT (EnvName, EnvValue)
VALUES (EnvName, EnvValue)
-- DELETE rows that ARE IN the TARGET but NOT the SOURCE
--WHEN NOT MATCHED BY SOURCE THEN
--DELETE
;

--Set fields for committe date
MERGE INTO CMDB.Environment AS env
USING (VALUES
	('ScheduledCommitteeDate', '31.08.2017'),
	('StatusCommitteeDate', 'Activate'),
	('LastCommitteeDate', '31.08.2017')
)
AS SOURCE (EnvName, EnvValue)
ON env.EnvName = Source.EnvName
WHEN NOT MATCHED BY TARGET THEN
INSERT (EnvName, EnvValue)
VALUES (EnvName, EnvValue)
;