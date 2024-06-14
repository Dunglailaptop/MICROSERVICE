using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 // Thêm namespace này

namespace LibraryAuthentication.Controller
{
    public class Connect
    {
        public static string connectionString = "server=localhost;database=users_service;user id=root;password=2792001dung";

        public Connect() { }

        public static List<T> Select<T>(string query) where T : new()
        {
            List<T> data = new List<T>();
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Thay thế SqlConnection bằng MySqlConnection
            {
                MySqlCommand command = new MySqlCommand(query, connection); // Thay thế SqlCommand bằng MySqlCommand
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader(); // Thay thế SqlDataReader bằng MySqlDataReader

                while (reader.Read())
                {
                    T item = new T();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        object value = reader[i];

                        // Using reflection to set the property value of the object
                        var property = typeof(T).GetProperty(columnName);
                        if (property != null && value != DBNull.Value)
                        {
                            property.SetValue(item, value);
                        }
                    }

                    data.Add(item);
                }

                reader.Close();
            }

            return data;
        }

        public static DataTable SelectAll(string query)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Thay thế SqlConnection bằng MySqlConnection
            {
                MySqlCommand command = new MySqlCommand(query, connection); // Thay thế SqlCommand bằng MySqlCommand
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader(); // Thay thế SqlDataReader bằng MySqlDataReader

                dataTable.Load(reader); // Load data directly into DataTable

                reader.Close();
            }

            return dataTable;
        }

        public static T SelectSingle<T>(string query) where T : new()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Thay thế SqlConnection bằng MySqlConnection
            {
                MySqlCommand command = new MySqlCommand(query, connection); // Thay thế SqlCommand bằng MySqlCommand
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader(); // Thay thế SqlDataReader bằng MySqlDataReader

                T item = default(T);

                if (reader.Read())
                {
                    item = new T();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        object value = reader[i];

                        // Using reflection to set the property value of the object
                        var property = typeof(T).GetProperty(columnName);
                        if (property != null && value != DBNull.Value)
                        {
                            property.SetValue(item, value);
                        }
                    }
                }
                reader.Close();
                return item;
            }
        }
    }

}
