using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;

namespace tpvFarmacia
{
    public partial class formGestion : Form
    {
        conectarBD cnx;
        List<claseMedicamento> listaMedicamento = new List<claseMedicamento>();
        String nombreImagen;
        claseMedicamento med = new claseMedicamento();
        String pdfPedido;

        public formGestion()
        {
            InitializeComponent();
        }

        private void formGestion_Load(object sender, EventArgs e)
        {
            cnx = new conectarBD();
            listaMedicamento = cnx.listar();
            dataGridView1.DataSource = listaMedicamento;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] bloque = br.ReadBytes((int)fs.Length);
                cnx.Insertar(txtNombre.Text, Convert.ToDouble(txtPrecio.Text), bloque, Convert.ToInt16(txtStockMin.Text), Convert.ToInt16(txtStockActual.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("datos incompletos");
            }

         }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "imagenes|*.jpg;*.png";
            if (op1.ShowDialog()==DialogResult.OK)
            {
                nombreImagen = op1.FileName;
                pictureBox1.Image = Image.FromFile(nombreImagen);
            }
           
        }

        private void txt_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtNombreMod.Text = listaMedicamento[dataGridView1.CurrentRow.Index].Nombre;
            txtPrecioMod.Text = Convert.ToString(listaMedicamento[dataGridView1.CurrentRow.Index].Precio);
            txtStockActMod.Text = Convert.ToString(listaMedicamento[dataGridView1.CurrentRow.Index].Stockactual);
            txtStockMinMod.Text = Convert.ToString(listaMedicamento[dataGridView1.CurrentRow.Index].Stockminimo);
            MemoryStream ms = new MemoryStream(listaMedicamento[dataGridView1.CurrentRow.Index].Imagen);
            pictureBoxMod.Image = Image.FromStream(ms);
            med.Imagen = listaMedicamento[dataGridView1.CurrentRow.Index].Imagen;
            lbIndice.Text = Convert.ToString(listaMedicamento[dataGridView1.CurrentRow.Index].Indice);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            med.Indice = Convert.ToInt16(lbIndice.Text);
            med.Nombre = txtNombreMod.Text;
            med.Precio = Convert.ToDouble(txtPrecioMod.Text);
            med.Stockminimo = Convert.ToInt16(txtStockMinMod.Text);
            med.Stockactual = Convert.ToInt16(txtStockActMod.Text);
            cnx.modificarMedicamento(med);
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaMedicamento;
        }

        private void pictureBoxMod_Click(object sender, EventArgs e)
        {
            String imagen;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imagen = openFileDialog1.FileName;
                    pictureBoxMod.Image = Image.FromFile(imagen);
                    FileStream fs = new FileStream(imagen, FileMode.Open, FileAccess.Read);
                    long tamanio = fs.Length;

                    BinaryReader br = new BinaryReader(fs);
                    byte[] bloque = br.ReadBytes((int)fs.Length);
                    fs.Read(bloque, 0, Convert.ToInt32(tamanio));

                    med.Imagen = bloque;
                    // MemoryStream ms = new MemoryStream(bloque);

                    //  listadoMedicamento[dataGridView1.CurrentRow.Index].Imagen = bloque;


                    // cargarBotones();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("El archivo seleccionado no es un tipo de imagen");
            }
        }

        private void formGestion_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnControlStock_Click(object sender, EventArgs e)
        {
            List<claseMedicamento> mediki = new List<claseMedicamento>();
            mediki = cnx.obtenerMedicamentosPorStock();

            pdfPedido = generarPedido(mediki);
            mail_pedido(pdfPedido);



        }

        private String generarPedido(List<claseMedicamento>mediki)
        {
            PdfPTable pdfTable = new PdfPTable(2);

            //padding
            pdfTable.DefaultCell.Padding = 3;

            //ancho que va a ocupar la tabla en el pdf
            pdfTable.WidthPercentage = 80;

            //alineación
            pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            //borde de las tablas
            pdfTable.DefaultCell.BorderWidth = 1;
            //Añadir fila de cabecera
            for(int i=0;i<2;i++)
            {
                if (i == 0)
                {
                    PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase("Nombre"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                else
                {
                    PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase("Cantidad Necesaria"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
                    pdfTable.AddCell(cell);
                }
            }
            //añadir filas
            foreach (claseMedicamento m  in mediki)
            {
                pdfTable.AddCell(m.Nombre);
                pdfTable.AddCell((m.Stockminimo - m.Stockactual).ToString());
            }
            pdfTable.AddCell(DateTime.Now.ToString("MM-dd-yy"));
            pdfTable.AddCell("HEY YOH ALRIGHT!!");

            //Exportar a pdf (ruta por defect
            string folderPath = "C:\\pedido\\";

            //si no existe el directoria se crea
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string nombrePedido = DateTime.Now.ToString("MM-dd-yy_HH-mm-ss") + ".pdf";
            folderPath += nombrePedido;
            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A6, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);

                pdfDoc.Close();
                stream.Close();
            }
            System.Diagnostics.Process pc = new System.Diagnostics.Process();
            pc.StartInfo.FileName = folderPath;
            pc.Start();
            
            return folderPath;
        }
        private void mail_pedido(String pdfPedido)
        {
            try
            {
                string email = "jaliyodiaz96@gmail.com";
                string password = "gmail de jalo5";

                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 25);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress("profeaugustobriga@gmail.com"));
                msg.Subject = "Pedido Farmacia ProHacking";
                msg.Body = "Pedido por: Alejandro Díaz Obregón";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(pdfPedido);
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
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void txtAñadirMedicamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cnx.insertarPedido(txtAñadirMedicamento.Text);
                txtAñadirMedicamento.Text = "";
            }
        }

        private void btnExportarSql_Click(object sender, EventArgs e)
        {
            string nombreFichero = "C:\\BackUp\\CopiaSeguridad.sql";

            cnx.exportarBD(nombreFichero);
        }

        private void btnImportarSql_Click(object sender, EventArgs e)
        {
            string nombreFichero = "C:\\BackUp\\CopiaSeguridad.sql";

            cnx.importarBD(nombreFichero);
        }
    }
}
