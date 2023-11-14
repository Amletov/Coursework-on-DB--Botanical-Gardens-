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
    public class CataloguePresenter
    {
        private ICatalogueView view;
        private ICatalogueRepository catalogueRepository;
        private IGeneraRepository generaRepository;
        private BindingSource cataloguesBindingSourse;
        private BindingSource generaBindingSourse;
        private IEnumerable<GeneraDataModel> generalist;
        private IEnumerable<CatalogueDataModel> catalogueList;

        public CataloguePresenter(ICatalogueView view, ICatalogueRepository catalogueRepository, IGeneraRepository generaRepository)
        {
            this.cataloguesBindingSourse = new BindingSource();
            this.generaBindingSourse = new BindingSource();
            this.view = view;
            this.catalogueRepository = catalogueRepository;
            this.generaRepository = generaRepository;

            this.view.SearchEvent += SearchCatalogue;
            this.view.AddNewEvent += AddNewCatalogue;
            this.view.EditEvent += LoadSelectedCatalogueToEdit;
            this.view.DeleteEvent += DeleteSelectedCatalogue;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveCatalogue;
            this.view.CancelEvent += CancelAction;

            this.view.SetCatalogueListBindingSource(cataloguesBindingSourse);
            this.view.SetGeneraListComboBox(generaBindingSourse);

            LoadAllGeneraList();
            LoadAllCatalogueList(view.Page);

            this.view.Show();

        }


        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllCatalogueList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllCatalogueList(view.Page);
        }
        private void LoadAllGeneraList()
        {
            generalist = generaRepository.GetAll(1, 999999);
            generaBindingSourse.DataSource = generalist;
        }

        private void LoadAllCatalogueList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            catalogueList = catalogueRepository.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CatalogueDataModel, CatalogueViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<CatalogueViewModel> viewModels = mapper.Map<List<CatalogueViewModel>>(catalogueList);

            cataloguesBindingSourse.DataSource = viewModels;
            view.SetTotal(catalogueRepository.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveCatalogue(object? sender, EventArgs e)
        {
            var model = new CatalogueDataModel();
            model.Id = Convert.ToInt32(view.CatalogueId);
            model.Fullname = view.FullName;
            model.LifeSpan = view.LifeSpan;
            model.Annual = view.Annual;
            model.GeneraId = Convert.ToInt32(view.GeneraId);

            try
            {
                if (view.IsEdit)
                {
                    catalogueRepository.Edit(model);
                    view.Message = "Вид успешно изменен";
                }
                else
                {
                    catalogueRepository.Add(model);
                    view.Message = "Вид успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllCatalogueList(view.Page);
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
            view.CatalogueId = "0";
            view.FullName = "";
            view.LifeSpan = 1;

        }

        private void DeleteSelectedCatalogue(object? sender, EventArgs e)
        {
            try
            {
                var catalogue = (CatalogueViewModel)cataloguesBindingSourse.Current;
                catalogueRepository.Delete(catalogue.Id);
                view.IsSuccessful = true;
                view.Message = "Вид успешно удален";
                LoadAllCatalogueList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedCatalogueToEdit(object? sender, EventArgs e)
        {
            var catalogue = (CatalogueViewModel)cataloguesBindingSourse.Current;
            view.CatalogueId = catalogue.Id.ToString();
            view.FullName = catalogue.Fullname;
            view.Genera = catalogue.Genera;
            view.LifeSpan = catalogue.LifeSpan;
            view.IsEdit = true;

        }

        private void AddNewCatalogue(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchCatalogue(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                catalogueList = catalogueRepository.GetByValue(this.view.SearchValue);
            }
            else
            {
                catalogueList = catalogueRepository.GetAll(view.Page, 50);
            }
            cataloguesBindingSourse.DataSource = catalogueList;
        }
    }
}
