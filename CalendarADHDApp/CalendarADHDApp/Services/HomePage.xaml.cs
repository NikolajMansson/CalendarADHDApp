using CalendarADHDApp.Helpers;
using CalendarADHDApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarADHDApp.Services
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        private void Tblogout_OnClicked(object sender, EventArgs e)
        {
            Settings.UserName = "";
            Settings.Password = "";
            Settings.Accesstoken = "";
            Navigation.InsertPageBefore(new SignInPage(), this);
            Navigation.PopAsync();

        }
        
        private void BtnAddActivity_OnClicked(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new RegisterWorkTaskPage(), this);
            Navigation.PopAsync();

        }
        private void BtnSearchActivity_OnClicked(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new TasksListPage(Settings.UserName), this);
            Navigation.PopAsync();

        }

    }
}