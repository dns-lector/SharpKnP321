using Microsoft.Data.SqlClient;
using SharpKnP321.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP321.Data
{
    internal class DataAccessor
    {
        private readonly SqlConnection connection;

        public DataAccessor()
        {
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samoylenko_d\Source\Repos\SharpKnP321\Database1.mdf;Integrated Security=True";
            this.connection = new(connectionString);
            try
            {
                this.connection.Open();   // підключення необхідно відкривати окремою командою
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = [];
            String sql = "SELECT * FROM Products";
            using SqlCommand cmd = new(sql, connection);
            try
            {
                using SqlDataReader reader = cmd.ExecuteReader();   // Reader - ресурс для передачі даних від БД до програми
                while (reader.Read())   // читаємо по одному рядку доки є результати
                {
                    products.Add(Product.FromReader(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed: {0}\n{1}", ex.Message, sql);
            }
            return products;
        }

        public void Install()
        {
            String sql = "CREATE TABLE Products(" +
                "Id    UNIQUEIDENTIFIER PRIMARY KEY," +
                "Name  NVARCHAR(64)     NOT NULL," +
                "Price DECIMAL(14,2)    NOT NULL)";
            using SqlCommand cmd = new(sql, connection);
            try
            {
                cmd.ExecuteNonQuery();   // без зворотнього результату
            }
            catch (Exception ex)
            {
                Console.WriteLine("Command failed: {0}\n{1}", ex.Message, sql);
            }
        }

        public void Seed()
        {
            String sql = "INSERT INTO Products VALUES" +
                "('1C87B849-12F8-43A8-802F-89578FF1E6DC', N'Samsung Galaxy S24 Ultra', 20000.00)," +
                "('86352131-DB1F-4DCC-98EE-25752269AB62', N'Google Pixel 8 Pro', 10000.00)," +
                "('2E64C765-79EB-44BB-AC8A-0673864BDDD0', N'iPhone 15 Pro', 30000.00)," +
                "('71EEA200-E5A6-48CC-A1C8-98FA1989DD72', N'OnePlus 12', 15000.00)," +
                "('02B4C962-2342-471E-9FC0-393ACD01B90F', N'Samsung Galaxy Note 10 Lite', 9000.00)," +
                "('4E654CB6-23DA-452E-BE2E-E290ECCA61FE', N'Xiaomi Poco X3 NFC', 11000.00)," +
                "('B53CC6C7-CE42-4409-9A5B-BB359AF0AE34', N'ASUS Rog Phone 3', 18000.00)," +
                "('71238977-8557-46C1-A169-525A48A2D671', N'OnePlus 8 Pro', 7000.00)," +
                "('76B32D09-AFAF-4069-B0B1-6E6FDC96FADB', N'Xiaomi Redmi Note 8 Pro', 13000.00)," +
                "('968CE4DF-21D2-4E55-81C7-0311F19F3E47', N'HUAWEI P40 Pro', 14000.00)";
            using SqlCommand cmd = new(sql, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Command failed: {0}\n{1}", ex.Message, sql);
            }
        }
    }
}
