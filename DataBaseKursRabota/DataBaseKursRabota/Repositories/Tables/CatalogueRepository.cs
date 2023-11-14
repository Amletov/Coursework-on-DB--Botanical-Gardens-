using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories.Tables
{
    public class CatalogueRepository : ICatalogueRepository
    {
        public void Add(CatalogueDataModel catalogueModel)
        {
            var payLoad = Server.GetPayload(catalogueModel);
            Server.Instance.PostRequest("catalogue/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"catalogue/delete/{id}");

        }

        public void Edit(CatalogueDataModel catalogueModel)
        {
            var payLoad = Server.GetPayload(catalogueModel);
            Server.Instance.PostRequest($"catalogue/update/{catalogueModel.Id}", payLoad);
        }

        public IEnumerable<CatalogueDataModel> GetAll(int page, int limit)
        {
            var catalogueList = new List<CatalogueDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/catalogue/getAll?page={page}&limit={limit}");
            ResponseData<CatalogueDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<CatalogueDataModel>>(jsonResult);
            catalogueList = responseData.Rows;
            return catalogueList;
        }

        public IEnumerable<CatalogueDataModel> GetByValue(string value)
        {
            var catalogueList = new List<CatalogueDataModel>();
            var jsonResult = Server.Instance.GetRequest($"catalogue/getByValue?catalogue={value}");
            ResponseData<CatalogueDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<CatalogueDataModel>>(jsonResult);
            catalogueList = responseData.Rows;
            return catalogueList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/catalogue/getAll?page={1}&limit=50");
            ResponseData<CatalogueDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<CatalogueDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
