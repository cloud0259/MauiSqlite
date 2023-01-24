using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? Description { get; set; }
        public string? Other { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
