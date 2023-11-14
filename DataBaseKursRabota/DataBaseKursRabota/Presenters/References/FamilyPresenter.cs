using DataBaseKursRabota.Models;
using DataBaseKursRabota.Views;

namespace DataBaseKursRabota.Presenters
{
    public class FamilyPresenter
    {
        private IFamilyView view;
        private IFamilyRepository repository;
        private BindingSource dataBindingSourse;
        private IEnumerable<FamilyModel> dataList;

        public FamilyPresenter(IFamilyView view, IFamilyRepository repository)
        {
            this.dataBindingSourse = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += Search;
            this.view.AddNewEvent += AddNew;
            this.view.EditEvent += LoadSelectedToEdit;
            this.view.DeleteEvent += DeleteSelectedFamily;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveFamily;
            this.view.CancelEvent += CancelAction;

            this.view.SetFamilyListBindingSource(dataBindingSourse);
            LoadAllFamilyList(view.Page);

            this.view.Show();

        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllFamilyList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllFamilyList(view.Page);
        }

        private void LoadAllFamilyList(int page)
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

        private void SaveFamily(object? sender, EventArgs e)
        {
            var model = new FamilyModel();
            model.Id = Convert.ToInt32(view.FamilyId);
            model.Family = view.Family;

            try
            {
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Семейство успешно изменен";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Семейство успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllFamilyList(view.Page);
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
            view.FamilyId = "0";
            view.Family = "";
        }

        private void DeleteSelectedFamily(object? sender, EventArgs e)
        {
            try
            {
                var family = (FamilyModel)dataBindingSourse.Current;
                repository.Delete(family.Id);
                view.IsSuccessful = true;
                view.Message = "Семейство успешно удален";
                LoadAllFamilyList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var family = (FamilyModel)dataBindingSourse.Current;
            view.FamilyId = family.Id.ToString();
            view.Family = family.Family;
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
