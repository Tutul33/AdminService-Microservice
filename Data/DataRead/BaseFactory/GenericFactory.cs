
using Data.RadisCache;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DataFactory.BaseFactory
{
    //public class GenericFactory<T> where T : class, new() //No Interface
    public class GenericFactory<T> : IGenericFactory<T> where T : class, new()
    {
        private readonly string _connectionString;
        private readonly CacheService _cacheService;
        public GenericFactory()
        {
            _connectionString = "";
            _cacheService = new CacheService();
        }
        public Task<int> ExecuteCommand(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                int result = 0;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        IDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            result = dr.GetInt32(0);
                        }
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }

                return result;
            });
        }

        public Task<string> ExecuteCommandString(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                string result = "";
                try
                {
                    string cacheKey = $"Data_{spQuery.GetHashCode()}";
                    var cachedData = _cacheService.GetCache<DataTable>(cacheKey);
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        IDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            result = dr.IsDBNull(0) ? "[]" : dr.GetString(0);
                        }
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return result;
            });
        }
        public DataTable ExecuteCommandDataTable(string spQuery, Hashtable ht, string conString)
        {
            //return Task.Run(() =>
            //{
                DataTable dataTable = new DataTable();
                try
                {
                    string cacheKey = $"Data_{spQuery.GetHashCode()}";
                    var cachedData = _cacheService.GetCache<DataTable>(cacheKey);
                    if (cachedData != null)
                    {
                        return cachedData;
                    }

                    
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                       
                        adapter.Fill(dataTable);

                        _cacheService.SetCache(cacheKey, dataTable, TimeSpan.FromMinutes(10));
                    //IDataReader dr = cmd.ExecuteReader();
                    //if (dr.Read())
                    //{
                    //    result = dr.IsDBNull(0) ? "[]" : dr.GetString(0);
                    //}
                    //cmd.Parameters.Clear();
                }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return dataTable;
            //});
        }
        public Task<string> ExecuteCommandString(string spQuery, string conString)
        {
            return Task.Run(() =>
            {
                string result = string.Empty;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        IDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            result = Convert.ToString(dr.GetString(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return result;
            });
        }

        public Task<List<T>> ExecuteCommandList(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                List<T> Results = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        Results = DataReaderMapToList<T>(cmd.ExecuteReader());
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return Results;
            });
        }

        public Task<T> ExecuteCommandSingle(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                T Results = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        Results = DataReaderMapToList<T>(cmd.ExecuteReader()).FirstOrDefault();
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }

                return Results;
            });
        }

        public Task<T> ExecuteQuerySingle(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                T Results = null;

                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        Results = DataReaderMapToList<T>(cmd.ExecuteReader()).FirstOrDefault();
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }

                return Results;
            });
        }

        public Task<List<T>> ExecuteQuery(string spQuery, Hashtable ht, string conString)
        {
            return Task.Run(() =>
            {
                List<T> Results = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }
                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            Results = DataReaderMapToList<T>(reader).ToList();
                        }
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return Results;
            });
        }

        public Task<List<T>> ExecuteCommandFunc(string spQuery, string conString)
        {
            return Task.Run(() =>
            {
                List<T> Results = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            Results = DataReaderMapToList<T>(reader).ToList();
                        }
                        cmd.Parameters.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
                return Results;
            });
        }

        public List<T> DataReaderMapToList<Tentity>(IDataReader reader)
        {
            var results = new List<T>();
            var columnCount = reader.FieldCount;
            while (reader.Read())
            {
                var item = Activator.CreateInstance<T>();
                try
                {
                    var rdrProperties = Enumerable.Range(0, columnCount).Select(i => reader.GetName(i)).ToArray();
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if ((typeof(T).GetProperty(property.Name).GetGetMethod().IsVirtual) || (!rdrProperties.Contains(property.Name)))
                        {
                            continue;
                        }
                        else
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            {
                                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                            }
                        }
                    }
                    results.Add(item);
                }
                catch (Exception ex)
                {
                    //Logs.WriteBug(ex);
                }
            }
            return results;
        }
    }
}
