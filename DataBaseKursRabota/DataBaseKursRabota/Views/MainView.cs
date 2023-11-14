namespace DataBaseKursRabota.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            cityButton.Click += delegate { ShowCityView?.Invoke(this, EventArgs.Empty); };
            positionButton.Click += delegate { ShowPositionView?.Invoke(this, EventArgs.Empty); };
            propertyButton.Click += delegate { ShowPropertyView?.Invoke(this, EventArgs.Empty); };
            careProductButton.Click += delegate { ShowCareProductView?.Invoke(this, EventArgs.Empty); };
            familyButton.Click += delegate { ShowFamilyView?.Invoke(this, EventArgs.Empty); };
            generaButton.Click += delegate { ShowGeneraView?.Invoke(this, EventArgs.Empty); };
            plantButton.Click += delegate { ShowPlantView?.Invoke(this, EventArgs.Empty); };
            catalogueButton.Click += delegate { ShowCatalogueView?.Invoke(this, EventArgs.Empty); };
            employeeButton.Click += delegate { ShowEmployeeView?.Invoke(this, EventArgs.Empty); };
            gardenButton.Click += delegate { ShowGardenView?.Invoke(this, EventArgs.Empty); };
            serviceButton.Click += delegate { ShowServiceView?.Invoke(this, EventArgs.Empty); };
            queriesButton.Click += delegate { ShowQueriesView?.Invoke(this, EventArgs.Empty); };
        }

        //Справочники
        public event EventHandler ShowCityView;
        public event EventHandler ShowPositionView;
        public event EventHandler ShowPropertyView;
        public event EventHandler ShowCareProductView;
        public event EventHandler ShowFamilyView;
        //Таблицы
        public event EventHandler ShowGeneraView;
        public event EventHandler ShowPlantView;
        public event EventHandler ShowCatalogueView;
        public event EventHandler ShowEmployeeView;
        public event EventHandler ShowGardenView;
        public event EventHandler ShowServiceView;
        //Запросы
        public event EventHandler ShowQueriesView;
    }
}
