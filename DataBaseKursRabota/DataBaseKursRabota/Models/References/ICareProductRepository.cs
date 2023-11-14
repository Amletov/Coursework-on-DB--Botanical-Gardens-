using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public interface ICareProductRepository
    {
        void Add(CareProductModel dataModel);
        void Edit(CareProductModel dataModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<CareProductModel> GetAll(int page, int limit);
        IEnumerable<CareProductModel> GetByValue(string value);
    }
}
