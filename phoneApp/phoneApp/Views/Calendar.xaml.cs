using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace phoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        public Calendar()
        {
            InitializeComponent();

            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;
        }

        private void OnLocalNotificationTapped(NotificationEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Notification Tapped", "Event Added", "OK");
            });
        }

        private void Button_Clicked(object sender, EventArgs b)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Reminder Added!!",
                Description = "Your Event Has been added to the Calendar",
                ReturningData = "Dummy data",
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(10)
                }
            };
            NotificationCenter.Current.Show(notification);
        }

        async void Calendar_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            string result = await DisplayPromptAsync("SpecialEvent", "Create a new Event:");

            if (result == null)
            {
                return;
            }

            var specialDates = calendar.SpecialDates;

            SpecialDate newDate = new SpecialDate(e.DateTime)
            {
                Selectable = true,
                BackgroundPattern = new BackgroundPattern(1)
                {
                    Pattern = new List<Pattern>
                    {
                         new Pattern { WidthPercent = 1f, HightPercent = 0.6f, Color = Color.Transparent },
                         new Pattern{ WidthPercent = 1f, HightPercent = 0.4f, Color = Color.Transparent, Text = result, TextColor=Color.Black, TextSize=11, TextAlign=TextAlign.Middle},
                    }
                }
            };
            specialDates.Add(newDate);

            calendar.SpecialDates = specialDates;
            calendar.ForceRedraw();

        }
    }
}