using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calculator.viewmodels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, args);
        }
    }
}
