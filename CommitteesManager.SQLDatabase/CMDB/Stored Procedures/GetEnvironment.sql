﻿CREATE PROCEDURE CMDB.GetEnvironment
	@EnvName		VARCHAR(20),
	@EnvValue		VARCHAR(100)	OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	@EnvValue = EnvValue
	FROM PLC.Environment
	WHERE EnvName = @EnvName;
	RETURN;
END