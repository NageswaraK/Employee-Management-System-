using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data
{
    public class DBSqlCommand : IDisposable
    {
        private SqlCommand _sqlCommand = null;
        private SqlFunctions _sqlFunctions = null;
        public DBSqlCommand(CommandType commandType = CommandType.StoredProcedure)
        {
            _sqlFunctions = new SqlFunctions();
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlFunctions.GetConnection();
            _sqlCommand.CommandType = commandType;
        }

        public void AddParameters(object value, string parameter_name, SqlDbType _type, ParameterDirection paramDirection = ParameterDirection.Input, int size = 0)
        {
            _sqlCommand.Parameters.Add(parameter_name, _type);
            _sqlCommand.Parameters[parameter_name].Value = value;
            _sqlCommand.Parameters[parameter_name].Direction = paramDirection;
            if (size > 0)
                _sqlCommand.Parameters[parameter_name].Size = size;
        }

        public SqlCommand sqlCommand
        {
            get
            {
                return _sqlCommand;
            }
        }

        public DataTable ExecuteDataTable(string commandText)
        {
            DataTable dTable = null;
            _sqlCommand.CommandText = commandText;
            using (SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommand))
            {
                dTable = new DataTable();
                adapter.Fill(dTable);
            }
            return dTable;
        }

        public bool ExecuteNonQuery(string commandText)
        {
            _sqlCommand.CommandText = commandText;
            int _count = _sqlCommand.ExecuteNonQuery();
            if (_count > 0)
                return true;
            return false;
        }

        public object ExecuteScalar(string commandText)
        {
            _sqlCommand.CommandText = commandText;
            return _sqlCommand.ExecuteScalar();
        }

        public IDataReader ExecuteDataReader(string commandText)
        {
            _sqlCommand.CommandText = commandText;
            return _sqlCommand.ExecuteReader();
        }

        public DataSet ExecuteDataDataSet(string commandText)
        {
            DataSet dDataSet = null;
            _sqlCommand.CommandText = commandText;
            using (SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommand))
            {
                dDataSet = new DataSet();
                adapter.Fill(dDataSet);
            }
            return dDataSet;
        }

        public void Dispose()
        {
            _sqlFunctions.CloseConnection();
            GC.SuppressFinalize(this);
        }
    }
}
