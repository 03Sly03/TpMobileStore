using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TpMobileStore.Models;
using TpMobileStore.Services;
using TpMobileStore.ViewModels;

namespace TpMobileStore.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public IAPIService _apiService;
        protected readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService, IAPIService apiService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }
    }
}
