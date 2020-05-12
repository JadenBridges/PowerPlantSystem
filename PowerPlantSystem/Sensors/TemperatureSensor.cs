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
    class TemperatureSensor : SensorAC
    {
        public TemperatureSensor()
        {
            data = "70";
            unit = "F";
        }

        public override void setData()
        {
            // if no control program loaded
            if (ascp == null)
            {
                Random random = new Random();
                double num = Convert.ToDouble(data);

                // sensor is responsible for setting data
                if (random.Next(10) < 3)
                    num -= random.Next(2) * random.NextDouble();
                else
                    num += random.Next(4) * random.NextDouble();

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
