using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using DataBaseKursRabota.Presenters.Tables;
using DataBaseKursRabota.Repositories;
using DataBaseKursRabota.Repositories.Tables;
using DataBaseKursRabota.Views;
using DataBaseKursRabota.Views.References;
using DataBaseKursRabota.Views.Tables;

namespace DataBaseKursRabota.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            //Справочники
            this.mainView.ShowCityView += ShowCitiesView;
            this.mainView.ShowFamilyView += ShowFamilyView;
            this.mainView.ShowPropertyView += ShowPropertyView;
            this.mainView.ShowPositionView += ShowPositionView;
            this.mainView.ShowCareProductView += ShowCareProductView;
            //Таблицы
            this.mainView.ShowGeneraView += ShowGeneraView;
            this.mainView.ShowCatalogueView += ShowCatalogueView;
            this.mainView.ShowEmployeeView += ShowEmployeeView;
            this.mainView.ShowPlantView += ShowPlantView;
            this.mainView.ShowGardenView += ShowGardenProductView;
            this.mainView.ShowServiceView += ShowServiceView;
            //Запросы
            this.mainView.ShowQueriesView += ShowQueriesView;

            this.mainView.Show();
        }
        //Запросы
        private void ShowQueriesView(object? sender, EventArgs e)
        {
            IQueryView view = QueryView.GetInstace((MainView)mainView);
            IQueryRepository repository = new QueryRepository();
            new QueryPresenter(view, repository);
        }

        //Таблицы
        private void ShowServiceView(object? sender, EventArgs e)
        {
            IServiceView view = ServiceView.GetInstace((MainView)mainView);
            IServiceRepository serviceRepository = new ServiceRepository();
            ICareProductRepository careProductRepository = new CareProductRepository();
            IPlantRepository plantRepository = new PlantRepository();
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            new ServicePresenter(view, serviceRepository, careProductRepository, employeeRepository, plantRepository );
        }

        private void ShowGardenProductView(object? sender, EventArgs e)
        {
            IGardenView view = GardenView.GetInstace((MainView)mainView);
            IGardenRepository gardenRepository = new GardenRepository();
            ICityRepository cityRepository = new CityRepository();
            IPropertyRepository propertyRepository = new PropertyRepository();
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            new GardenPresenter(view, gardenRepository, cityRepository, propertyRepository, employeeRepository);
        }

        private void ShowPlantView(object? sender, EventArgs e)
        {
            IPlantView view = PlantView.GetInstace((MainView)mainView);
            IPlantRepository plantRepository = new PlantRepository();
            ICatalogueRepository catalogueRepository = new CatalogueRepository();
            new PlantPresenter(view, plantRepository, catalogueRepository);
        }

        private void ShowEmployeeView(object? sender, EventArgs e)
        {
            IEmployeeView view = EmployeeView.GetInstace((MainView)mainView);
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            IPositionRepository positionRepository = new PositionRepository();
            new EmployeePresenter(view, employeeRepository, positionRepository);
        }

        private void ShowCatalogueView(object? sender, EventArgs e)
        {
            ICatalogueView view = CatalogueView.GetInstace((MainView)mainView);
            ICatalogueRepository catalogueRepository = new CatalogueRepository();
            IGeneraRepository generaRepository = new GeneraRepository();
            new CataloguePresenter(view, catalogueRepository, generaRepository);
        }

        private void ShowGeneraView(object? sender, EventArgs e)
        {
            IGeneraView view = GeneraView.GetInstace((MainView)mainView);
            IGeneraRepository generaRepository = new GeneraRepository();
            IFamilyRepository familyRepository = new FamilyRepository();
            new GeneraPresenter(view, generaRepository, familyRepository);
        }
        //Справочники
        private void ShowCareProductView(object? sender, EventArgs e)
        {
            ICareProductView view = CareProductView.GetInstace((MainView)mainView);
            ICareProductRepository repository = new CareProductRepository();
            new CareProductPresenter(view, repository);
        }

        private void ShowPositionView(object? sender, EventArgs e)
        {
            IPositionView view = PositionView.GetInstace((MainView)mainView);
            IPositionRepository repository = new PositionRepository();
            new PositionPresenter(view, repository);
        }

        private void ShowPropertyView(object? sender, EventArgs e)
        {
            IPropertyView view = PropertyView.GetInstace((MainView)mainView);
            IPropertyRepository repository = new PropertyRepository();
            new PropertyPresenter(view, repository);
        }

        private void ShowFamilyView(object? sender, EventArgs e)
        {
            IFamilyView view = FamilyView.GetInstace((MainView)mainView);
            IFamilyRepository repository = new FamilyRepository();
            new FamilyPresenter(view, repository);
        }

        private void ShowCitiesView(object sender, EventArgs e)
        {
            ICityView view = CityView.GetInstace((MainView)mainView);
            ICityRepository repository = new CityRepository();
            new CityPresenter(view, repository);
        }
    }
}
