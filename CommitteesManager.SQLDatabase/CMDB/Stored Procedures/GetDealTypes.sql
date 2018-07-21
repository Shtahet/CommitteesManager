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