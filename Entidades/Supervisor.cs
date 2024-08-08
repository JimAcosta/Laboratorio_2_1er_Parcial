using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Supervisor : Empleado
    {
        private static float valorHora;

        static Supervisor()
        {
            valorHora = 1025.50F;
        }

        private Supervisor(string legajo) : base("n/a", legajo, new TimeSpan(9, 0, 0))
        {
        }

        public Supervisor(string legajo,string nombre,TimeSpan horaIngreso):base(legajo,nombre,horaIngreso)
        { 

        }

        public static float ValorHora
        {
            get { return valorHora; }
            set
            {
                if (value > 0)
                {
                    valorHora = value;
                }
            }
        }

        public override string EmitirFactura()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Factura de {this.Nombre}");
            sb.AppendLine($"Legajo{this.Legajo}");
            sb.AppendLine($"Importe a Facturar {base.Facturar()}");

            return sb.ToString();


        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - {legajo}- {nombre}";
        }

        public static implicit operator Supervisor(string legajo)
        {
            return new Supervisor(legajo);
        }
    }


}

