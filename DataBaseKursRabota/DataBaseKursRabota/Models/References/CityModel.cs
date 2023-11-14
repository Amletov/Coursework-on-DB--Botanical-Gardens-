using Newtonsoft.Json;

namespace DataBaseKursRabota.Models
{
    public class CityModel
    {
        private int id;
        private string city;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("city")] public string City { get => city; set => city = value; }

        public override string ToString()
        {
            return City;
        }
    }
}
