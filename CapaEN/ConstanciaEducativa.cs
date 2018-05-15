using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class ConstanciaEducativa
    {
        public int id_constancia { get; set; }
        public int id_nivel { get; set; }
        public int id_empleado { get; set; }
        public string lugar { get; set; }
        public DateTime fecha_desde { get; set; }
        public DateTime fecha_hasta { get; set; }
        public string descripcion { get; set; }
        public int? id_archivo { get; set; }
        public string archivo_url { get; set; }
    }
}
