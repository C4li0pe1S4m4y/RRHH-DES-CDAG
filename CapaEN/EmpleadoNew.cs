using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class EmpleadoNew
    {
        public int id_empleado { get; set; }
        public int codigo { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string apellido_casada { get; set; }
        public string cui { get; set; }
        public string nit { get; set; }
        public int id_genero { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string lugar_nacimiento { get; set; }
        public string afiliacion_igss { get; set; }
        public int id_municipio_cui { get; set; }
        public int? telefono_movil { get; set; }
        public int? telefono_residencial { get; set; }
        public int id_estado_civil { get; set; }
        public bool tipo_vivienda { get; set; }
        public string direccion_residencial { get; set; }
        public int id_municipio_residencial { get; set; }
        public int id_profesion { get; set; }
        public string licencia_conducir { get; set; }
        public int? id_tipo_licencia { get; set; }
        public string correo { get; set; }
        public string url_Imagen { get; set; }
        public int? id_archivo { get; set; }


    }
}
