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
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
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

        private Action _VMAction;
        private Action<T> _ParVMAction;
    }
}
