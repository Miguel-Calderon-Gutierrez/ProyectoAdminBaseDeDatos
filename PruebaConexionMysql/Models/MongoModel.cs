using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace PruebaConexionMysql.Models
{
    public class MongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DisplayName("ID")]
        public string id { get; set; }
        [BsonElement("nombreUsuario")]
        [DisplayName("NOMBRE DE USUARIO")]
        public string nombreUsuario { get; set; }
        [BsonElement("fechaIngreso")]
        [DisplayName("FECHA Y HORA DE INGRESO")]
        public string horayfechaingreso { get; set; }


    }
}
