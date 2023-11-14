using DataBaseKursRabota.Models.Tables;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class CatalogueView : Form, ICatalogueView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;
        private bool _isLastPage;
        private bool _annual;

        public CatalogueView()
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
                detailTabPage.Text = "Добавить каталог";
            };
            //Редактирование
            editButton.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(listTabPage);
                tabControl.TabPages.Add(detailTabPage);
                detailTabPage.Text = "Изменить каталог";
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
        public string CatalogueId { get => idTextBox.Text; set => idTextBox.Text = value.ToString(); }
        public string FullName { get => fullNameTextBox.Text; set => fullNameTextBox.Text = value; }
        public string Genera { get => generaComboBox.SelectedItem.ToString(); set => generaComboBox.SelectedItem = value; }
        public int GeneraId { get => ((GeneraDataModel)generaComboBox.SelectedItem).Id; set => ((GeneraDataModel)generaComboBox.SelectedItem).Id = value; }
        public int LifeSpan { get => (Int32)lifeSpanNumericUpDown.Value; set => lifeSpanNumericUpDown.Value = value; }
        public bool Annual
        {
            get
            {
                if (LifeSpan == 1) return true;
                else return false;
            }
            set
            {
                _annual = value;
            }
        }

        //Остальные
        public string SearchValue { get => searchTextBox.Text; set => searchTextBox.Text = value; }
        public string Message { get => _message; set => _message = value; }
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

        public void SetCatalogueListBindingSource(BindingSource catalogueList)
        {
            dataGridView.DataSource = catalogueList;
        }

        public void SetGeneraListComboBox(BindingSource generaList)
        {
            generaComboBox.DataSource = generaList;
        }


        public void SetTotal(int total)
        {
            Total = total;
        }

        private static CatalogueView instance;
        public static CatalogueView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CatalogueView();
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

        public void SetGeneraListBindingSource(BindingSource generaList)
        {
            throw new NotImplementedException();
        }
    }
}

