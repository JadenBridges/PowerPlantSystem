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
    class ComponentFactory : FactoryIF
    {
        public RCIF createObject(string discriminator)
        {
            discriminator = "PowerPlantSystem." + discriminator;
            Type t = Type.GetType(discriminator, true);
            Object instance = Activator.CreateInstance(t);
            return (RCIF)instance;
        }
    }
}
