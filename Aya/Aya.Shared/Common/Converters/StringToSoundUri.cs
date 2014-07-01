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
            return new Uri("ms-appx:///Assets/sound/" + value.ToString() + ".wav", UriKind.Absolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
