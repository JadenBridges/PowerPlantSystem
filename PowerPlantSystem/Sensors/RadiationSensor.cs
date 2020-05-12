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
    class RadiationSensor : SensorAC
    {
        public RadiationSensor() : base()
        {
            data = "0";
            unit = "gray";
        }

        public override void setData()
        {
            // if no control program loaded
            if (ascp == null)
            {
                Random random = new Random();
                double num = Convert.ToDouble(data);

                // sensor is responsible for generating data
                if ((random.Next(10) < 4) && (num > 1))
                    num -= random.NextDouble() * random.NextDouble();
                else
                    num += random.NextDouble() * random.NextDouble() * random.Next(4);

                data = num.ToString("0.00");
            }
            // if control program loaded
            else
            {
                // rely on control program to generate data
                data = ascp.adjust();
            }
        }
    }
}
