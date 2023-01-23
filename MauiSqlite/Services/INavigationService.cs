using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Services
{
    public interface INavigationService
    {
        Task NavigateToOtherPage<T>(object parameter) where T: ContentPage;
        Task NavigateBack();
        Task NavigateToMainPage();
    }
}
