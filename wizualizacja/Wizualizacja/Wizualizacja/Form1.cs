﻿using System;
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
        Client specialEventsClient;
        Client stateCheckingClient;

        Drawer drawer;
        bool sCheckingConnected = false;      // tells whether state Checking Client is working 
        bool sEventsConnected = false;      // tells whether special Events Client is working
        bool running;
        bool isGetFullStateNecessary;
        bool isJustDrawing;    

        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            specialEventsClient = new Client();
            stateCheckingClient = new Client();
            running = true;
            isGetFullStateNecessary = true;

            AirportState.initialize();
            drawer = new Drawer(pictureBox1.CreateGraphics());
            Thread drawingThread=new Thread(new ThreadStart( drawingLoop ) );
            drawingThread.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (isJustDrawing)
                return;
            isJustDrawing = true;
            if (sCheckingConnected && isGetFullStateNecessary)
            {
                Console.WriteLine("PRZED1");
                AirportState.interpretMakeStatesQuery(
                        stateCheckingClient.SendRequest(stateCheckingClient.Serialize(new MessageInfo(RequestType.getFullState))),
                        stateCheckingClient);
                Console.WriteLine("PO1");
                isGetFullStateNecessary = false;
            }
            else if (sCheckingConnected)
            {
                Console.WriteLine("PRZED2");
                AirportState.interpretMakeStatesQuery(
                        stateCheckingClient.SendRequest(stateCheckingClient.Serialize(new MessageInfo(RequestType.getFullState))),
                        stateCheckingClient);
                Console.WriteLine("PO2");
            }
            drawer.draw();
            isJustDrawing = false;
        }

        private void drawingLoop()
        {
            const float fixedFPS = 8;
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
            if (specialEventsClient.Connect("192.168.65.128", 5678))
                sEventsConnected = false;
            else sEventsConnected = true;
            if (stateCheckingClient.Connect("192.168.65.128", 5679))
                sCheckingConnected = false;
            else sCheckingConnected = true;
            if (!sEventsConnected || !sCheckingConnected)
                MessageBox.Show("Problem with connection to host");
            //string buf=client.SendRequest(client.Serialize(new MessageInfo(RequestType.getFullState)));

            /*MessageBox.Show(buf);
            MessageInfo msgInfo = new MessageInfo(); 
            
            msgInfo = client.Deserialize(buf);
            AirportState.suitcasesArray = msgInfo.suitcasesArray;*/
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
                //suitcase.toString();


                specialEventsClient.SendRequest(specialEventsClient.Serialize(new MessageInfo(suitcase)));
                
            }


        }

        private void newPlaneBut_Click(object sender, EventArgs e)
        {
            if (!sEventsConnected)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


       

    }
}
