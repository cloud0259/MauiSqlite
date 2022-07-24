﻿using AutoMapper;
using MauiSqlite.Domain.Models;
using MauiSqlite.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;
        private readonly IMapper _mapper;

        public BlogRepository(BlogContext blogContext, IMapper mapper)
        {
            _blogContext = blogContext;
            _mapper = mapper;
        }

        public async Task CreateBlogAsync(CreateUpdateBlogDto input)
        {
            var blog = _mapper.Map<CreateUpdateBlogDto, Blog>(input);
            await _blogContext.Blogs.AddAsync(blog);
            await _blogContext.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            var blog = await  _blogContext.Blogs.Where(b => b.Id == id).FirstOrDefaultAsync();
            if(blog != null)
                _blogContext.Blogs.Remove(blog);
        }

        public async Task<BlogDto> GetBlogAsync(int id)
        {
            var blog = await _blogContext.Blogs.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (blog == null)
                return null;
            return _mapper.Map<Blog, BlogDto>(blog);
        }

        public async Task<IEnumerable<BlogDto>> GetListBlogAsync()
        {
            var blogs = await _blogContext.Blogs.ToListAsync();
            return _mapper.Map<List<Blog>, List<BlogDto>>(blogs);
        }

        public async Task UpdateBlogAsync(int id, CreateUpdateBlogDto input)
        {
            var blog = await _blogContext.Blogs.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (blog != null)
            {
                blog.FirstName = input.FirstName;
                blog.Name = input.Name;
                blog.Description = input.Description;

                 _blogContext.Blogs.Update(blog);
                await _blogContext.SaveChangesAsync();
            }
        }
    }
}
