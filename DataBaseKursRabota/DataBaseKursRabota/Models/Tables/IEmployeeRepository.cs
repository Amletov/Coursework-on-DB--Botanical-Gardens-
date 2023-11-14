namespace DataBaseKursRabota.Models.Tables
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeDataModel employeeModel);
        Task AddEmployeeAsync(EmployeeDataModel employeeModel);
        void Edit(EmployeeDataModel employeeModel);
        void Delete(int id);
        int GetTotal();
        EmployeeDataModel Generate(IEnumerable<PositionModel> positionList);
        IEnumerable<EmployeeDataModel> GetAll(int page, int limit);
        IEnumerable<EmployeeDataModel> GetByValue(string value);
    }
}
