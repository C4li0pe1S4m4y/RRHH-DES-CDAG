using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class AlergiasYEnfermedadesNew
    {
        public int id_empleado { get; set; }
        public int? id_tipo_sangre { get; set; }
        public List<string> Alergias { get; set; }
        public List<string> Enfermedades { get; set; }
    }
}
