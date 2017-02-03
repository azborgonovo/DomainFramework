using System.Data.Entity;

namespace InfrastructureFramework.EF6
{
    public interface IDbSetFactory
    {
        IDbSet<T> CreateDbSet<T>() where T : class;
    }
}