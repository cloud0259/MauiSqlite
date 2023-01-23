using MauiSqlite.Domain.Models;
using MauiSqlite.Infrastructure.Dtos;
using MauiSqlite.Infrastructure.Repository;
using MauiSqlite.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiSqlite.ViewModels
{
    public class EditBlogViewModel:BaseViewModel
    {
        private BlogDto _blog;
        public BlogDto Blog { get=> _blog; set { _blog = value; RaisePropertyChange(); } }

        private readonly IBlogRepository _blogRepository;
        private readonly INavigationService _navigationService;

        public ICommand UpdateBlogCommand => new Command(async (param) =>
        {
            var blogDto = param as UpdateBlogDto;
            await UpdateBlogAsync(Blog.Id, blogDto);
        });

        public EditBlogViewModel(IBlogRepository blogRepository, INavigationService navigationService)
        {
            _blogRepository = blogRepository;
            _navigationService = navigationService;
        }

        public async Task GetBlogAsync(int id)
        {
            Blog = await _blogRepository.GetBlogAsync(id);
        }

        public async Task UpdateBlogAsync(int id, UpdateBlogDto input)
        {
            await _blogRepository.UpdateBlogAsync(id, input);

            await _navigationService.NavigateBack();
        }

        public override async Task OnNavigatingTo(object parameter)
        {
            await GetBlogAsync((int)parameter);
            await base.OnNavigatingTo(parameter);
        }
    }
}
