using CommunityToolkit.Maui;
using MauiSqlite.Infrastructure;
using MauiSqlite.Infrastructure.Repository;
using MauiSqlite.ViewModels;

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

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder.Services.AddAutoMapper(options =>
		{
			options.AddProfile(new AutoMapperProfile());
		});
        builder.Services.AddDbContext<BlogContext>();
		builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<BlogViewModel>();

        var provider = builder.Services.BuildServiceProvider();

        return builder.Build();
	}
}
