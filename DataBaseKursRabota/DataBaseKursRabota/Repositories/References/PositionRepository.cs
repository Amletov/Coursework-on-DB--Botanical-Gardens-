using DataBaseKursRabota.Models;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        public void Add(PositionModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest("positions/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"positions/delete/{id}");
        }

        public void Edit(PositionModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest($"positions/update/{dataModel.Id}", payLoad);
        }


        public IEnumerable<PositionModel> GetAll(int page, int limit)
        {
            var positionList = new List<PositionModel>();
            var jsonResult = Server.Instance.GetRequest($"ref/positions/getAll?page={page}&limit={limit}");
            ResponseData<PositionModel> responseData = JsonConvert.DeserializeObject<ResponseData<PositionModel>>(jsonResult);
            positionList = responseData.Rows;
            return positionList;
        }

        public IEnumerable<PositionModel> GetByValue(string value)
        {
            var positionList = new List<PositionModel>();
            var jsonResult = Server.Instance.GetRequest($"positions/getByValue?position={value}");
            ResponseData<PositionModel> responseData = JsonConvert.DeserializeObject<ResponseData<PositionModel>>(jsonResult);
            positionList = responseData.Rows;
            return positionList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"ref/positions/getAll?page={1}&limit=50");
            ResponseData<PositionModel> responseData = JsonConvert.DeserializeObject<ResponseData<PositionModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
