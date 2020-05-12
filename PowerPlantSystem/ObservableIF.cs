﻿/*=============================================================================
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
    interface ObservableIF
    {
        void addObserver(ObserverIF oif);
        void removeObserver(ObserverIF oif);
        void notify();
    }
}
