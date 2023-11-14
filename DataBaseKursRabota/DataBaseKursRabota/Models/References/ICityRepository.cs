using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public interface ICityRepository
    {
        void Add(CityModel dataModel);
        void Edit(CityModel dataModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<CityModel> GetAll(int page, int limit);
        IEnumerable<CityModel> GetByValue(string value);
    }
}
