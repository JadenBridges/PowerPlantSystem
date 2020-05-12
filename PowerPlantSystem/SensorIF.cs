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
    interface SensorIF
    {
        string getData();
        void setData();
        void setMax();
        void shutdown(bool isShutdown);
        void recordMax(bool start, SensorIF sif);
        bool getIsShutdown();
        void setControlProgram(AbstractSensorControlProgram ascp);
    }
}
