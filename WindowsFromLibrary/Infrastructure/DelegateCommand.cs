using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFromLibrary.Infrastructure
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public bool CanExecuteProperty
        {
            get => CanExecute ();
        }

        public DelegateCommand ( Action action , Func<bool> canExecute = default )
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute ( object parameter )
        {
            return _canExecute?.Invoke () ?? true;
        }

        public bool CanExecute ()
        {
            return _canExecute?.Invoke () ?? true;
        }

        public void Execute ( object parameter )
        {
            _action?.Invoke ();
        }

        public void Execute ()
        {
            _action?.Invoke ();
        }

        public void DelegateCanExecute ()
        {
            CanExecuteChanged?.Invoke ( this , EventArgs.Empty );
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;

        public DelegateCommand ( Action<T> action , Func<T , bool> canExecute = default )
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute ( object parameter )
        {
            return _canExecute?.Invoke ( ( T ) parameter ) ?? true;
        }

        public void Execute ( object parameter )
        {
            _action?.Invoke ( ( T ) parameter );
        }

        public void DelegateCanExecute ()
        {
            CanExecuteChanged?.Invoke ( this , EventArgs.Empty );
        }
    }
}
