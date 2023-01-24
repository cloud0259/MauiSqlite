using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual Task OnNavigatingTo(object? parameter)
           => Task.CompletedTask;

        public virtual Task OnNavigatedFrom(bool isForwardNavigation)
            => Task.CompletedTask;

        public virtual Task OnNavigatedTo()
            => Task.CompletedTask;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}
