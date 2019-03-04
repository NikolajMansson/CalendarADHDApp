using CalendarADHDApp.Helpers;
using CalendarADHDApp.Models;
using CalendarADHDApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarADHDApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubTaskPage : ContentPage
	{
        public ObservableCollection<WorkSubtask> WorkSubtasks;
        private string _titleTask;
        public SubTaskPage (string titleTask)
		{
			InitializeComponent ();
            WorkSubtasks = new ObservableCollection<WorkSubtask>();
            _titleTask = titleTask;
            FindSubtasks();
        }

        private async void FindSubtasks()
        {
            ApiServices apiServices = new ApiServices();
            var tasks = await apiServices.FindSubWorkTask(Settings.UserName, _titleTask);

            foreach (var task in tasks)
            {
                WorkSubtasks.Add(task);
            }

            LvSubtasks.ItemsSource = WorkSubtasks;
        }
    }
}