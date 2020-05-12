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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlantSystem
{
    public partial class AddComponentForm : Form
    {
        public string component_type;

        public AddComponentForm()
        {
            InitializeComponent();

            var subclasses =
               from assembly in AppDomain.CurrentDomain.GetAssemblies()
               from type in assembly.GetTypes()
               where typeof(ComponentAC).IsAssignableFrom(type) && type.IsClass
               select type;

            bool skipfirst = true;
            foreach (Type type in subclasses)
            {
                if (!skipfirst)
                {
                    object o = Activator.CreateInstance(type);
                    ComponentTypeComboBox.Items.Add(o.ToString().Remove(0, "PowerPlantSystem.".Length));
                }
                skipfirst = false;
            }
        }

        private void AddComponentButton_Click(object sender, EventArgs e)
        {
            component_type = ComponentTypeComboBox.GetItemText(ComponentTypeComboBox.SelectedItem);
            this.Close();
        }
    }
}
