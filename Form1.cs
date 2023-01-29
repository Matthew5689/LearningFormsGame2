using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsGame2
{
    public partial class Form1 : Form
    {
        static bool rectExist = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.");
            }

            switch (e.KeyChar)
            {
                case (char)49:
                case (char)52:
                case (char)55:
                    if (checkBox1.Checked)
                    {
                        MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.");
                    }
                    e.Handled = true;
                    break;
            }

            if (rectExist)
            {
                EraseRect();
            }
            else
            {
                DrawRect();
            }

        }

        public void DrawRect(bool erase, Color color, int posx, int posy, int xsize, int ysize)
        {
            // Brush is used to set the color of the Filled Rectangle Color
            SolidBrush myBrush = new SolidBrush(color);

            // Graphics is the object for the Form (GDI+ Drawing Surface)
            // We then create the graphics which is a reference to the Form1 Object
            // If we its possible to remove the this statement as we are still in 
            // context of this Form (This Form being referenced as Form1)
            Graphics formGraphics;
            formGraphics = CreateGraphics();
            formGraphics.FillRectangle(myBrush, 0, 0, 100, 100);
            myBrush.Dispose();
            formGraphics.Dispose();

            rectExist = true;
        }

        public void EraseRect()
        {
            SolidBrush myBrush = new SolidBrush(Color.White);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, 0, 0, 100, 100);
            myBrush.Dispose();
            formGraphics.Dispose();

            rectExist = false;
        }

        enum rectColors
        {
            Red,
            White
        }
    }
}
