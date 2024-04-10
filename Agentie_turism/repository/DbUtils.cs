using System.Collections.Generic;
using System.Data;

namespace Agentie_turism.repository;

public class DbUtils
{
    private static IDbConnection _instance;

    public static IDbConnection GetConnection(IDictionary<string,string> props)
    {
        if (_instance == null || _instance.State == System.Data.ConnectionState.Closed)
        {
            _instance = GetNewConnection(props);
            _instance.Open();
        }
        return _instance;
    }

    private static IDbConnection GetNewConnection(IDictionary<string,string> props)
    {
        return ConnectionUtils.ConnectionFactory.GetInstance().CreateConnection(props);
    }
}