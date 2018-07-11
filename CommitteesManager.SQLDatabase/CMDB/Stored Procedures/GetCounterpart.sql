CREATE PROCEDURE CMDB.GetCounterpart
	@ID			INT				= NULL,
	@NameUA		NVARCHAR(200)	= NULL,
	@Avaliable	BIT				= 1
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	[CounterpartID], [Counterpart_name_UA], [Counterpart_name_US], [Is_available]
	FROM CMDB.Counterparties
	WHERE ([CounterpartID] = @ID OR @ID IS NULL)
	AND ([Counterpart_name_UA] = @NameUA or @NameUA IS NULL)
	AND Is_available = @Avaliable
END