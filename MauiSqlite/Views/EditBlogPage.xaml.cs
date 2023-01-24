using MauiSqlite.ViewModels;

namespace MauiSqlite.Views;

public partial class EditBlogPage : ContentPage
{
	EditBlogViewModel _editBlogViewModel;

	public EditBlogPage(EditBlogViewModel editBlogViewModel)
	{
		InitializeComponent();
		_editBlogViewModel = editBlogViewModel;
		BindingContext = _editBlogViewModel;
	}
}