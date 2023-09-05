using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp1Assesment1Thursday
{
    class Pm
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description1 { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public double QuanityInStock { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

    }
    class Program
    {
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Initial Catalog=PreranaCP;User ID=SA;Password=Password@123456-=";
        const string STRSELECT = "SELECT p.ProductName,p.Price,p.Description1,c.CategoryName,s.SupplierName,i.QuanityInStock,p.ProductId,c.CategoryId FROM Products p Join Categories c on p.CategoryID = c.CategoryID join ProductSuppliers ps on p.ProductID = ps.ProductID join Suppliers s on ps.SupplierID = s.SupplyId join Inventory i on p.ProductID = i.ProductID;";
        static List<ProductData> getAllDetails()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
            List<ProductData> records = new List<ProductData>();
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pd = new ProductData
                    {
                        ProductName = reader[0].ToString(),
                        Price = Convert.ToInt32(reader[1]),
                        Description1 = reader[2].ToString(),
                        CategoryName = reader[3].ToString(),
                        SupplierName = reader[4].ToString(),
                        QuanityInStock = Convert.ToInt32(reader[5]),
                        ProductId = Convert.ToInt32(reader[6]),
                        CategoryId = Convert.ToInt32(reader[7]),

                    };
                    records.Add(pd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return records;

        }

        static void readAllRecords()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = STRCONNECTION;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = STRSELECT;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["productName"]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private static void insertRecord(int CategoryId, string CategoryName)
        {
            string query = $"Insert into Categories values('{CategoryId}','{CategoryName}')";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Categories inserted successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private static void deleteRecord(int id)
        {
            string query = $"Delete from Categories where CategoryId={id}";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Category deleted successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private static void updateRecord(int cat1, string cat2)
        {
            string query = $"Update Categories Set CategoryName='{cat2}' where CategoryId='{cat1}'";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Category inserted successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            const string filename = @"C:\Users\precp\AppData\Roaming\Microsoft\Windows\Network Shortcuts\MenuProduct.txt";
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
                Console.WriteLine(line);
            Console.WriteLine("Enter choice");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("CategoryId");
                    int cId = int.Parse(Console.ReadLine());
                    Console.WriteLine("CategoryName");
                    string cName = Console.ReadLine();
                    insertRecord(cId, cName);
                    break;
                case 2: deleteRecord(4);break;
                case 3: updateRecord(4, "PersnalCare");break;
                case 4: readAllRecords();break;
                case 5: List<ProductData> records = getAllDetails();
                    foreach (var pd in records)
                    {
                      Console.WriteLine("--------------------");
                      Console.WriteLine(pd.ProductName);
                      Console.WriteLine(pd.Price);
                      Console.WriteLine(pd.Description1);
                    };break;
            }

           
        }
    }

}
