using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace tpvFarmacia
{
    class conectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<claseMedicamento> listaMedicamento = new List<claseMedicamento>();
        List<claseTarjetaSanitaria> listaTarjetas = new List<claseTarjetaSanitaria>();
        List<claseTratamientos> listaTratamientos = new List<claseTratamientos>();
        MySqlConnection conexion2;
        public conectarBD()
        {
            conexion2 = new MySqlConnection();
            conexion2.ConnectionString = "Server=remotemysql.com;Database=j3vYEeCG3p;Uid=j3vYEeCG3p;pwd=GPpsVJJ4SK";
            conexion = new MySqlConnection();
            conexion.ConnectionString = "Server=remotemysql.com;Database=Pr1mdxAdrh;Uid=Pr1mdxAdrh;pwd=fNBUrxid1O";

        }
        public List<claseMedicamento> listar()
        {
            conexion.Open();
            String cadenaSql = "select * from medicamento";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                claseMedicamento cm = new claseMedicamento();
                cm.Indice = Convert.ToInt16(datos["indice"]);
                cm.Nombre = Convert.ToString(datos["nombre"]);
                cm.Precio = Convert.ToDouble(String.Format("{0:0.00}", datos["precio"]));
                cm.Imagen = (byte[])datos["imagen"];
                cm.Stockactual = Convert.ToInt16(datos["stockactual"]);
                cm.Stockminimo = Convert.ToInt16(datos["stockminimo"]);
                listaMedicamento.Add(cm);
            }
            conexion.Close();
            return listaMedicamento;
        }

        internal void Insertar(String nombreM, Double precio, byte[] imagen, int stockMin, int stockActual)
        {
            conexion.Open();
            String cadenaSql = "insert into medicamento values(null,?nom,?precio,?imagen,?stockmin,?stockactual)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = nombreM;
            comando.Parameters.Add("?precio", MySqlDbType.Double).Value = precio;
            comando.Parameters.Add("?imagen", MySqlDbType.Blob).Value = imagen;
            comando.Parameters.Add("?stockmin", MySqlDbType.Int16).Value = stockMin;
            comando.Parameters.Add("?stockActual", MySqlDbType.Int16).Value = stockActual;



            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public int buscarUsuario(String dni, String pwd)
        {

            String sql = "select nivel from usuario where dni=?dni and clave=?pwd ";
            conexion.Open();
            comando = new MySqlCommand(sql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.String).Value = dni;
            comando.Parameters.Add("?pwd", MySqlDbType.String).Value = pwd;
            MySqlDataReader datos = comando.ExecuteReader();
            int nivel = 0;
            if (datos.Read())
            {
                nivel = Convert.ToInt16(datos["nivel"]);
            }



            conexion.Close();

            return nivel;
        }
        public List<String> buscarDni(String dni)
        {
            List<String> userypassword = new List<String>();

            String sql = "select * from usuario where dni=?dni";
            conexion.Open();
            comando = new MySqlCommand(sql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.String).Value = dni;
            MySqlDataReader datos = comando.ExecuteReader();

            if (datos.Read())
            {
                userypassword.Add(Convert.ToString(datos["dni"]));
                userypassword.Add(Convert.ToString(datos["clave"]));
            }

            conexion.Close();
            return userypassword;
        }

        public void insertarFacturas(List<claseMedicamento> listaCesta, string dniVendedor, double total)
        {
            string cadenaProductos = "";
            for (int i = 0; i < listaCesta.Count; i++)
            {
                cadenaProductos += listaCesta[i].Nombre + ",";
            }
            conexion.Open();
            String cadenaSql = "insert into facturacion values(null,?dni,?cadenaProd,?fecha,?total)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = dniVendedor;
            comando.Parameters.Add("?cadenaProd", MySqlDbType.VarChar).Value = cadenaProductos;
            comando.Parameters.Add("?fecha", MySqlDbType.DateTime).Value = DateTime.Now;
            comando.Parameters.Add("?total", MySqlDbType.Double).Value = total;
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        internal void modificarMedicamento(claseMedicamento med)
        {
            conexion.Open();
            String cadenaSql = "update  medicamento set nombre=?nom,precio=?pr,stockminimo=?sm,stockactual=?sa,imagen=?im where indice=?id";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?id", MySqlDbType.Int16).Value = med.Indice;
            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = med.Nombre;
            comando.Parameters.Add("?pr", MySqlDbType.Double).Value = med.Precio;

            comando.Parameters.Add("?sa", MySqlDbType.Int16).Value = med.Stockactual;
            comando.Parameters.Add("?sm", MySqlDbType.Int16).Value = med.Stockminimo;
            comando.Parameters.Add("?im", MySqlDbType.Blob).Value = (byte[])med.Imagen;
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void Lanzar_actualizacion(List<claseMedicamento> listaCesta)
        {
            conexion.Open();
            for (int i = 0; i < listaCesta.Count; i++)
            {
                string NombreMed = listaCesta[i].Nombre;
                String cadenaSql = "update medicamento set stockactual=stockactual-1 where nombre= '" + NombreMed + "'";
                comando = new MySqlCommand(cadenaSql, conexion);
                comando.ExecuteNonQuery();
            }
            //  String cadenaSql = ""
            conexion.Close();
        }

        public List<claseTarjetaSanitaria> listarTarjetas()
        {
            conexion.Open();
            String cadenaSql = "select * from tarjetaSanitaria";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                claseTarjetaSanitaria cTS = new claseTarjetaSanitaria();
                cTS.Dni = Convert.ToString(datos["dni"]);
                cTS.Nombre = Convert.ToString(datos["nombre"]);
                cTS.Email = Convert.ToString(datos["email"]);
                cTS.FechaNacimiento = Convert.ToDateTime(datos["fechaNacimiento"]);
                listaTarjetas.Add(cTS);
            }
            conexion.Close();
            return listaTarjetas;

        }

        public List<claseTratamientos> listarTratamientos(string dni, int mes)
        {
            conexion.Open();
            String cadenaSql = "select * from tratamientos where dni=?d and mes=?m and recogido=0";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?d", MySqlDbType.VarChar).Value = dni;
            comando.Parameters.Add("?m", MySqlDbType.Int16).Value = mes;
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                claseTratamientos cT = new claseTratamientos();
                cT.Identificador = Convert.ToInt16(datos["identificador"]);
                cT.Dni = Convert.ToString(datos["dni"]);
                cT.Medicamento = Convert.ToString(datos["medicamento"]);
                cT.Mes = Convert.ToInt16(datos["mes"]);
                cT.Recogido = Convert.ToInt16(datos["recogido"]);

                listaTratamientos.Add(cT);
            }
            conexion.Close();
            return listaTratamientos;
        }

        public void actualizarTratamiento(List<claseMedicamento> listaCesta, string dni, int month)
        {
            conexion.Open();
            for (int i = 0; i < listaCesta.Count; i++)
            {
                String cadenaSql = "update tratamientos set recogido=1 where dni=?d and medicamento=?m";
                comando = new MySqlCommand(cadenaSql, conexion);
                comando.Parameters.Add("?d", MySqlDbType.VarChar).Value = dni;
                comando.Parameters.Add("?m", MySqlDbType.VarChar).Value = listaCesta[i].Nombre;
                comando.ExecuteNonQuery();
            }
            conexion.Close();
        }

        public List<claseMedicamento> obtenerMedicamentosPorStock()
        {
            List<claseMedicamento> lista = new List<claseMedicamento>();
            conexion.Open();
            String cadenaSql = "select * from medicamento where stockactual<stockminimo";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                claseMedicamento cm = new claseMedicamento();
                cm.Indice = Convert.ToInt16(datos["indice"]);
                cm.Nombre = Convert.ToString(datos["nombre"]);
                cm.Precio = Convert.ToDouble(String.Format("{0:0.00}", datos["precio"]));
                cm.Imagen = (byte[])datos["imagen"];
                cm.Stockactual = Convert.ToInt16(datos["stockactual"]);
                cm.Stockminimo = Convert.ToInt16(datos["stockminimo"]);
                lista.Add(cm);
            }
            conexion.Close();

            return lista;
        }


        public void insertarPedido(String idMedicamento)
        {
            conexion.Open();
            String cadenaSql = "update medicamento set stockactual=stockactual+1 where indice=?d";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?d", MySqlDbType.Int16).Value = Convert.ToInt16(idMedicamento);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void exportarBD(String file)
        {
            comando.Connection = conexion;
            conexion.Open();
            MySqlBackup mb = new MySqlBackup(comando);
            mb.ExportToFile(file);
            conexion.Close();
        }
        
        public void importarBD(String file)
        {
            comando.Connection = conexion2;
            conexion2.Open();
            MySqlBackup mb = new MySqlBackup(comando);
            mb.ImportFromFile(file);
            conexion2.Close();
            MessageBox.Show("Se ha importado la BD correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
