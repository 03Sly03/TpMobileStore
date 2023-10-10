using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMobileStore.Services
{
    public class NavigationService : INavigationService
    {
        private ArgsService _argsService;

        public NavigationService(ArgsService argsService)
        {
            _argsService = argsService;
        }
        public Task NavigateToAsync(string route, IDictionary<string, object> parameters = null)
        {
            if (parameters != null)
                foreach (var (key, value) in parameters)
                {
                    _argsService.Save(key, value);
                }
            return Shell.Current.GoToAsync(route);
            //if(parameters != null)
            //    return Shell.Current.GoToAsync(route, parameters);
            //else
            //    return Shell.Current.GoToAsync(route);
        }

        public Task PopAsync()
        {
            return Shell.Current.Navigation.PopAsync();
        }
    }
}
