using ExamenClaroVideo.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.Model
{
    public interface IBussinesLayer
    {
        bool HayInternet();
        Task<ObservableCollection<PeliculaDetalleType>> DameListaPelis();
        void PeliculaActualSet(PeliculaDetalleType peliculaActual);
        PeliculaDetalleType PeliculaActualGet();

    }
}
