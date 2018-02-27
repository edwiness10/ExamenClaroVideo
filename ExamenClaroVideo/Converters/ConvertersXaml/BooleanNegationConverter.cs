using System;
using System.Diagnostics;
using Windows.UI.Xaml.Data;

namespace ExamenClaroVideo.Converters
{
    internal class BooleanNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value != null)
                {
                    if (value is bool)
                    {
                        Boolean b = (Boolean)value;
                        return !b;
                    }                    
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
                     
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
