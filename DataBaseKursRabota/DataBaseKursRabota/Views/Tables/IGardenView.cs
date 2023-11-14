using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.Tables
{
    public interface IGardenView
    {
        string GardenId { get; set; }
        string Garden { get; set; }
        int Opening { get; set; }
        Int64 Phone { get; set; }
        bool Financing { get; set; }
        string City { get; set; }
        int CityId { get; }
        string Property { get; set; }
        int PropertyId { get; }
        string Employee { get; set; }
        int EmployeeId { get; }

        string SearchValue { get; set; }
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

        void SetGardenListBindingSource(BindingSource generaList);
        void SetCityListComboBox(BindingSource cityList);
        void SetPropertyListComboBox(BindingSource propertyList);
        void SetEmployeeListComboBox(BindingSource employeeList);
        void SetTotal(int total);
        void Show();
    }
}
