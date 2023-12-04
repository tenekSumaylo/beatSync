using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using beatSync.ViewModels;


namespace beatSync
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransientPopup<CreateAccount, CreateAccountViewModel>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<CreateAccount>();
            builder.Services.AddTransient<CreateAccountViewModel>();

            builder.Services.AddTransient<PublisherLandingPage>();
            builder.Services.AddTransient<PublisherLandingPageViewModel>();

            builder.Services.AddTransient<AddSong>();
            builder.Services.AddTransient<AddSongViewModel>();


            return builder.Build();
        }
    }
}