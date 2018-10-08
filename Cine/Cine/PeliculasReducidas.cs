using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine
{
    class PeliculasReducidas
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("nombre_de_pelicula")]
        public String nombre_de_pelicula { get; set; }
        [BsonElement("genero")]
        public String genero { get; set; }
        [BsonElement("año_de_estreno")]
        public double año_de_estreno { get; set; }

        public PeliculasReducidas(string nombre_de_pelicula, string genero, double año_de_estreno)
        {
            this.nombre_de_pelicula = nombre_de_pelicula;
            this.genero = genero;
            this.año_de_estreno = año_de_estreno;
        }
    }
}
