using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class ServiceView : Form, IServiceView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;
        private bool _isLastPage;
        private bool _isGenerating;

        public ServiceView()
        {
            InitializeComponent();
            RaiseViewEvents();
            tabControl.TabPages.Remove(detailTabPage);
        }
        private void RaiseViewEvents()
        {
            //Поиск
            searchButton.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            searchTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Добавление
            addButton.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(listTabPage);
                tabControl.TabPages.Add(detailTabPage);
                detailTabPage.Text = "Добавить работника";
            };
            //Редактирование
            editButton.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(listTabPage);
                tabControl.TabPages.Add(detailTabPage);
                detailTabPage.Text = "Изменить работника";
            };
            //Сохранить
            saveButton.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (_isSuccessful)
                {
                    tabControl.TabPages.Remove(detailTabPage);
                    tabControl.TabPages.Add(listTabPage);
                }
                MessageBox.Show(Message);
            };
            //Отмена
            cancelButton.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(detailTabPage);
                tabControl.TabPages.Add(listTabPage);
            };
            //Удаление
            deleteButton.Click += delegate
            {
                var result = MessageBox.Show("Вы уверены в том, что хотите удалить выбранную модель?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            //Следующая страница
            nextButton.Click += delegate
            {
                NextPageEvent?.Invoke(this, EventArgs.Empty);
                nextButton.Enabled = IsLastPage;
                prevButton.Enabled = true;
            };
            //Педыдущая страница
            prevButton.Click += delegate
            {
                PrevPageEvent?.Invoke(this, EventArgs.Empty);
                nextButton.Enabled = true;
                if (Page == 1) prevButton.Enabled = false;
            };
            //Сгенерировать
            generateButton.Click += delegate
            {
                StartGenerateEvent?.Invoke(this, EventArgs.Empty);
                generateButton.Enabled = false;
                cancelGenButton.Enabled = true;
            };
            //Отмена генерации
            cancelGenButton.Click += delegate
            {
                CancelGenerateEvent?.Invoke(this, EventArgs.Empty);
                generateButton.Enabled = true;
                cancelGenButton.Enabled = false;
            };
        }

        //Для передачи в detailTab
        public string ServiceId { get => idTextBox.Text; set => idTextBox.Text = value.ToString(); }
        public string Employee { get => employeeComboBox.Text; set => employeeComboBox.Text = value; }
        public int EmployeeId { get => ((EmployeeDataModel)employeeComboBox.SelectedItem).Id; set => ((EmployeeDataModel)employeeComboBox.SelectedItem).Id = value; }
        public string CareProduct { get => employeeComboBox.Text; set => employeeComboBox.Text = value; }
        public int CareProductId { get => ((CareProductModel)careProductComboBox.SelectedItem).Id; set => ((CareProductModel)careProductComboBox.SelectedItem).Id = value; }
        public string Fertilized { get => fertilizedDateTimePicker.Value.ToString(); set => fertilizedDateTimePicker.Value.ToString(); }
        public string Plant { get => plantComboBox.Text; set => plantComboBox.Text = value; }
        public int PlantId { get => ((PlantDataModel)plantComboBox.SelectedItem).Id; set => ((PlantDataModel)plantComboBox.SelectedItem).Id = value; }
        public int Amount { get => (Int32)amountNumericUpDown.Value; set => amountNumericUpDown.Value = value; }

        //Остальные
        public string SearchValue { get => searchTextBox.Text; set => searchTextBox.Text = value; }
        public string Message { get => _message; set => _message = value; }
        public bool IsGenerating { get => _isGenerating; set => _isGenerating = value; }
        public bool IsEdit { get => _isEdit; set => _isEdit = value; }
        public bool IsSuccessful { get => _isSuccessful; set => _isSuccessful = value; }
        public bool IsLastPage { get => _isLastPage; set => _isLastPage = value; }
        public int Page { get => Convert.ToInt32(pageLabel.Text); set => pageLabel.Text = value.ToString(); }
        public int Total { get => Convert.ToInt32(totalLabel.Text); set => totalLabel.Text = value.ToString(); }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler PrevPageEvent;
        public event EventHandler NextPageEvent;
        public event EventHandler StartGenerateEvent;
        public event EventHandler CancelGenerateEvent;

        public void SetServiceListBindingSource(BindingSource serviceList)
        {
            dataGridView.DataSource = serviceList;
        }

        public void SetEmployeeListComboBox(BindingSource employeeList)
        {
            employeeComboBox.DataSource = employeeList;
        }
        public void SetCareProductListComboBox(BindingSource careProductList)
        {
            careProductComboBox.DataSource = careProductList;
        }
        public void SetPlantListComboBox(BindingSource plantList)
        {
            plantComboBox.DataSource = plantList;
        }


        public void SetTotal(int total)
        {
            Total = total;
        }

        private static ServiceView instance;
        

        public static ServiceView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ServiceView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
                instance.prevButton.Enabled = false;
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
