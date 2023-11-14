using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public class FamilyModel
    {
        private int id;
        private string family;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("family")] public string Family { get => family; set => family = value; }

        public override string ToString()
        {
            return Family;
        }
    }
}
