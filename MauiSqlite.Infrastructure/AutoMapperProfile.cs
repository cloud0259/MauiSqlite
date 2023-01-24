using AutoMapper;
using MauiSqlite.Domain.Models;
using MauiSqlite.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateBlogDto, Blog>();
            CreateMap<Blog,BlogDto>();
        }
    }
}
