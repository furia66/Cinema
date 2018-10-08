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
    public partial class PPC : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("cinema");
        static IMongoCollection<Peliculas> collection = db.GetCollection<Peliculas>("Peliculas");
        public PPC()
        {
            InitializeComponent();
        }

        private void PPC_Load(object sender, EventArgs e)
        {

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

                List<Peliculas> list = collection.Find("{'compañia_productora':'" + nombre + "'}").ToList<Peliculas>();

                dataGridView1.DataSource = list;
                dataGridView1.Columns.Remove("Id");
                dataGridView1.Columns.Remove("nombre_del_director");
                dataGridView1.Columns.Remove("franquicia");
                dataGridView1.Columns.Remove("pais_de_origen");
                dataGridView1.Columns.Remove("duracion_en_minutos");
                dataGridView1.Columns.Remove("actores");

            }
            catch (Exception err)
            {
                MessageBox.Show("no se encontró el nombre de la compañia productora");
            }
        }
    }
}
