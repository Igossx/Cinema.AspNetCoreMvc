using Cinema.Application.Interfaces;
using Cinema.Domain.Interfaces;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace Cinema.Application.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserContext _userContext;
        private readonly IScreeningRepository _screeningRepository;

        public PdfGeneratorService(IReservationRepository reservationRepository, IUserContext userContext,
            IScreeningRepository screeningRepository)
        {
            _reservationRepository = reservationRepository;
            _userContext = userContext;
            _screeningRepository = screeningRepository;
        }

        public async Task<MemoryStream> GeneratePdf(Guid id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            var email = _userContext.GetCurrentUser()!.Email;

            var screening = await _screeningRepository.GetByIdAsync(reservation.ScreeningId);

            // Tworzenie dokumentu PDF
            PdfDocument document = new PdfDocument();

            document.PageSettings.Size = new SizeF(420, 280);

            // Dodawanie strony do dokumentu
            PdfPage page = document.Pages.Add();

            // Tworzenie obiektu typu PdfGraphics do rysowania na stronie
            PdfGraphics graphics = page.Graphics;

            // Tworzenie obiektu czcionki do kodu kreskowego
            PdfCode128Barcode barcode = new PdfCode128Barcode();

            // Ustawianie wartości kodu kreskowego
            barcode.Text = id.ToString();

            // Rysowanie kodu kreskowego na stronie PDF
            float barcodeY = page.Size.Height - 120;
            barcode.Draw(page.Graphics, new PointF(10, barcodeY));

            // Ustawienia czcionki
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 22);

            // Rysowanie tytułu biletu
            graphics.DrawString("Bilet", font2, PdfBrushes.Black, new PointF(10, 0));

            // Rysowanie danych rezerwacji
            graphics.DrawString($"Tytul filmu: {screening.Movie.Title}", font, PdfBrushes.Black, new PointF(10, 30));
            graphics.DrawString($"Data i godzina projekcji: {screening.Date.ToShortDateString()} - {screening.Time.ToString("hh\\:mm")}", font, PdfBrushes.Black, new PointF(10, 50));
            graphics.DrawString($"Kwota: {reservation.TotalCost} PLN", font, PdfBrushes.Black, new PointF(10, 70));
            graphics.DrawString($"Miejsca: {reservation.Seats}", font, PdfBrushes.Black, new PointF(10, 90));
            graphics.DrawString($"Adres e-mail: {email}", font, PdfBrushes.Black, new PointF(10, 110));

            // Zapisywanie dokumentu PDF do strumienia
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            return stream;
        }
    }
}
