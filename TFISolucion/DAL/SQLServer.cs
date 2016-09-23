using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TFI.DAL
{
    public class SQLServer : IConnection
    {
        private SqlConnection cnn;
        private DataSet dataset;
        private SqlTransaction tr;
        private SqlCommand cmd;

        public SQLServer()
        {
            dataset = new DataSet();
            cmd = new SqlCommand();
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString);
        }

        public DataSet Read(string query, Hashtable data)
        {
            ConnectionOpen();

            ConnectionBind(query);

            AddParameters(data);

            DataSetFill();

            ConnectionClose();

            return dataset;
        }

        public bool Write(string query, Hashtable data, bool withTransaction = true)
        {
            if (IsConnectionClosed())
                ConnectionOpen();

            try
            {
                TransactionBegin();

                ConnectionBind(query, withTransaction: withTransaction);

                AddParameters(data);

                var result = CommandExcecute();

                if (withTransaction)
                    TransactionCommit();

                return true;
            }
            catch (System.Exception)
            {
                if (withTransaction)
                    TransactionCancel();

                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }

        #region Transaction

        private void TransactionCancel()
        {
            tr.Rollback();
        }

        private void TransactionCommit()
        {
            tr.Commit();
        }

        private void TransactionBegin()
        {
            tr = cnn.BeginTransaction();
        }

        #endregion Transaction

        private int CommandExcecute()
        {
            return cmd.ExecuteNonQuery();
        }

        #region Connection

        private bool IsConnectionClosed()
        {
            return (cnn.State == ConnectionState.Closed);
        }

        private void ConnectionOpen()
        {
            cnn.Open();
        }

        private void ConnectionClose()
        {
            cnn.Close();
        }

        private void ConnectionBind(string query, bool withTransaction = false, CommandType type = CommandType.StoredProcedure)
        {
            cmd.Connection = cnn;
            cmd.CommandText = query;
            cmd.CommandType = type;
            if (withTransaction)
                cmd.Transaction = tr;
        }

        #endregion Connection

        private void DataSetFill()
        {
            var da = new SqlDataAdapter();
            da.Fill(dataset);
        }

        private void AddParameters(System.Collections.Hashtable data)
        {
            if (data != null)
            {
                foreach (string d in data.Keys)
                {
                    cmd.Parameters.AddWithValue(d, data[d]);
                }
            }
        }
    }
}