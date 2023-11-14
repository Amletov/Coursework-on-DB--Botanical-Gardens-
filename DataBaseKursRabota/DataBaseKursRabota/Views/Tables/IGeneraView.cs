﻿namespace DataBaseKursRabota.Views.Tables
{
    public interface IGeneraView
    {
        string GeneraId { get; set; }
        string Genera { get; set; }
        string Family { get; set; }
        int FamilyId { get; }

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

        void SetGeneraListBindingSource(BindingSource generaList);
        void SetFamiyListComboBox(BindingSource familyList);
        void SetTotal(int total);
        void Show();
    }
}
