
using MauiSqlite.Infrastructure;
using MauiSqlite.Infrastructure.Repository;
using MauiSqlite.Services;
using MauiSqlite.ViewModels;
using MauiSqlite.Views;

namespace MauiSqlite;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddAutoMapper(options =>
		{
			options.AddProfile(new AutoMapperProfile());
		});
        builder.Services.AddDbContext<BlogContext>();
		builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<EditBlogPage>();

        builder.Services.AddScoped<BlogViewModel>();
		builder.Services.AddScoped<EditBlogViewModel>();

        var provider = builder.Services.BuildServiceProvider();

        return builder.Build();
	}
}
