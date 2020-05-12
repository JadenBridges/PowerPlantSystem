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
    class KpaFilter : FilterAC
    {
        public KpaFilter(FilterIF fif) : base(fif) {}
        public KpaFilter(string data) : base(data) {}

        public override string getData()
        {
            if (fif != null)
            {
                data = fif.getData();
            }
            
            // replace current and max values with kpa and replace units

            int first = data.IndexOf('?');
            int last = data.LastIndexOf('?');

            // get the doubles from the data string
            double currentd = Convert.ToDouble(data.Substring(0, first));
            double maxd = Convert.ToDouble(data.Substring(first + 1, last - first - 1));

            // convert those values to kpa
            currentd = currentd * 6.895;
            maxd = maxd * 6.895;

            // fix data string
            return currentd.ToString("0.00") + "?" + maxd.ToString("0.00") + "?kPa";
        }
    }
}
