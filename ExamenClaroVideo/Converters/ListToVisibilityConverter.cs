using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ExamenClaroVideo.Converters
{
    internal sealed class ListToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value != null)
                {
                    var dato = (List<string>)value;
                    if (dato.Count() > 0)
                    {
                        return Visibility.Visible;
                    }

                }
                return Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Visibility.Visible;
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
