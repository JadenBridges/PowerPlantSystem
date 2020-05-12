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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlantSystem
{
    public partial class AddReactorForm : Form
    {
        public string reactor_type;
        public string reactor_name;

        public AddReactorForm()
        {
            InitializeComponent();

            var subclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where typeof(ReactorAC).IsAssignableFrom(type) && type.IsClass
            select type;

            bool skipfirst = true;
            foreach (Type type in subclasses)
            {
                if (!skipfirst)
                {
                    object o = Activator.CreateInstance(type);
                    ReactorTypeComboBox.Items.Add(o.ToString().Remove(0, "PowerPlantSystem.".Length));
                }
                skipfirst = false;
            }
        }

        private void AddReactorButton_Click(object sender, EventArgs e)
        {
            reactor_type = ReactorTypeComboBox.GetItemText(ReactorTypeComboBox.SelectedItem);
            reactor_name = ReactorNameTextBox.Text;
            this.Close();
        }
    }
}
