using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Aya.Common.Converters
{
    public class UppercaseConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null ? value.ToString().ToUpper() : String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
