using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ExamenClaroVideo.Infrastructure
{
    public  class Eventos: IEventos
    {
        public event EventHandler<object> CambioData;
    }

    public interface IEventos
    {
         event EventHandler<object> CambioData;
    }
}
