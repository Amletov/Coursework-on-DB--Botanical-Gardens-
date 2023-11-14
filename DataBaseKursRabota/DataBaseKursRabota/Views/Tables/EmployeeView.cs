using DataBaseKursRabota.Models;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class EmployeeView : Form, IEmployeeView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;
        private bool _isLastPage;
        private bool _isGenerating;

        public EmployeeView()
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
        public string EmployeeId { get => idTextBox.Text; set => idTextBox.Text = value.ToString(); }
        public string Surname { get => surnameTextBox.Text; set => surnameTextBox.Text = value.ToString(); }
        public string Name { get => nameTextBox.Text; set => nameTextBox.Text = value.ToString(); }
        public string Patronymic { get => middlenameTextBox.Text; set => middlenameTextBox.Text = value.ToString(); }
        public string Birth { get => birthDateTimePicker.Value.ToString(); set => birthDateTimePicker.Value.ToString(); }
        public string Position { get => positionComboBox.SelectedItem.ToString(); set => positionComboBox.SelectedItem = value; }
        public int PositionId { get => ((PositionModel)positionComboBox.SelectedItem).Id; set => ((PositionModel)positionComboBox.SelectedItem).Id = value; }
        public int Experience { get => (Int32)experienceNumericUpDown.Value; set => experienceNumericUpDown.Value = value; }
        public int Salary { get => (Int32)salaryNumericUpDown.Value; set => salaryNumericUpDown.Value = value; }

        //Остальные
        public string SearchValue { get => searchTextBox.Text; set => searchTextBox.Text = value; }
        public string Message { get => _message; set => _message = value; }
        public bool IsEdit { get => _isEdit; set => _isEdit = value; }
        public bool IsSuccessful { get => _isSuccessful; set => _isSuccessful = value; }
        public bool IsLastPage { get => _isLastPage; set => _isLastPage = value; }
        public bool IsGenerating { get => _isGenerating; set => _isGenerating = value; }
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

        public void SetEmployeeListBindingSource(BindingSource employeeList)
        {
            dataGridView.DataSource = employeeList;
        }

        public void SetPositionListComboBox(BindingSource positionList)
        {
            positionComboBox.DataSource = positionList;
        }


        public void SetTotal(int total)
        {
            Total = total;
        }

        private static EmployeeView instance;
        public static EmployeeView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeeView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
                instance.prevButton.Enabled = false;
                instance.cancelGenButton.Enabled = false;
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
