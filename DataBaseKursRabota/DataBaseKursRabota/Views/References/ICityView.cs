using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views
{
    public interface ICityView
    {
        string CityId { get; set; }
        string City { get; set; }

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

        void SetCityListBindingSource(BindingSource dataList);
        void SetTotal(int total);
        void Show();
    }
}
