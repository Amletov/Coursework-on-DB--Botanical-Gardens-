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
    public class PlantPresenter
    {
        private IPlantView view;
        private IPlantRepository plantRepository;
        private ICatalogueRepository catalogueRepository;
        private BindingSource plantsBindingSourse;
        private BindingSource catalogueBindingSourse;
        private IEnumerable<CatalogueDataModel> cataloguelist;
        private IEnumerable<PlantDataModel> plantList;

        public PlantPresenter(IPlantView view, IPlantRepository plantRepository, ICatalogueRepository catalogueRepository)
        {
            this.plantsBindingSourse = new BindingSource();
            this.catalogueBindingSourse = new BindingSource();
            this.view = view;
            this.plantRepository = plantRepository;
            this.catalogueRepository = catalogueRepository;

            this.view.SearchEvent += SearchPlant;
            this.view.AddNewEvent += AddNewPlant;
            this.view.EditEvent += LoadSelectedPlantToEdit;
            this.view.DeleteEvent += DeleteSelectedPlant;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SavePlant;
            this.view.CancelEvent += CancelAction;
            this.view.LoadPhotoEvent += LoadPhoto;

            this.view.SetPlantListBindingSource(plantsBindingSourse);
            this.view.SetCatalogueListComboBox(catalogueBindingSourse);

            LoadAllCatalogueList();
            LoadAllPlantList(view.Page);

            this.view.Show();

        }

        private void LoadPhoto(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    view.PhotoPath = filePath;

                    try
                    {
                        view.Photo = Image.FromFile(filePath);
                    }
                    catch (Exception ex)
                    {
                        view.Message = "Произшла ошибка: " + ex.Message;
                    }
                }
            };
        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllPlantList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllPlantList(view.Page);
        }
        private void LoadAllCatalogueList()
        {
            cataloguelist = catalogueRepository.GetAll(1, 999);
            catalogueBindingSourse.DataSource = cataloguelist;
        }

        private void LoadAllPlantList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            plantList = plantRepository.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlantDataModel, PlantViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<PlantViewModel> viewModels = mapper.Map<List<PlantViewModel>>(plantList);

            plantsBindingSourse.DataSource = viewModels;
            view.SetTotal(plantRepository.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SavePlant(object? sender, EventArgs e)
        {
            var model = new PlantDataModel();
            model.Id = Convert.ToInt32(view.PlantId);
            model.Photo = view.Photo;
            model.Price = view.Price;
            model.Plot = view.Plot;
            model.Planting = view.Planting;
            model.CatalogueId = view.CatalogueId;
            model.Conditions = view.Conditions;

            try
            {
                if (view.IsEdit)
                {
                    plantRepository.Edit(model);
                    view.Message = "Работник успешно изменен";
                }
                else
                {
                    plantRepository.Add(model);
                    view.Message = "Работник успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllPlantList(view.Page);
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
            view.PlantId = "0";
            view.Price = 1;
            view.Plot = 1;
            view.Photo = null;
            view.Conditions = "Условия по умолчанию отствуют";
        }

        private void DeleteSelectedPlant(object? sender, EventArgs e)
        {
            try
            {
                var plant = (PlantViewModel)plantsBindingSourse.Current;
                plantRepository.Delete(plant.Id);
                view.IsSuccessful = true;
                view.Message = "Работник успешно удален";
                LoadAllPlantList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedPlantToEdit(object? sender, EventArgs e)
        {
            var plant = (PlantViewModel)plantsBindingSourse.Current;
            view.PlantId = plant.Id.ToString();
            view.Photo = plant.Photo;
            view.Price = plant.Price;
            view.Plot = plant.Plot;
            view.Planting = plant.Planting;
            view.Conditions = plant.Conditions;
            view.IsEdit = true;

        }

        private void AddNewPlant(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchPlant(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                plantList = plantRepository.GetByValue(this.view.SearchValue);
            }
            else
            {
                plantList = plantRepository.GetAll(view.Page, 50);
            }
            plantsBindingSourse.DataSource = plantList;
        }
    }
}
