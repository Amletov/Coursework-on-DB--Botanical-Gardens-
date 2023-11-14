using System.Xml.Linq;

namespace DataBaseKursRabota.Views.Tables
{
    public interface IEmployeeView
    {
        public string EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Birth { get; set; }
        public string Position { get; set; }
        public int PositionId { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }

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

        void SetEmployeeListBindingSource(BindingSource employeeList);
        void SetPositionListComboBox(BindingSource positionList);
        void SetTotal(int total);
        void Show();
    }
}
