/*=============================================================================
|   Assignment: Final Project
|   Course: SWENG 421
|   
|   Authors:    David Lengel
|               Jaden Bridges
*============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlantSystem
{
    class TerminationObservable : ObservableIF
    {
        private bool plannedShutdown = false;
        private List<ObserverIF> observers = new List<ObserverIF>();

        public void addObserver(ObserverIF oif)
        {
            observers.Add(oif);
        }
        public void removeObserver(ObserverIF oif)
        {
            observers.Remove(oif);
        }
        public void notify()
        {
            plannedShutdown = !plannedShutdown;
            foreach(ObserverIF observer in observers)
            {
                observer.notifyShutdown(plannedShutdown);
            }
        }
    }
}
