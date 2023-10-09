using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TpMobileStore.Models;
using TpMobileStore.Pages;
using TpMobileStore.Services;

namespace TpMobileStore.ViewModels
{
    [QueryProperty(nameof(MyProductDetails), "MyProductDetails")]
    public partial class ProductViewModel : BaseViewModel
    {
        public Product MyProductDetails { get; set; }

        public ProductViewModel(INavigationService navigationService, IAPIService apiService) : base(navigationService, apiService)
        {
        }
        
    }
}
