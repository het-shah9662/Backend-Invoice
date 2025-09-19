using Microsoft.Data.SqlClient;
using Project1.Models;
using System.Data;
using static Azure.Core.HttpHeader;

namespace Project1.DAL
{
    public class Repo : Interface
    {
        public readonly IConfiguration _configuration;
        public readonly string _connectionString;

        public Repo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public List<Item> GetAllInvoices()
        {
            string query = "SELECT CustomerName, Name, Price FROM InvoiceItems AS I LEFT JOIN Invoices AS l ON l.InvoiceID = I.InvoiceID;";
            var items = new List<Item>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read()) 
                        {
                            items.Add(new Item
                            {
                                customerName = reader["CustomerName"]?.ToString(),
                                name = reader["Name"]?.ToString(),
                                price = reader["Price"] != DBNull.Value ? Convert.ToDouble(reader["Price"]) : 0.0
                            });
                        }

                        return items;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Database error: {ex.Message}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        throw;
                    }
                }
            }
        }

    }
}
