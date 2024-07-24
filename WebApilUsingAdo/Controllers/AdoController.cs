/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApilUsingAdo.Models;


namespace WebApiUsingAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employees> employeesList = new List<Employees>();
            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employees employee = new Employees
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Gender = (string)reader["Gender"],
                        Age = (int)reader["Age"],
                        Designation = (string)reader["Designation"],
                        City = (string)reader["City"]
                    };
                    employeesList.Add(employee);
                }
                connection.Close();
            }
            return Ok(employeesList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, Gender, Age, Designation, City) VALUES (@Name, @Gender, @Age, @Designation, @City)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@City", employee.City);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Name = @Name, Gender = @Gender, Age = @Age, Designation = @Designation, City = @City WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@City", employee.City);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }
    }
}

*/




/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApilUsingAdo.Models;


namespace WebApiUsingAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            List<Employees> employeesList = new List<Employees>();
            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employees employee = new Employees
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Gender = (string)reader["Gender"],
                        Age = (int)reader["Age"],
                        Designation = (string)reader["Designation"],
                        City = (string)reader["City"]
                    };
                    employeesList.Add(employee);
                }
                connection.Close();
            }
            return Ok(employeesList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAddEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@gender", employee.Gender);
                command.Parameters.AddWithValue("@age", employee.Age);
                command.Parameters.AddWithValue("@designation", employee.Designation);
                command.Parameters.AddWithValue("@city", employee.City);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@gender", employee.Gender);
                command.Parameters.AddWithValue("@age", employee.Age);
                command.Parameters.AddWithValue("@designation", employee.Designation);
                command.Parameters.AddWithValue("@city", employee.City);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string connectionString = _configuration.GetConnectionString("Dbconnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok();
        }
    }
}

*/

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApilUsingAdo.Data_Access_Layer.Interface;
using WebApilUsingAdo.Models;

namespace WebApiUsingAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoController : ControllerBase
    {
        private readonly IEmployeeDAL _employeeDAL;

        public AdoController(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employees> employeesList = _employeeDAL.GetAllEmployees();
            return Ok(employeesList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _employeeDAL.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _employeeDAL.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeDAL.DeleteEmployee(id);

            // Get the current max ID from the table and reseed the identity
            int maxId = _employeeDAL.GetMaxEmployeeId();
            _employeeDAL.ReseedIdentity(maxId);

            return Ok();
        }
    }
}

