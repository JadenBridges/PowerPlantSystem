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
    abstract class FilterAC : FilterIF
    {
        protected FilterIF fif = null;
        protected string data;

        public FilterAC(FilterIF fif)
        {
            this.fif = fif;
        }
        public FilterAC(string data)
        {
            this.data = data;
        }

        public abstract string getData();
    }
}
