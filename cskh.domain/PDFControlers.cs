using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.IO;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;
using List = Spire.Pdf.Exporting.XPS.Schema.List;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;
using Spire.Pdf.Tables;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Windows.Forms;

namespace cskh.domain
{
    public class PDFControlers
    {
        private static string fontPath = string.Format("{0}XMLSigner\\Font", Application.StartupPath.Split(new[] { "XMLSigner" }, StringSplitOptions.None)[0]);
        public byte[] createPDF(DataTable dt)
        {
            DataTable _dt = new DataTable();

            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 15f, 15f);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                // step 3
                pdfdoc.Open();
                //MemoryStream stream = new MemoryStream();
                // step 4 how many tables you want to create
                //for (int i = 0; i < 5; i++)
                //{
                var paragraph = new Paragraph();
                //paragraph.Add(createFDFTable(dt));
                //pdfdoc.Add(paragraph);
                pdfdoc.Add(createFDFTable(dt));

                //}
                // step 5
                pdfdoc.Close();
                writer.Close();
                byte[] byteArray = stream.ToArray();
                return byteArray;
            }
        }

        public static PdfPTable createFDFTable(DataTable dt)
        {
            //PdfPTable tb = createTableHeader(dt);
            List<PdfPCell> cells = new List<PdfPCell>();
            var bf = BaseFont.CreateFont((string.Format("{0}\\{1}.ttf", fontPath, "TIMES")), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var _fontRedNomal = new Font(bf) { Size = 12, Color = new BaseColor(255, 0, 0) };
            var _fontNomal = new Font(bf) { Size = 12, Color = new BaseColor(0, 0, 0) };
            // a table with three columns
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            // we add a cell with colspan 3
            //cell = new PdfPCell(new Phrase("Cell with colspan 3"));
            // Create Table Header
            table.Rows.Add(new PdfPRow(createTableHeader(dt)));
            // the cell object
            PdfPCell cell;
            //foreach (DataColumn cl in dt.Columns)
            //{
            //    cell = new PdfPCell(new Phrase(TableHeaderCaption.getCaption(cl.ColumnName), _fontRedNomal));
            //    table.AddCell(cell);
            //}

            // Create Table content
            foreach (DataRow dr in dt.Rows)
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    cell = new PdfPCell(new Phrase(dr[i].ToString(), _fontNomal));
                    cell.Padding = 5;
                    table.AddCell(cell);
                }
            }
            return table;
        }
        public static PdfPCell[] createTableHeader(DataTable dt)
        {
            //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //Font font = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.NORMAL);
            var bf = BaseFont.CreateFont((string.Format("{0}\\{1}.ttf", fontPath, "TIMES")), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var _fontRedNomal = new Font(bf) { Size = 12, Color = new BaseColor(255, 0, 0) };

            // a table with three columns
            PdfPCell[] cells = new PdfPCell[dt.Columns.Count];
            // the cell object
            PdfPCell cell;
            // we add a cell with colspan 3
            //cell = new PdfPCell(new Phrase("Cell with colspan 3"));

            var index = 0;
            foreach (DataColumn cl in dt.Columns)
            {
                cell = new PdfPCell(new Phrase(TableHeaderCaption.getCaption(cl.ColumnName), _fontRedNomal));
                cell.Padding = 5;
                cells[index] = cell;
                index++;
            }
            return cells;
        }
    }

}

