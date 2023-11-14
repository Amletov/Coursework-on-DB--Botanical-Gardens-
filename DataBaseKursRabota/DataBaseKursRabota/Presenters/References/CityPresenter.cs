using DataBaseKursRabota.Views;
using DataBaseKursRabota.Models;

namespace DataBaseKursRabota.Presenters
{
    public class CityPresenter
    {
        private ICityView view;
        private ICityRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<CityModel> dataList;

        public CityPresenter(ICityView view, ICityRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.EditEvent += LoadSelectedToEdit;
            this.view.DeleteEvent += DeleteSelectedCity;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveCity;
            this.view.CancelEvent += CancelAction;

            this.view.SetCityListBindingSource(dataBindingSourse);
            LoadAllCityList(view.Page);

            this.view.Show();

        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllCityList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllCityList(view.Page);
        }

        private void LoadAllCityList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            dataList = repository.GetAll(page, 50);
            dataBindingSourse.DataSource = dataList;
            view.SetTotal(repository.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveCity(object? sender, EventArgs e)
        {
            var model = new CityModel();
            model.Id = Convert.ToInt32(view.CityId);
            model.City = view.City;

            try
            {
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Город успешно изменен";
                }
                else
                { 
                    repository.Add(model);
                    view.Message = "Город успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllCityList(view.Page);
                CleanViewFields();
            }
            catch(Exception ex)
            {
                view.IsSuccessful= false;
                view.Message = ex.Message;
            }

        }

        private void CleanViewFields()
        {
            view.CityId = "0";
            view.City = "";
        }

        private void DeleteSelectedCity(object? sender, EventArgs e)
        {
            try
            {
                var city = (CityModel)dataBindingSourse.Current;
                repository.Delete(city.Id);
                view.IsSuccessful = true;
                view.Message = "Город успешно удален";
                LoadAllCityList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var city = (CityModel)dataBindingSourse.Current;
            view.CityId = city.Id.ToString();
            view.City = city.City;
            view.IsEdit = true;

        }

        private void AddNew(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if(emptyValue == false) 
            {
                dataList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                dataList = repository.GetAll(view.Page, 50);
            }
            dataBindingSourse.DataSource = dataList;
        }
    }
}
