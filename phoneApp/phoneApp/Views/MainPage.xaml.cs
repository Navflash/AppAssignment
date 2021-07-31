using phoneApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Xamarin.Forms;
using Tweetinvi;
using Tweetinvi.Models;
using Xamarin.Auth;
using Xamarin.Essentials;

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

        private static void Message()
        {

            string accountSid = "AC7c75eec37a44ee26509a3f8a2edba918";
            string authToken = "2b8e0c9cebfff799bfb5f63401cdc3c4";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is a Test Message",
                from: new Twilio.Types.PhoneNumber("+18782016301"),
                to: new Twilio.Types.PhoneNumber("+919971069076")
            );

            Console.WriteLine(message.Sid);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Message();
        }
        private async static void Twitter()
        {
            var creds = new TwitterCredentials("Ao9x8Px5jLPizlGbhJgcagRoE", "xmsPiTAykHi2OLRLaVAn6yeQTpBAFOoWk6AwT86pXpGqgytmZI", "876154838521917440-5WAkuCnX1jUvyfcqS50TjzYInRzOgSm", "nKS7jrhWKMevr2JY5zLgTkxQJHcfgfGw4wOk8NmAlKYKJ");
            var client = new TwitterClient(creds);
            var authenticatedUser = client.Users.GetAuthenticatedUserAsync().Result;
            var tweet = await client.Tweets.PublishTweetAsync("Test Tweet");

        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            Twitter();
        }

        private async void ToolbarItem_Clicked_3(object sender, EventArgs e)
        {
            if (!await Launcher.TryOpenAsync("twitter://user?user_id=876154838521917440"))
            {
                await Browser.OpenAsync("https://twitter.com/dropofsagar");
            }
        }
    }
}

