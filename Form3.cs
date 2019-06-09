﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Radio
{
    public partial class Form3 : Form
    {
        int m, s, h;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            


            StartPosition = FormStartPosition.Manual;
            Location =     new Point(1130, 350);

            string[] mas = File.ReadAllLines(@"timer1", System.Text.Encoding.Default);
           textBox1.Text = mas[0];
           textBox2.Text = mas[1];
           textBox3.Text = mas[2];

        }



        

        private void Button1_Click(object sender, EventArgs e)
        {
           // Form1 fm1 = new Form1();
           // fm1.label1.Text = this.label6.Text;
            

            Close();
            

            string[] createtext = { textBox1.Text,textBox2.Text,textBox3.Text };
            File.WriteAllLines(@"timer1", createtext, System.Text.Encoding.Default);




            timer1.Enabled = true;
            timer1.Start();
            h = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            s = Convert.ToInt32(textBox3.Text);
            

        }

        
        
     

        private void Timer1_Tick(object sender, EventArgs e)
        {


            Per.hac = label4.Text;
            Per.min = label5.Text;
            Per.sec = label6.Text;

            label4.Text = Convert.ToString(h);
            label5.Text = Convert.ToString(m);
            label6.Text = Convert.ToString(s);
           

            

                s = s - 1;
            if (s == -1 )

            {


                m = m - 1;
                s = 59;
            
            }

            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }

         if (h == 0 && m == 0 && s == 30)
           
         MessageBox.Show("До выключения компьютера осталось " + Convert.ToString(s)+ " секунд ");

             

            if (h == 0 && m == 0 && s == 0)
            {
                

                timer1.Stop();
                MessageBox.Show("Время вышло!");
               
               
            }

            
        }      

        private void Button3_Click(object sender, EventArgs e)
        {

            label1.Text = " 0 ";
            label2.Text = " 0 ";
            label3.Text = " 0 ";
            timer1.Stop();
        }
        

        private void Button2_Click(object sender, EventArgs e)
        {
               timer1.Stop();
        }       
            
            
        
    }
}