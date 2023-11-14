using DataBaseKursRabota.Models;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories
{
    public class CityRepository : ICityRepository
    {
        public void Add(CityModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest("cities/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"cities/delete/{id}");

        }

        public void Edit(CityModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest($"cities/update/{dataModel.Id}", payLoad);
        }


        public IEnumerable<CityModel> GetAll(int page, int limit)
        {
            var cityList = new List<CityModel>();
            var jsonResult = Server.Instance.GetRequest($"ref/cities/getAll?page={page}&limit={limit}");
            ResponseData<CityModel> responseData = JsonConvert.DeserializeObject<ResponseData<CityModel>>(jsonResult);
            cityList = responseData.Rows;
            return cityList;
        }

        public IEnumerable<CityModel> GetByValue(string value)
        {
            var cityList = new List<CityModel>();
            var jsonResult = Server.Instance.GetRequest($"cities/getByValue?city={value}");
            ResponseData<CityModel> responseData = JsonConvert.DeserializeObject<ResponseData<CityModel>>(jsonResult);
            cityList = responseData.Rows;
            return cityList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"ref/cities/getAll?page={1}&limit=50");
            ResponseData<CityModel> responseData = JsonConvert.DeserializeObject<ResponseData<CityModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
