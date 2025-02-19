﻿using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataFactory.BaseFactory
{
    public interface IGenericFactory<T> where T : class
    {
        Task<int> ExecuteCommand(string spQuery, Hashtable ht, string conString);
        Task<string> ExecuteCommandString(string spQuery, Hashtable ht, string conString);
        Task<string> ExecuteCommandString(string spQuery, string conString);
        Task<List<T>> ExecuteCommandList(string spQuery, Hashtable ht, string conString);
        Task<T> ExecuteCommandSingle(string spQuery, Hashtable ht, string conString);
        Task<T> ExecuteQuerySingle(string spQuery, Hashtable ht, string conString);
        Task<List<T>> ExecuteQuery(string spQuery, Hashtable ht, string conString);
        Task<List<T>> ExecuteCommandFunc(string spQuery, string conString);
        List<T> DataReaderMapToList<Tentity>(IDataReader reader);

        DataTable ExecuteCommandDataTable(string spQuery, Hashtable ht, string conString);
    }
}
