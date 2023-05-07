using BananaProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaProject.ViewModels
{
    public partial class EntryViewModel : ObservableObject
    {

        [RelayCommand]
        async Task GoToMain()
        {
            App.Current.MainPage = new AppShell();
        }
    }
}
