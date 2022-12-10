namespace Italo.Customer.Infrastructure.Interfaces
{
    public interface IUserContext
    {
        public string? GetUserNameByToken();
    }
}
