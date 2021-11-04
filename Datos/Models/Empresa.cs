using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Empresa
    {
        public Empresa(int id, string nombre, string cuit)
        {
            Id = id;
            Nombre = nombre;
            Cuit = cuit;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
    }

}
