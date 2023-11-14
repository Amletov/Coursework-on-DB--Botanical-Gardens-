using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public class CareProductModel
    {
        private int id;
        private string careProduct;
        private string unit;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("care_product")] public string CareProduct { get => careProduct; set => careProduct = value; }
        [JsonProperty("unit")] public string Unit { get => unit; set => unit = value; }

        public override string ToString()
        {
            return CareProduct;
        }
    }
}
