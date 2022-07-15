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
    public class EmployeesController : ControllerBase
    {
        //api/employees/byId?id=1
        [HttpGet("byId")]
        public List<Emploee> GetById(int id)
        {
            string sql = "SELECT id, division_id, job_title, full_name FROM employees WHERE id = " + id;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Emploee> emlpoees = new List<Emploee>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            emlpoees.Add(new Emploee(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetString(2), reader.GetString(3)));
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
            return emlpoees;
        }

        //api/employees/byDivision_id?division_id=1
        [HttpGet("byDivision_id")]
        public List<Emploee> GetDivision_id(int division_id)
        {
            string sql = "SELECT id, division_id, job_title, full_name FROM employees WHERE division_id = " + division_id;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Emploee> emlpoees = new List<Emploee>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            emlpoees.Add(new Emploee(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetString(2), reader.GetString(3)));
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
            return emlpoees;
        }

        // POST api/employees/add
        [HttpPost("add")]
        public NonQueryResponse PostData(int division_id, string job_title, string full_name)
        {
            string sql = "INSERT INTO employees (division_id, job_title, full_name) VALUES ('" + division_id + "', '" + job_title + "', '" + full_name + "')";
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

        //api/employees/editById
        [HttpPut("editById")]
        public NonQueryResponse PutData(int id, int division_id, string job_title, string full_name)
        {
            string sql = "UPDATE employees SET division_id = '" + division_id + "', job_title = '" + job_title + "', full_name = '" + full_name + "' WHERE (id = '" + id + "');";
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
      
        
        //api/employees/deleteById
        [HttpDelete("deleteById")]
        public NonQueryResponse DeleteData(int id)
        {
            string sql = "DELETE FROM employees WHERE (id = '" + id + "');";
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

        //api/employees/byStringInclude?stringInclude=1
        [HttpGet("byStringInclude")]
        public List<Emploee> GetByStringInclude(string stringInclude)
        {
            string sql = "SELECT * FROM employees WHERE (job_title LIKE '%" + stringInclude + "%' or full_name LIKE '%" + stringInclude + "%')";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Emploee> emlpoees = new List<Emploee>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            emlpoees.Add(new Emploee(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetString(2), reader.GetString(3)));
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
            return emlpoees;
        }

    }
}
