using DataBaseKursRabota.Models;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        public void Add(FamilyModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest("families/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"families/delete/{id}");

        }

        public void Edit(FamilyModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest($"families/update/{dataModel.Id}", payLoad);
        }


        public IEnumerable<FamilyModel> GetAll(int page, int limit)
        {
            var familyList = new List<FamilyModel>();
            var jsonResult = Server.Instance.GetRequest($"ref/families/getAll?page={page}&limit={limit}");
            ResponseData<FamilyModel> responseData = JsonConvert.DeserializeObject<ResponseData<FamilyModel>>(jsonResult);
            familyList = responseData.Rows;
            return familyList;
        }

        public IEnumerable<FamilyModel> GetByValue(string value)
        {
            var familyList = new List<FamilyModel>();
            var jsonResult = Server.Instance.GetRequest($"families/getByValue?family={value}");
            ResponseData<FamilyModel> responseData = JsonConvert.DeserializeObject<ResponseData<FamilyModel>>(jsonResult);
            familyList = responseData.Rows;
            return familyList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"ref/families/getAll?page={1}&limit=50");
            ResponseData<FamilyModel> responseData = JsonConvert.DeserializeObject<ResponseData<FamilyModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
