using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rac:Empleado
    {
        public enum EGrupo
        {
            CALL_IN,
            CALL_OUT,
            RRSS
        };

        private EGrupo grupo ;
        private static double valorHora;

        public Rac(string legajo,string nombre,TimeSpan horaIngreso):base(legajo,nombre,horaIngreso)
        {
        }

        public Rac(string legajo, string nombre, TimeSpan horaIngreso, EGrupo grupo) : this(legajo, nombre, horaIngreso) 
        {
            grupo = EGrupo.CALL_IN;
            valorHora = 875.90F;
        }

        public EGrupo Grupo 
        {
            get {return grupo;}
        }
        public static double ValorHora 
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

        private double CalcularBonoDeGrupo() 
        {
            if (this.Grupo == EGrupo.CALL_IN)
            {
                return 0;
            }
            else if (this.Grupo == EGrupo.CALL_OUT)
            {
                return 0.1;
            }
            else
            {
                return 0.2;
            }
        }

        protected double Facturar() 
        {
            return ValorHora * CalcularBonoDeGrupo();
        }

        public override string ToString() 
        {
            return $"{this.GetType().Name} - {legajo}- {nombre}";
        }




    }
}
