using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.Tables
{
    public interface IServiceView
    {
        public string ServiceId { get; set; }
        public string Employee { get; set; }
        public int EmployeeId { get; set; }
        public string CareProduct { get; set; }
        public int CareProductId { get; set; }
        public string Fertilized { get; set; }
        public int Amount { get; set; }
        public string Plant { get; set; }
        public int PlantId { get; set; }

        string SearchValue { get; set; }
        bool IsGenerating { get; set; }
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
        event EventHandler StartGenerateEvent;
        event EventHandler CancelGenerateEvent;

        void SetServiceListBindingSource(BindingSource serviceList);
        void SetEmployeeListComboBox(BindingSource employeeList);
        void SetCareProductListComboBox(BindingSource careProductList);
        void SetPlantListComboBox(BindingSource plantList);
        void SetTotal(int total);
        void Show();
    }
}
