using EmployeeMicroservice.Models;

namespace EmployeeMicroservice.Infrastructure
{
    public interface IEmployee
    {
        Employee Getprofile(int emploeeId);
    }
}
