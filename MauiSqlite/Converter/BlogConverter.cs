using MauiSqlite.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Converter
{
    public class BlogConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values.Length == 3)
            {
                string firstName = values[0].ToString();
                string name = values[1].ToString();
                string description = values[2].ToString();
                return new CreateUpdateBlogDto { Name = name, FirstName = firstName, Description = description };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}