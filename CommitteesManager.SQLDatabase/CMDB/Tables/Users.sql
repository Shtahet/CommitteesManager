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

CREATE TABLE [CMDB].[Users]
(
	[UserID]				varchar(20) NOT NULL,
	[Access_typeID]			int NULL,
	[User_name_UA]			varchar(100) NOT NULL,
	[User_name_US]			varchar(100) NOT NULL,
	[Job_title]				varchar(255) NULL,
	[Email]					varchar(100) NOT NULL,
	[Phone_number]			varchar(20) NULL,
	[HeadID]				varchar(20) NULL,
	[User_order]			int NULL,
	[Is_available]			bit NOT NULL DEFAULT(1),
	CONSTRAINT PK_Users_UserID PRIMARY KEY CLUSTERED (UserID),
	CONSTRAINT FK_AccessTypeID_AccessType_TypeID FOREIGN KEY (Access_typeID)
		REFERENCES CMDB.AccessTypes (Type_level)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	CONSTRAINT FK_Users_PK_Users_HeadID FOREIGN KEY (HeadID)
		REFERENCES CMDB.Users (UserID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION	
)
