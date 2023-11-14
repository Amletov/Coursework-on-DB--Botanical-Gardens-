using AutoMapper;
using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using DataBaseKursRabota.Views.Tables;
using DataBaseKursRabota.Views.ViewModels.Tables;

namespace DataBaseKursRabota.Presenters.Tables
{
    public class ServicePresenter
    {
        private IServiceView view;
        private IServiceRepository serviceRep;
        private ICareProductRepository careProductRep;
        private IEmployeeRepository employeeRep;
        private IPlantRepository plantRep;
        private BindingSource servicesBindingSourse;
        private BindingSource careProductBindingSourse;
        private BindingSource employeeBindingSourse;
        private BindingSource plantBindingSourse;
        private IEnumerable<ServiceDataModel> serviceList;
        private IEnumerable<CareProductModel> careProductList;
        private IEnumerable<EmployeeDataModel> employeeList;
        private IEnumerable<PlantDataModel> plantList;

        public ServicePresenter(IServiceView view, IServiceRepository serviceRep, ICareProductRepository careProductRep, IEmployeeRepository employeeRep, IPlantRepository plantRep)
        {
            this.servicesBindingSourse = new BindingSource();
            this.careProductBindingSourse = new BindingSource();
            this.employeeBindingSourse = new BindingSource();
            this.plantBindingSourse = new BindingSource();

            this.view = view;
            this.serviceRep = serviceRep;
            this.careProductRep = careProductRep;
            this.employeeRep = employeeRep;
            this.plantRep = plantRep;

            this.view.SearchEvent += SearchService;
            this.view.AddNewEvent += AddNewService;
            this.view.EditEvent += LoadSelectedServiceToEdit;
            this.view.DeleteEvent += DeleteSelectedService;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveService;
            this.view.CancelEvent += CancelAction;
            this.view.StartGenerateEvent += GenerateRows;
            this.view.CancelGenerateEvent += CancelGenerateRows;

            this.view.SetServiceListBindingSource(servicesBindingSourse);
            this.view.SetCareProductListComboBox(careProductBindingSourse);
            this.view.SetEmployeeListComboBox(employeeBindingSourse);
            this.view.SetPlantListComboBox(plantBindingSourse);

            LoadAllEmployeeList();
            LoadAllCareProductList();
            LoadAllPlantList();
            LoadAllServiceList(view.Page);

            this.view.Show();

        }

        private void CancelGenerateRows(object? sender, EventArgs e)
        {
            view.IsGenerating = false;
            view.Message = "Записи сгенерированы.";
            LoadAllServiceList(view.Page);
        }

        private async void GenerateRows(object? sender, EventArgs e)
        {
            view.IsGenerating = true;
            for (int i = 0; i < 10000; i++)
            {
                if (!view.IsGenerating) break;

                ServiceDataModel service = serviceRep.Generate(careProductList, employeeList, plantList);
                await serviceRep.AddServiceAsync(service);

                if (i % 10 == 0) view.SetTotal(serviceRep.GetTotal());
            }
            view.Message = "Записи сгенерированы.";
            LoadAllServiceList(view.Page);
        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllServiceList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllServiceList(view.Page);
        }
        private void LoadAllEmployeeList()
        {
            employeeList = employeeRep.GetAll(1, 999999);
            employeeBindingSourse.DataSource = employeeList;
        }
        private void LoadAllCareProductList()
        {
            careProductList = careProductRep.GetAll(1, 999999);
            careProductBindingSourse.DataSource = careProductList;
        }
        private void LoadAllPlantList()
        {
            plantList = plantRep.GetAll(1, 99999);
            plantBindingSourse.DataSource = plantList;
        }

        private void LoadAllServiceList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            serviceList = serviceRep.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceDataModel, ServiceViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<ServiceViewModel> viewModels = mapper.Map<List<ServiceViewModel>>(serviceList);

            servicesBindingSourse.DataSource = viewModels;
            view.SetTotal(serviceRep.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveService(object? sender, EventArgs e)
        {
            var model = new ServiceDataModel();
            model.Id = Convert.ToInt32(view.ServiceId);
            model.CareProductId = view.CareProductId;
            model.PlantId = view.PlantId;
            model.EmployeeId = view.EmployeeId;
            model.Amount = view.Amount;
            model.Fertilized = view.Fertilized;

            try
            {
                if (view.IsEdit)
                {
                    serviceRep.Edit(model);
                    view.Message = "Обслуживание успешно изменен";
                }
                else
                {
                    serviceRep.Add(model);
                    view.Message = "Обслуживание успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllServiceList(view.Page);
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }

        }

        private void CleanViewFields()
        {
            view.ServiceId = "0";
            view.Amount = 1;
        }

        private void DeleteSelectedService(object? sender, EventArgs e)
        {
            try
            {
                var service = (ServiceViewModel)servicesBindingSourse.Current;
                serviceRep.Delete(service.Id);
                view.IsSuccessful = true;
                view.Message = "Обслуживание успешно удалено";
                LoadAllServiceList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedServiceToEdit(object? sender, EventArgs e)
        {
            var service = (ServiceViewModel)servicesBindingSourse.Current;
            view.ServiceId = service.Id.ToString();
            view.CareProduct = service.CareProduct;
            view.Plant = service.Plant;
            view.Employee = service.Employee;
            view.Amount = service.Amount;
            view.Fertilized = service.Fertilized;
            view.IsEdit = true;

        }

        private void AddNewService(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchService(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                serviceList = serviceRep.GetByValue(this.view.SearchValue);
            }
            else
            {
                serviceList = serviceRep.GetAll(view.Page, 50);
            }
            servicesBindingSourse.DataSource = serviceList;
        }
    }
}
