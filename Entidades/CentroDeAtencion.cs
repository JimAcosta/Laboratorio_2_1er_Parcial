using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CentroDeAtencion
    {
        private int cantRacsPorSuper;
        private List<Empleado> empleados;
        private string nombre;

        public CentroDeAtencion(string nombre, int cantRacsPorSuper)
        {
            this.nombre = nombre;
            this.cantRacsPorSuper = cantRacsPorSuper;
            empleados = new List<Empleado>();
        }

        public List<Empleado> Empleados 
        {
            get { return empleados; }
        }

        public string Nombre 
        {
            get{ return nombre; }
        }

        public static bool operator ==(CentroDeAtencion c, Empleado e)
        {
            foreach (var item in c.Empleados) 
            {
                if (e.Legajo == item.Legajo) 
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(CentroDeAtencion c, Empleado e)
        {
            return !(c == e);
        }

        private bool ValidaCantidadDeRacs()
        {
            int numRacs = 0;
            foreach (Empleado empleado in empleados)
            {
                if (empleado is Rac)
                {
                    numRacs++;
                }
            }
            if (numRacs > cantRacsPorSuper)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator +(CentroDeAtencion c, Empleado e)
        {
            if (c != e)
            {
                if (e is Supervisor && !c.ValidaCantidadDeRacs())
                {
                    return false;
                }
                c.empleados.Add(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string operator -(CentroDeAtencion c, Empleado e)
        {
            foreach (var item in c.Empleados)
            {
                if (e.Legajo == item.Legajo)
                {
                    e.HoraEgreso = DateTime.Now.TimeOfDay;
                    string factura = e.EmitirFactura();
                    c.empleados.Remove(item);
                    return factura;
                }
            }
            return "Empleado no encontrado";
        }

        public string ImprimirNomina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nómina de empleados:");

            foreach (Empleado empleado in empleados)
            {
                sb.AppendLine(empleado.ToString());
            }

            return sb.ToString();
        }



    }
}
