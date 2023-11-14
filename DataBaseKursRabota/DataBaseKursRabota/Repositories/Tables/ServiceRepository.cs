using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories.Tables
{
    internal class ServiceRepository : IServiceRepository
    {
        public void Add(ServiceDataModel serviceModel)
        {
            var payLoad = Server.GetPayload(serviceModel);
            Server.Instance.PostRequest("service/add", payLoad);
        }

        public async Task AddServiceAsync(ServiceDataModel serviceModel)
        {
            var payLoad = Server.GetPayload(serviceModel);
            await Server.Instance.PostRequestAsync("service/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"service/delete/{id}");
        }

        public void Edit(ServiceDataModel serviceModel)
        {
            var payLoad = Server.GetPayload(serviceModel);
            Server.Instance.PostRequest($"service/update/{serviceModel.Id}", payLoad);
        }

        public ServiceDataModel Generate(IEnumerable<CareProductModel> careProductList, IEnumerable<EmployeeDataModel> employeeList, IEnumerable<PlantDataModel> plantList)
        {
            Random random = new Random();

            int day = random.Next(1, 29);
            int month = random.Next(1, 9);
            int year = DateTime.Now.Year;
            DateTime randomDateTime = new DateTime(year, month, day, random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));

            var fertilized = randomDateTime.ToString();
            var careProductId = careProductList.ElementAt(random.Next(1, careProductList.Count())).Id;
            var plantId = plantList.ElementAt(random.Next(1, plantList.Count())).Id;
            var employeeId = employeeList.ElementAt(random.Next(1, employeeList.Count())).Id;
            var amount = random.Next(1, 25);

            ServiceDataModel service = new ServiceDataModel
            {
                Fertilized = fertilized,
                CareProductId = careProductId,
                PlantId = plantId,
                Amount = amount,
                EmployeeId = employeeId,
            };
            return service;
        }

        public IEnumerable<ServiceDataModel> GetAll(int page, int limit)
        {
            var serviceList = new List<ServiceDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/service/getAll?page={page}&limit={limit}");
            ResponseData<ServiceDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<ServiceDataModel>>(jsonResult);
            serviceList = responseData.Rows;
            return serviceList;
        }

        public IEnumerable<ServiceDataModel> GetByValue(string value)
        {
            var serviceList = new List<ServiceDataModel>();
            var jsonResult = Server.Instance.GetRequest($"service/getByValue?service={value}");
            ResponseData<ServiceDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<ServiceDataModel>>(jsonResult);
            serviceList = responseData.Rows;
            return serviceList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/service/getAll?page={1}&limit=50");
            ResponseData<ServiceDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<ServiceDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
