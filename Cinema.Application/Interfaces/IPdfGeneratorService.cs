using Cinema.Application.PdfGenerator;

namespace Cinema.Application.Interfaces
{
    public interface IPdfGeneratorService
    {
        void GenerateTicketPdf(string fileName, TicketData ticketData);
    }
}
