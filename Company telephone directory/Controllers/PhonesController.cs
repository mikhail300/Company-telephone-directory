using Company_telephone_directory.Database;
using Company_telephone_directory.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data.Common;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company_telephone_directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        //api/divisions/byEmployee_id?employee_id=1
        [HttpGet("byEmployee_id")]
        public List<Phone> GetByEmployee_id(int employee_id)
        {
            string sql = "SELECT id, type, number, employee_id FROM phones WHERE employee_id = " + employee_id;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Phone> phones = new List<Phone>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            phones.Add(new Phone(Convert.ToInt32(reader.GetValue(0)), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetValue(3))));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return phones;
        }

        // POST api/phones/add
        [HttpPost("add")]
        public NonQueryResponse PostData(string type, string number, int employee_id)
        {
            string sql = "INSERT INTO phones (type, number, employee_id) VALUES ('" + type + "', '" + number + "', '" + employee_id + "')";
            NonQueryResponse nonQueryResponse = new NonQueryResponse();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                nonQueryResponse.numberOfRecords = cmd.ExecuteNonQuery();
                nonQueryResponse.lastInsertedId = cmd.LastInsertedId;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return nonQueryResponse;
        }

        //api/phones/editById
        [HttpPut("editById")]
        public NonQueryResponse PutData(int id, string type, string number, int employee_id)
        {
            string sql = "UPDATE phones SET type = '" + type + "', number = '" + number + "', employee_id = '" + employee_id + "' WHERE (id = '" + id + "');";
            NonQueryResponse nonQueryResponse = new NonQueryResponse();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                nonQueryResponse.numberOfRecords = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return nonQueryResponse;
        }


        //api/phones/deleteById
        [HttpDelete("deleteById")]
        public NonQueryResponse DeleteData(int id)
        {
            string sql = "DELETE FROM phones WHERE (id = '" + id + "');";
            NonQueryResponse nonQueryResponse = new NonQueryResponse();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                nonQueryResponse.numberOfRecords = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return nonQueryResponse;
        }
    }
}
