using System.Data;

namespace DapperEx.Infra.Contracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Connection();
    }
}
