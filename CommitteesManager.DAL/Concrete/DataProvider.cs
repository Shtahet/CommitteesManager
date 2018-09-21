﻿using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment = CommitteesManager.DAL.Model.Environment;

namespace CommitteesManager.DAL.Concrete
{
    public class DataProvider : IDataProvider
    {
        private CMDB _dbContext;
        private GeneralRepository<Environment> _environmentRepo;
		private GeneralRepository<Committee> _committeeRepo;
		private GeneralRepository<Mode> _modeRepo;
		private GeneralRepository<DealType> _dealTypeRepo;
        public DataProvider()
        {
            _dbContext = new CMDB();
        }
        public IRepository<Environment> Environments
        {
            get
            {
                if (_environmentRepo == null)
                {
                    _environmentRepo = new GeneralRepository<Environment>(_dbContext);
                }
                return _environmentRepo;
            }
        }

		public IRepository<Committee> Committees
		{
			get
			{
				if (_committeeRepo == null)
				{
					_committeeRepo = new GeneralRepository<Committee>(_dbContext);
				}
				return _committeeRepo;
			}
		}

		public IRepository<Mode> Modes
		{
			get
			{
				if (_modeRepo == null)
				{
					_modeRepo = new GeneralRepository<Mode>(_dbContext);
				}
				return _modeRepo;
			}
		}

		public IRepository<DealType> DealTypes => throw new NotImplementedException();
	}
}
