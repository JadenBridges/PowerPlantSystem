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
    abstract class AbstractSensorControlProgram
    {
        protected SensorIF sif;

        public AbstractSensorControlProgram(SensorIF sif)
        {
            this.sif = sif;
        }

        public abstract string adjust();
    }
}
