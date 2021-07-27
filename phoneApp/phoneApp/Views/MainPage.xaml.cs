using phoneApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace phoneApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //GetALLUsers
            var userList = await App.SQLiteDb.GetUsersAsync();
            if(userList != null)
            {
                lstPersons.ItemsSource = userList;
            }

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Users users = new Users()
                {
                    Name = txtName.Text
                };

                //Add New User
                await App.SQLiteDb.SaveItemAsync(users);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person added Successfully", "OK");
                //Get All Users
                var userList = await App.SQLiteDb.GetUsersAsync();
                if (userList != null)
                {
                    lstPersons.ItemsSource = userList;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserId.Text))
            {
                //Get User
                var users = await App.SQLiteDb.GetUser(Convert.ToInt32(txtUserId.Text));
                if (users != null)
                {
                    txtName.Text = users.Name;
                    await DisplayAlert("Success", "Person Name: " + users.Name, "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserId.Text))
            {
                Users users = new Users()
                {
                    UserID = Convert.ToInt32(txtUserId.Text),
                    Name = txtName.Text
                };

                //Update User
                await App.SQLiteDb.SaveItemAsync(users);

                txtUserId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated Successfully", "OK");
                //Get All Users
                var userList = await App.SQLiteDb.GetUsersAsync();
                if (userList != null)
                {
                    lstPersons.ItemsSource = userList;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserId.Text))
            {
                //Get User
                var person = await App.SQLiteDb.GetUser(Convert.ToInt32(txtUserId.Text));
                if (person != null)
                {
                    //Delete user
                    await App.SQLiteDb.DeleteItemAsync(person);
                    txtUserId.Text = string.Empty;
                    await DisplayAlert("Success", "Person Deleted", "OK");

                    //Get All Users
                    var userList = await App.SQLiteDb.GetUsersAsync();
                    if (userList != null)
                    {
                        lstPersons.ItemsSource = userList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllUsersPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage());
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calendar());
        }
    }
}

