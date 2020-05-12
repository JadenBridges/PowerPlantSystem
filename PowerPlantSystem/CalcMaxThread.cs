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
using System.Threading;

namespace PowerPlantSystem
{
    class CalcMaxThread
    {
        private SensorIF sif;

        public CalcMaxThread(SensorIF sif)
        {
            this.sif = sif;
        }

        public void run()
        {
            while(true)
            {
                sif.setMax();
                Thread.Sleep(100);
            }
        }
    }
}
