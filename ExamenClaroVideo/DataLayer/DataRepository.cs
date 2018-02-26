using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.DataLayer
{
    public class DataRepository : IDataRepository
    {

        public async void GuardarListaPeliculas(ObservableCollection<Db_Peliculas> observableCollection)
        {
            try
            {
                using (var db = new DatosContext())
                {
                    foreach (var item in observableCollection)
                    {
                        var data = db.Peliculas.Where(x => x.Id == item.Id).FirstOrDefault();
                        if (data != null)
                        {
                            db.Peliculas.Remove(data);
                            await db.SaveChangesAsync();
                        }
                        await db.Peliculas.AddAsync(item);
                    }
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }    
        }
        public ObservableCollection<Db_Peliculas>  DameListaPeliculas()
        {
            try
            {
                ObservableCollection<Db_Peliculas> datosGuardados = new ObservableCollection<Db_Peliculas>();
                using (var db = new DatosContext())
                {
                     datosGuardados = new ObservableCollection<Db_Peliculas>(db.Peliculas);
                }
                return datosGuardados;
            }
            catch (Exception ex)
            {                
                Debug.WriteLine(ex);
                return new ObservableCollection<Db_Peliculas>();
            }
        }


    }
}
