using System.Data.SqlClient;
using System.Data;
using WebApilUsingAdo.Models;
using WebApilUsingAdo.Data_Access_Layer.Interface;

namespace WebApilUsingAdo.Data_Access_Layer
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employees> GetAllEmployees()
        {
            List<Employees> employeesList = new List<Employees>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString() ?? string.Empty,
                        Gender = reader["Gender"].ToString() ?? string.Empty,
                        Age = Convert.ToInt32(reader["Age"]),
                        Designation = reader["Designation"].ToString() ?? string.Empty,
                        City = reader["City"].ToString() ?? string.Empty
                    };
                    employeesList.Add(employee);
                }
                connection.Close();
            }
            return employeesList;
        }

        public void AddEmployee(Employees employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spAddEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@name", (object)employee.Name ?? DBNull.Value);
                command.Parameters.AddWithValue("@gender", (object)employee.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@age", employee.Age);
                command.Parameters.AddWithValue("@designation", (object)employee.Designation ?? DBNull.Value);
                command.Parameters.AddWithValue("@city", (object)employee.City ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateEmployee(Employees employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@name", (object)employee.Name ?? DBNull.Value);
                command.Parameters.AddWithValue("@gender", (object)employee.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@age", employee.Age);
                command.Parameters.AddWithValue("@designation", (object)employee.Designation ?? DBNull.Value);
                command.Parameters.AddWithValue("@city", (object)employee.City ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
        }

        public void ReseedIdentity(int reseedValue)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand($"DBCC CHECKIDENT ('Employees', RESEED, {reseedValue})", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public int GetMaxEmployeeId()
        {
            int maxId = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM Employees", connection);
                connection.Open();
                maxId = (int)command.ExecuteScalar();
                connection.Close();
            }
            return maxId;
        }

    }
}
