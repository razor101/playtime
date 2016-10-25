namespace PlayTime.Infrastructure.Interfaces
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBaseRepository<TModel> where TModel : class
    {
        DbSet<TModel> Table { get; }

        DbQuery<TModel> JoinedTable { get; }
    }
}