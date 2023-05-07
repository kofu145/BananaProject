using BananaProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BananaProject.ViewModels
{
    public partial class EntryViewModel : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string loginStatus;
        
        public EntryViewModel()
        {
            LoginStatus = "Sign up now, or login if you have an account!";
        }

        [RelayCommand]
        async Task AttemptSignup()
        {
            var payload = new Dictionary<string, string>()
            {
                {"username", Username},
            };
            var data = new FormUrlEncodedContent(payload);
            using (var result = await RequestsClient.httpClient.PostAsync(RequestsClient.Server + "/signup", data))
            {
                var stringContent = result.Content.ReadAsStringAsync();
                stringContent.Wait();
                dynamic jsonResult = JsonConvert.DeserializeObject<dynamic>(stringContent.Result);

                LoginStatus = jsonResult.message;
            }
                
        }

        [RelayCommand]
        async Task AttemptSignin()
        {
            var payload = new Dictionary<string, string>()
            {
                {"username", Username},
            };
            var data = new FormUrlEncodedContent(payload);
            using (var result = await RequestsClient.httpClient.PostAsync(RequestsClient.Server + "/login", data))
            {
                var stringContent = result.Content.ReadAsStringAsync();
                stringContent.Wait();
                dynamic jsonResult = JsonConvert.DeserializeObject<dynamic>(stringContent.Result);
                string authToken = jsonResult.auth;

                if (result.StatusCode == HttpStatusCode.OK)
                {

                    RequestsClient.Username = Username;
                    RequestsClient.authToken = authToken;
                    App.Current.MainPage = new AppShell();
                }
                else
                {
                    LoginStatus = jsonResult.message;
                }
            }
            
        }

        [RelayCommand]
        async Task GoToMain()
        {
            App.Current.MainPage = new AppShell();
        }
    }
}
