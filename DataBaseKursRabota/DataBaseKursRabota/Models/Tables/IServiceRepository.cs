namespace DataBaseKursRabota.Models.Tables
{
    public interface IServiceRepository
    {
        void Add(ServiceDataModel serviceModel);
        Task AddServiceAsync(ServiceDataModel serviceModel);
        void Edit(ServiceDataModel serviceModel);
        void Delete(int id);
        int GetTotal();
        ServiceDataModel Generate(IEnumerable<CareProductModel> careProductList, IEnumerable<EmployeeDataModel> employeeList, IEnumerable<PlantDataModel> plantList);
        IEnumerable<ServiceDataModel> GetAll(int page, int limit);
        IEnumerable<ServiceDataModel> GetByValue(string value);
    }
}
