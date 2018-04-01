using ExamenClaroVideo.ViewModel;
using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ExamenClaroVideo.Infrastructure
{
    public class ServiceNavigation : ObservableObject
    {
        public Frame NavigationFrame { get; private set; }
        public void SetNavigationFrame(Frame frame)
        {
            frame.CacheSize = 3;
            if (frame == null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            if (NavigationFrame == null)
            {                
                NavigationFrame = frame;
                Navigate(typeof(CategoriaPage));
            }
        }
        public virtual void Navigate(Type destinationPage)
        {
            if (destinationPage!=null)
            {
                NavigationFrame.Navigate(destinationPage, null);
            }           
        }
        public virtual void NavigateTo(Type destinationPage, object parameter)
        {
            if (destinationPage != null)
            {
                NavigationFrame.Navigate(destinationPage, parameter);
               // NavigationFrame.BackStack.Clear();
            }           
        }
        public virtual void GoBack()
        {
            NavigationFrame.GoBack();
            
        }
    }
}
