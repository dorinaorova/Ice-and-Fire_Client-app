using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KliensoldaliHf_GTAYJ0
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual void OnAppearing()
        {
        }
        public virtual async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state) { }
        public ViewModelBase(INavigation navigation)
        {
            Navigation = navigation;
        }

    }
}
