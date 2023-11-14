using DataBaseKursRabota.Models;
using DataBaseKursRabota.Views;

namespace DataBaseKursRabota.Presenters
{
    public class PositionPresenter
    {
        private IPositionView view;
        private IPositionRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<PositionModel> dataList;

        public PositionPresenter(IPositionView view, IPositionRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.EditEvent += LoadSelectedToEdit;
            this.view.DeleteEvent += DeleteSelectedPosition;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SavePosition;
            this.view.CancelEvent += CancelAction;

            this.view.SetPositionListBindingSource(dataBindingSourse);
            LoadAllPositionList(view.Page);

            this.view.Show();

        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllPositionList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllPositionList(view.Page);
        }

        private void LoadAllPositionList(int page)
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

        private void SavePosition(object? sender, EventArgs e)
        {
            var model = new PositionModel();
            model.Id = Convert.ToInt32(view.PositionId);
            model.Position = view.Position;

            try
            {
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Должность успешно изменен";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Должность успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllPositionList(view.Page);
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
            view.PositionId = "0";
            view.Position = "";
        }

        private void DeleteSelectedPosition(object? sender, EventArgs e)
        {
            try
            {
                var city = (PositionModel)dataBindingSourse.Current;
                repository.Delete(city.Id);
                view.IsSuccessful = true;
                view.Message = "Должность успешно удален";
                LoadAllPositionList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var city = (PositionModel)dataBindingSourse.Current;
            view.PositionId = city.Id.ToString();
            view.Position = city.Position;
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
