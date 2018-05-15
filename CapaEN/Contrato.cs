using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class Contratos
    {
        public int id_empleado { get; set; }
		public string puesto { get; set; }
		public string area { get; set; }
		public int id_renglon_presupuestario { get; set; }
		public string jefe_inmediato { get; set; }
        public string puesto_jefe_inmediato { get; set; }
        public decimal salario { get; set; }
		public int id_contrato { get; set; }
        public string fecha_inicial { get; set; }
		public string fecha_final { get; set; }
        public int id_estado_contrato { get; set; }
        public string motivo { get; set; }

    }
}
