namespace Cinema.Application.Screening.Commands
{
    public class CreateScreeningDto
    {
        public int MovieId { get; set; }
        public int CinemaHallId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
