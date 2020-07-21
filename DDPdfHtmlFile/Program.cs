using GrapeCity.Documents.Html;
using GrapeCity.Documents.Pdf;
using System.Drawing;
using System.IO;

namespace DDPdfHtmlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //GcPdfDocument.SetLicenseKey("");

            var doc = new GcPdfDocument();
            var page = doc.NewPage();
            var g = page.Graphics;

            g.DrawHtml(File.ReadAllText("ActiveReports.html"),
                       72,
                       72,
                       new HtmlToPdfFormat(false),
                       out SizeF size);

            doc.Save("HTMLFileToPDF.pdf");


            var gcHtmlRenderer = new GcHtmlRenderer(File.ReadAllText("ActiveReports.html"));

            gcHtmlRenderer.RenderToJpeg("HTMLFileToPDF.jpeg", new JpegSettings());
            gcHtmlRenderer.RenderToPng("HTMLFileToPDF.png", new PngSettings());
        }
    }
}
