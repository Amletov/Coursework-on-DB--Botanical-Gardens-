using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public interface ICatalogueRepository
    {
        void Add(CatalogueDataModel catalogueModel);
        void Edit(CatalogueDataModel catalogueModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<CatalogueDataModel> GetAll(int page, int limit);
        IEnumerable<CatalogueDataModel> GetByValue(string value);
    }
}
