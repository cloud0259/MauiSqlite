﻿using MauiSqlite.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure.Repository
{
    public interface IBlogRepository
    {
        public Task CreateBlogAsync(CreateUpdateBlogDto input);
        public Task<BlogDto> GetBlogAsync(int id);
        public Task<IEnumerable<BlogDto>> GetListBlogAsync();
        public Task UpdateBlogAsync(int id, CreateUpdateBlogDto input);
        public Task DeleteBlogAsync(int id);
    }
}
