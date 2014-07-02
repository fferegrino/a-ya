using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Aya.Common.Converters
{
    public class StringToSoundUri : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null ? new Uri("ms-appx:///Assets/sound/" + value.ToString() + ".wav", UriKind.Absolute) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
