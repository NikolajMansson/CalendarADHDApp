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
	public partial class TasksListPage : ContentPage
	{
        public ObservableCollection<WorkTask> WorkTasks;
        private string _email;
		public TasksListPage (string email)  
		{
			InitializeComponent ();
            WorkTasks = new ObservableCollection<WorkTask>();
            _email = email;
            FindWorkshifts();
		}

        private async void FindWorkshifts()
        {
            ApiServices apiServices = new ApiServices();
            var tasks = await apiServices.FindWorkTask(_email);

            foreach (var task in tasks)
            {
                WorkTasks.Add(task);
            }

            LvTasks.ItemsSource = WorkTasks;
        }

        private void LvTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTask = e.SelectedItem as WorkTask;
            Navigation.PushAsync(new SubTaskPage(selectedTask.TitleWorkTask));
        }
    }
}