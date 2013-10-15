using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace TTTimer.Commands
{
    public class CRestore : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Window window = Application.Current.MainWindow;
            window.Visibility = Visibility.Visible;
        }
    }
}
