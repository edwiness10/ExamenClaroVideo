
using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Infrastructure;
using ExamenClaroVideo.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenClaroVideo.ViewModel
{
    public class DetallesViewModel : ViewModelBase
    {
        #region "Variables Etc"
        private ServiceNavigation serviceNavigation;
        private PeliculaDetalleType _peliculaActual;
        private ICommand _comandoGoBack;
        private ICommand _pageLoadedCommand;
        private IBussinesLayer bussinesLayer;
        #endregion

        #region "Propiedades"
        public ICommand ComandoGoBack
        {
            get
            {
                if (_comandoGoBack == null)
                {
                    _comandoGoBack = new RelayCommand(Goback);
                }
                return _comandoGoBack;
            }
        }
        public PeliculaDetalleType PeliculaActual
        {
            get { return _peliculaActual; }
            set
            {
                _peliculaActual = value;
                RaisePropertyChanged(() => PeliculaActual);
            }
        }
        public ICommand PageLoadedCommand
        {
            get
            {
                if (_pageLoadedCommand == null)
                {
                    _pageLoadedCommand = new RelayCommand(CargarDatos);
                }
                return _pageLoadedCommand;
            }
        }

        #endregion

        #region "Constructor Etc"
        public DetallesViewModel(IBussinesLayer bussinesLayer,ServiceNavigation serviceNavigation)
        {
            this.serviceNavigation = serviceNavigation;
            this.bussinesLayer = bussinesLayer;

        }

        #endregion

        #region "Procedimientos Externos"

        #endregion

        #region "Procedimientos Internos"
        private void Goback()
        {
            serviceNavigation.GoBack();
        }
        private void CargarDatos()
        {
            //if (PeliculaActual==null)
            //{
            //   PeliculaActual = bussinesLayer.PeliculaActualGet();
            //}
        }
        #endregion


    }
}
