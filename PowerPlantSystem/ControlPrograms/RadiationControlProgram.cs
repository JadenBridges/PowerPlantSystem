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
    class RadiationControlProgram : AbstractSensorControlProgram
    {
        public RadiationControlProgram(SensorIF sif) : base(sif)
        {
        }

        public override string adjust()
        {
            string data = sif.getData();
            double num = Convert.ToDouble(data.Substring(0, data.IndexOf('?')));

            // bring down radiation

            num -= (num / 20);

            return num.ToString("0.00");
        }
    }
}
