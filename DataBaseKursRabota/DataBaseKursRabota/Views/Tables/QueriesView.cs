using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class QueryView : Form, IQueryView
    {
        private string _message;
        private bool _isExportable;
        private bool _isChartable;

        public QueryView()
        {
            InitializeComponent();
            RaiseViewEvents();
        }

        private void RaiseViewEvents()
        {
            queriesComboBox.SelectedIndexChanged += delegate
            {
                QueryChangedEvent?.Invoke(this, EventArgs.Empty);
            };
            excelButton.Click += delegate
            {
                SaveExcelEvent?.Invoke(this, EventArgs.Empty);
            };
            chartButton.Click += delegate
            {
                ShowPlotChartEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string Message { get => _message; set => _message = value; }
        public int QueryNumber { get => queriesComboBox.SelectedIndex; set => queriesComboBox.SelectedIndex = value; }
        public bool IsExportable 
        { 
            get => _isExportable;
            set
            {
                excelButton.Enabled = value;
                _isExportable = value;
            }
        }
        public bool IsChartable 
        {
            get => _isChartable;
            set
            {
                chartButton.Enabled = value;
                _isExportable = value;
            }
        }

        public event EventHandler SaveExcelEvent;
        public event EventHandler ShowPlotChartEvent;
        public event EventHandler QueryChangedEvent;

        public void SetDataListBindingSource(BindingSource dataList)
        {
            if (dataList.DataSource != null)
            {
                foreach (var key in ((IEnumerable<Dictionary<string, object>>)dataList.DataSource).ElementAt(0).Keys)
                {
                    dataGridView.Columns.Add(key, key);
                }
            }
            dataGridView.DataSource = dataList;
        }

        private static QueryView instance;
        public static QueryView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new QueryView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
