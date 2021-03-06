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
        private GeneralRepository<Protocol> _protocolRepo;
        private GeneralRepository<Agenda> _agendaRepo;
        private GeneralRepository<Deal> _dealRepo;
        private GeneralRepository<User> _userRepo;
        private GeneralRepository<Region> _regionRepo;
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

		public IRepository<DealType> DealTypes
        {
            get
            {
                if (_dealTypeRepo == null)
                {
                    _dealTypeRepo = new GeneralRepository<DealType>(_dbContext);
                }
                return _dealTypeRepo;
            }
        }

        public IRepository<Protocol> Protocols
        {
            get
            {
                if (_protocolRepo == null)
                {
                    _protocolRepo = new GeneralRepository<Protocol>(_dbContext);
                }
                return _protocolRepo;
            }
        }

        public IRepository<Agenda> Agendas
        {
            get
            {
                if (_agendaRepo == null)
                {
                    _agendaRepo = new GeneralRepository<Agenda>(_dbContext);
                }
                return _agendaRepo;
            }
        }

        public IRepository<Deal> Deals
        {
            get
            {
                if (_dealRepo == null)
                {
                    _dealRepo = new GeneralRepository<Deal>(_dbContext);
                }
                return _dealRepo;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new GeneralRepository<User>(_dbContext);
                }
                return _userRepo;
            }
        }
        public IRepository<Region> Regions
        {
            get
            {
                if(_regionRepo == null)
                {
                    _regionRepo = new GeneralRepository<Region>(_dbContext);
                }
                return _regionRepo;
            }
        }
	}
}
