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


CREATE TABLE [CMDB].[Deals]
(
	DealID						INT				NOT NULL,
	AgendaID					NUMERIC(18, 0)	NOT NULL,
	Deal_typeID					INT				NOT NULL,
	Agreed_deal_typeID			INT				NULL,
	DecisionID					INT				NULL,
	ReasonID					INT				NULL,
	Deal_date					DATE			NULL,
	Deal_statusID				INT				NULL,
	Status_date					DATETIME		NULL,
	Next_date_committee			DATE			NULL,
	Revision_status				VARCHAR(50)		NULL,
	Revision_comment			VARCHAR(500)	NULL,
	Revision_date				DATE			NULL,
	CONSTRAINT FK_Deals_Agendas FOREIGN KEY (AgendaID)
		REFERENCES CMDB.Agendas (AgendaID),
	CONSTRAINT FK_Deals_DealType FOREIGN KEY (Deal_typeID)
		REFERENCES CMDB.DealTypes (Deal_typeID),
	CONSTRAINT FK_DealsAgrDeal_DealTypes FOREIGN KEY (Agreed_deal_typeID)
		REFERENCES CMDB.DealTypes (Deal_typeID),
	CONSTRAINT FK_DealsDecision_Statuses FOREIGN KEY (DecisionID)
		REFERENCES CMDB.Statuses (StatusID),
	CONSTRAINT FK_DealsStatus_Statuses FOREIGN KEY (Deal_statusID)
		REFERENCES CMDB.Statuses (StatusID),
	CONSTRAINT FK_Deals_Reasons FOREIGN KEY (ReasonID)
		REFERENCES CMDB.Reasons (ReasonID)
)
