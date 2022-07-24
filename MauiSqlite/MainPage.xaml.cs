using MauiSqlite.ViewModels;

namespace MauiSqlite;

public partial class MainPage : ContentPage
{
	BlogViewModel _blogViewModel;

	public MainPage(BlogViewModel blogViewModel)
	{
		InitializeComponent();
		_blogViewModel = blogViewModel;		
		BindingContext = _blogViewModel;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await _blogViewModel.GetListBlogAsync();
	}

}

