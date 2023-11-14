using DataBaseKursRabota.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataBaseKursRabota.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public void Add(PropertyModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest("properties/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"properties/delete/{id}");

        }

        public void Edit(PropertyModel dataModel)
        {
            var payLoad = Server.GetPayload(dataModel);
            Server.Instance.PostRequest($"properties/update/{dataModel.Id}", payLoad);
        }


        public IEnumerable<PropertyModel> GetAll(int page, int limit)
        {
            var propertyList = new List<PropertyModel>();
            var jsonResult = Server.Instance.GetRequest($"ref/properties/getAll?page={page}&limit={limit}");
            ResponseData<PropertyModel> responseData = JsonConvert.DeserializeObject<ResponseData<PropertyModel>>(jsonResult);
            propertyList = responseData.Rows;
            return propertyList;
        }

        public IEnumerable<PropertyModel> GetByValue(string value)
        {
            var propertyList = new List<PropertyModel>();
            var jsonResult = Server.Instance.GetRequest($"properties/getByValue?property={value}");
            ResponseData<PropertyModel> responseData = JsonConvert.DeserializeObject<ResponseData<PropertyModel>>(jsonResult);
            propertyList = responseData.Rows;
            return propertyList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"ref/properties/getAll?page={1}&limit=50");
            ResponseData<PropertyModel> responseData = JsonConvert.DeserializeObject<ResponseData<PropertyModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
