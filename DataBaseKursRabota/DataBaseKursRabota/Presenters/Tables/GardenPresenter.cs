using AutoMapper;
using DataBaseKursRabota.Models.Tables;
using DataBaseKursRabota.Models;
using DataBaseKursRabota.Views.Tables;
using DataBaseKursRabota.Views.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Presenters.Tables
{
    public class GardenPresenter
    {
        private IGardenView view;
        private IGardenRepository gardenRep;
        private ICityRepository cityRep;
        private IPropertyRepository propertyRep;
        private IEmployeeRepository employeeRep;
        private BindingSource gardensBindingSourse;
        private BindingSource cityBindingSourse;
        private BindingSource propertyBindingSourse;
        private BindingSource employeeBindingSourse;
        private IEnumerable<GardenDataModel> gardenList;
        private IEnumerable<CityModel> cityList;
        private IEnumerable<PropertyModel> propertyList;
        private IEnumerable<EmployeeDataModel> employeeList;

        public GardenPresenter(IGardenView view, IGardenRepository gardenRep, ICityRepository cityRep, IPropertyRepository propertyRep, IEmployeeRepository employeeRep)
        {
            this.gardensBindingSourse = new BindingSource();
            this.cityBindingSourse = new BindingSource();
            this.propertyBindingSourse = new BindingSource();
            this.employeeBindingSourse = new BindingSource();

            this.view = view;
            this.gardenRep = gardenRep;
            this.cityRep = cityRep;
            this.propertyRep = propertyRep;
            this.employeeRep = employeeRep;

            this.view.SearchEvent += SearchGarden;
            this.view.AddNewEvent += AddNewGarden;
            this.view.EditEvent += LoadSelectedGardenToEdit;
            this.view.DeleteEvent += DeleteSelectedGarden;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveGarden;
            this.view.CancelEvent += CancelAction;

            this.view.SetGardenListBindingSource(gardensBindingSourse);
            this.view.SetCityListComboBox(cityBindingSourse);
            this.view.SetPropertyListComboBox(propertyBindingSourse);
            this.view.SetEmployeeListComboBox(employeeBindingSourse);

            LoadAllCityList();
            LoadAllPropertyList();
            LoadAllEmployeeList();
            LoadAllGardenList(view.Page);

            this.view.Show();
        }


        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllGardenList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllGardenList(view.Page);
        }
        private void LoadAllCityList()
        {
            cityList = cityRep.GetAll(1, 999999);
            cityBindingSourse.DataSource = cityList;
        }
        private void LoadAllPropertyList()
        {
            propertyList = propertyRep.GetAll(1, 999999);
            propertyBindingSourse.DataSource = propertyList;
        }
        private void LoadAllEmployeeList()
        {
            employeeList = employeeRep.GetAll(1, 999999);
            employeeBindingSourse.DataSource = employeeList;
        }

        private void LoadAllGardenList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            gardenList = gardenRep.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<GardenDataModel, GardenViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<GardenViewModel> viewModels = mapper.Map<List<GardenViewModel>>(gardenList);

            gardensBindingSourse.DataSource = viewModels;
            view.SetTotal(gardenRep.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveGarden(object? sender, EventArgs e)
        {
            var model = new GardenDataModel();
            model.Id = Convert.ToInt32(view.GardenId);
            model.Financing = view.Financing;
            model.Opening = view.Opening;
            model.Phone = view.Phone;
            model.Garden = view.Garden;
            model.CityId = Convert.ToInt32(view.CityId);
            model.PropertyId = Convert.ToInt32(view.PropertyId);
            model.EmployeeId = Convert.ToInt32(view.EmployeeId);

            try
            {
                if (view.IsEdit)
                {
                    gardenRep.Edit(model);
                    view.Message = "Сад успешно изменен";
                }
                else
                {
                    gardenRep.Add(model);
                    view.Message = "Сад успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllGardenList(view.Page);
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
            view.GardenId = "0";
            view.Garden = "";
            view.Phone = 70000000000;
            view.Financing = false;

        }

        private void DeleteSelectedGarden(object? sender, EventArgs e)
        {
            try
            {
                var garden = (GardenViewModel)gardensBindingSourse.Current;
                gardenRep.Delete(garden.Id);
                view.IsSuccessful = true;
                view.Message = "Сад успешно удален";
                LoadAllGardenList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedGardenToEdit(object? sender, EventArgs e)
        {
            var garden = (GardenViewModel)gardensBindingSourse.Current;
            view.GardenId = garden.Id.ToString();
            view.Garden = garden.Garden;
            view.Phone = garden.Phone;
            view.Financing = garden.Financing;
            view.Opening = garden.Opening;
            view.City = garden.City;
            view.Property = garden.Property;
            view.Employee = garden.Employee;
            view.IsEdit = true;

        }

        private void AddNewGarden(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchGarden(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                gardenList = gardenRep.GetByValue(this.view.SearchValue);
            }
            else
            {
                gardenList = gardenRep.GetAll(view.Page, 50);
            }
            gardensBindingSourse.DataSource = gardenList;
        }
    }
}
