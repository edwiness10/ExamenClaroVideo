using ExamenClaroVideo.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ExamenClaroVideo.Converters
{
    internal class PeliculasTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value != null)
                {
                    if (value is ObservableCollection<PeliculaDetalleType>)
                    {
                        var data = (ObservableCollection<PeliculaDetalleType>)value;
                        if (data.Count > 0)
                        {
                            return Visibility.Collapsed;
                        }
                    }                   
                }
                return Visibility.Visible;
            }
            catch (Exception)
            {
                return Visibility.Visible;
            }           
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
