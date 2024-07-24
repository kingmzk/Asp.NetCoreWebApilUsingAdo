using WebApilUsingAdo.Models;

namespace WebApilUsingAdo.Data_Access_Layer.Interface
{
    public interface IEmployeeDAL
    {
        List<Employees> GetAllEmployees();
        void AddEmployee(Employees employee);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(int id);
        void ReseedIdentity(int reseedValue);
        int GetMaxEmployeeId();
    }
}
