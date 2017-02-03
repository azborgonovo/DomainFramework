namespace InfrastructureFramework.EF6
{
    public interface ITenant
    {
        string ConnectionString { get; }
        string Schema { get; }
    }
}
