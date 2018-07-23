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

CREATE PROCEDURE CMDB.GetStatuses
	@StatusID		INT				= NULL,
	@StatusTypeID	INT				= NULL,
	@StatusTypeName	VARCHAR(50)		= NULL,
	@StatusName		VARCHAR(100)	= NULL,
	@Available		BIT				= 1
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	[StatusID],		[Status_typeID],	[Status_type_name],	[Status_name_UA],	[Status_name_US],	[Is_available]
	FROM CMDB.Statuses
	WHERE ([StatusID] = @StatusID OR @StatusID IS NULL)
	AND ([Status_typeID] = @StatusTypeID OR @StatusTypeID IS NULL)
	AND ([Status_type_name] = @StatusTypeName OR @StatusTypeName IS NULL)
	AND ([Status_name_UA] = @StatusName OR @StatusName IS NULL)
	AND Is_available = @Available
END
GO
