using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace bo_macro
{
    public partial class Form2 : Form
    {
        Thread th;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Bitmap temp)
        {
            InitializeComponent();
            pictureBox1.Image = temp;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this.Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            var relativePoint = this.PointToClient(Cursor.Position);
            label1.Text = relativePoint.X.ToString();
            label2.Text = relativePoint.Y.ToString();
        }
    }
}
