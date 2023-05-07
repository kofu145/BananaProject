using BananaProject.ViewModels;
using BananaProject.Views;
using Microsoft.Extensions.Logging;

namespace BananaProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<EntryPage>();
		builder.Services.AddTransient<EntryViewModel>();
        builder.Services.AddSingleton<MessageBoard>();
		builder.Services.AddSingleton<MessageViewModel>();
		builder.Services.AddSingleton<EventPage>();
        builder.Services.AddSingleton<EventViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

