using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Shutdown_Engine_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Panel Settings
        private void Button1_Click(object sender, EventArgs e)
        {

            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;

        }
        //Program Exit
        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Panel Settings
        private void Button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
           

        }

        

        // Shutdown Timer
        private void Button6_Click_1(object sender, EventArgs e)
        {
            int hours, minutes, seconds;
            if (!int.TryParse(textBox1.Text, out hours)) hours = 0;
            if (!int.TryParse(textBox2.Text, out minutes)) minutes = 0;
            if (!int.TryParse(textBox3.Text, out seconds)) seconds = 0;

            
          
         
            if (hours > 0 || minutes > 0 || seconds > 59)
            {
                

                int total = (hours * 3600) + (minutes * 60) + (seconds * 1);

                Process.Start("shutdown", "/s /t " + total);
               
            }
            else
            {
                MessageBox.Show("Please select a time at least 1 minute or higher.");
            }
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

    

        //Shutdown cancel
    private void Button7_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/a");
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            
        }

       
        //Only digit for textbox 1-3
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch !=43)
            {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }

            
        }

        
        //Shutdown Default Timers 
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.ThreeState)
            {
                checkBox1.ThreeState = true;
                Process.Start("shutdown", "/s /t 1800");
            }

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
          if(!checkBox2.ThreeState)
            {
                checkBox2.ThreeState = true;
                Process.Start("shutdown", "/s /t 3600");
            }
                
            
        }
      

       
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.ThreeState)
            {
                checkBox3.ThreeState = true;
                Process.Start("shutdown", "/s /t 5400");
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.ThreeState)
            {
                checkBox4.ThreeState = true;
                Process.Start("shutdown", "/s /t 7200");
            }
        }
        //Windows Free Move
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        //force shutdown
        private void Button8_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /f");
        }
        //panel settings
        private void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
           
        }
        //Set timer restart
        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox8.ThreeState)
            {
                checkBox8.ThreeState = true;
                Process.Start("shutdown", "/r /t 1800");
            }
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox7.ThreeState)
            {
                checkBox7.ThreeState = true;
                Process.Start("shutdown", "/r /t 3600");
            }
        }

        private void CheckBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox6.ThreeState)
            {
                checkBox6.ThreeState = true;
                Process.Start("shutdown", "/r /t 5400");
            }
        }

        private void CheckBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox5.ThreeState)
            {
                checkBox5.ThreeState = true;
                Process.Start("shutdown", "/r /t 7200");
            }
        }
        //Restart Cancel
        private void Button10_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/a");
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }
        //Restart Set
        private void Button11_Click(object sender, EventArgs e)
        {
            int hours, minutes, seconds;
            if (!int.TryParse(textBox6.Text, out hours)) hours = 0;
            if (!int.TryParse(textBox5.Text, out minutes)) minutes = 0;
            if (!int.TryParse(textBox4.Text, out seconds)) seconds = 0;




            if (hours > 0 || minutes > 0 || seconds > 59)
            {


                int total = (hours * 3600) + (minutes * 60) + (seconds * 1);

                Process.Start("shutdown", "/r /t " + total);

            }
            else
            {
                MessageBox.Show("Please select a time at least 1 minute or higher.");
            }

            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    
        // Force Restart
        private void Button9_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /f");
        }

        
        
        //Textbox digit only
        private void TextBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }
        // Hibernate panel control
        private void Button12_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
        }
        //Hibernate panel close
        private void Button16_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Hibernate, false, false);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, false, false);
        }

        
    }
    
 }

