using AndroidX.Core.Util;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BananaProject.ViewModels
{
    public partial class PostEntryViewModel : ObservableObject
    {
        [ObservableProperty]
        public string postText;

        [RelayCommand]
        async Task AttemptPost()
        {
            // POST request to the server to submit
            var post = new Dictionary<string, string>()
            {
                {"author", RequestsClient.Username},
                {"content", PostText},
                {"auth", RequestsClient.authToken}
            };
            var data = new FormUrlEncodedContent(post);

            await RequestsClient.httpClient.PostAsync(RequestsClient.Server + $"/posts", data);

            await Shell.Current.GoToAsync("..");
        }
    }
}
