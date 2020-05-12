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
using System.Threading;
using System.Threading.Tasks;

namespace PowerPlantSystem
{
    class CurrentReactorThread
    {
        PowerPlantSystem pps;

        public CurrentReactorThread(PowerPlantSystem pps)
        {
            this.pps = pps;
        }

        public void run()
        {
            while (true)
            {
                pps.updateValues();
                Thread.Sleep(200);
            }
        }
    }
}
