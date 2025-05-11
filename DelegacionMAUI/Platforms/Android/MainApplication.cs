using Android.App;
using Android.Runtime;

namespace DelegacionMAUI;

//[Application]
//Se agrego lo siguiente para conectarnos a nuestra api no segura
[Application(UsesCleartextTraffic = true)]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
