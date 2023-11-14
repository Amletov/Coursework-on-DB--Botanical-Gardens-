using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public interface IPlantRepository
    {
        void Add(PlantDataModel plantModel);
        void Edit(PlantDataModel plantModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<PlantDataModel> GetAll(int page, int limit);
        IEnumerable<PlantDataModel> GetByValue(string value);
    }
}
