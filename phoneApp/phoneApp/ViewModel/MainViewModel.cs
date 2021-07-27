using phoneApp.Model;
using phoneApp.Services;
using phoneApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace phoneApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<UsersFromApi> _userlist;

        public List<UsersFromApi> Userslist
        {
            get { return _userlist; }
            set
            {
                _userlist = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var userservices = new UserServices();

            Userslist = await userservices.GetUsersAsync();
        }
        public INavigation Navigation { get; set; }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        //public Command GetUsersFromApi
        //{
        //    get
        //    {
        //        return new Command(async() =>
        //        {
        //            await Navigation.PushAsync(new AllUsersPage());
        //        });
        //    }
        //}
    }
}
