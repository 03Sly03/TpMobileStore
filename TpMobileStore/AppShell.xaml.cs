using TpMobileStore.Pages;

namespace TpMobileStore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ProductDetails), typeof(ProductDetails));
        }
    }
}