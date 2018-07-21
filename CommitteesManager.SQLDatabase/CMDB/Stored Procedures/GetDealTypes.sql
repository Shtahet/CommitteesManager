CREATE PROCEDURE CMDB.GetDealTypes
	@DealTypeID			INT				= NULL,
	@Deal_name_UA		VARCHAR(200)	= NULL,
	@Question_type_UA	VARCHAR(200)	= NULL,
	@Avaliable			BIT				= 1
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	[Deal_typeID],		[Deal_name_UA],		[Deal_name_US],
			[Question_type_UA],	[Question_type_US],	
			[Deal_type],		[Is_available]
	FROM CMDB.DealTypes
	WHERE (Deal_typeID = @DealTypeID OR @DealTypeID IS NULL)
	AND (Deal_name_UA = @Deal_name_UA OR @Deal_name_UA IS NULL)
	AND (Question_type_UA = @Question_type_UA OR @Question_type_UA IS NULL)
	AND Is_available >= @Avaliable
END
GO