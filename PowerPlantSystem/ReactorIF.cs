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
    interface ReactorIF : ObserverIF, RCIF
    {
        List<SensorIF> getSensors();
        List<ComponentIF> getComponents();
        void addComponent(ComponentIF cif);
        void setName(string name);
        void setSubscribedPS(bool sps);
        bool getSubscribedPS();
        void setControlStatus(int index, bool status);
        bool getControlStatus(int index);
    }
}
