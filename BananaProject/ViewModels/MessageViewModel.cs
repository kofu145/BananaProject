using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using BananaProject.Models;
using BananaProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace BananaProject.ViewModels
{
	public partial class MessageViewModel : ObservableObject
	{
		[ObservableProperty]
		ObservableCollection<Message> posts;

		public MessageViewModel()
		{
			Posts = new ObservableCollection<Message>();
			UpdateMessages();
		}

		[RelayCommand]
		public void RedirectPostEntry()
		{
			Shell.Current.GoToAsync(nameof(PostEntryPage));
        }

		

		[RelayCommand]
		async Task UpdateMessages()
		{
			// GET request to the server for current messages
			using (var result = await RequestsClient.httpClient.GetAsync(RequestsClient.Server + $"/posts?auth={RequestsClient.authToken}"))
			{
				var stringContent = result.Content.ReadAsStringAsync();
				stringContent.Wait();
				ObservableCollection<Message> jsonResult = JsonConvert.DeserializeObject<ObservableCollection<Message>>(stringContent.Result);
				Posts = new ObservableCollection<Message>(jsonResult.Reverse());
			}
            

        }
    }
}

