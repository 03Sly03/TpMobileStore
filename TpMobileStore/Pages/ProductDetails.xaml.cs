using TpMobileStore.ViewModels;

namespace TpMobileStore.Pages;

public partial class ProductDetails : ContentPage
{
	public ProductDetails(ProductViewModel productViewModel)
	{
		BindingContext = productViewModel;
		InitializeComponent();
	}
}