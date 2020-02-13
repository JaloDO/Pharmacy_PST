using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using MessagingToolkit.Barcode;
using System.Net.Mail;
using System.Net;

namespace tpvFarmacia
{
    public partial class Form1 : Form
    {
        conectarBD cnx;
        List<claseMedicamento> listaMedicamento = new List<claseMedicamento>();
        List<claseMedicamento> listaCesta = new List<claseMedicamento>();
        List<claseMedicamento> MedEncontrados = new List<claseMedicamento>();
        List<claseTarjetaSanitaria> listaTarjetas = new List<claseTarjetaSanitaria>();
        List<claseTratamientos> listaTratamientos = new List<claseTratamientos>();
        List<String> userPass = new List<String>();
        double total = 0;
        String pdfTicket;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Total :", total);
            cnx = new conectarBD();
            listaMedicamento = cnx.listar();
            cargarTPV(listaMedicamento);
            block();

        }

        private void cargarTPV(List<claseMedicamento> listaMedicamento)
        {
            int nfilas = Convert.ToInt16(numericUpDown1.Value);
            int ncolumnas = Convert.ToInt16(numericUpDown2.Value);
            int nPantallas = listaMedicamento.Count / (nfilas * ncolumnas);
            //construir un tabpage cada x medicamentos

            int indiceLista = 0;
            int ancho = tabControl1.Width - 40;
            int alto = tabControl1.Height - 40;
            for (int indicePanales = 0; indicePanales <= nPantallas; indicePanales++)
            {

                TabPage tp = new TabPage(Convert.ToString(indicePanales + 1));
                tabControl1.Controls.Add(tp);
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.AutoSize = true;
                tlp.RowCount = nfilas;
                tlp.ColumnCount = ncolumnas;
                tp.Controls.Add(tlp);

                for (int contMed = 0; contMed < nfilas * ncolumnas; contMed++)
                {
                    //construir y diseña el botón

                    Button botonX = new Button();
                    botonX.Height = alto / nfilas;
                    botonX.Width = ancho / ncolumnas;
                    botonX.Tag = indiceLista;
                    botonX.Click += new EventHandler((sender, e) => aniadir_cesta(sender, e, listaMedicamento));
                    botonX.MouseHover += new EventHandler((sender, e) => mostrar_Informacion(sender, e, listaMedicamento));


                    //cargar la imagen en el botón a través de un objeto MemoryStream
                    try
                    {
                        MemoryStream ms = new MemoryStream(listaMedicamento[indiceLista].Imagen);
                        botonX.BackgroundImage = System.Drawing.Image.FromStream(ms);
                        //necesito ajustar la imagen la imagen al tamaño del boton
                        botonX.BackgroundImageLayout = ImageLayout.Stretch;
                        //contenedor que ubica el botón el tlp
                        tlp.Controls.Add(botonX);
                        indiceLista++;
                    }
                    catch (Exception ex)
                    {

                    }


                }

            }
        }

        private void mostrar_Informacion(object sender, EventArgs e, List<claseMedicamento> lm)
        {
            Button boton = (Button)sender;
            int indice = Convert.ToInt16(boton.Tag);
            lbNombre.Text = lm[indice].Nombre;
            lbPrecio.Text = "" + Math.Round(lm[indice].Precio, 2);
            lbStockMin.Text = "" + lm[indice].Stockminimo;
            lbStockActual.Text = "" + lm[indice].Stockactual;




        }

