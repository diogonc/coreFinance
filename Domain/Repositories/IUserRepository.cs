namespace CoreFinance.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool Exists(string username, string password, string propertyUuid);
    }
}
