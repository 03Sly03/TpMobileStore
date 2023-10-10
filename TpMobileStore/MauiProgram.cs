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
            builder.Services.AddScoped<ProductsViewModel>();
            builder.Services.AddScoped<ProductViewModel>();
            builder.Services.AddScoped<CartViewModel>();
            builder.Services.AddScoped<IAPIService, RestAPIService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ProductDetails>();
            builder.Services.AddScoped<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ArgsService>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<CartPage>();
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