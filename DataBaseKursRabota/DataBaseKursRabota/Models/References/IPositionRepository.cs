using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public interface IPositionRepository
    {
        void Add(PositionModel dataModel);
        void Edit(PositionModel dataModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<PositionModel> GetAll(int page, int limit);
        IEnumerable<PositionModel> GetByValue(string value);
    }
}
