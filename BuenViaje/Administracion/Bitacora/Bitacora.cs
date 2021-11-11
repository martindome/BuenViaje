using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using BE;
using System.IO;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.Rendering.ChartMapper;
using MigraDoc.Rendering.UnitTest;
using MigraDoc.RtfRendering;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Fields;

namespace BuenViaje.Administracion
{
    public partial class Bitacora : Form
    {
        public Principal parent { get; set; }
        private static Dictionary<string, ToolTip> tooltips = new Dictionary<string, ToolTip>();
        public Bitacora()
        {
            InitializeComponent();
            BitacoraComboUsuario.HelpRequested += new HelpEventHandler(textBox_HelpRequested);
        }

        public Bitacora(Principal fPrincipal)
        {
            parent = fPrincipal;
            InitializeComponent();
        }

        private void SetToolTips()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in this.Controls)
            {
                ToolTip toolTip;
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                if (tooltipMessaje != "")
                {
                    if (tooltips.Keys.Contains(c.Name))
                    {
                        toolTip = tooltips[c.Name];
                    }
                    else
                    {
                        toolTip = new ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 1000;
                        toolTip.ReshowDelay = 500;
                        // Force the ToolTip text to be displayed whether or not the form is active.
                        toolTip.ShowAlways = true;
                        tooltips[c.Name] = toolTip;
                    }

                    toolTip.SetToolTip(c, tooltipMessaje);
                }
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
                }
            }

        }

        private void SetToolTipsGroupBox(GroupBox groupBox)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in groupBox.Controls)
            {
                ToolTip toolTip;
                string tooltipMessaje = IdiomaBL.ObtenerMensajeTextos(c.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
                if (tooltipMessaje != "")
                {
                    if (tooltips.Keys.Contains(c.Name))
                    {
                        toolTip = tooltips[c.Name];
                    }
                    else
                    {
                        toolTip = new ToolTip();
                        toolTip.AutoPopDelay = 5000;
                        toolTip.InitialDelay = 1000;
                        toolTip.ReshowDelay = 500;
                        // Force the ToolTip text to be displayed whether or not the form is active.
                        toolTip.ShowAlways = true;
                        tooltips[c.Name] = toolTip;
                    }

                    toolTip.SetToolTip(c, tooltipMessaje);
                }
                if (c is GroupBox)
                {
                    SetToolTipsGroupBox((GroupBox)c);
                }
            }
        }

        private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // This event is raised when the F1 key is pressed or the
            // Help cursor is clicked on any of the address fields.
            // The Help text for the field is in the control's
            // Tag property. It is retrieved and displayed in the label.

            Control requestingControl = (Control)sender;
            string message = IdiomaBL.ObtenerMensajeTextos(requestingControl.Name, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            if (message != "")
            {
                MessageBox.Show(message);
                hlpevent.Handled = true;
            }
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToParent();
            BitacoraDataGrid1.Columns.Add(ObtenerMensajeColumna("Bitacora-Columna-BitacoraID"), ObtenerMensajeColumna("Bitacora-Columna-BitacoraID"));
            BitacoraDataGrid1.Columns.Add(ObtenerMensajeColumna("Bitacora-Columna-BitacoraFecha"), ObtenerMensajeColumna("Bitacora-Columna-BitacoraFecha"));
            BitacoraDataGrid1.Columns.Add(ObtenerMensajeColumna("Bitacora-Columna-BitacoraUsuario"), ObtenerMensajeColumna("Bitacora-Columna-BitacoraUsuario"));
            BitacoraDataGrid1.Columns.Add(ObtenerMensajeColumna("Bitacora-Columna-BitacoraCriticidad"), ObtenerMensajeColumna("Bitacora-Columna-BitacoraCriticidad"));
            BitacoraDataGrid1.Columns.Add(ObtenerMensajeColumna("Bitacora-Columna-BitacoraMovimiento"), ObtenerMensajeColumna("Bitacora-Columna-BitacoraMovimiento"));
            BitacoraDataGrid1.Columns[ObtenerMensajeColumna("Bitacora-Columna-BitacoraID")].Visible = false;

            BitacoraDataGrid1.EditMode = DataGridViewEditMode.EditProgrammatically;
            BitacoraDataGrid1.AllowUserToAddRows = false;
            BitacoraDataGrid1.AllowUserToDeleteRows = false;
            BitacoraDataGrid1.AllowUserToResizeColumns = true;
            BitacoraDataGrid1.AllowUserToResizeRows = false;
            BitacoraDataGrid1.RowHeadersVisible = false;
            BitacoraDataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BitacoraDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BitacoraDataGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            BitacoraDatePickerDesde.CustomFormat = "MM-dd-yyyy";
            BitacoraDatePickerDesde.Format = DateTimePickerFormat.Custom;

            BitacoraDatePickerDesdeHora.Format = DateTimePickerFormat.Time;
            BitacoraDatePickerDesdeHora.ShowUpDown = true;

            BitacoraDatePickerHasta.CustomFormat = "MM-dd-yyyy";
            BitacoraDatePickerHasta.Format = DateTimePickerFormat.Custom;

            BitacoraDatePickerHastaHora.Format = DateTimePickerFormat.Time;
            BitacoraDatePickerHastaHora.ShowUpDown = true;

            //ComboBox
            BitacoraComboCriticidad.Items.Add("*");
            BitacoraComboCriticidad.Items.Add("HIGH");
            BitacoraComboCriticidad.Items.Add("MEDIUM");
            BitacoraComboCriticidad.Items.Add("LOW");
            BitacoraComboCriticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            BitacoraComboCriticidad.SelectedIndex = 0;

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(SingletonSesion.Instancia.Usuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("Bitacora-Form", SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
            SetToolTips();
        }

        private void CargarIdioma(List<ControlBE> pControles)
        {
            foreach (Control C in this.Controls)
            {
                foreach (ControlBE pControl in pControles)
                {
                    if (pControl.ID_Control == C.Name)
                    {
                        C.Text = pControl.Mensaje;
                        break;
                    }  
                }
            }
        }

        private string ObtenerMensajeColumna(string pstring)
        {
            return IdiomaBL.ObtenerMensajeTextos(pstring, SingletonSesion.Instancia.Usuario.Idioma_Descripcion);
        }

        private void BitacoraBotonConsultar_Click(object sender, EventArgs e)
        {
            //BitacoraBE mBitacora = new BitacoraBE();
            //DateTime Desde = BitacoraDatePickerDesde.Value.Date + BitacoraDatePickerDesdeHora.Value.TimeOfDay;
            //DateTime Hasta = BitacoraDatePickerHasta.Value.Date + BitacoraDatePickerHastaHora.Value.TimeOfDay;
            //if (this.BitacoraComboUsuario.Text != "")
            //{
            //    UsuarioBE usuario = new UsuarioBL().Obtener(this.BitacoraComboUsuario.Text);
            //    if (null == usuario)
            //    {
            //        mBitacora.Nombre_Usuario = "*";
            //    }
            //    else
            //    {
            //        mBitacora.Nombre_Usuario = usuario.Nombre_Usuario;
            //    }
            //}
            //else if(this.BitacoraComboUsuario.Text != "" || this.BitacoraComboUsuario.Text != "")
            //{
            //    mBitacora.Nombre_Usuario = "*";
            //}

            //mBitacora.Tipo_Evento = BitacoraComboCriticidad.SelectedItem.ToString();
            //BitacoraBL pBitacora = new BitacoraBL();
            //List<BitacoraBE> Registros = pBitacora.Listar(mBitacora, Desde, Hasta);
            //List<BitacoraBE> RegistrosAux = new List<BitacoraBE>();
            //foreach (BitacoraBE bitacora in Registros)
            //{
            //    if (bitacora.Nombre_Usuario.Contains(this.BitacoraComboUsuario.Text.ToString()))
            //    {
            //        RegistrosAux.Add(bitacora);
            //    }
            //}
            //ActualizarGrilla(RegistrosAux);
            ActualizarGrillaBitacora();
        }


        private void ActualizarGrillaBitacora()
        {
            this.BitacoraDataGrid1.Rows.Clear();
            BitacoraBL bitacorabl = new BitacoraBL();
            DateTime Desde = BitacoraDatePickerDesde.Value.Date + BitacoraDatePickerDesdeHora.Value.TimeOfDay;
            DateTime Hasta = BitacoraDatePickerHasta.Value.Date + BitacoraDatePickerHastaHora.Value.TimeOfDay;
            foreach (BitacoraBE bitacorabe in bitacorabl.Listar(Desde, Hasta))
            {
                bool flag = true;
                //if (this.RutasPrincipalText2.Text != "" && this.RutasPrincipalText2.Text != rutabe.Origen.Nombre)
                if (this.BitacoraComboUsuario.Text != "" && !(bitacorabe).Nombre_Usuario.Contains(this.BitacoraComboUsuario.Text) && this.BitacoraComboUsuario.Text != "*")
                {
                    flag = false;
                }
                //if (this.RutasPrincipalText3.Text != "" && this.RutasPrincipalText3.Text != rutabe.Destino.Nombre)
                if (BitacoraComboCriticidad.SelectedItem.ToString() != "" && !(bitacorabe).Tipo_Evento.Contains(BitacoraComboCriticidad.SelectedItem.ToString()) && BitacoraComboCriticidad.SelectedItem.ToString() != "*")
                {
                    flag = false;
                }
                if (flag)
                {
                BitacoraDataGrid1.Rows.Add(bitacorabe.ID_Bitacora, bitacorabe.Fecha, bitacorabe.Nombre_Usuario, bitacorabe.Tipo_Evento, bitacorabe.Descripcion);
                }
            }
        }


        private void ActualizarGrilla(List<BitacoraBE> Registros)
        {
            BitacoraDataGrid1.Rows.Clear();
            foreach (BitacoraBE mReg in Registros)
                BitacoraDataGrid1.Rows.Add(mReg.ID_Bitacora, mReg.Fecha, mReg.Nombre_Usuario, mReg.Tipo_Evento, mReg.Descripcion);
        }

        private void BitacoraBottonExportToPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = @"report_" + this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".pdf";
            // set filters - this can be done in properties as well
            savefile.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                Document document = new Document();
                document.DefaultPageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
                document.DefaultPageSetup.PageFormat = PageFormat.A4;
                Section section = document.AddSection();


                //Titulo
                Paragraph Title = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Bitacora-pdf-Title", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + "\n\n", "Heading1");
                Title.AddBookmark("Title");
                Title.Format.Font.Size = 30;
                //Title.Format.Font.Color = Colors.DarkBlue;
                Title.Format.Alignment = ParagraphAlignment.Center;

                Paragraph Date = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Bitacora-pdf-Date", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) + ": " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\nn", "Heading1");
                Date.AddBookmark("Date");
                Date.Format.Font.Size = 15;
                //Date.Format.Font.Color = Colors.DarkBlue;
                Date.Format.Alignment = ParagraphAlignment.Left;

                Paragraph Requested = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Bitacora-pdf-Requested", SingletonSesion.Instancia.Usuario.Idioma_Descripcion) +": " +  SingletonSesion.Instancia.Usuario.Nombre_Usuario + "\nn", "Heading1");
                Requested.AddBookmark("Requested");
                Requested.Format.Font.Size = 15;
                //Requested.Format.Font.Color = Colors.DarkBlue;
                Requested.Format.Alignment = ParagraphAlignment.Left;

                this.CreateTable(document, savefile.FileName);
                var renderer = new PdfDocumentRenderer();
                renderer.Document = document;
                renderer.RenderDocument();

                renderer.Save(savefile.FileName);
                
                //DemonstrateAlignment(document);
                //DemonstrateCellMerge(document);


                //int yPoint = 0;
                //PdfDocument pdf = new PdfDocument();
                //PdfPage pdfPage = pdf.AddPage();

                //XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                //XFont fontTable = new XFont("Verdana", 8, XFontStyle.Bold);
                ////graph.DrawString("This is my first PDF document", font, XBrushes.Black,
                ////new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                //yPoint = yPoint + 100;
                //foreach (DataGridViewRow row in BitacoraDataGrid1.Rows)
                //{

                //    string fecha = row.Cells[1].Value.ToString();
                //    string usuario = row.Cells[2].Value.ToString();
                //    string criticidad = row.Cells[3].Value.ToString();
                //    string descripcion = row.Cells[4].Value.ToString();

                //    graph.DrawString(fecha, fontTable, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                //    graph.DrawString(usuario, fontTable, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                //    graph.DrawString(criticidad, fontTable, XBrushes.Black, new XRect(200, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                //    graph.DrawString(descripcion, fontTable, XBrushes.Black, new XRect(300, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                //    yPoint = yPoint + 40;

                //}
                //pdf.Save(savefile.FileName);
            }
        }

        private void CreateTable (Document document, string TableName)
        {
            //Paragraph paragraph = document.LastSection.AddParagraph(TableName, "Heading2");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column1 = table.AddColumn(Unit.FromCentimeter(2));
            column1.Format.Alignment = ParagraphAlignment.Center;
            Column column2 = table.AddColumn(Unit.FromCentimeter(5));
            column2.Format.Alignment = ParagraphAlignment.Center;
            Column column3 = table.AddColumn(Unit.FromCentimeter(2));
            column3.Format.Alignment = ParagraphAlignment.Center;
            Column column4 = table.AddColumn(Unit.FromCentimeter(8));
            column4.Format.Alignment = ParagraphAlignment.Center;

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.AddParagraph(ObtenerMensajeColumna("Bitacora-Columna-BitacoraFecha"));
            cell = row.Cells[1];
            cell.AddParagraph((ObtenerMensajeColumna("Bitacora-Columna-BitacoraUsuario")));
            cell = row.Cells[2];
            cell.AddParagraph((ObtenerMensajeColumna("Bitacora-Columna-BitacoraCriticidad")));
            cell = row.Cells[3];
            cell.AddParagraph(ObtenerMensajeColumna("Bitacora-Columna-BitacoraMovimiento"));

            //BitacoraDataGrid1.Sort(BitacoraDataGrid1.Columns[1], ListSortDirection.Ascending);
            foreach (DataGridViewRow GridRow in BitacoraDataGrid1.Rows)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(GridRow.Cells[1].Value.ToString());
                cell = row.Cells[1];
                cell.AddParagraph(GridRow.Cells[2].Value.ToString());
                cell = row.Cells[2];
                cell.AddParagraph(GridRow.Cells[3].Value.ToString());
                cell = row.Cells[3];
                cell.AddParagraph(GridRow.Cells[4].Value.ToString());
            }
            //table.SetEdge(0, 0, 2, 3, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);
            document.LastSection.Add(table);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
