using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models
{
    public class PositionModel
    {
        private int id;
        private string position;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("position")] public string Position { get => position; set => position = value; }

        public override string ToString()
        {
            return Position;
        }
    }
}
