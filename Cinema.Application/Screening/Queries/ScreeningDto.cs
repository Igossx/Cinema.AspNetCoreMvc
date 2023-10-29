namespace Cinema.Application.Screening.Queries
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } = default!;
        public string CinemaHallName { get; set; } = default!;
        public DateTime ScreeningDate { get; set; }
        public TimeSpan ScreeningTime { get; set; }
    }
}
