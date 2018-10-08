using MongoDB.Bson;
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
    public partial class IEPC : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("cinema");
        static IMongoCollection<Peliculas> collection = db.GetCollection<Peliculas>("Peliculas");
        public static String May = "";
        public static String Men = "";

        public void ReadAllDocuments()
        {
            List<Peliculas> list = collection.AsQueryable().ToList<Peliculas>();
            dataGridView1.DataSource = list;

        }

        public IEPC()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consultas p = new Consultas();
            this.Hide();
            p.Show();
        }

        private void IEPC_Load(object sender, EventArgs e)
        {

            label7.Text = dataGridView1.RowCount.ToString();

            List<string> duracion = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //MessageBox.Show(dataGridView1.Rows[i].Cells[7].Value.ToString());
                duracion.Add(dataGridView1.Rows[i].Cells[7].Value.ToString());
                

            }
            List<int> intList = duracion.ConvertAll(int.Parse);

            string mayor = intList.Max().ToString();
            string menor = intList.Min().ToString();

            May = mayor;
            Men = menor;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string m = Men;

                List<Peliculas> list = collection.Find("{'duracion_en_minutos':'" + m + "'}").ToList<Peliculas>();
                dataGridView1.DataSource = list;

            }
            catch (Exception err)
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string m = May;

                List<Peliculas> list = collection.Find("{'duracion_en_minutos':'" + m + "'}").ToList<Peliculas>();
                dataGridView1.DataSource = list;

            }
            catch (Exception err)
            {
                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBox1.Text;

                List<Peliculas> list = collection.Find("{'compañia_productora':'" + nombre + "'}").ToList<Peliculas>();

                dataGridView1.DataSource = list;

            }
            catch (Exception err)
            {
                MessageBox.Show("no se encontró el nombre de la compañia productora");
            }

            List<string> duracion2 = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //MessageBox.Show(dataGridView1.Rows[i].Cells[7].Value.ToString());
                duracion2.Add(dataGridView1.Rows[i].Cells[7].Value.ToString());


            }
            List<int> intList2 = duracion2.ConvertAll(int.Parse);

            int suma = 0;
            foreach (int item in intList2)
            {
                suma = suma + item;
            }

            int promedio = suma / intList2.Count();
            label6.Text = promedio.ToString();



        }
    }
}
