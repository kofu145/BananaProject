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
        Image image;

        public CameraViewModel()
        {
            Image = new Image
            {
                Source = ImageSource.FromResource("BananaProject.Images.camera.png")
            };
        }

        [RelayCommand]
        public async void TakePhoto()
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
                            this.Image = new Image
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
