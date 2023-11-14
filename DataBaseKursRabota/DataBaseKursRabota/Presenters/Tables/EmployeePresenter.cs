using AutoMapper;
using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using DataBaseKursRabota.Views.Tables;
using DataBaseKursRabota.Views.ViewModels.Tables;

namespace DataBaseKursRabota.Presenters.Tables
{
    public class EmployeePresenter
    {
        private IEmployeeView view;
        private IEmployeeRepository employeeRepository;
        private IPositionRepository positionRepository;
        private BindingSource employeesBindingSourse;
        private BindingSource positionBindingSourse;
        private IEnumerable<PositionModel> positionlist;
        private IEnumerable<EmployeeDataModel> employeeList;

        public EmployeePresenter(IEmployeeView view, IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            this.employeesBindingSourse = new BindingSource();
            this.positionBindingSourse = new BindingSource();
            this.view = view;
            this.employeeRepository = employeeRepository;
            this.positionRepository = positionRepository;

            this.view.SearchEvent += SearchEmployee;
            this.view.AddNewEvent += AddNewEmployee;
            this.view.EditEvent += LoadSelectedEmployeeToEdit;
            this.view.DeleteEvent += DeleteSelectedEmployee;
            this.view.NextPageEvent += NextPage;
            this.view.PrevPageEvent += PrevPage;
            this.view.SaveEvent += SaveEmployee;
            this.view.CancelEvent += CancelAction;
            this.view.StartGenerateEvent += GenerateRows;
            this.view.CancelGenerateEvent += CancelGenerateRows;

            this.view.SetEmployeeListBindingSource(employeesBindingSourse);
            this.view.SetPositionListComboBox(positionBindingSourse);

            LoadAllPositionList();
            LoadAllEmployeeList(view.Page);

            this.view.Show();

        }

        private void CancelGenerateRows(object? sender, EventArgs e)
        {
            view.IsGenerating = false;
            view.Message = "Записи сгенерированы.";
            LoadAllEmployeeList(view.Page);
        }

        private async void GenerateRows(object? sender, EventArgs e)
        {
            view.IsGenerating = true;
            for (int i = 0; i < 10000; i++)
            {
                if (!view.IsGenerating) break;

                EmployeeDataModel employee = employeeRepository.Generate(positionlist);
                await employeeRepository.AddEmployeeAsync(employee);

                if(i%10 == 0) view.SetTotal(employeeRepository.GetTotal());
            }
            view.Message = "Записи сгенерированы.";
            LoadAllEmployeeList(view.Page);
        }

        
        private void LoadAllPositionList()
        {
            positionlist = positionRepository.GetAll(1, 999999);
            positionBindingSourse.DataSource = positionlist;
        }

        private void LoadAllEmployeeList(int page)
        {
            var offset = (view.Page - 1) * 50;
            if (offset + 50 < view.Total) view.IsLastPage = true;
            else view.IsLastPage = false;

            employeeList = employeeRepository.GetAll(page, 50);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDataModel, EmployeeViewModel>());
            var mapper = config.CreateMapper();

            IEnumerable<EmployeeViewModel> viewModels = mapper.Map<List<EmployeeViewModel>>(employeeList);

            employeesBindingSourse.DataSource = viewModels;
            view.SetTotal(employeeRepository.GetTotal());
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveEmployee(object? sender, EventArgs e)
        {
            var model = new EmployeeDataModel();
            model.Id = Convert.ToInt32(view.EmployeeId);
            model.Surname = view.Surname;
            model.Name = view.Name;
            model.Patronymic = view.Patronymic;
            model.Birth = view.Birth;
            model.Experience = view.Experience;
            model.Salary = view.Salary;
            model.PositionId = Convert.ToInt32(view.PositionId);

            try
            {
                if (view.IsEdit)
                {
                    employeeRepository.Edit(model);
                    view.Message = "Работник успешно изменен";
                }
                else
                {
                    employeeRepository.Add(model);
                    view.Message = "Работник успешно добавлен";
                }
                view.IsSuccessful = true;
                LoadAllEmployeeList(view.Page);
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
            view.EmployeeId = "0";
            view.Surname = "";
            view.Name = "";
            view.Birth = "";
            view.Salary = 1;
            view.Experience = 1;

        }

        private void DeleteSelectedEmployee(object? sender, EventArgs e)
        {
            try
            {
                var employee = (EmployeeViewModel)employeesBindingSourse.Current;
                employeeRepository.Delete(employee.Id);
                view.IsSuccessful = true;
                view.Message = "Работник успешно удален";
                LoadAllEmployeeList(view.Page);
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;

            };
        }

        private void LoadSelectedEmployeeToEdit(object? sender, EventArgs e)
        {
            var employee = (EmployeeViewModel)employeesBindingSourse.Current;
            view.EmployeeId = employee.Id.ToString();
            view.Surname = employee.Surname;
            view.Name = employee.Name;
            view.Patronymic = employee.Patronymic;
            view.Birth = employee.Birth;
            view.Salary = employee.Salary;
            view.Experience = employee.Experience;
            view.Position = employee.Position;
            view.IsEdit = true;

        }

        private void AddNewEmployee(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchEmployee(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);
            if (emptyValue == false)
            {
                employeeList = employeeRepository.GetByValue(this.view.SearchValue);
            }
            else
            {
                employeeList = employeeRepository.GetAll(view.Page, 50);
            }
            employeesBindingSourse.DataSource = employeeList;
        }

        private void PrevPage(object? sender, EventArgs e)
        {
            view.Page--;
            LoadAllEmployeeList(view.Page);
        }

        private void NextPage(object? sender, EventArgs e)
        {
            view.Page++;
            LoadAllEmployeeList(view.Page);
        }
    }
}
