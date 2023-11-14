using Newtonsoft.Json;

namespace DataBaseKursRabota.Models.Tables
{
    public class CatalogueDataModel
    {
        private int id;
        private string fullname;
        private int lifeSpan;
        private string genera;
        private int generaId;
        private bool annual;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        [JsonProperty("full_name")] public string Fullname { get => fullname; set => fullname = value; }
        [JsonProperty("life_span")] public int LifeSpan { get => lifeSpan; set => lifeSpan = value; }
        [JsonProperty("genera")] public string Genera { get => genera; set => genera = value; }
        [JsonProperty("genera_id")] public int GeneraId { get => generaId; set => generaId = value; }
        [JsonProperty("annual")] public bool Annual { get => annual; set => annual = value; }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
