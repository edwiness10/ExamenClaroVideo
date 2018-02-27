using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace ExamenClaroVideo.Converters
{
    internal class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {           
           try
            {
                if (value != null)
                {
                    if (value is List<string>)
                    {
                        var dato = (List<string>)value;
                        if (dato.Count() > 0)
                        {
                            var data = String.Join(",", dato);
                            return data;
                        }
                    }
                }
                return"";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
