using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories.Tables
{
    public class GardenRepository : IGardenRepository
    {
        public void Add(GardenDataModel gardenModel)
        {
            var payLoad = Server.GetPayload(gardenModel);
            Server.Instance.PostRequest("gardens/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"gardens/delete/{id}");
        }

        public void Edit(GardenDataModel gardenModel)
        {
            var payLoad = Server.GetPayload(gardenModel);
            Server.Instance.PostRequest($"gardens/update/{gardenModel.Id}", payLoad);
        }

        public IEnumerable<GardenDataModel> GetAll(int page, int limit)
        {
            var gardenList = new List<GardenDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/gardens/getAll?page={page}&limit={limit}");
            ResponseData<GardenDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GardenDataModel>>(jsonResult);
            gardenList = responseData.Rows;
            return gardenList;
        }

        public IEnumerable<GardenDataModel> GetByValue(string value)
        {
            var gardenList = new List<GardenDataModel>();
            var jsonResult = Server.Instance.GetRequest($"gardens/getByValue?garden={value}");
            ResponseData<GardenDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GardenDataModel>>(jsonResult);
            gardenList = responseData.Rows;
            return gardenList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/gardens/getAll?page={1}&limit=50");
            ResponseData<GardenDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GardenDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
