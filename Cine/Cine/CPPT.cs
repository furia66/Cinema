using MongoDB.Driver;
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
    public partial class CPPT : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("cinema");
        static IMongoCollection<Peliculas> collection = db.GetCollection<Peliculas>("Peliculas");

        
        public CPPT()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultas p = new Consultas();
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;

                List<Peliculas> list = collection.Find("{'nombre_de_pelicula':'"+nombre+"'}").ToList<Peliculas>();
                dataGridView1.DataSource = list;

            }
            catch (Exception err)
            {
                MessageBox.Show("no se encontró el nombre de la pelicula en la base de datos");
            }
        }
    }
}
