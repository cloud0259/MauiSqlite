using AutoMapper;
using MauiSqlite.Domain.Models;
using MauiSqlite.Infrastructure;
using MauiSqlite.Infrastructure.Dtos;
using MauiSqlite.Infrastructure.Repository;
using MauiSqlite.Services;
using MauiSqlite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiSqlite.ViewModels
{
    public class BlogViewModel:BaseViewModel
    {
        private bool _isExisting = false;
        public ObservableCollection<BlogDto> Blogs { get; set; }
        private readonly INavigationService _navigationService;

        public bool IsRefreshing
        {
            get => _isExisting;
            set
            {
                _isExisting = value;
                RaisePropertyChange();
            }
        }

        private readonly IBlogRepository _blogRepository;

        public ICommand AddBlogCommand => new Command(async (param) =>
        {
            var blogDto = param as CreateBlogDto;
            await CreateBlog(blogDto);
        });

        public ICommand GetAllBlogCommand => new Command(async () =>
        {
            await GetListBlogAsync();
        });

        public ICommand DeleteBlogCommand => new Command(async (param) =>
        {
            var id = (int)param;
            await DeleteBlogAsync(id);
        });

        public ICommand NavigateToUpdateCommand => new Command(async (param) =>
        {
            await _navigationService.NavigateToOtherPage<EditBlogPage>(param);
        });

        public BlogViewModel(IBlogRepository blogRepository, INavigationService navigationService)
        {
            _blogRepository = blogRepository;
            _navigationService = navigationService;
            Blogs = new ObservableCollection<BlogDto>();
        }

        public async Task CreateBlog(CreateBlogDto input)
        {
            await _blogRepository.CreateBlogAsync(input);
            await GetListBlogAsync();
        }

        public async Task GetListBlogAsync()
        {
            IsRefreshing = true;
            Blogs.Clear();
            var listBlog =  await _blogRepository.GetListBlogAsync();
            if (listBlog != null)
            {
                foreach (var blog in listBlog)
                {
                    Blogs.Add(blog);
                }
            }
            IsRefreshing = false;
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _blogRepository.DeleteBlogAsync(id);
            await GetListBlogAsync();
        }
    }
}
