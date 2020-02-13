using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpvFarmacia
{
    class claseTratamientos
    {
        int identificador;
        String dni;
        String medicamento;
        int mes;
        int recogido;

        public int Identificador
        {
            get
            {
                return identificador;
            }

            set
            {
                identificador = value;
            }
        }

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

        public string Medicamento
        {
            get
            {
                return medicamento;
            }

            set
            {
                medicamento = value;
            }
        }

        public int Mes
        {
            get
            {
                return mes;
            }

            set
            {
                mes = value;
            }
        }

        public int Recogido
        {
            get
            {
                return recogido;
            }

            set
            {
                recogido = value;
            }
        }

        public claseTratamientos(int identificador, string dni, string medicamento, int mes, int recogido)
        {
            this.Identificador = identificador;
            this.Dni = dni;
            this.Medicamento = medicamento;
            this.Mes = mes;
            this.Recogido = recogido;
        }

        public claseTratamientos()
        {
        }
    }
}
