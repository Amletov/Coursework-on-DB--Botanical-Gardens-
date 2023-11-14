using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Models.Tables
{
    public class PlantDataModel
    {
        private int id;
        private string photo;
        private int price;
        private string planting;
        private string death;
        private string catalogue;
        private int catalogueId;
        private int plot;
        private string conditions;

        [JsonProperty("id")] public int Id { get => id; set => id = value; }
        public Image Photo 
        {
            get
            {
                if (IsBase64Image(Image))
                {
                    byte[] bytes = Convert.FromBase64String(Image);

                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = System.Drawing.Image.FromStream(ms);
                    }

                    return image;
                }
                else
                {
                    // Обработка случая, когда Photo не является Base64-изображением.
                    return null;
                }
            }
            set
            {
                byte[] bytes = null;

                if (value != null)
                {
                    ImageConverter converter = new ImageConverter();
                    bytes = converter.ConvertTo(value, typeof(byte[])) as byte[];

                }

                Image = "\\x" + BitConverter.ToString(bytes).Replace("-", "");
            }
        }
        [JsonProperty("photo")] public string Image { get => photo; set => photo = value; }
        [JsonProperty("price")] public int Price { get => price; set => price = value; }
        [JsonProperty("planting")] public string Planting { get => planting; set => planting = value; }
        [JsonProperty("death")] public string Death { get => death; set => death = value; }
        [JsonProperty("catalogue")] public string Catalogue { get => catalogue; set => catalogue = value; }
        [JsonProperty("catalogue_id")] public int CatalogueId { get => catalogueId; set => catalogueId = value; }
        [JsonProperty("plot")] public int Plot { get => plot; set => plot = value; }
        [JsonProperty("conditions")] public string Conditions { get => conditions; set => conditions = value; }

        public override string ToString()
        {
            return Price.ToString() + "/" + Catalogue + "/" + Plot.ToString();
        }
        public bool IsBase64Image(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    System.Drawing.Image.FromStream(ms);
                    return true; // Если конвертация прошла успешно, то это Base64-изображение.
                }
            }
            catch (Exception)
            {
                return false; // Если возникла ошибка при конвертации, то это не Base64-изображение.
            }
        }
    }
}
