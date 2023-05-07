using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaProject.ViewModels
{
    public partial class CameraViewModel : ObservableObject
    {

        [ObservableProperty]
        Image mainImage;

        public CameraViewModel()
        {
           
        }

        [RelayCommand]
        async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    var content = new MultipartFormDataContent();

                    var stream = photo.OpenReadAsync().Result;
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        
                        var image = new ByteArrayContent(memoryStream.ToArray());
                        content.Add(image, "image", "test.jpg");
                    }
                    using (var result = await RequestsClient.httpClient.PostAsync(RequestsClient.Server + "/image", content))
                    {
                        using (var memoryStream = new MemoryStream(result.Content.ReadAsByteArrayAsync().Result))
                        {
                            this.MainImage = new Image
                            {
                                Source = ImageSource.FromStream(() => memoryStream)
                            };
                        }
                    }
                }
            }
        }
    }
}
