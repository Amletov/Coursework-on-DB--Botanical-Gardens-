using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Repositories.Tables
{
    public class GeneraRepository : IGeneraRepository
    {
        public void Add(GeneraDataModel generaModel)
        {
            var payLoad = Server.GetPayload(generaModel);
            Server.Instance.PostRequest("generas/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"generas/delete/{id}");
        }

        public void Edit(GeneraDataModel generaModel)
        {
            var payLoad = Server.GetPayload(generaModel);
            Server.Instance.PostRequest($"generas/update/{generaModel.Id}", payLoad);
        }

        public IEnumerable<GeneraDataModel> GetAll(int page, int limit)
        {
            var generaList = new List<GeneraDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/generas/getAll?page={page}&limit={limit}");
            ResponseData<GeneraDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GeneraDataModel>>(jsonResult);
            generaList = responseData.Rows;
            return generaList;
        }

        public IEnumerable<GeneraDataModel> GetByValue(string value)
        {
            var generaList = new List<GeneraDataModel>();
            var jsonResult = Server.Instance.GetRequest($"generas/getByValue?genera={value}");
            ResponseData<GeneraDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GeneraDataModel>>(jsonResult);
            generaList = responseData.Rows;
            return generaList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/generas/getAll?page={1}&limit=50");
            ResponseData<GeneraDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<GeneraDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
