using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public interface IGardenRepository
    {
        void Add(GardenDataModel gardenModel);
        void Edit(GardenDataModel gardenModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<GardenDataModel> GetAll(int page, int limit);
        IEnumerable<GardenDataModel> GetByValue(string value);
    }
}
