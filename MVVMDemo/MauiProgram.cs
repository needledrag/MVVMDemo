using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;

namespace MVVMDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
	
		builder.Services.AddTransient<ViewModels.TransientMsgRecieverViewModel>();
		builder.Services.AddTransient<ViewModels.MessageSenderViewModel>();
        builder.Services.AddSingleton<ViewModels.SingletonMsgRecieverViewModel>();

        return builder.Build();
	}
}

