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
    abstract class SensorAC : SensorIF
    {
        protected string data;
        protected double max = 0;
        protected string unit;
        protected AbstractSensorControlProgram ascp = null;
        protected SetDataThread sdt;
        protected CalcMaxThread cmt;
        public bool isShutdown = false;
        protected Thread tSetData;
        private Thread tTrackMax;

        public SensorAC()
        {
            data = "0";
            startSetData();
        }

        public abstract void setData();

        public string getData()
        {
            // create the data string with current value, max value, and units
            // each of these will be separated by a '?'
            // example for temperature:  75.62?98.74?F

            return data + "?" + max.ToString("0.00") + "?" + unit;
        }
        public void setMax()
        {
            double temp = Convert.ToDouble(data);
            if (temp > max)
            {
                max = temp;
            }
        }
        public void shutdown(bool isShutdown)
        {
            this.isShutdown = isShutdown;
            // if sensor is to shut down
            if (isShutdown)
            {
                // first shut down the thread calculating max values,
                // then shut down the thread generating values
                tSetData.Abort();
                data = "0";
            }
            // if sensor is to start up
            else
            {
                // first start up the thread generating values,
                // then start up the thread calculating max values
                startSetData();
            }
        }
        public void recordMax(bool start, SensorIF sif)
        {
            if (start)
            {
                // start thread to track max sensor value
                cmt = new CalcMaxThread(sif);
                tTrackMax = new Thread(cmt.run);
                tTrackMax.Start();
            }
            else
            {
                // abort thread to track max sensor value
                tTrackMax.Abort();
            }
        }
        public bool getIsShutdown()
        {
            return isShutdown;
        }
        private void startSetData()
        {
            max = 0;
            // start thread for generating new values
            sdt = new SetDataThread(this);
            tSetData = new Thread(sdt.run);
            tSetData.Start();
        }
        public void setControlProgram(AbstractSensorControlProgram ascp)
        {
            this.ascp = ascp;
        }
    }
}
