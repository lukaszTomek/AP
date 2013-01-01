using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wizualizacja
{
    public enum selectedDangerous
    {
        NONE,
        DRUGS,
        EXPLOSIVES
    }
    public partial class NewSuitcaseDialog : Form
    {
        selectedDangerous selectedRadioButton;
        int weight;
        int planeId;

        public int getPlaneID()
        {
            return planeId;
        }
        public int getWeight()
        {
            return weight;
        }
        public selectedDangerous getDangerous()
        {
            return selectedRadioButton;
        }
        public NewSuitcaseDialog()
        {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property 
            // changed to true. 
            if (rb.Checked)
            {
                if(rb.Text=="Drugs")
                    selectedRadioButton=selectedDangerous.DRUGS;
                else if(rb.Text=="Explosives")
                    selectedRadioButton=selectedDangerous.EXPLOSIVES;
                else
                    selectedRadioButton = selectedDangerous.NONE;
            }

        }


        private void NewSuitcaseDialog_Load(object sender, EventArgs e)
        {
            noneRadio.Checked = true;
            List<Plane> planes= AirportState.getPlanes();
            foreach (Plane plane in planes)
                comboBox1.Items.Add(plane);
            if (planes.Count != 0)
                comboBox1.SelectedIndex = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //target plane na
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //etykieta napis
        }
    }
}
