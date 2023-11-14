namespace DataBaseKursRabota.Views.ViewModels.Tables
{
    public class PlantViewModel
    {
        private int id;
        private Image photo;
        private int price;
        private string planting;
        private string death;
        private string catalogue;
        private int plot;
        private string conditions;

        public int Id { get => id; set => id = value; }
        public Image Photo { get => photo; set => photo = value; }
        public int Price { get => price; set => price = value; }
        public string Planting { get => planting; set => planting = value; }
        public string Death { get => death; set => death = value; }
        public string Catalogue { get => catalogue; set => catalogue = value; }
        public int Plot { get => plot; set => plot = value; }
        public string Conditions { get => conditions; set => conditions = value; }
    }
}