        private void aniadir_cesta(object sender, EventArgs e, List<claseMedicamento> lm)
        {
            Button botonx = (Button)sender;
            if (btnRefrescar.Enabled == false)
            {
                botonx.Enabled = false;
            }
            int posicion = Convert.ToInt16(botonx.Tag);
            if (lm[posicion].Stockactual > 0)
            {
                total += lm[posicion].Precio;
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
                dataGridView1.Rows.Add(lm[posicion].Nombre, String.Format("{0:0.00}", listaMedicamento[posicion].Precio));
                dataGridView1.Rows.Add("Total:", Math.Round(total, 2));
                listaCesta.Add(lm[posicion]);

                lbSuma.Text = String.Format("{0:0.00}", total);
            }
            else
            {
                MessageBox.Show("No hay queda en el almacén " + listaMedicamento[posicion].Nombre);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.Controls.Clear();
            pictureBox1.Image = null;
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();
            try
            {
                cargarTPV(listaMedicamento);
            }
            catch (Exception ex) { }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            pdfTicket = imprimirTicket();

            Actualizar_Tabla();
            Insertar_Factura();
            mandar_mail(pdfTicket);
            limpiar();
            btnRefrescar.Enabled = true;
        }

        private void mandar_mail(String pdfTicket)
        {
            try
            {
                string email = "augustobrigaprofe@gmail.com";
                string password = txtPasswordEmpresa.Text;

                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 25);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(txtCliente.Text));
                msg.Subject = "Factura Farmacia LUPO";
                msg.Body = "se adjunta ticket de la compra en farmacia lupo";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(pdfTicket);
                msg.Attachments.Add(attachment);



                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;

                smtpClient.Send(msg);
                smtpClient.Dispose();
            }
            catch (Exception ex)
            {

            }

        }

        private void Insertar_Factura()
        {
            cnx.insertarFacturas(listaCesta, txtdni.Text, total);
        }

        private void Actualizar_Tabla()
        {
            if (btnRefrescar.Enabled == false)
            {
                cnx.actualizarTratamiento(listaCesta, lbDni.Text, Convert.ToInt16(DateTime.Now.Month));

            }
            cnx.Lanzar_actualizacion(listaCesta);
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();

        }

        private String imprimirTicket()
        {
            MessageBox.Show("Total a pagar " + Math.Round(total, 2));

            //Crear Tabla iTextSharp  desde una tabla de datos (datagridView)
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

            //padding
            pdfTable.DefaultCell.Padding = 3;

            //ancho que va a ocupar la tabla en el pdf
            pdfTable.WidthPercentage = 80;

            //alineación
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

            //borde de las tablas
            pdfTable.DefaultCell.BorderWidth = 1;
            //Añadir fila de cabecera
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //añadir filas
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch { }
                }
            }
            pdfTable.AddCell(DateTime.Now.ToString("MM-dd-yy"));
            pdfTable.AddCell(lbNombre.Text);

            //Exportar a pdf (ruta por defect
            string folderPath = "C:\\ticket\\";

            //si no existe el directoria se crea
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string nombreTicket = DateTime.Now.ToString("MM-dd-yy_HH-mm-ss") + ".pdf";
            folderPath += nombreTicket;
            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A6, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);

                pdfDoc.Close();
                stream.Close();
            }
            Process pc = new Process();
            pc.StartInfo.FileName = folderPath;
            pc.Start();
            dataGridView1.Rows.Add("Total:", 0);
            return folderPath;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            listaCesta.Clear();
            dataGridView1.Rows.Clear();
            lbSuma.Text = "0";
            total = 0;
            dataGridView1.Rows.Add("Total:", 0);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int posicion = dataGridView1.CurrentRow.Index;
            if (listaCesta.Count > 0)
            {
                if (posicion != dataGridView1.RowCount - 1)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres eliminar producto de la cesta?", "TPVFARM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {


                        double precioParcial = listaCesta[posicion].Precio;
                        total = total - precioParcial;
                        listaCesta.RemoveAt(posicion);
                        dataGridView1.Rows.RemoveAt(posicion);
                        lbSuma.Text = String.Format("{0:0.00}", total);
                        dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
                        dataGridView1.Rows.Add("TOTAL: ", Math.Round(total, 2));
                    }

                }
            }

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int nivel = cnx.buscarUsuario(txtdni.Text, txtPwd.Text);
                if (nivel == 0)
                    MessageBox.Show("Usuario No existe");
                else
                {
                    if (nivel == 1)
                    {
                        MessageBox.Show("Nivel administrador");
                        btnGestion.Visible = true;
                        pictureBox2.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Usuario dependiente");
                    }
                    lbUsuario.Text = txtdni.Text;
                    txtdni.Visible = false;
                    txtPwd.Visible = false;
                    btnCerrarSesion.Visible = true;
                    btnPagar.Visible = true;
                    btnVaciarCesta.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtdni.Text = "";
            txtPwd.Text = "";
            txtdni.Visible = true;
            txtPwd.Visible = true;
            lbUsuario.Text = "";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Quieres salir?", "TPV Farmacia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {

            formGestion fg = new formGestion();
            fg.ShowDialog();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tabControl1.Controls.Clear();
            MedEncontrados.Clear();

            foreach (claseMedicamento med in listaMedicamento)
            {
                if (med.Nombre.StartsWith(textBox1.Text, true, null))
                {
                    MedEncontrados.Add(med);
                }
            }
            cargarTPV(MedEncontrados); //o bien recargar la lista principal con esta lista Aux
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (OD.ShowDialog() == DialogResult.OK)
                pictureBox1.Load(OD.FileName);
            BarcodeDecoder Scanner = new BarcodeDecoder();
            Result result = Scanner.Decode(new Bitmap(pictureBox1.Image));

            txtCodigoBarra.Text = result.Text;
        }

        private void txtPasswordEmpresa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPasswordEmpresa.Enabled = false;
        }






        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            tabControl1.Controls.Clear();
            MedEncontrados.Clear();

            foreach (claseMedicamento med in listaMedicamento)
            {
                if (med.Indice == Convert.ToInt16(txtCodigoBarra.Text))
                {
                    MedEncontrados.Add(med);
                }
            }
            cargarTPV(MedEncontrados);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (OD.ShowDialog() == DialogResult.OK)
                pictureBox2.Load(OD.FileName);
            BarcodeDecoder Scanner = new BarcodeDecoder();
            Result result = Scanner.Decode(new Bitmap(pictureBox2.Image));

            lbDni.Text = result.Text;
            listaTarjetas = cnx.listarTarjetas();
            btnRefrescar.Enabled = false;
            for (int i = 0; i < listaTarjetas.Count; i++)
            {
                if (listaTarjetas[i].Dni == lbDni.Text)
                {
                    int mes = Convert.ToInt16(DateTime.Now.Month);
                    lbMail.Text = listaTarjetas[i].Email;
                    txtCliente.Text = listaTarjetas[i].Email;
                    listaTratamientos.Clear();
                    listaTratamientos = cnx.listarTratamientos(listaTarjetas[i].Dni, mes);
                    tabControl1.Controls.Clear();
                    MedEncontrados.Clear();
                    for (int j = 0; j < listaTratamientos.Count; j++)
                    {



                        foreach (claseMedicamento med in listaMedicamento)
                        {
                            if (med.Nombre == listaTratamientos[j].Medicamento)
                            {
                                MedEncontrados.Add(med);
                            }
                        }

                    }
                    cargarTPV(MedEncontrados);
                }
            }

        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////////////////
        ///////////////////////////////////////////////////
        /////////////////////////////////////////////

        private void txtLector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lbDni.Text = txtLector.Text;
                listaTarjetas = cnx.listarTarjetas();
                btnRefrescar.Enabled = false;
                for (int i = 0; i < listaTarjetas.Count; i++)
                {
                    if (listaTarjetas[i].Dni == lbDni.Text)
                    {
                        int mes = Convert.ToInt16(DateTime.Now.Month);
                        lbMail.Text = listaTarjetas[i].Email;
                        txtCliente.Text = listaTarjetas[i].Email;
                        listaTratamientos.Clear();
                        listaTratamientos = cnx.listarTratamientos(listaTarjetas[i].Dni, mes);
                        tabControl1.Controls.Clear();
                        MedEncontrados.Clear();
                        for (int j = 0; j < listaTratamientos.Count; j++)
                        {



                            foreach (claseMedicamento med in listaMedicamento)
                            {
                                if (med.Nombre == listaTratamientos[j].Medicamento)
                                {
                                    MedEncontrados.Add(med);
                                }
                            }

                        }
                        cargarTPV(MedEncontrados);
                    }
                }
            }
        }

        private void btnBloqueo_Click(object sender, EventArgs e)
        {
            block();
        }
        private void block()
        {
            foreach(Control ctrl in this.Controls)
            {
                ctrl.Enabled = false;
            }
            txtLectorUsuario.Enabled = true;
            btnCerrarSesion.Enabled = true;
            btnSalir.Enabled = true;
        }
        private void disblock()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = true;
            }
        }


        private void txtLectorUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                disblock();
                userPass =cnx.buscarDni(txtLectorUsuario.Text);
                txtdni.Text = userPass[0];
                txtPwd.Text = userPass[1];
                txtPwd.Focus();
            }
        }
    }
}
