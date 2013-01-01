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
    public partial class Form1 : Form
    {
        Client client;
        bool connected=false;
        public Form1()
        {
            InitializeComponent();
            client = new Client();
        }

        private void connectBut_Click(object sender, EventArgs e)
        {
            if (client.Connect("192.168.153.130", 5678))
                connected = false;
            else connected = true;
        }

        private void newSuitcaseBut_Click(object sender, EventArgs e)
        {
            /*if (!connected)
            {
                MessageBox.Show("You are not connected to the system!");
                return;
            }*/

            //string s=client.SendRequest("wysylam bagaz");
            //MessageBox.Show(s);

            NewSuitcaseDialog newSuitcaseDialog = new NewSuitcaseDialog();
            if (newSuitcaseDialog.ShowDialog() == DialogResult.OK)
            {
                Suitcase suitcase = new Suitcase(
                    newSuitcaseDialog.getDangerous(),
                    newSuitcaseDialog.getWeight(),
                    newSuitcaseDialog.getPlaneID()
                    );
                
            }


        }

        private void newPlaneBut_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("You are not connected to the system!");
                return;
            }
        }



    }
}
