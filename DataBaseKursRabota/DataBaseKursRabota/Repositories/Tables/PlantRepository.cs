using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Repositories.Tables
{
    public class PlantRepository : IPlantRepository
    {
        public void Add(PlantDataModel plantModel)
        {
            var payLoad = Server.GetPayload(plantModel);
            Server.Instance.PostRequest("plants/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"plants/delete/{id}");
        }

        public void Edit(PlantDataModel plantModel)
        {
            var payLoad = Server.GetPayload(plantModel);
            Server.Instance.PostRequest($"plants/update/{plantModel.Id}", payLoad);
        }

        public IEnumerable<PlantDataModel> GetAll(int page, int limit)
        {
            var plantList = new List<PlantDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/plants/getAll?page={page}&limit={limit}");
            ResponseData<PlantDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<PlantDataModel>>(jsonResult);
            plantList = responseData.Rows;
            return plantList;
        }

        public IEnumerable<PlantDataModel> GetByValue(string value)
        {
            var plantList = new List<PlantDataModel>();
            var jsonResult = Server.Instance.GetRequest($"plants/getByValue?plant={value}");
            ResponseData<PlantDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<PlantDataModel>>(jsonResult);
            plantList = responseData.Rows;
            return plantList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/plants/getAll?page={1}&limit=50");
            ResponseData<PlantDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<PlantDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
