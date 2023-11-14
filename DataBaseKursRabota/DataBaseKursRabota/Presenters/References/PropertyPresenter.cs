using DataBaseKursRabota.Models;
using DataBaseKursRabota.Views;

namespace DataBaseKursRabota.Presenters
{
    public class PropertyPresenter
    {
        private IPropertyView view;
        private IPropertyRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<PropertyModel> dataList;

        public PropertyPresenter(IPropertyView view, IPropertyRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.EditEvent += LoadSelectedToEdit;
            this.view.DeleteEvent += DeleteSelectedProperty;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveProperty;
            this.view.CancelEvent += CancelAction;

            this.view.SetPropertyListBindingSource(dataBindingSourse);
            LoadAllPropertyList(view.Page);

            this.view.Show();

        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllPropertyList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllPropertyList(view.Page);
        }

        private void LoadAllPropertyList(int page)
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

        private void SaveProperty(object? sender, EventArgs e)
        {
            var model = new PropertyModel();
            model.Id = Convert.ToInt32(view.PropertyId);
            model.Property = view.Property;

            try
            {
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Тип собственности успешно изменен";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Тип собственности успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllPropertyList(view.Page);
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
            view.PropertyId = "0";
            view.Property = "";
        }

        private void DeleteSelectedProperty(object? sender, EventArgs e)
        {
            try
            {
                var city = (PropertyModel)dataBindingSourse.Current;
                repository.Delete(city.Id);
                view.IsSuccessful = true;
                view.Message = "Тип собственности успешно удален";
                LoadAllPropertyList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var city = (PropertyModel)dataBindingSourse.Current;
            view.PropertyId = city.Id.ToString();
            view.Property = city.Property;
            view.IsEdit = true;

        }

        private void AddNew(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
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
