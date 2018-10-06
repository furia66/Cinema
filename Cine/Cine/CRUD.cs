using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD_Peliculas cp = new CRUD_Peliculas();
            this.Hide();
            cp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUD_Compañias p = new CRUD_Compañias();
            this.Hide();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 p = new Form1();
            this.Hide();
            p.Show();
        }
    }
}
