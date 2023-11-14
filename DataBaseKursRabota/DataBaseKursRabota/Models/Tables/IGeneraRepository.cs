using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public interface IGeneraRepository
    {
        void Add(GeneraDataModel generaModel);
        void Edit(GeneraDataModel generaModel);
        void Delete(int id);
        int GetTotal();
        IEnumerable<GeneraDataModel> GetAll(int page, int limit);
        IEnumerable<GeneraDataModel> GetByValue(string value);
    }
}
