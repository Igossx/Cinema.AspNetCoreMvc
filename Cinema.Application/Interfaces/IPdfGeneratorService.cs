namespace Cinema.Application.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<MemoryStream> GeneratePdf(Guid id);
    }
}
