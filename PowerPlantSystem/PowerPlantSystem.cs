/*=============================================================================
|   Assignment: Final Project
|   Course: SWENG 421
|   
|   Authors:    David Lengel
|               Jaden Bridges
*============================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlantSystem
{
    public partial class PowerPlantSystem : Form
    {
        ReactorIF current_reactor = null;
        List<ReactorIF> rifl = new List<ReactorIF>();
        FactoryIF fif = new RCFactory();
        TerminationObservable to = new TerminationObservable();
        FilterIF filter = null;
        AddReactorForm rf;
        AddComponentForm cf;
        CurrentReactorThread crt;
        bool emergencyShutdown = false;
        bool plannedShutdown = false;

        delegate void SetTextCallback();

        public PowerPlantSystem()
        {
            InitializeComponent();

            crt = new CurrentReactorThread(this);
            Thread t1 = new Thread(crt.run);
            t1.Start();
        }

        // update all TextBox values
        public void updateValues()
        {
            if (current_reactor != null)
            {
                // TEMPERATURE
                filter = null;
                string data = current_reactor.getSensors()[0].getData();
                // check and apply any temperature filters
                if(CRadioButton.Checked)
                {
                    if (TempCheckBox.Checked)
                    {
                        filter = new CelsiusFilter(data);
                        filter = new IntegerFilter(filter);
                    }
                    else
                    {
                        filter = new CelsiusFilter(data);
                    }
                    data = filter.getData();
                }
                else if (TempCheckBox.Checked)
                {
                    filter = new IntegerFilter(data);
                    data = filter.getData();
                }
                int first = data.IndexOf('?');
                int last = data.LastIndexOf('?');
                string current_temp = data.Substring(0, first);
                string max_temp = data.Substring(first + 1, last - first - 1);
                string unit_temp = data.Substring(last + 1, data.Length - last - 1);

                // RADIATION
                filter = null;
                data = current_reactor.getSensors()[1].getData();
                // check and apply any temperature filters
                if (RadRadioButton.Checked)
                {
                    if (RadCheckBox.Checked)
                    {
                        filter = new RadFilter(data);
                        filter = new IntegerFilter(filter);
                    }
                    else
                    {
                        filter = new RadFilter(data);
                    }
                    data = filter.getData();
                }
                else if (RadCheckBox.Checked)
                {
                    filter = new IntegerFilter(data);
                    data = filter.getData();
                }
                first = data.IndexOf('?');
                last = data.LastIndexOf('?');
                string current_radi = data.Substring(0, first);
                string max_radi = data.Substring(first + 1, last - first - 1);
                string unit_radi = data.Substring(last + 1, data.Length - last - 1);

                // PRESSURE
                filter = null;
                data = current_reactor.getSensors()[2].getData();
                // check and apply any temperature filters
                if (KpaRadioButton.Checked)
                {
                    if (PresCheckBox.Checked)
                    {
                        filter = new KpaFilter(data);
                        filter = new IntegerFilter(filter);
                    }
                    else
                    {
                        filter = new KpaFilter(data);
                    }
                    data = filter.getData();
                }
                else if (PresCheckBox.Checked)
                {
                    filter = new IntegerFilter(data);
                    data = filter.getData();
                }
                first = data.IndexOf('?');
                last = data.LastIndexOf('?');
                string current_pres = data.Substring(0, first);
                string max_pres = data.Substring(first + 1, last - first - 1);
                string unit_pres = data.Substring(last + 1, data.Length - last - 1);

                try {
                    TempTextBox.Invoke(new Action(() => TempTextBox.Text = current_temp));
                    MaxTempTextBox.Invoke(new Action(() => MaxTempTextBox.Text = max_temp));
                    TempUnitsTextBox.Invoke(new Action(() => TempUnitsTextBox.Text = unit_temp));
                    RadTextBox.Invoke(new Action(() => RadTextBox.Text = current_radi));
                    MaxRadTextBox.Invoke(new Action(() => MaxRadTextBox.Text = max_radi));
                    RadUnitsTextBox.Invoke(new Action(() => RadUnitsTextBox.Text = unit_radi));
                    PresTextBox.Invoke(new Action(() => PresTextBox.Text = current_pres));
                    MaxPresTextBox.Invoke(new Action(() => MaxPresTextBox.Text = max_pres));
                    PresUnitsTextBox.Invoke(new Action(() => PresUnitsTextBox.Text = unit_pres));
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void refreshReactorComboBox()
        {
            ReactorComboBox.Items.Clear();
            foreach (ReactorIF rif in rifl)
            {
                ReactorComboBox.Items.Add(rif.getName());
            }
        }

        private void refreshComponentListBox()
        {
            ComponentsListBox.Items.Clear();
            foreach (ComponentIF cif in current_reactor.getComponents())
            {
                ComponentsListBox.Items.Add(cif.getName());
            }
        }

        private void refreshSubscribeButton()
        {
            // if subscribed
            if (current_reactor.getSubscribedPS())
                SubscribeButton.Text = "Unsubscribe from Planned Shutdown";
            // if not subscribed
            else
                SubscribeButton.Text = "Subscribe to Planned Shutdown";
        }

        private void setControlButtonTexts()
        {
            string unload = "Unload Control Program";
            string load = "Load Control Program";

            if (current_reactor.getControlStatus(0))
                TempCntrlButton.Text = unload;
            else
                TempCntrlButton.Text = load;
            if (current_reactor.getControlStatus(1))
                RadCntrlButton.Text = unload;
            else
                RadCntrlButton.Text = load;
            if (current_reactor.getControlStatus(2))
                PresCntrlButton.Text = unload;
            else
                PresCntrlButton.Text = load;
        }

        private void AddReactorButton_Click(object sender, EventArgs e)
        {
            // show dialog for adding reactor
            rf = new AddReactorForm();
            rf.ShowDialog();

            // create reactor based on that dialog
            ReactorIF tempreactor = (ReactorIF)fif.createObject(rf.reactor_type);
            if (tempreactor != null)
            {
                // set name
                tempreactor.setName(rf.reactor_name);
                // add to reactor list
                rifl.Add(tempreactor);
            }
            else
            {
                // notify user that reactor couldn't be created
                MessageBox.Show("Could not create reactor " + rf.reactor_name + ".");
            }

            // add created reactor to combobox
            refreshReactorComboBox();

            // start tracking new reactor
            current_reactor = rifl[rifl.Count - 1];
            ReactorComboBox.Text = current_reactor.getName();
        }

        private void AddComponentButton_Click(object sender, EventArgs e)
        {
            if (current_reactor != null)
            {
                // show dialog for adding component
                cf = new AddComponentForm();
                cf.ShowDialog();

                // create component based on that dialog and set its values
                ComponentIF tempcomponent = (ComponentIF)fif.createObject(cf.component_type);
                if (tempcomponent != null)
                {
                    // add properties then add to list
                    current_reactor.addComponent(tempcomponent);
                }
                else
                {
                    // notify user that reactor couldn't be created
                    MessageBox.Show("Could not create component " + rf.reactor_name + ".");
                }

                // update component list
                refreshComponentListBox();
            }
        }

        private void ReactorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_reactor = rifl[ReactorComboBox.SelectedIndex];
            refreshComponentListBox();
            refreshSubscribeButton();
            setControlButtonTexts();
        }

        private void EmergencyShutdownButton_Click(object sender, EventArgs e)
        {
            emergencyShutdown = !emergencyShutdown;
            PlannedShutdownButton.Enabled = !emergencyShutdown;
            if (emergencyShutdown)
                EmergencyShutdownButton.Text = "END EMERGENCY SHUTDOWN";
            else
                EmergencyShutdownButton.Text = "INITIATE EMERGENCY SHUTDOWN";

            // notify all reactors of shutdown
            foreach(ReactorIF reactor in rifl)
            {
                if (!(reactor.getSubscribedPS() && plannedShutdown))
                    reactor.notifyShutdown(emergencyShutdown);
            }
        }

        private void PlannedShutdownButton_Click(object sender, EventArgs e)
        {
            plannedShutdown = !plannedShutdown;
            if (plannedShutdown)
                PlannedShutdownButton.Text = "END PLANNED SHUTDOWN";
            else
                PlannedShutdownButton.Text = "INITIATE PLANNED SHUTDOWN";

            // disable subscribe button if planned shutdown in progress, else enable
            SubscribeButton.Enabled = !plannedShutdown;

            // notify all reactors subscribed to planned shutdown of shutdown
            if(!emergencyShutdown)
                to.notify();
        }

        private void SubscribeButton_Click(object sender, EventArgs e)
        {
            if (current_reactor != null)
            {
                // set subscribtion status
                current_reactor.setSubscribedPS(!current_reactor.getSubscribedPS());

                // add or remove from observer list
                if (current_reactor.getSubscribedPS())
                    to.addObserver(current_reactor);
                else
                    to.removeObserver(current_reactor);

                // change button text
                refreshSubscribeButton();
            }
        }

        private void TempCntrlButton_Click(object sender, EventArgs e)
        {
            if (current_reactor != null)
            {
                current_reactor.setControlStatus(0, !current_reactor.getControlStatus(0));

                if (current_reactor.getControlStatus(0))
                    TempCntrlButton.Text = "Unload Control Program";
                else
                    TempCntrlButton.Text = "Load Control Program";

                SensorIF tempsensor = current_reactor.getSensors()[0];

                if (current_reactor.getControlStatus(0)) {
                    // load control program
                    tempsensor.setControlProgram((AbstractSensorControlProgram)new TempControlProgram(tempsensor));
                }
                else {
                    // do not load control program
                    tempsensor.setControlProgram(null);
                }
            }
        }

        private void RadCntrlButton_Click(object sender, EventArgs e)
        {
            if (current_reactor != null)
            {
                current_reactor.setControlStatus(1, !current_reactor.getControlStatus(1));

                if (current_reactor.getControlStatus(1))
                    RadCntrlButton.Text = "Unload Control Program";
                else
                    RadCntrlButton.Text = "Load Control Program";

                SensorIF radisensor = current_reactor.getSensors()[1];

                if (current_reactor.getControlStatus(1)) {
                    // load control program
                    radisensor.setControlProgram((AbstractSensorControlProgram)new RadiationControlProgram(radisensor));
                }
                else {
                    // do not load control program
                    radisensor.setControlProgram(null);
                }
            }
        }

        private void PresCntrlButton_Click(object sender, EventArgs e)
        {
            if (current_reactor != null)
            {
                current_reactor.setControlStatus(2, !current_reactor.getControlStatus(2));

                if (current_reactor.getControlStatus(2))
                    PresCntrlButton.Text = "Unload Control Program";
                else
                    PresCntrlButton.Text = "Load Control Program";

                SensorIF pressensor = current_reactor.getSensors()[2];

                if (current_reactor.getControlStatus(2)) {
                    // load control program
                    pressensor.setControlProgram((AbstractSensorControlProgram)new PressureControlProgram(pressensor));
                }
                else {
                    // do not load control program
                    pressensor.setControlProgram(null);
                }
            }
        }
    }
}
