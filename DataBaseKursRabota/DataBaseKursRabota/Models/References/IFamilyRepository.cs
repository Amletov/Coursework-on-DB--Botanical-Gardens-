using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public interface IFamilyRepository
    {
        void Add(FamilyModel dataModel);
        void Edit(FamilyModel dataModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<FamilyModel> GetAll(int page, int limit);
        IEnumerable<FamilyModel> GetByValue(string value);
    }
}
