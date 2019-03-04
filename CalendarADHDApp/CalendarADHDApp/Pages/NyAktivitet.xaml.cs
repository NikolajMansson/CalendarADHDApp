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
	public partial class NyAktivitet : ContentPage
	{
		public NyAktivitet ()
		{
			InitializeComponent ();
		}

        private async void BtnOk_OnClicked(object sender, EventArgs e)
        {

            ApiServices apiServices = new ApiServices();
            var calendarUser = new CalendarUser()
            {
                Email = Settings.UserName,
                Password = Settings.Password
            };
            var workTask = new WorkTask()
            {
                TitleWorkTask = "Handla",
                CalendarUserEmail = "johnny@gmail.com",
            };
            bool response = await apiServices.RegisterWorkTask(workTask);
            if (!response)
            {
                await DisplayAlert("Alert", "Something wrong...", "Cancel");
            }
            else
            {
                await DisplayAlert("Skapat!", "Din aktivitet har skapats", "Ok");
                Navigation.InsertPageBefore(new HomePage(), this);
                await Navigation.PopAsync();
            }

        }
    }
}