using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public class PropertyModel
    {
        private int id;
        private string property;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("property")] public string Property { get => property; set => property = value; }

        public override string ToString()
        {
            return Property;
        }
    }
}
