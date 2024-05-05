using Cinema.Application.Interfaces;
using Cinema.Application.PdfGenerator;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Cinema.Application.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public void GenerateTicketPdf(string fileName, TicketData ticketData)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 12);

            gfx.DrawString($"Ticket ID: {ticketData.Id}", font, XBrushes.Black,
                new XRect(10, 10, page.Width, page.Height), XStringFormats.TopLeft);

            // Wypisz inne dane biletu

            pdf.Save(fileName);
        }
    }
}
