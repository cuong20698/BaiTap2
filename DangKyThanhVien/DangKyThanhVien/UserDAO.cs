using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DangKyThanhVien
{
    public class UserDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        public bool CheckUser(string userName)
        {
            string sql = @"SELECT COUNT(*) FROM UserInfo WHERE UserName = @usn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@usn", userName);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }

        public bool Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO UserInfo VALUES(@usn, @pass, @fname, @lname, @email, @gender, @address)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@usn", user.UserName);
                command.Parameters.AddWithValue("@pass", user.PassWord);
                command.Parameters.AddWithValue("@fname", user.FirstName);
                command.Parameters.AddWithValue("@lname", user.LastName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@address", user.Address);

                connection.Open();
                int count = command.ExecuteNonQuery();
                return (count >= 1);
            }
        }
    }
}