using DataBaseKursRabota.Models;
using DataBaseKursRabota.Views;

namespace DataBaseKursRabota.Presenters
{
    public class CareProductPresenter
    {
        private ICareProductView view;
        private ICareProductRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<CareProductModel> dataList;

        public CareProductPresenter(ICareProductView view, ICareProductRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.EditEvent += LoadSelectedToEdit;
            this.view.DeleteEvent += DeleteSelectedCareProduct;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveCareProduct;
            this.view.CancelEvent += CancelAction;

            this.view.SetCareProductListBindingSource(dataBindingSourse);
            LoadAllCareProductList(view.Page);

            this.view.Show();

        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllCareProductList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllCareProductList(view.Page);
        }

        private void LoadAllCareProductList(int page)
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

        private void SaveCareProduct(object? sender, EventArgs e)
        {
            var model = new CareProductModel();
            model.Id = Convert.ToInt32(view.CareProductId);
            model.CareProduct = view.CareProduct;
            model.Unit = view.Unit;

            try
            {
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Средство ухода успешно изменен";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Средство ухода успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllCareProductList(view.Page);
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
            view.CareProductId = "0";
            view.CareProduct = "";
            view.Unit = "";
        }

        private void DeleteSelectedCareProduct(object? sender, EventArgs e)
        {
            try
            {
                var model = (CareProductModel)dataBindingSourse.Current;
                repository.Delete(model.Id);
                view.IsSuccessful = true;
                view.Message = "Средство ухода успешно удален";
                LoadAllCareProductList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var model = (CareProductModel)dataBindingSourse.Current;
            view.CareProductId = model.Id.ToString();
            view.CareProduct = model.CareProduct;
            view.Unit = model.Unit;
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
