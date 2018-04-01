using CommonServiceLocator;
using ExamenClaroVideo.DataLayer;
using ExamenClaroVideo.Infrastructure;
using ExamenClaroVideo.Model;
using ExamenClaroVideo.Services;
using GalaSoft.MvvmLight.Ioc;

namespace ExamenClaroVideo.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegistroServicios(SimpleIoc.Default);
            RegistroViewModel(SimpleIoc.Default);
        }
        private static void RegistroServicios(SimpleIoc ioc)
        {
            ioc.Register<IBussinesLayer, BussinesLayer>();
            ioc.Register<IDataRepository, DataRepository>();
            ioc.Register<IWebService, WebService>();
        }
        private static void RegistroViewModel(SimpleIoc ioc)
        {       
            ioc.Register<DetallesViewModel>();
            ioc.Register<CategoriaViewModel>();
            ioc.Register<MainPageViewModel>();
            ioc.Register<ServiceNavigation>();           
        }
       
        public static DetallesViewModel Detalle => ServiceLocator.Current.GetInstance<DetallesViewModel>();
        public static CategoriaViewModel Categoria => ServiceLocator.Current.GetInstance<CategoriaViewModel>();
        public static MainPageViewModel Main => ServiceLocator.Current.GetInstance<MainPageViewModel>();

    }
}
