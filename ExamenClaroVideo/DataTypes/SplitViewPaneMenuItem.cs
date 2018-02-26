using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using System;

namespace ExamenClaroVideo.DataTypes
{
    public class SplitViewPaneMenuItem
    {
        public string Label { get; set; }

        public Symbol Icono { get; set; }

        public Type AssociatedPage { get; set; }        
    }
}
