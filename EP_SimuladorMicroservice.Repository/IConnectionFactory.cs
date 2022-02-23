using System.Data;

namespace EP_SimuladorMicroservice.Repository
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
