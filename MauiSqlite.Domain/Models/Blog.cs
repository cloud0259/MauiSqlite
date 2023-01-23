using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Domain.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? Description { get; set; }
        public string? Test { get; set; }
        public string? Other { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

    }
}
