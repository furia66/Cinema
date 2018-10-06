using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine
{
    class Compañias
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("nombre_de_la_compañia")]
        public String nombre_de_la_compañia { get; set; }
        [BsonElement("año_de_fundacion")]
        public double año_de_fundacion { get; set; }
        [BsonElement("direccion_web")]
        public String direccion_web { get; set; }

        public Compañias(string nombre_de_la_compañia, double año_de_fundacion, string direccion_web)
        {
            this.nombre_de_la_compañia = nombre_de_la_compañia;
            this.año_de_fundacion = año_de_fundacion;
            this.direccion_web = direccion_web;
        }
    }
}
