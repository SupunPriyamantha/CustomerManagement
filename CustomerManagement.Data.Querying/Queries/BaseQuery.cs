using CustomerManagement.Domain.Infrastructure.Providers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Querying.Queries
{
    public abstract class BaseQuery
    {
        private readonly IDbConnectionProvider _connectionProvider;

        public BaseQuery(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected virtual async Task<List<T>> QueryAsync<T>(string sql, object param, CancellationToken cancellationToken)
        {
            using var connection = _connectionProvider.GetConnection();
            connection.Open();
            List<T> result = (await connection.QueryAsync<T>(sql, param))?.ToList();
            return result;
        }

        //protected virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql, CancellationToken cancellationToken)
        //{
        //    using var connection = _connectionProvider.GetConnection();
        //    connection.Open();
        //    List<T> result = (await connection.QueryAsync<T>(new CommandDefinition(sql, null, null, null, null, CommandFlags.Buffered, cancellationToken)))?.ToList();
        //    return result;
        //}

        protected virtual async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param , CancellationToken cancellationToken)
        {
            using var connection = _connectionProvider.GetConnection();
            connection.Open();
            T result = await connection.QueryFirstOrDefaultAsync<T>(sql, param);
            return result;
        }

        //protected virtual async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CancellationToken cancellationToken)
        //{
        //    using var connection = _connectionProvider.GetConnection();
        //    connection.Open();
        //    T result = await connection.ExecuteScalarAsync<T>(sql, param);
        //    return result;
        //}
    }
}
