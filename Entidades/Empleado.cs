namespace Entidades
{
    public abstract class Empleado
    {
        protected TimeSpan horaEgreso;
        protected TimeSpan horaIngreso;
        protected string legajo;
        protected string nombre;

        public Empleado() 
        {

        }

        public Empleado(string legajo,string nombre,TimeSpan horaIngreso) 
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.horaIngreso = horaIngreso;
        }

        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Legajo
        {
            get { return this.legajo; }
        }
        public TimeSpan HoraIngreso
        {
            get { return this.horaIngreso; }
        }
        public TimeSpan HoraEgreso
        {
            get { return this.horaEgreso; }

            set { ValidaHoraEgreso(this.HoraIngreso); }
            
        }


        public abstract string EmitirFactura();


        private TimeSpan ValidaHoraEgreso(TimeSpan horaEgreso) 
        {
            if (horaEgreso > this.HoraIngreso) 
            {
                return horaEgreso;
            }
            return DateTime.Now.TimeOfDay;
        }

        protected virtual double Facturar()
        {
            TimeSpan HorasTotales = this.HoraEgreso - HoraIngreso;
            return HorasTotales.TotalHours;
        }

        public static bool operator ==(Empleado empleado1, Empleado empleado2) 
        {
            if (!(empleado1 is null || empleado2 is null))
            {
                return empleado1 == empleado2;
            }
            return false;
        }
        public static bool operator !=(Empleado empleado1, Empleado empleado2)
        {
            return !(empleado1 == empleado2);
        }




    }
}
