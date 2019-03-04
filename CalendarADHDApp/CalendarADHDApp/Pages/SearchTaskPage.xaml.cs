using CalendarADHDApp.Helpers;
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
	public partial class SearchTaskPage : ContentPage
	{
		public SearchTaskPage ()
		{
			InitializeComponent ();
		}
        private void BtnSearch_OnClick(object sender, EventArgs e)
        {
            var email = PickerUser.Items[PickerUser.SelectedIndex].Trim();

            Navigation.PushAsync(new TasksListPage(Settings.UserName));
        }
    }


}