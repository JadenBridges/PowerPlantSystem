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
    class PressureSensor : SensorAC
    {
        public PressureSensor() : base()
        {
            data = "14";
            unit = "psi";
        }

        public override void setData()
        {
            // if no control program loaded
            if (ascp == null)
            {
                Random random = new Random();
                double num = Convert.ToDouble(data);

                // sensor is responsible for generating data
                if ((random.Next(10) < 4) && (num > 10))
                    num -= random.Next(10) * random.NextDouble();
                else
                    num += random.Next(15) * random.NextDouble();

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
