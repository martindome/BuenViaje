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
        public Bitacora()
        {
            InitializeComponent();
        }

        public Bitacora(Principal fPrincipal)
        {
            parent = fPrincipal;
            InitializeComponent();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            #region Formato Grilla
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
            #endregion

            BitacoraDatePickerDesde.CustomFormat = "dd-MM-yyyy hh:mm:ss";
            BitacoraDatePickerDesde.Format = DateTimePickerFormat.Custom;

            BitacoraDatePickerHasta.CustomFormat = "dd-MM-yyyy hh:mm:ss";
            BitacoraDatePickerHasta.Format = DateTimePickerFormat.Custom;

            //ComboBox
            BitacoraComboUsuario.Items.Add("*");
            foreach (string mS in BitacoraBL.ListarUsuarios())
                BitacoraComboUsuario.Items.Add(mS);
            BitacoraComboCriticidad.Items.Add("*");
            BitacoraComboCriticidad.Items.Add("HIGH");
            BitacoraComboCriticidad.Items.Add("MEDIUM");
            BitacoraComboCriticidad.Items.Add("LOW");
            BitacoraComboCriticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            BitacoraComboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            BitacoraComboCriticidad.SelectedIndex = 0;
            BitacoraComboUsuario.SelectedIndex = 0;

            CargarIdioma(IdiomaBL.ObtenerMensajeControladores(LoginBL.SingleUsuario.Idioma_Descripcion));
            this.Text = IdiomaBL.ObtenerMensajeTextos("Bitacora-Form", LoginBL.SingleUsuario.Idioma_Descripcion);
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
            return IdiomaBL.ObtenerMensajeTextos(pstring, LoginBL.SingleUsuario.Idioma_Descripcion);
        }

        private void BitacoraBotonConsultar_Click(object sender, EventArgs e)
        {
            BitacoraBE mBitacora = new BitacoraBE();
            DateTime Desde = BitacoraDatePickerDesde.Value.Date;
            DateTime Hasta = BitacoraDatePickerHasta.Value.Date;
            mBitacora.Nombre_Usuario = BitacoraComboUsuario.SelectedItem.ToString();
            mBitacora.Tipo_Evento = BitacoraComboCriticidad.SelectedItem.ToString();
            BitacoraBL pBitacora = new BitacoraBL();
            List<BitacoraBE> Registros = pBitacora.Listar(mBitacora, Desde, Hasta);
            ActualizarGrilla(Registros);
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

                Paragraph paragraph = document.LastSection.AddParagraph(IdiomaBL.ObtenerMensajeTextos("Bitacora-pdf-Title", LoginBL.SingleUsuario.Idioma_Descripcion), "Heading1");
                paragraph.AddBookmark("Tables");

                this.DemonstrateSimpleTable(document, savefile.FileName);
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

        private void DemonstrateSimpleTable (Document document, string TableName)
        {
            document.LastSection.AddParagraph(TableName, "Heading2");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(3));
            column.Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn(Unit.FromCentimeter(6));
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(6));

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.AddParagraph(ObtenerMensajeColumna("Bitacora-Columna-BitacoraFecha"));
            cell = row.Cells[1];
            cell.AddParagraph((ObtenerMensajeColumna("Bitacora-Columna-BitacoraUsuario")));
            cell = row.Cells[2];
            cell.AddParagraph((ObtenerMensajeColumna("Bitacora-Columna-BitacoraCriticidad")));
            cell = row.Cells[3];
            cell.AddParagraph(ObtenerMensajeColumna("Bitacora-Columna-BitacoraMovimiento"));

            foreach(DataGridViewRow GridRow in BitacoraDataGrid1.Rows)
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

            table.SetEdge(0, 0, 2, 3, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);
        }

        private static void DemonstrateAlignment(Document document)
        {
            document.LastSection.AddParagraph("Cell Alignment", "Heading2");

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            table.Format.Shading.Color = Colors.LavenderBlush;
            table.Shading.Color = Colors.Salmon;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 35;

            Row row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");
        }

        private static void DemonstrateCellMerge(Document document)
        {
            document.LastSection.AddParagraph("Cell Merge", "Heading2");

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 35;

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Merge Right");
            row.Cells[0].MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeDown = 1;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].AddParagraph("Merge Down");

            table.AddRow();
        }
    }
}
