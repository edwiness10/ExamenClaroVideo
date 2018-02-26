using ExamenClaroVideo.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.DataLayer
{
    public interface IDataRepository
    {
        void GuardarListaPeliculas(ObservableCollection<Db_Peliculas> observableCollection);
    }
}
