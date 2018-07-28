using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    class RelayCommand : ICommand
    {
        Action<object> _action;
        Predicate<object> _canAction;
        public RelayCommand(Action<object> act, Predicate<object> canAct)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canAction == null ? true : _canAction(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
