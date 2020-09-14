using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolTableCursed.AdministratorWindow
{
    public class TabNavigator : INotifyPropertyChanged
    {
        private FrameworkElement _element;
        public FrameworkElement Element
        {
            get => _element; 
            set 
            {
                _element = value;
                OnPropertyChanged("Page"); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
