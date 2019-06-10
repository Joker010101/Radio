using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Windows.Forms;

namespace Radio
{
    public partial class Form1 : Form
    {
        string radioStation;
        private FileStream fs;
        

        private bool state = false;

        public Form1()
        {
            InitializeComponent();
            
        
          
           
        }



        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void GetStream()
        {

            string now = DateTime.Now.ToLongTimeString();
            now = now.Replace(':', '-');
            fs = new FileStream(now + ".mp3", FileMode.Create);
            WebResponse response = WebRequest.Create(radioStation).GetResponse();
            // Получаем поток порциями в 65536 байтов
            using (Stream stream = response.GetResponseStream())
            {
                byte[] buffer = new byte[99999];
                int read;
                while ((state == true) && ((read = stream.Read(buffer, 0, buffer.Length)) > 0))
                {
                    long pos = fs.Position;
                    fs.Position = fs.Length;
                    fs.Write(buffer, 0, read);
                    fs.Position = pos;
                }
                fs.Flush();
            }
            response.Close();
            fs.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox1.Text = Per.Text;

           
            axWindowsMediaPlayer1.URL = textBox1.Text;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
            








        

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ПоказатьСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Play.Visible = false;
            newForm.Show();
            // коменты были сделаны 
            // коменты были сделаны 
            // коменты были сделаны 


        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            Form2 fm2 = new Form2();

          
            if (textBox1.Text != "")
            {
                string o = this.textBox1.Text;

                fm2.listBox1.Items.Add(o);
                fm2.ShowDialog();
            }

        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

         Form2 fm2 = new Form2();
            fm2.button1.Visible = false;
            fm2.button2.Visible = false;
            fm2.ShowDialog();

        }       
               
            
            
     

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;

            if (axWindowsMediaPlayer1.URL == Per.Text)
            {
               axWindowsMediaPlayer1.URL = textBox1.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play(); 
            }
            else

                axWindowsMediaPlayer1.URL = "http://online.radiorecord.ru:8102/sd90_128";
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ТаймерToolStripMenuItem_Click(object sender, EventArgs e)
        {

           label4.Visible = true;
            label5.Visible = true;
            Form3 fm3 = new Form3();
           fm3.ShowDialog();
         } 

            
           
            
           
            
       

        private void Timer1_Tick(object sender, EventArgs e)
        {

        label1.Text =Per.sec;
        label2.Text = Per.min;
        label3.Text = Per.hac;        
               
           

        }

       
    }
    
}
