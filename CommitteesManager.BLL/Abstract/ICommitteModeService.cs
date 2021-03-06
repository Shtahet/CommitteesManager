﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.DAL.Model;

namespace CommitteesManager.BLL.Abstract
{
    public interface ICommitteModeService:ITemplateService<Mode>
    {
        Mode Get(int Id);
        void Delete(int Id);
    }
}
