using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BLPDF
    {
        private static readonly int TOP_OFFSET = 80;
        private static readonly int LEFT_OFFSET = 40;

        public Stream GeneratePDF(float confidence, string documentName, string secret, string key)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "DecryptService Response";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            // title
            gfx.DrawString("Report", font, XBrushes.Black,
                new XRect(0, 0, page.Width, 40),
                XStringFormats.Center);

            // content
            string content = $"Confidence : {confidence} %\n" +
                $"Key : {key}\n" +
                $"Secret : {secret}\n" +
                $"Document : {documentName}";

            XRect rect = new XRect(LEFT_OFFSET, TOP_OFFSET, page.Width - LEFT_OFFSET * 2, page.Height - TOP_OFFSET * 2);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            Stream stream = new MemoryStream();
            document.Save(stream);
            return stream;
        }
    }
}
