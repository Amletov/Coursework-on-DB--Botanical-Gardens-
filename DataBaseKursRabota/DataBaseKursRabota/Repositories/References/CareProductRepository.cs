using DataBaseKursRabota.Models;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories
{
    public class CareProductRepository : ICareProductRepository
    {
        public void Add(CareProductModel careProductModel)
        {
            var payLoad = Server.GetPayload(careProductModel);
            Server.Instance.PostRequest("care_products/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"care_products/delete/{id}");
        }

        public void Edit(CareProductModel careProductModel)
        {
            var payLoad = Server.GetPayload(careProductModel);
            Server.Instance.PostRequest($"care_products/update/{careProductModel.Id}", payLoad);
        }

        public IEnumerable<CareProductModel> GetAll(int page, int limit)
        {
            var careProductList = new List<CareProductModel>();
            var jsonResult = Server.Instance.GetRequest($"ref/care_products/getAll?page={page}&limit={limit}");
            ResponseData<CareProductModel> responseData = JsonConvert.DeserializeObject<ResponseData<CareProductModel>>(jsonResult);
            careProductList = responseData.Rows;
            return careProductList;
        }

        public IEnumerable<CareProductModel> GetByValue(string value)
        {
            var careProductList = new List<CareProductModel>();
            var jsonResult = Server.Instance.GetRequest($"care_products/getByValue?care_product={value}");
            ResponseData<CareProductModel> responseData = JsonConvert.DeserializeObject<ResponseData<CareProductModel>>(jsonResult);
            careProductList = responseData.Rows;
            return careProductList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"ref/care_products/getAll?page={1}&limit=50");
            ResponseData<CareProductModel> responseData = JsonConvert.DeserializeObject<ResponseData<CareProductModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
