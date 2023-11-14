namespace DataBaseKursRabota.Views.ViewModels.Tables
{
    public class CatalogueViewModel
    {
        private int id;
        private string fullname;
        private int life_span;
        private string genera;
        private bool annual;

        public int Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public int LifeSpan { get => life_span; set => life_span = value; }
        public string Genera { get => genera; set => genera = value; }
        public bool Annual { get => annual; set => annual = value; }
    }
}
