using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpvFarmacia
{
    class claseTarjetaSanitaria
    {
        String dni;
        String nombre;
        String email;
        DateTime fechaNacimiento;

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public claseTarjetaSanitaria(string dni, string nombre, string email, DateTime fechaNacimiento)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
        }
        public claseTarjetaSanitaria()
        {

        }

    }
}
