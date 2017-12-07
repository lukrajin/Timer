﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int counter;
        private Timer timer1;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Start.Text == "Start")
            {

                if (minin.Value != 0 || secin.Value != 0)
                {
                    Start.Text = "Pause";
                    minin.Enabled = false;
                    secin.Enabled = false;
                  
                    timer1 = new System.Windows.Forms.Timer();
                    counter = (int)secin.Value;
                    int m = (int)minin.Value;
                    if (m < 10)
                        minout.Text = "0" + m.ToString();
                    else
                        minout.Text = m.ToString();

                    Stop.Enabled = true;
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; 
                    timer1.Start();


                    if (secin.Value < 10)
                        secout.Text = "0" + counter.ToString();
                    else
                        secout.Text = counter.ToString();
                    if (secin.Value < 10)
                        secout.Text = "0" + counter.ToString();
                    else
                        secout.Text = counter.ToString();
                }
            }
            else if (Start.Text == "Pause")
            {
                Start.Text = "Continue";
                timer1.Stop();
            }
            else if (Start.Text == "Continue")
            {
                Start.Text = "Pause";
                timer1.Start();
            }

            
           
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (int.Parse(minout.Text) < 5)
            {
                if (minout.BackColor == Color.White)
                {
                    minout.BackColor = Color.Orange;
                    secout.BackColor = Color.Orange;
                }
                else
                {
                    minout.BackColor = Color.White;
                    secout.BackColor = Color.White;
                }
            }

            if (int.Parse(minout.Text) == 0 && int.Parse(secout.Text) == 0)
            {
                
                minout.Text = "00";
                secout.Text = "00";
                Start.Text = "Start";
                minout.BackColor = Color.White;
                secout.BackColor = Color.White;
                timer1.Stop();
                minin.Enabled = true;
                secin.Enabled = true;
                Stop.Enabled = false;
                Start.Enabled = true;
                
            }
            else if (counter == 0)
            {
                int m = int.Parse(minout.Text) - 1;
                if (m < 10)
                    minout.Text = "0"+m.ToString();
                else
                    minout.Text =m.ToString();
                counter = 59;
                secout.Text = counter.ToString();
            }
            else
            {
                counter--;
              
                if (counter < 10)
                    secout.Text = "0" + counter.ToString();
                else
                    secout.Text = counter.ToString();
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {


                Start.Text = "Start";
                Start.Enabled = true;
                timer1.Stop();
                counter = 0;
             
            
                Stop.Enabled = false;
                minin.Enabled = true;
                secin.Enabled = true;
                minout.Text = "00";
                secout.Text = "00";
                minout.BackColor = Color.White;
                secout.BackColor = Color.White;



        }

        
    }
}