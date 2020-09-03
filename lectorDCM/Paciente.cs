using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace lectorDCM
{
    public class Paciente
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string ID { get; set; }
        public List<Plan> Planes { get; set; }
    }
}
