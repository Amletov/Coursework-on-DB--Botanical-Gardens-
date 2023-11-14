using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views.ViewModels.Tables
{
    public class EmployeeViewModel
    {
        private int id;
        private string surname;
        private string name;
        private string patronymic;
        private string birth;
        private string position;
        private int experience;
        private int salary;

        public int Id { get => id; set => id = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public string Patronymic { get => patronymic; set => patronymic = value; }
        public string Birth { get => birth; set => birth = value; }
        public string Position { get => position; set => position = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}
