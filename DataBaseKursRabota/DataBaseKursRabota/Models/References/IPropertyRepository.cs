using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public interface IPropertyRepository
    {
        void Add(PropertyModel dataModel);
        void Edit(PropertyModel dataModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<PropertyModel> GetAll(int page, int limit);
        IEnumerable<PropertyModel> GetByValue(string value);
    }
}
