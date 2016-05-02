using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restaurant.Services
{
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (_VMAction != null)
                _VMAction();
            if (_ParVMAction != null)
                _ParVMAction((T)parameter);
        }

        public RelayCommand(Action pAction)
        {
            _VMAction = pAction;
        }
        public RelayCommand(Action<T> pAction)
        {
            _ParVMAction = pAction;
        }

        public RelayCommand(Action<T> pAction, Predicate<T> pCanExecute)
        {
            _ParVMAction = pAction;
            _CanExecute = pCanExecute;
        }

        private Action _VMAction;
        private Action<T> _ParVMAction;
        private Predicate<T> _CanExecute;
    }
}
