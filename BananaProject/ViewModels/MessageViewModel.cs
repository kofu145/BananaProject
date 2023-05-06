using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BananaProject.ViewModel
{
	public partial class MessageViewModel : ObservableObject
	{
		[ObservableProperty]
		ObservableCollection<Dictionary<string, string>> posts;

		public MessageViewModel()
		{
			posts = new ObservableCollection<Dictionary<string, string>>();
			UpdateMessages();
		}


		[RelayCommand]
		void UpdateMessages()
		{
			// GET request to the server for current messages
		}
	}
}

