using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.Tables
{
    public interface IPlantView
    {
        string PlantId { get; set; }
        string Conditions { get; set; }
        string Catalogue { get; set; }
        string Planting { get; set; }
        int CatalogueId { get; set; }
        int Price { get; set; }
        int Plot { get; set; }
        Image Photo { get; set; }

        string SearchValue { get; set; }
        string PhotoPath { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        bool IsLastPage { get; set; }
        string Message { get; set; }
        int Page { get; set; }
        int Total { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler PrevPageEvent;
        event EventHandler NextPageEvent;
        event EventHandler LoadPhotoEvent;

        void SetPlantListBindingSource(BindingSource plantList);
        void SetCatalogueListComboBox(BindingSource catalogueList);
        void SetTotal(int total);
        void Show();
    }
}
