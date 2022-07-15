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

    }
}

