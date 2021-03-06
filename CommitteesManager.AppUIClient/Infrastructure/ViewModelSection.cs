﻿using CommitteesManager.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    abstract class ViewModelSection: ViewModelBase
    {
        protected IServiceProvider _services;
        public ViewModelSection(IServiceProvider inServiceProvider)
        {
            _services = inServiceProvider;
        }
        public string Name { get; set; }
        public bool IsExpanded { get; set; } = true;

        public abstract ViewModelSection Filter { get; set; }

        public event EventHandler<ViewModelEventArgs> CreateView;
        protected void InvokeCreateViewEvent(object derivedSender, ViewModelEventArgs e)
        {
            CreateView?.Invoke(derivedSender, e);
        }

        public event EventHandler<ViewModelEventArgs> WantToClose;

        protected RelayCommand _expandCmd;
        public RelayCommand Expand
        {
            get
            {
                if (_expandCmd == null)
                    _expandCmd = new RelayCommand(obj =>
                    {
                        IsExpanded = false;
                        OnPropertyChanged("IsExpanded");
                    });

                return _expandCmd;
            }
        }

        protected RelayCommand _closeCmd;
        public RelayCommand Close
        {
            get
            {
                if (_closeCmd == null)
                    _closeCmd = new RelayCommand(obj =>
                    {
                        WantToClose?.Invoke(this, new ViewModelEventArgs(JoinDirectionEnum.After, null));
                    });

                return _closeCmd;
            }
        }
    }
}
