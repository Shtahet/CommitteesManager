CREATE PROCEDURE CMDB.GetCommittee
	@CommitteeID		INT				= NULL,
	@Committee_name_UA	VARCHAR(100)	= NULL,
	@Avaliable			BIT				= 1
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	[CommitteeID],	[Committee_name_UA],	[Committee_name_US],	[Is_available]
	FROM CMDB.Committees
	WHERE (CommitteeID = @CommitteeID OR @CommitteeID IS NULL)
	AND (Committee_name_UA = @Committee_name_UA OR @Committee_name_UA IS NULL)
	AND Is_available = @Avaliable
END
GO
