using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOC_Control_Activos.Models
{
    public class Empleado
    {
        public int IDEmpleado { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string telefono { get; set; }
        public int tipo_acceso { get; set; }
    }
}