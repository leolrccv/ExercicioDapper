using DapperEx.Infra.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperEx.Infra.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbConnection Connection() => new SqlConnection("Data Source=DESKTOP-SQM1R9E\\SQLEXPRESS;Initial Catalog=DapperEx;Integrated Security=True;");
    }
}
