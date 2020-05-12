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
    class IntegerFilter : FilterAC
    {
        public IntegerFilter(FilterIF fif) : base(fif) {}
        public IntegerFilter(string data) : base(data) {}

        public override string getData()
        {
            if (fif != null)
            {
                data = fif.getData();
            }

            // replace doubles for current and max values with ints
            
            int first = data.IndexOf('?');
            int last = data.LastIndexOf('?');

            // get the doubles from the data string
            string currentd = data.Substring(0, first);
            string maxd = data.Substring(first + 1, last - first - 1);

            // convert the doubles to ints
            int currenti = Convert.ToInt32(Convert.ToDouble(currentd));
            int maxi = Convert.ToInt32(Convert.ToDouble(maxd));

            // remove old values from string
            data = data.Remove(0, last);

            // insert new values into string
            data = data.Insert(0, currenti.ToString() + "?" + maxi.ToString());

            return data;
        }
    }
}
