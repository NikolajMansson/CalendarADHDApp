using CalendarADHDApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CalendarADHDApp.Helpers;

namespace CalendarADHDApp.Services
{
    class ApiServices
    {
        public async Task<bool> RegisterUser(string email, string password, string confirmPassword)
        {
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var calendarUser = new CalendarUser()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://calendaradhd.azurewebsites.net/api/Account/Register", content);
            await RegisterCalendarUser(calendarUser);
            return response.IsSuccessStatusCode;   
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var keyvalues = new List<KeyValuePair<string, string>>()
             {
               new KeyValuePair<string, string>("username", email),
               new KeyValuePair<string, string>("password", password),
               new KeyValuePair<string, string>("grant_type", "password"),
             };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://calendaradhd.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(keyvalues);
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(content);
            var accesstoken = jObject.Value<string>("access_token");
            Settings.Accesstoken = accesstoken;
            Settings.UserName = email;
            Settings.Password = password;
            return response.IsSuccessStatusCode;
        }

        public async Task<List<WorkTask>> FindWorkTask(string calendarUserEmail)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var workTaskApiUrl = "http://calendaradhd.azurewebsites.net/api/WorkTasks/Get";
            var json = await httpClient.GetStringAsync($"{workTaskApiUrl}?calendarUserEmail={calendarUserEmail}");
            return JsonConvert.DeserializeObject<List<WorkTask>>(json);
        }

        public async Task<List<WorkSubtask>> FindSubWorkTask(string calendarUserEmail, string titleWorkTask)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var workTaskApiUrl = "http://calendaradhd.azurewebsites.net/api/WorkSubtasks/Get";
            var json = await httpClient.GetStringAsync($"{workTaskApiUrl}?calendarUserEmail={calendarUserEmail}&titleWorkTask={titleWorkTask}");
            return JsonConvert.DeserializeObject<List<WorkSubtask>>(json);
        }

        public async Task<List<WorkTask>> LatestWorkTask()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var workTaskApiUrl = "http://calendaradhd.azurewebsites.net/api/WorkTasks/GetWorkTasks";
            var json = await httpClient.GetStringAsync(workTaskApiUrl);
            return JsonConvert.DeserializeObject<List<WorkTask>>(json);
        }
        public async Task<bool> RegisterWorkTask(WorkTask workTask)
        {
            var json = JsonConvert.SerializeObject(workTask);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var workTaskApiUrl = "http://calendaradhd.azurewebsites.net/api/WorkTasks/PostWorkTask";
            var response = await httpClient.PostAsync(workTaskApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterWorkSubTask(WorkSubtask workSubtask)
        {
            var json = JsonConvert.SerializeObject(workSubtask);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var workSubtaskApiUrl = "http://calendaradhd.azurewebsites.net/api/WorkSubtasks/PostWorkSubtask";
            var response = await httpClient.PostAsync(workSubtaskApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterCalendarUser(CalendarUser calendarUser)
        {
            var json = JsonConvert.SerializeObject(calendarUser);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var calendarUserApiUrl = "http://calendaradhd.azurewebsites.net/api/CalendarUsers/PostCalendarUser";
            var response = await httpClient.PostAsync(calendarUserApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterPause(Pause pause)
        {
            var json = JsonConvert.SerializeObject(pause);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var pauseApiUrl = "http://calendaradhd.azurewebsites.net/api/Pauses/PostPause";
            var response = await httpClient.PostAsync(pauseApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterReminder(Reminder reminder)
        {
            var json = JsonConvert.SerializeObject(reminder);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var reminderApiUrl = "http://calendaradhd.azurewebsites.net/api/Reminders/PostReminder";
            var response = await httpClient.PostAsync(reminderApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterPlannedWorkshift(PlannedWorkshift plannedWorkshift)
        {
            var json = JsonConvert.SerializeObject(plannedWorkshift);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.Accesstoken);
            var plannedWorkshiftApiUrl = "http://calendaradhd.azurewebsites.net/api/PlannedWorkshifts/PostPlannedWorkshift";
            var response = await httpClient.PostAsync(plannedWorkshiftApiUrl, content);
            return response.IsSuccessStatusCode;
        }

    }

}
