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
    public partial class CRUD_Peliculas : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("cinema");
        static IMongoCollection<Peliculas> collection = db.GetCollection<Peliculas>("Peliculas");

        public void ReadAllDocuments()
        {
            List<Peliculas> list = collection.AsQueryable().ToList<Peliculas>();
            dataGridView1.DataSource = list;
            textBox10.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();

        }
        public CRUD_Peliculas()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox6.Text);
            collection.InsertOne(p);
            ReadAllDocuments();
        }

        private void CRUD_Peliculas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUD c = new CRUD();
            this.Hide();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string np = textBox1.Text;
                string g = textBox2.Text;
                string nd = textBox3.Text;
                string f = textBox4.Text;
                string po = textBox5.Text;
                string ac = textBox6.Text;
                string año = textBox7.Text;
                String dm = textBox8.Text;
                String cp = textBox9.Text;
                string prueba = "{$set:{'nombre_de_pelicula':'nuevo','genero':'viejo'}}";
                string param = "{$set:{'nombre_de_pelicula':'" + np + "','genero':'" + g + "','nombre_del_director':'" + nd + "','franquicia':'" + f + "','pais_de_origen':'" + po + "','año_de_estreno':'" + año + "','duracion_en_minutos':'" + dm + "','compañia_productora':'" + cp + "','actores':'" + ac + "'}}";
                BsonDocument document = BsonDocument.Parse(param);
                var updateDef = Builders<Peliculas>.Update.Set("nombre_de_pelicula", textBox1.Text).Set("genero", textBox2.Text).Set("nombre_del_director", textBox3.Text).Set("franquicia", textBox4.Text).Set("pais_de_origen", textBox5.Text).Set("año_de_estreno", textBox7).Set("duracion_en_minutos", textBox8.Text).Set("compañia_productora", textBox9).Set("actores", textBox6.Text);
                collection.UpdateOne(s => s.Id == ObjectId.Parse(textBox10.Text), document);
                ReadAllDocuments();
            }
            catch(Exception err)
            {
               MessageBox.Show("Failed:"+ err);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(p => p.Id == ObjectId.Parse(textBox10.Text));
            ReadAllDocuments();
        }
    }
}
