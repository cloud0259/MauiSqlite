using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure.Dtos
{
    public class CreateBlogDto
    {
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? Description { get; set; }
    }
}
