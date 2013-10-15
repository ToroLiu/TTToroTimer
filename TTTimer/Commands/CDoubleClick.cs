using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TTTimer.Commands
{
    public class CDoubleClick : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            MainWindow mw = parameter as MainWindow;
            if (mw == null) return;

            mw.DoDblClick();
        }
    }
}
