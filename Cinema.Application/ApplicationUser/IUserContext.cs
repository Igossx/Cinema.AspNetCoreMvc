namespace Cinema.Application
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
