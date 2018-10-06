using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine
{
    class Peliculas
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("nombre_de_pelicula")]
        public String nombre_de_pelicula { get; set; }
        [BsonElement("genero")]
        public String genero { get; set; }
        [BsonElement("nombre_del_director")]
        public String nombre_del_director { get; set; }
        [BsonElement("franquicia")]
        public String franquicia { get; set; }
        [BsonElement("pais_de_origen")]
        public String pais_de_origen { get; set; }
        [BsonElement("año_de_estreno")]
        public double año_de_estreno { get; set; }
        [BsonElement("duracion_en_minutos")]
        public double duracion_en_minutos { get; set; }
        [BsonElement("compañia_productora")]
        public String compañia_productora { get; set; }
        [BsonElement("actores")]
        public String actores { get; set; }

        public Peliculas(string nombre_de_pelicula, string genero, string nombre_del_director, string franquicia, string pais_de_origen, double año_de_estreno, double duracion_en_minutos, string compañia_productora, String actores)
        {
            this.nombre_de_pelicula = nombre_de_pelicula;
            this.genero = genero;
            this.nombre_del_director = nombre_del_director;
            this.franquicia = franquicia;
            this.pais_de_origen = pais_de_origen;
            this.año_de_estreno = año_de_estreno;
            this.duracion_en_minutos = duracion_en_minutos;
            this.compañia_productora = compañia_productora;
            this.actores = actores;
        }
    }
}
