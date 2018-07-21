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
