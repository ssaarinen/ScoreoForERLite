using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScoreoForERLite.App
{
    public class PropertyChangeNotifierBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}