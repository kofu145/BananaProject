using Android.App;
using Android.Runtime;

namespace BananaProject;

                                   // connect to local service on the
[Application(UsesCleartextTraffic = true)]  // emulator's host for debugging,
                                   // access via http://10.0.2.2

public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

