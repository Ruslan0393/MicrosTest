using MicrosTest.Data.Helpers;
using MicrosTest.Data.IRepositories;
using MicrosTest.Domain;
using MicrosTest.DTO.Users;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            string query = $"insert into Users (fullName, info, image, username, email, facebook, twitter, lastTimeAccess)" +
                $"values ('{user.Fullname}', '{user.Info}', '{user.Image}', '{user.Username}', '{user.Email}', '{user.Facebook}', '{user.Twitter}', NOW())";
            NpgsqlConnection connection = new NpgsqlConnection(Constants.CONNECTION_STRING);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IList<User> GetAll()
        {
            string query = "Select * From users;";
            NpgsqlConnection connection = new NpgsqlConnection(Constants.CONNECTION_STRING);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            var reader = command.ExecuteReader();

            IList<User> users = new List<User>(); 

            while (reader.Read())
            {
                users.Add
                (
                    new User
                    {
                        Id = reader.GetInt64(0),
                        Fullname = reader.GetString(1),
                        Info = reader.GetString(2),
                        Image = reader.GetString(3),
                        Username = reader.GetString(4),
                        Email = reader.GetString(5),
                        Facebook = reader.GetString(6),
                        Twitter = reader.GetString(7),
                        LastTimeAccess = reader.GetDateTime(8)
                    }
                );
            }
            connection.Close();
            return users;

        }
    }
}
