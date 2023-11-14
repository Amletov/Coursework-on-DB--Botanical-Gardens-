using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public class GeneraDataModel
    {
        private int id;
        private string genera;
        private string family;
        private int familyId;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("genera")] public string Genera { get => genera; set => genera = value; }
        [JsonProperty("family")] public string Family { get => family; set => family = value; }
        [JsonProperty("family_id")] public int FamilyId { get => familyId; set => familyId = value; }

        public override string ToString()
        {
            return Genera;
        }

    }
}
