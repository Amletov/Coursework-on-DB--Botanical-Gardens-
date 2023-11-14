using DataBaseKursRabota.Models;
using DataBaseKursRabota.Repositories;
using DataBaseKursRabota.Views.Tables;
using OfficeOpenXml;
using System.Data;

namespace DataBaseKursRabota.Presenters
{
    public class QueryPresenter
    {
        private IQueryView view;
        private IQueryRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<Dictionary<string, object>> dataList;

        public QueryPresenter(IQueryView view, IQueryRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.QueryChangedEvent += ChangeQuery;
            this.view.SaveExcelEvent += SaveExcel;
            this.view.ShowPlotChartEvent += ShowPlotChart;

            this.view.SetDataListBindingSource(dataBindingSourse);

            this.view.Show();
        }

        private void ChangeQuery(object? sender, EventArgs e)
        {
            if (view.QueryNumber != 18)
            {
                view.IsChartable = false;

            }
            else
            {
                view.IsChartable = true;
            }
            if (view.QueryNumber == 0)
            {
                view.IsExportable = false;
                return;
            }
            view.IsExportable = true;
            dataList = repository.Query(view.QueryNumber);
            DataTable dt = new DataTable();

            foreach (var dict in dataList)
            {
                DataRow row = dt.NewRow();
                foreach (var entry in dict)
                {
                    if (!dt.Columns.Contains(entry.Key))
                    {
                        dt.Columns.Add(entry.Key, entry.Value.GetType());
                    }
                    row[entry.Key] = entry.Value;
                }
                dt.Rows.Add(row);
            }

            dataBindingSourse.DataSource = dt;
        }

        private void ShowPlotChart(object? sender, EventArgs e)
        {
            var obj = new ObjToDiagram();
            obj.Title = view.QueryNumber.ToString();
            var dictionaries = new Dictionary<string, double>();
            if(view.QueryNumber == 18) 
            {
                view.IsChartable = true;
                foreach (var dictionary in dataList)
                {
                    dictionaries.Add((string)dictionary["Название"], (double)dictionary["Средняя цена"]);
                }
            }
            obj.Values = dictionaries;
            var plotView = new PlotView(obj);
            plotView.Show();
        }

        private void SaveExcel(object? sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = view.QueryNumber.ToString();
            dialog.Filter = "Excel files|*.xlsx";
            var res = dialog.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;

            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                DataTable dataTable = ((DataTable)dataBindingSourse.DataSource).Copy();

                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                using (Stream stream = new FileStream(dialog.FileName, FileMode.Create))
                {
                    package.SaveAs(stream);
                }
            }
            view.Message = "Экспорт выполнен";
        }

    }
}
