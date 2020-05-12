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

namespace PowerPlantSystem
{
    class SetDataThread
    {
        private SensorIF sif;
        private int timeout;

        public SetDataThread(SensorIF sif)
        {
            this.sif = sif;
            this.timeout = 1000;
        }
        public SetDataThread(SensorIF sif, int timeout)
        {
            this.sif = sif;
            this.timeout = timeout;
        }
        public void run() {
            // set first data
            sif.setData();
            // start recording max
            sif.recordMax(true, sif);
            // continue setting sensor data while sensor is still active
            while (!sif.getIsShutdown())
            {
                Thread.Sleep(timeout);
                sif.setData();
            }
            // if sensor is shut down, shut down threads
            sif.shutdown(true);
        }

    }
}
