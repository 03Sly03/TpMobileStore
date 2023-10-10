using TpMobileStore.ViewModels;

namespace TpMobileStore.Pages;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel cartViewModel)
	{
		BindingContext = cartViewModel;
		InitializeComponent();
	}
}