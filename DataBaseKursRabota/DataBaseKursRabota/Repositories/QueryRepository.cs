using DataBaseKursRabota.Models;
using Newtonsoft.Json;

namespace DataBaseKursRabota.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        public IEnumerable<Dictionary<string, object>> Query(int number)
        {
            IEnumerable<Dictionary<string, object>> dataList;
            var jsonResult = Server.Instance.GetRequest($"queries/{number}");
            ResponseData<Dictionary<string, object>> responseData = JsonConvert.DeserializeObject<ResponseData<Dictionary<string, object>>>(jsonResult);
            dataList = responseData.Rows;
            return dataList;
        }
    }
}
