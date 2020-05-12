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
    class TempControlProgram : AbstractSensorControlProgram
    {
        public TempControlProgram(SensorIF sif) : base(sif)
        {
        }

        public override string adjust()
        {
            Random random = new Random();
            string data = sif.getData();
            double num = Convert.ToDouble(data.Substring(0, data.IndexOf('?')));

            // bring down temperature if above 0, raise if below 0

            if (num > 32)
                num -= num / random.Next(20, 30) + random.Next(0, 3);
            else
            {
                if (num > 0)
                    num += num / random.Next(20, 30);
                if (num == 0)
                    num += 0.1;
                else
                    num += num / random.Next(20, 30);
            }

            data = data.Remove(0, data.IndexOf('?'));
            
            return num.ToString("0.00");
        }
    }
}
