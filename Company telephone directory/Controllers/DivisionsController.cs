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
    public class DivisionsController : ControllerBase
    {
        //api/divisions/byId?id=1
        [HttpGet("byId")]
        public List<Division> GetById(int id)
        {
            string sql = "SELECT id, title, parent_id FROM divisions WHERE id = " + id;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Division> divisions = new List<Division>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            divisions.Add(new Division(Convert.ToInt32(reader.GetValue(0)), reader.GetString(1), Convert.ToInt32(reader.GetValue(2))));
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
            return divisions;
        }

        //api/divisions/All
        [HttpGet("All")]
        public List<Division> GetAll()
        {
            string sql = "SELECT id, title, parent_id FROM divisions ";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Division> divisions = new List<Division>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            divisions.Add(new Division(Convert.ToInt32(reader.GetValue(0)), reader.GetString(1), Convert.ToInt32(reader.GetValue(2))));
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
            return divisions;
        }

        //api/divisions/byParent_id?parent_id=1
        [HttpGet("byParent_id")]
        public List<Division> GetByParent_id(int parent_id)
        {
            string sql = "SELECT id, title, parent_id FROM divisions WHERE parent_id = " + parent_id;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<Division> divisions = new List<Division>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            divisions.Add(new Division(Convert.ToInt32(reader.GetValue(0)), reader.GetString(1), Convert.ToInt32(reader.GetValue(2))));
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
            return divisions;
        }


        // POST api/divisions/add
        [HttpPost("add")]
        public NonQueryResponse PostData(string title, int parent_id)
        {
            string sql = "INSERT INTO divisions (title, parent_id) VALUES ('" + title + "', '" + parent_id + "')";
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

        //api/divisions/editById
        [HttpPut("editById")]
        public NonQueryResponse PutData(int id, string title, int parent_id)
        {
            NonQueryResponse nonQueryResponse = new NonQueryResponse();
            if (id == 1)
            {
                nonQueryResponse.numberOfRecords = 0;
                return nonQueryResponse;
            }
            string sql = "UPDATE divisions SET title = '" + title + "', parent_id = '" + parent_id + "' WHERE (id = '" + id + "');";
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


        //api/division/deleteById
        [HttpDelete("deleteById")]
        public NonQueryResponse DeleteData(int id)
        {
            NonQueryResponse nonQueryResponse = new NonQueryResponse();

            if (id == 1)
            {
                nonQueryResponse.numberOfRecords = 0;
                return nonQueryResponse;
            }
            string sql = "DELETE FROM divisions WHERE (id = '" + id + "');";
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

