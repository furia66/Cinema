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
    public partial class CRUD_Compañias : Form
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("cinema");
        static IMongoCollection<Compañias> collection = db.GetCollection<Compañias>("Compañias");

        public void ReadAllDocuments()
        {
            List<Compañias> list = collection.AsQueryable().ToList<Compañias>();
            dataGridView1.DataSource = list;
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();


        }
        public CRUD_Compañias()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUD p = new CRUD();
            p.Show();
            this.Hide();
        }

        private void CRUD_Compañias_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compañias p = new Compañias(textBox2.Text, Double.Parse(textBox3.Text), textBox4.Text);
            collection.InsertOne(p);
            ReadAllDocuments();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(p => p.Id == ObjectId.Parse(textBox1.Text));
            ReadAllDocuments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nc = textBox2.Text;
            string af = textBox3.Text;
            string dw = textBox4.Text;

            string prueba = "{$set:{'nombre_de_pelicula':'nuevo','genero':'viejo'}}";
            string param = "{$set:{'nombre_de_la_compañia':'" + nc + "','año_de_fundacion':'" + af + "','direccion_web':'" + dw +"'}}";
            BsonDocument document = BsonDocument.Parse(param);
           // var updateDef = Builders<Peliculas>.Update.Set("nombre_de_pelicula", textBox1.Text).Set("genero", textBox2.Text).Set("nombre_del_director", textBox3.Text).Set("franquicia", textBox4.Text).Set("pais_de_origen", textBox5.Text).Set("año_de_estreno", textBox7).Set("duracion_en_minutos", textBox8.Text).Set("compañia_productora", textBox9).Set("actores", textBox6.Text);
            collection.UpdateOne(s => s.Id == ObjectId.Parse(textBox1.Text), document);
            ReadAllDocuments();
        }
    }
}
