using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radio
{
    public partial class Form2 : Form
    {
      

        public Form2()
        {
            InitializeComponent();
           
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
         

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //button3.Visible = false;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(455, 350);

            using (System.IO.StreamReader sr = new System.IO.StreamReader("Save.txt"))
           {
                 while (!sr.EndOfStream)
               
            {
                    listBox1.Items.Add(sr.ReadLine());
               }
           }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Save.txt"))
           {
               for (int i = 0; i < listBox1.Items.Count; i++)
                    sw.WriteLine(listBox1.Items[i].ToString());
            }
          {
               if (textBox1.Text != "")
             {
                    listBox1.Items.Add(textBox1.Text);
               }
           }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }   
            

             


        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            string sell = listBox1.SelectedItem.ToString();
            textBox1.Text=sell;
            Per.Text = sell;
           
        }    
          
           



        
    }
}
