using TpMobileStore.ViewModels;

namespace TpMobileStore
{
    public partial class MainPage : ContentPage
    {

        public MainPage(ProductsViewModel productViewModel)
        {
            BindingContext = productViewModel;
            InitializeComponent();
        }
    }
}