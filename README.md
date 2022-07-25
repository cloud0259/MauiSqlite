[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)


# .Net MAUI SQLite Sample

Sample built with .Net MAUI.

This sample implements SQLite with Entity Framework Core.

## Documentation


the application is based on three projects:  
* A Domain project for the models  
* An Infrastructure project for database management
* The MAUI project

## Usage/Examples

Before the first launch, be sure to perform a **migration** in the Infrastructure project

```
dotnet ef migrations add Initial_Create
```

To change the path of the .db file, you must edit the **BlogContextFactory** file and in the **BlogContext**
(An appsettings.json file is recommended)

```c#
 public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "blog.db");
            optionsBuilder.UseSqlite($"Data Source={sqlitePath}");

            return new BlogContext(optionsBuilder.Options);
        }
    }
```


## .Net MAUI Links

* [.NET MAUI Website](https://github.com/dotnet/maui-samples#:~:text=.NET%20MAUI%20Website,NET%20MAUI%20GitHub)
* [.NET MAUI Documentation](https://github.com/dotnet/maui-samples#:~:text=.NET%20MAUI%20Website,NET%20MAUI%20GitHub)
* [.NET MAUI Blog](https://github.com/dotnet/maui-samples#:~:text=.NET%20MAUI%20Website,NET%20MAUI%20GitHub)
* [.NET MAUI GitHub](https://github.com/dotnet/maui-samples#:~:text=.NET%20MAUI%20Website,NET%20MAUI%20GitHub)
## .Net Foundation

There are many .NET related projects on GitHub.

* [.NET home repo](https://github.com/dotnet/maui-samples#:~:text=There%20are%20many,ASP.NET%20Core.) - links to hundreds of .NET projects, from Microsoft and the community.
* [ASP.NET Core home](https://github.com/dotnet/maui-samples#:~:text=There%20are%20many,ASP.NET%20Core.) - the best place to start learning about ASP.NET Core.
## Authors

- [@Cloud0259](https://www.github.com/cloud0259)


## License

.NET (including the maui-samples repo) is licensed under the [MIT](https://choosealicense.com/licenses/mit/) license.

