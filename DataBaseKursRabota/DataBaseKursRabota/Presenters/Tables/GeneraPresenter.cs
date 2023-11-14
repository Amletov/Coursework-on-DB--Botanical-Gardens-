using AutoMapper;
using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using DataBaseKursRabota.Views.Tables;
using DataBaseKursRabota.Views.ViewModels.Tables;

namespace DataBaseKursRabota.Presenters.Tables
{
    public class GeneraPresenter
    {
        private IGeneraView view;
        private IGeneraRepository generaRepository;
        private IFamilyRepository familyRepository;
        private BindingSource generasBindingSourse;
        private BindingSource familyBindingSourse;
        private IEnumerable<FamilyModel> familylist;
        private IEnumerable<GeneraDataModel> generaList;

        public GeneraPresenter(IGeneraView view, IGeneraRepository generaRepository, IFamilyRepository familyRepository)
        {
            this.generasBindingSourse = new BindingSource();
            this.familyBindingSourse = new BindingSource();
            this.view = view;
            this.generaRepository = generaRepository;
            this.familyRepository = familyRepository;

            this.view.SearchEvent += SearchGenera;
            this.view.AddNewEvent += AddNewGenera;
            this.view.EditEvent += LoadSelectedGeneraToEdit;
            this.view.DeleteEvent += DeleteSelectedGenera;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveGenera;
            this.view.CancelEvent += CancelAction;

            this.view.SetGeneraListBindingSource(generasBindingSourse);
            this.view.SetFamiyListComboBox(familyBindingSourse);

            LoadAllFamilyList();
            LoadAllGeneraList(view.Page);

            this.view.Show();

        }


        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllGeneraList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllGeneraList(view.Page);
        }
        private void LoadAllFamilyList()
        {
            familylist = familyRepository.GetAll(view.Page, 50);
            familyBindingSourse.DataSource = familylist;
        }

        private void LoadAllGeneraList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            generaList = generaRepository.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<GeneraDataModel, GeneraViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<GeneraViewModel> viewModels = mapper.Map<List<GeneraViewModel>>(generaList);

            generasBindingSourse.DataSource = viewModels;
            view.SetTotal(generaRepository.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveGenera(object? sender, EventArgs e)
        {
            var model = new GeneraDataModel();
            model.Id = Convert.ToInt32(view.GeneraId);
            model.Genera = view.Genera;
            model.FamilyId = Convert.ToInt32(view.FamilyId);

            try
            {
                if (view.IsEdit)
                {
                    generaRepository.Edit(model);
                    view.Message = "Вид успешно изменен";
                }
                else
                {
                    generaRepository.Add(model);
                    view.Message = "Вид успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllGeneraList(view.Page);
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
            view.GeneraId = "0";
            view.Genera = "";

        }

        private void DeleteSelectedGenera(object? sender, EventArgs e)
        {
            try
            {
                var genera = (GeneraViewModel)generasBindingSourse.Current;
                generaRepository.Delete(genera.Id);
                view.IsSuccessful = true;
                view.Message = "Вид успешно удален";
                LoadAllGeneraList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedGeneraToEdit(object? sender, EventArgs e)
        {
            var genera = (GeneraViewModel)generasBindingSourse.Current;
            view.GeneraId = genera.Id.ToString();
            view.Genera = genera.Genera;
            view.Family = genera.Family;
            view.IsEdit = true;

        }

        private void AddNewGenera(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchGenera(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                generaList = generaRepository.GetByValue(this.view.SearchValue);
            }
            else
            {
                generaList = generaRepository.GetAll(view.Page, 50);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GeneraDataModel, GeneraViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<GeneraViewModel> viewModels = mapper.Map<List<GeneraViewModel>>(generaList);

            generasBindingSourse.DataSource = viewModels;
        }
    }
}
