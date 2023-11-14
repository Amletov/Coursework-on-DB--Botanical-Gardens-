using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.Tables
{
    public interface IQueryView
    {
        bool IsExportable { get; set; }
        bool IsChartable { get; set; }
        int QueryNumber { get; set; }
        string Message { get; set; }

        event EventHandler QueryChangedEvent;
        event EventHandler SaveExcelEvent;
        event EventHandler ShowPlotChartEvent;

        void SetDataListBindingSource(BindingSource dataList);
        void Show();
    }
}
