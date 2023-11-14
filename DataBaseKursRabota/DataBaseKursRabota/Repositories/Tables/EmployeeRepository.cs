using DataBaseKursRabota.Models;
using DataBaseKursRabota.Models.Tables;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace DataBaseKursRabota.Repositories.Tables
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(EmployeeDataModel employeeModel)
        {
            var payLoad = Server.GetPayload(employeeModel);
            Server.Instance.PostRequest("employees/add", payLoad);
        }

        public void Delete(int id)
        {
            Server.Instance.DeleteRequest($"employees/delete/{id}");
        }

        public void Edit(EmployeeDataModel employeeModel)
        {
            var payLoad = Server.GetPayload(employeeModel);
            Server.Instance.PostRequest($"employees/update/{employeeModel.Id}", payLoad);
        }

        public EmployeeDataModel Generate(IEnumerable<PositionModel> positionList)
        {
            Random random = new Random();
            //Случайное Ф.И.О.
            string[] names = {
                                    "Святослав",
                                    "Игорь",
                                    "Владимир",
                                    "Борис",
                                    "Мстислав",
                                    "Ярослав",
                                    "Олег",
                                    "Ростислав",
                                    "Станислав",
                                    "Семён",
                                    "Добрыня",
                                    "Изяслав",
                                    "Всеволод",
                                    "Мирон",
                                    "Светослав",
                                    "Любомир",
                                    "Глеб",
                                    "Радимир",
                                    "Велимир",
                                    "Богдан",
                                    "Любослав",
                                    "Милослав",
                                    "Роман",
                                    "Святополк",
                                    "Ратибор",
                                    "Боримир",
                                    "Велеслав",
                                    "Денис",
                                    "Добромысл",
                                    "Збышек",
                                    "Казимир",
                                    "Мечислав",
                                    "Пересвет",
                                    "Радислав",
                                    "Собеслав",
                                    "Тимур",
                                    "Федор",
                                    "Чеслав",
                                    "Ян",
                                    };
            string[] surnames = {
    "Иванов",
    "Петров",
    "Смирнов",
    "Соколов",
    "Козлов",
    "Михайлов",
    "Федоров",
    "Морозов",
    "Волков",
    "Кузнецов",
    "Новиков",
    "Васильев",
    "Зайцев",
    "Павлов",
    "Семенов",
    "Голубев",
    "Виноградов",
    "Белов",
    "Дмитриев",
    "Королев",
    "Гусев",
    "Титов",
    "Кудрявцев",
    "Баранов",
    "Жуков",
    "Куликов",
    "Александров",
    "Лебедев",
    "Суханов",
    "Поляков",
    "Беляков",
    "Кирсанов",
    "Щербаков",
    "Андреев",
    "Алексеев",
    "Лазарев",
    "Матвеев",
    "Родионов",
    "Богданов",
    "Тихонов",
    "Комаров",
    "Барсуков",
    "Анисимов",
    "Дорофеев",
};
            string[] midllenames = {
    "Иванович",
    "Петрович",
    "Александрович",
    "Сергеевич",
    "Михайлович",
    "Федорович",
    "Николаевич",
    "Андреевич",
    "Дмитриевич",
    "Владимирович",
    "Егорович",
    "Артемович",
    "Константинович",
    "Ярославович",
    "Георгиевич",
    "Денисович",
    "Анатольевич",
    "Вячеславович",
    "Павлович",
    "Савельевич",
    "Степанович",
    "Игоревич",
    "Антонович",
    "Валентинович",
    "Васильевич",
    "Викторович",
    "Аркадьевич",
    "Тимофеевич",
    "Виталиевич",
};
            //Случайная дата рождения
            int day = random.Next(1, 29);
            int month = random.Next(1, 9);
            int currentYear = DateTime.Now.Year;
            int year = currentYear - random.Next(0, 40) - 21;
            DateTime randomDateTime = new DateTime(year, month, day, random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
            var surname = surnames[random.Next(1, surnames.Length)];
            var name = names[random.Next(1, names.Length)];
            var patronymic = midllenames[random.Next(1, midllenames.Length)];
            var birth = randomDateTime.ToString();
            var positionId = positionList.ElementAt(random.Next(1, positionList.Count())).Id;
            var experience = random.Next(1, 10);
            var salary = random.Next(1000, 5000);

            EmployeeDataModel employee = new EmployeeDataModel
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Birth = birth,
                PositionId = positionId,
                Experience = experience,
                Salary = salary
            };
            return employee;
        }

        public async Task AddEmployeeAsync(EmployeeDataModel employeeModel)
        {
            var payLoad = Server.GetPayload(employeeModel);
            await Server.Instance.PostRequestAsync("employees/add", payLoad);
        }

        public IEnumerable<EmployeeDataModel> GetAll(int page, int limit)
        {
            var employeeList = new List<EmployeeDataModel>();
            var jsonResult = Server.Instance.GetRequest($"table/employees/getAll?page={page}&limit={limit}");
            ResponseData<EmployeeDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<EmployeeDataModel>>(jsonResult);
            employeeList = responseData.Rows;
            return employeeList;
        }

        public IEnumerable<EmployeeDataModel> GetByValue(string value)
        {
            var employeeList = new List<EmployeeDataModel>();
            var jsonResult = Server.Instance.GetRequest($"employees/getByValue?employee={value}");
            ResponseData<EmployeeDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<EmployeeDataModel>>(jsonResult);
            employeeList = responseData.Rows;
            return employeeList;
        }

        public int GetTotal()
        {
            var jsonResult = Server.Instance.GetRequest($"table/employees/getAll?page={1}&limit=50");
            ResponseData<EmployeeDataModel> responseData = JsonConvert.DeserializeObject<ResponseData<EmployeeDataModel>>(jsonResult);
            var total = responseData.Total;
            return total;
        }
    }
}
