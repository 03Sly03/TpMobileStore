using Microsoft.Extensions.Logging;
using TpMobileStore.Pages;
//using TpMobileStore.Pages;
using TpMobileStore.Services;
using TpMobileStore.ViewModels;

namespace TpMobileStore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductViewModel>();
            builder.Services.AddTransient<IAPIService, RestAPIService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ProductDetails>();
            builder.Services.AddTransient<INavigationService, NavigationService>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}