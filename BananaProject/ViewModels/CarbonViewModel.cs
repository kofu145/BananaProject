using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace BananaProject.ViewModels
{
    public partial class CarbonViewModel : ObservableObject
    {
        [ObservableProperty]
        string text = "Hey wassup";


    }
}
