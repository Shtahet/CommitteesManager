﻿using CommittessManager.DAL.Abstract;
using CommittessManager.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommittessManager.BLL.Concrete
{
    public class ServiceProvider : Abstract.IServiceProvider
    {
        private readonly IDataProvider _dataProvider;
        private IScheduleService _schedule;
        public ServiceProvider(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        public IScheduleService ScheduleService
        {
            get
            {
                if (_schedule == null)
                    _schedule = new ScheduleProvider(_dataProvider);
                return _schedule;
            }
        }
    }
}
