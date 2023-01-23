using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiSqlite.ViewModels;

namespace MauiSqlite.Services
{
    public class NavigationService:INavigationService
    {
        readonly IServiceProvider _services;

        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    throw new Exception();
                }
            }
        }

        public NavigationService(IServiceProvider services)
            => _services = services;
       

        public Task NavigateToMainPage()
            => NavigateToPage<MainPage>();

        public Task NavigateToOtherPage<T>(object parameter) where T : ContentPage
            => NavigateToPage<T>(parameter);

        public Task NavigateBack()
        {
            if (Navigation.NavigationStack.Count > 1)
                return Navigation.PopAsync();

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        private async Task NavigateToPage<T>(object? parameter = null) where T : Page
        {
            var toPage = ResolvePage<T>();
            Console.WriteLine("resolution, de page");
            if (toPage is not null)
            {
                //Subscribe to the toPage's NavigatedTo event
                toPage.NavigatedTo += Page_NavigatedTo;

                //Get VM of the toPage
                var toViewModel = GetPageViewModelBase(toPage);

                //Call navigatingTo on VM, passing in the paramter
                if (toViewModel is not null)
                    await toViewModel.OnNavigatingTo(parameter);

                //Navigate to requested page
                await Navigation.PushAsync(toPage, true);

                //Subscribe to the toPage's NavigatedFrom event
                toPage.NavigatedFrom += Page_NavigatedFrom;
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }

        private async void Page_NavigatedFrom(object? sender, NavigatedFromEventArgs e)
        {
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1
                && Navigation.NavigationStack[^2] == sender;

            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= Page_NavigatedTo;
                    thisPage.NavigatedFrom -= Page_NavigatedFrom;
                }

                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }

        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        private async void Page_NavigatedTo(object? sender, NavigatedToEventArgs e)
            => await CallNavigatedTo(sender as Page);

        private Task CallNavigatedTo(Page? p)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        }

        private BaseViewModel? GetPageViewModelBase(Page? p)
            => p?.BindingContext as BaseViewModel;

        private T? ResolvePage<T>() where T : Page
            => _services.GetService<T>();

    
    }
}

