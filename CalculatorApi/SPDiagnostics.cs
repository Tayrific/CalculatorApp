using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class SPDiagnostics : IDiagnostics
    {
        private readonly string _connectionString;

        public SPDiagnostics(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Log(string message)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("LogMessage", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Message", System.Data.SqlDbType.NVarChar)
            {
                Value = message
            });
            command.Parameters.Add(new SqlParameter("@LogDate", System.Data.SqlDbType.DateTime)
            {
                Value = DateTime.Now
            });

            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

        }
    }
}
