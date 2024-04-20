using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Seat
{
    public class SeatDto
    {
        public int Id { get; set; }

        [Display(Name = "Rząd")]
        public char RowSign { get; set; } = default!;

        [Display(Name = "Numer")]
        public int SeatNumber { get; set; }

        [Display(Name = "Czy zarezerwowane")]
        public bool IsReserved { get; set; }
    }
}
