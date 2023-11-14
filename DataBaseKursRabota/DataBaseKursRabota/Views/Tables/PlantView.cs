using DataBaseKursRabota.Models.Tables;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class PlantView : Form, IPlantView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;
        private bool _isLastPage;

        public PlantView()
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
                detailTabPage.Text = "Добавить растение";
            };
            //Редактирование
            editButton.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(listTabPage);
                tabControl.TabPages.Add(detailTabPage);
                detailTabPage.Text = "Изменить растение";
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
            //Загрузить фото
            photoButton.Click += delegate
            {
                LoadPhotoEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        //Для передачи в detailTab
        public string PlantId { get => idTextBox.Text; set => idTextBox.Text = value; }
        public string Conditions { get => conditionsTextBox1.Text; set => conditionsTextBox1.Text = value; }
        public string Catalogue { get => catalogueComboBox.SelectedItem.ToString(); set => catalogueComboBox.SelectedItem = value; }
        public string Planting { get => plantingDateTimePicker.Value.ToString(); set => plantingDateTimePicker.Value.ToString(); }
        public int CatalogueId { get => ((CatalogueDataModel)catalogueComboBox.SelectedItem).Id; set => ((CatalogueDataModel)catalogueComboBox.SelectedItem).Id = value; }
        public int Price { get => (Int32)priceNumericUpDown.Value; set => priceNumericUpDown.Value = value; }
        public int Plot { get => (Int32)plotNumericUpDown.Value; set => plotNumericUpDown.Value = value; }
        public Image Photo { get => photoPictureBox.Image; set => photoPictureBox.Image = value; }

        //Остальноe
        public string PhotoPath { get => photoTextBox.Text; set => photoTextBox.Text = value; }
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
        public event EventHandler LoadPhotoEvent;

        public void SetPlantListBindingSource(BindingSource plantList)
        {
            dataGridView.DataSource = plantList;
        }

        public void SetCatalogueListComboBox(BindingSource catalogueList)
        {
            catalogueComboBox.DataSource = catalogueList;
        }

        public void SetTotal(int total)
        {
            Total = total;
        }

        private static PlantView instance;
        public static PlantView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PlantView();
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
