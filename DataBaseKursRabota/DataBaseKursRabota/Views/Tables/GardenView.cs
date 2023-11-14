using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class GardenView : Form, IGardenView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;
        private bool _isLastPage;

        public GardenView()
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
                detailTabPage.Text = "Добавить вид";
            };
            //Редактирование
            editButton.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(listTabPage);
                tabControl.TabPages.Add(detailTabPage);
                detailTabPage.Text = "Изменить вид";
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
        }

        //Для передачи в detailTab
        public string GardenId { get => idTextBox.Text; set => idTextBox.Text = value; }
        public string Garden { get => gardenTextBox.Text; set => gardenTextBox.Text = value; }
        public int Opening { get => openingDateTimePicker.Value.Year; set => openingDateTimePicker.Value = new DateTime(value, 1, 1); }
        public Int64 Phone { get => (Int64)phoneNumericUpDown.Value; set => phoneNumericUpDown.Value = value; }
        public bool Financing { get => financingCheckBox.Checked; set => financingCheckBox.Checked = value; }
        public string City { get => cityComboBox.SelectedItem.ToString(); set => cityComboBox.SelectedItem = value; }
        public int CityId { get => ((CityModel)cityComboBox.SelectedItem).Id; set => ((CityModel)cityComboBox.SelectedItem).Id = value; }
        public string Property { get => propertyComboBox.SelectedItem.ToString(); set => propertyComboBox.SelectedItem = value; }
        public int PropertyId { get => ((PropertyModel)propertyComboBox.SelectedItem).Id; set => ((PropertyModel)propertyComboBox.SelectedItem).Id = value; }
        public string Employee { get => employeeComboBox.SelectedItem.ToString(); set => employeeComboBox.SelectedItem = value; }
        public int EmployeeId { get => ((EmployeeDataModel)employeeComboBox.SelectedItem).Id; set => ((EmployeeDataModel)employeeComboBox.SelectedItem).Id = value; }

        //Остальноe
        public int Page { get => Convert.ToInt32(pageLabel.Text); set => pageLabel.Text = value.ToString(); }
        public string SearchValue { get => searchTextBox.Text; set => searchTextBox.Text = value; }
        public bool IsEdit { get => _isEdit; set => _isEdit = value; }
        public bool IsSuccessful { get => _isSuccessful; set => _isSuccessful = value; }
        public bool IsLastPage { get => _isLastPage; set => _isLastPage = value; }
        public int Total { get => Convert.ToInt32(totalLabel.Text); set => totalLabel.Text = value.ToString(); }
        public string Message { get => _message; set => _message = value; }


        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler PrevPageEvent;
        public event EventHandler NextPageEvent;

        public void SetGardenListBindingSource(BindingSource gardenList)
        {
            dataGridView.DataSource = gardenList;
        }

        public void SetCityListComboBox(BindingSource cityList)
        {
            cityComboBox.DataSource = cityList;
        }
        public void SetEmployeeListComboBox(BindingSource employeeList)
        {
            employeeComboBox.DataSource = employeeList;
        }
        public void SetPropertyListComboBox(BindingSource propertyList)
        {
            propertyComboBox.DataSource = propertyList;
        }


        public void SetTotal(int total)
        {
            Total = total;
        }

        private static GardenView instance;
        public static GardenView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new GardenView();
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
