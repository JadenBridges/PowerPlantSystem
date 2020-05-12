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
    class ReactorAC : ReactorIF
    {
        private List<ComponentIF> cifl = new List<ComponentIF>();
        private List<SensorIF> sifl;
        private string name;
        private bool subscribedPS = false;
        private bool[] controlStatuses = { false, false, false };

        public ReactorAC()
        {
            sifl = new List<SensorIF>()
            {
                new TemperatureSensor(),
                new RadiationSensor(),
                new PressureSensor()
            };
        }

        public List<SensorIF> getSensors()
        {
            return sifl;
        }
        public List<ComponentIF> getComponents()
        {
            return cifl;
        }
        public void addComponent(ComponentIF cif)
        {
            cifl.Add(cif);
        }
        public void notifyShutdown(bool isShutdown)
        {
            // shut down or restart all sensors, depending on bool passed in
            foreach(SensorIF sensor in sifl)
            {
                sensor.shutdown(isShutdown);
            }
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setSubscribedPS(bool sps)
        {
            subscribedPS = sps;
        }
        public bool getSubscribedPS()
        {
            return subscribedPS;
        }
        public void setControlStatus(int index, bool status)
        {
            if (!((0 <= index) && (index <= 3)))
                return;
            controlStatuses[index] = status;
        }
        public bool getControlStatus(int index)
        {
            if(!((0 <= index) && (index <= 3)))
                return false;
            return controlStatuses[index];
        }
    }
}
