using AutoMapper;
using MauiSqlite.Domain.Models;
using MauiSqlite.Infrastructure;
using MauiSqlite.Infrastructure.Dtos;
using MauiSqlite.Infrastructure.Repository;
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
        public BlogDto Blog { get; set; }
        public ObservableCollection<BlogDto> Blogs { get; set; }
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
            var blogDto = param as CreateUpdateBlogDto;
            await CreateBlog(blogDto);
        });

        public ICommand GetAllBlogCommand => new Command(async () =>
        {
            await GetListBlogAsync();
        });

        public BlogViewModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            Blogs = new ObservableCollection<BlogDto>();
        }

        public async Task CreateBlog(CreateUpdateBlogDto input)
        {
            await _blogRepository.CreateBlogAsync(input);
        }

        public async Task GetBlogAsync(int id)
        {
            Blog = await _blogRepository.GetBlogAsync(id);
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

        public Task DeleteBlogAsync(int id)
        {
            _blogRepository.DeleteBlogAsync(id);
            return Task.CompletedTask;
        }

        public async Task UpdateBlogAsync(int id, CreateUpdateBlogDto input)
        {
            await _blogRepository.UpdateBlogAsync(id, input);
        }
    }
}
