using MauiSqlite.Services;

namespace MauiSqlite;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();

		MainPage = new NavigationPage();
		navigationService.NavigateToMainPage();
	}
}
