using System.Collections.Generic;
using System.Data;
using Agentie_turism.domain;
using log4net;


namespace Agentie_turism.repository.userRepo;

public class UserDbRepository : IUserRepository
{
    private static readonly ILog Log = LogManager.GetLogger("UserDbRepository");
    private IDictionary<string, string> _props;
    
    public UserDbRepository(IDictionary<string, string> props)
    {
        Log.Info("Creating UserDbRepository...");
        this._props = props;
    }
    
    public IEnumerable<User> FindAll()
    {
        Log.InfoFormat("Entering FindAll() from UserDbRepository");
        IDbConnection con = DbUtils.GetConnection(_props);
        List<User> users = new List<User>();
        
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT * FROM Users";
            using (var dataR = comm.ExecuteReader())
            {
                while(dataR.Read())
                {
                    int idUser = dataR.GetInt32(0);
                    string username = dataR.GetString(1);
                    string password = dataR.GetString(2);

                    User user = new User(username, password);
                    user.Id = idUser;
                    users.Add(user);
                }
            }
        }
        
        Log.InfoFormat("Exiting findAll() from UserDbRepository");
        return users;
    }

    #nullable enable
    public User? Save(User entity)
    {
        Log.InfoFormat("Entering Save() from Users with value {0}", entity.Id);
        IDbConnection con = DbUtils.GetConnection(_props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "INSERT INTO Users(username, password) VALUES (@username, @password)";
            IDbDataParameter paramUsername = comm.CreateParameter();
            paramUsername.ParameterName = "@username";
            paramUsername.Value = entity.Username;
            comm.Parameters.Add(paramUsername);
            
            IDbDataParameter paramPassword = comm.CreateParameter();
            paramPassword.ParameterName = "@password";
            paramPassword.Value = entity.Password;
            comm.Parameters.Add(paramPassword);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
            {
                Log.Error("Error while trying to save user with id " + entity.Id);
                return entity;
            }
        }
        
        Log.InfoFormat("Exiting Save() from UserDbRepository with success");
        return null;
    }

    public User? Update(User entity)
    {
        return null;
    }

    public User? FindUserByUsername(string username)
    {
        Log.InfoFormat("Entring FindUserByUsername() with value {0}", username);
        IDbConnection con = DbUtils.GetConnection(_props);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "SELECT id, username, password FROM Users WHERE username = @username";
            IDbDataParameter paramUsername = comm.CreateParameter();
            paramUsername.ParameterName = "@username";
            paramUsername.Value = username;
            comm.Parameters.Add(paramUsername);

            using (var result = comm.ExecuteReader())
            {
                if (result.Read())
                {
                    int id = result.GetInt32(0);
                    string password = result.GetString(2);

                    User user = new User(username, password);
                    user.Id = id;
                    
                    Log.InfoFormat("Exiting FindUserByUsername() with values {0}", username);
                    return user;
                }
            }
        }
        Log.InfoFormat("Exiting FindUserByUsername() with value {0}", null);
        return null;
    }
}