using System.Collections;
using System.Data;

namespace TFI.DAL
{
    public interface IConnection
    {
        DataTable Read(string query, Hashtable data);

        bool Write(string query, Hashtable data, bool withTransaction = true);
    }
}