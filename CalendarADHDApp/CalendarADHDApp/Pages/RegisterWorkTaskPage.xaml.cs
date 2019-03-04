using CalendarADHDApp.Helpers;
using CalendarADHDApp.Models;
using CalendarADHDApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarADHDApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterWorkTaskPage : ContentPage
	{
		public RegisterWorkTaskPage ()
		{
			InitializeComponent ();
		}
        private async void OkButton_OnClicked(object sender, EventArgs e)
        {
            var title = EntTitle.Text;
            /*
            var calendarUser = new CalendarUser()
            {
                Email = Settings.UserName,
                Password = Settings.Password
            };
             */
            var workTask = new WorkTask()
            {
                TitleWorkTask = title,
                CalendarUserEmail = Settings.UserName
               // CalendarUser = calendarUser
            };
            ApiServices apiServices = new ApiServices();
            var response = await apiServices.RegisterWorkTask(workTask);
            if(!response)
            {
                await DisplayAlert("Alert", "Aktivitet har inte registrerats", "Cancel");

            }
            else
            {
                await DisplayAlert("Hi", "Din aktivitet har registrerats", "Alright");

            }
        }
    }


}