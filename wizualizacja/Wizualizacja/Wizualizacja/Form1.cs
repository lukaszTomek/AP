using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
namespace Wizualizacja
{
    public partial class Form1 : Form
    {
        Client client;
        Drawer drawer;
        bool connected=false;
        bool running;
        
        

        public Form1()
        {
            InitializeComponent();
            client = new Client();
            running = true;
            AirportState.initialize();
            drawer = new Drawer(pictureBox1.CreateGraphics());
            Thread drawingThread=new Thread(new ThreadStart( drawingLoop ) );
            drawingThread.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            drawer.draw();

        }

        private void drawingLoop()
        {
            const float fixedFPS = 10;
            const float timeStep = 1000.0f / fixedFPS;

            System.Timers.Timer timer = new System.Timers.Timer(timeStep);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
            while (running)
            {
            }
            drawer.stop();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            Thread.Sleep(100);
        }

       

    }
}
